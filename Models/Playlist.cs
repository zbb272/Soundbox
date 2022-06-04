﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soundbox.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}