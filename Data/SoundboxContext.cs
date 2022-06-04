using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soundbox.Models;

namespace Soundbox.Models
{
    public class SoundboxContext : DbContext
    {
        public SoundboxContext (DbContextOptions<SoundboxContext> options)
            : base(options)
        {
        }

        public DbSet<Soundbox.Models.Playlist> Playlist { get; set; }

        public DbSet<Soundbox.Models.Artist> Artist { get; set; }

        public DbSet<Soundbox.Models.Song> Song { get; set; }

        public DbSet<Soundbox.Models.PlaylistSong> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });
            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);
            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);
        }
    }
}
