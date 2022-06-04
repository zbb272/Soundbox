using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soundbox.Models;

namespace Soundbox.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly SoundboxContext _context;

        public PlaylistsController(SoundboxContext context)
        {
            _context = context;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Playlist.ToListAsync());
        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .Include(i => i.PlaylistSongs)
                    .ThenInclude(i => i.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            var playlistSongsVM = new PlaylistSongsViewModel
            {
                PlaylistId = playlist.Id,
                Playlist = playlist
            };

            return View(playlistSongsVM);
        }

        public async Task<IActionResult> DetailsModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .Include(i => i.PlaylistSongs)
                .ThenInclude(i => i.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            var playlistSongsVM = new PlaylistSongsViewModel
            {
                PlaylistId = playlist.Id,
                Playlist = playlist
            };

            return PartialView("~/Views/Playlists/_DetailsPlaylist.cshtml", playlistSongsVM);
        }

        // GET: Playlists/Create
        public IActionResult Create()
        {
            Playlist playlist = new Playlist();
            return PartialView("~/Views/Playlists/_CreatePlaylist.cshtml", playlist);
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        public async Task<IActionResult> EditModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Playlists/_EditPlaylist.cshtml", playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        public async Task<IActionResult> DeleteModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/Playlists/_DeletePlaylist.cshtml", playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playlist = await _context.Playlist.FindAsync(id);
            _context.Playlist.Remove(playlist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Playlists/Add/5
        public async Task<IActionResult> Add(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .Include(i => i.PlaylistSongs)
                 .ThenInclude(i => i.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }
            
            var playlistSongsVM = new PlaylistSongsViewModel
            {
                PlaylistId = playlist.Id,
                Songs = await _context.Song.ToListAsync()
            };

            return View(playlistSongsVM);
        }

        //POST: Playlists/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("PlaylistId,SongId")] PlaylistSongsViewModel playlistSongsVM)
        {

            var playlistToUpdate = await _context.Playlist
                .Include(i => i.PlaylistSongs)
                 .ThenInclude(i => i.Song)
                .FirstOrDefaultAsync(m => m.Id == playlistSongsVM.PlaylistId);

            if (playlistToUpdate == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync<Playlist>(
                    playlistToUpdate,
                    "",
                    i => i.Name))
                {
                    var songIdsInPlaylist = playlistToUpdate.PlaylistSongs.Select(ps => ps.SongId);
                    if (!songIdsInPlaylist.Contains(playlistSongsVM.SongId))
                    {
                        playlistToUpdate.PlaylistSongs.Add(new PlaylistSong { PlaylistId = playlistToUpdate.Id, SongId = playlistSongsVM.SongId });
                    }
                    else
                    {
                        PlaylistSong playlistSongToRemove =
                            playlistToUpdate.PlaylistSongs.FirstOrDefault(ps => ps.SongId == playlistSongsVM.SongId);
                        _context.Remove(playlistSongToRemove);
                    }
                    try
                    {
                        await _context.SaveChangesAsync();
                    }

                    catch (DbUpdateException /* ex */)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                                                     "Try again, and if the problem persists, " +
                                                     "see your system administrator.");
                    }

                }
            }
            return RedirectToAction(nameof(Details), playlistToUpdate);
        }


        private bool PlaylistExists(int id)
        {
            return _context.Playlist.Any(e => e.Id == id);
        }
    }
}
