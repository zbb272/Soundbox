using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soundbox.Models;

namespace Soundbox.Data
{
    public class DbInitializer
    {
            public static void Initialize(SoundboxContext context)
            {
                //seed data goes here

                //Check for any playlists
                if (context.Playlist.Any())
                {
                    return; // DB has been seeded
                }


                //PLAYLISTS
                var playlists = new Playlist[]
                {
                new Playlist { Name = "Test Playlist 1" },
                new Playlist { Name = "Test Playlist 2" },
                new Playlist { Name = "Test Playlist 3" }
                };

                foreach (Playlist p in playlists)
                {
                    context.Playlist.Add(p);
                }

                context.SaveChanges();

                //ARTISTS
                var artists = new Artist[]
                {
                new Artist {Name = "Artist1", Age = 50, NetWorth = 4, Retired = true, Email = "artist1@email.com", PhoneNumber = "301-111-1111" },
                new Artist {Name = "Artist2", Age = 60, NetWorth = 7, Retired = true, Email = "artist2@email.com", PhoneNumber = "301-222-2222" },
                new Artist {Name = "Artist3", Age = 55, NetWorth = 19, Retired = true, Email = "artist3@email.com", PhoneNumber = "301-333-3333" },
                new Artist {Name = "Artist4", Age = 47, NetWorth = 22, Retired = false, Email = "artist4@email.com", PhoneNumber = "301-444-4444" },
                };

                for (int i = 0; i < 10; i++)
                {
                    context.Artist.Add(new Artist
                    {
                        Name = $"Artist{i+5}",
                        Age = i + 20,
                        NetWorth = i,
                        Retired = false,
                        Email = $"artist{i+5}@email.com",
                        PhoneNumber = $"202-{100+i}-{2000+i}"
                    });
                }

                /*foreach (Artist a in artists)
                {
                    context.Artist.Add(a);
                }*/

                //SONGS
                var songs = new Song[]
                {
                new Song { Title = "Song1", Album = "Album1", ReleaseYear = 1990, Artist = artists.Single( a => a.Name == "Artist1") },
                new Song { Title = "Song2", Album = "Album1", ReleaseYear = 1990, Artist = artists.Single( a => a.Name == "Artist1")  },
                new Song { Title = "Song3", Album = "Album1", ReleaseYear = 1990, Artist = artists.Single( a => a.Name == "Artist2")  },
                new Song { Title = "Song4", Album = "Album2", ReleaseYear = 1995, Artist = artists.Single( a => a.Name == "Artist2")  },
                new Song { Title = "Song5", Album = "Album2", ReleaseYear = 1995, Artist = artists.Single( a => a.Name == "Artist3")  },
                new Song { Title = "Song6", Album = "Album2", ReleaseYear = 1995, Artist = artists.Single( a => a.Name == "Artist3")  },
                new Song { Title = "Song7", Album = "Album3", ReleaseYear = 1997, Artist = artists.Single( a => a.Name == "Artist4")  },
                new Song { Title = "Song8", Album = "Album3", ReleaseYear = 1997, Artist = artists.Single( a => a.Name == "Artist4")  },
                new Song { Title = "Song9", Album = "Album3", ReleaseYear = 1997, Artist = artists.Single( a => a.Name == "Artist4")  },
                new Song { Title = "Song10", Album = "Album3", ReleaseYear = 1997, Artist = artists.Single( a => a.Name == "Artist4")  },
                };

                foreach (Song s in songs)
                {
                    context.Song.Add(s);
                }

                context.SaveChanges();

                //PLAYLIST SONGS
                var playlistSongs = new PlaylistSong[]
                {
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song1") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song2") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song3") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song4") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song5") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song6") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song7") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song8") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song9") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 1"), Song = songs.Single( s => s.Title == "Song10") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 2"), Song = songs.Single( s => s.Title == "Song1") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 2"), Song = songs.Single( s => s.Title == "Song2") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 2"), Song = songs.Single( s => s.Title == "Song3") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 2"), Song = songs.Single( s => s.Title == "Song4") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 2"), Song = songs.Single( s => s.Title == "Song5") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 3"), Song = songs.Single( s => s.Title == "Song6") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 3"), Song = songs.Single( s => s.Title == "Song7") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 3"), Song = songs.Single( s => s.Title == "Song8") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 3"), Song = songs.Single( s => s.Title == "Song9") },
                new PlaylistSong { Playlist = playlists.Single( p => p.Name == "Test Playlist 3"), Song = songs.Single( s => s.Title == "Song10") }
                };

                foreach (PlaylistSong ps in playlistSongs)
                {
                    context.PlaylistSongs.Add(ps);
                }

                context.SaveChanges();
            }
    }
}

