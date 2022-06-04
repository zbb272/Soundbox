

function DetailsPlaylist(id) {
    $.ajax({
        url: `/Playlists/DetailsModal/${id}`,
        type: "GET",
        success: function (value) {
            $("#playlistActionModal").html(value);
            $("#playlistDetailsModal").modal('show');
            console.log(value);
        },
        error: function (em) {
            console.log(em);
        }
    });
}

function EditPlaylist(id) {
    $.ajax({
        url: `/Playlists/EditModal/${id}`,
        type: "GET",
        success: function (value) {
            $("#playlistActionModal").html(value);
            $("#playlistEditModal").modal('show');
            console.log(value);
        },
        error: function (em) {
            console.log(em);
        }
    });
}

function DeletePlaylist(id) {
    $.ajax({
        url: `/Playlists/DeleteModal/${id}`,
        type: "GET",
        success: function (value) {
            $("#playlistActionModal").html(value);
            $("#playlistDeleteModal").modal('show');
            console.log(value);
        },
        error: function (em) {
            console.log(em);
        }
    });
}