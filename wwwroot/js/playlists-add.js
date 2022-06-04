function AddSongToPlaylist(id, songId) {
    $.ajax({
        url: `/Playlists/Add/${id}`,
        type: "POST",
        data: {
            songId: songId
        },
        success: function (value) {
            console.log(value);
        },
        error: function (em) {
            console.log(em);
        }
    });
}