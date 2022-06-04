
function DetailsSong(id) {
    $.ajax({
        url: `/Songs/DetailsModal/${id}`,
        type: "GET",
        success: function(value) {
            $("#songActionModal").html(value);
            $("#detailsModal").modal('show');
            console.log(value);
        },
        error: function(em) {
            console.log(em);
        }
    });
}

function EditSong(id) {
    $.ajax({
        url: `/Songs/EditModal/${id}`,
        type: "GET",
        success: function(value) {
            $("#songActionModal").html(value);
            $("#editModal").modal('show');
            console.log(value);
        },
        error: function(em) {
            console.log(em);
        }
    });
}

function DeleteSong(id) {
    $.ajax({
        url: `/Songs/DeleteModal/${id}`,
        type: "GET",
        success: function(value) {
            $("#songActionModal").html(value);
            $("#deleteModal").modal('show');
            console.log(value);
        },
        error: function(em) {
            console.log(em);
        }
    });
}
