using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soundbox.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Album { get; set; }
        public int ReleaseYear { get; set; }

        public Artist Artist { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
