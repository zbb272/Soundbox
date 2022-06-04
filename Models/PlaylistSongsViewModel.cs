using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soundbox.Models
{
    public class PlaylistSongsViewModel
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public List<Song> Songs { get; set; }
        public Playlist Playlist { get; set; }

    }
}
