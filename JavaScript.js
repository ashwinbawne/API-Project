

function submitData() {

    var formData = new FormData($('#FormData')[0]);
    debugger;
    $.ajax({
        
        url: '/Employee/Create',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {

            $('#partialViewDisplayEmployee').html(data);
            clear();
        },
        error: function (data) {
            $('#partialViewDisplayEmployee').html(data);

        }
    });
}
$("#clearButton").on('click', function () {

    clear();
})
function clear() {

    $('#Id').val('');
    $('#Firstname').val('');
    $('#Lastname').val('');
    $('#Dateofbirth').val('');
    $('#Hobbies').val('');
    $('#Gender').val('');
    $('#State').val('');
    $('#City').val('');
    //$('#UploadImage').val();
    //$('#UploadPdf').val();
    $('#UploadImage').replaceWith($('#UploadImage').empty('').clone(true));
    $('#UploadPdf').replaceWith($('#UploadPdf').empty('').clone(true));
    $('#FormData')[0].reset();
    $('#FormData select').val('');
    $('#FormData input[type="checkbox"]').prop('checked', false);
}








$("#updatebtn").on('click', function () {
    console.log("Delete button clicked!");

    var formData = new FormData($('#editf')[0]);
    $.ajax({
        url: '/Employee/Edit',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#partialViewDisplayEmployee').html(data);
            resetFormFields();
        },
        error: function () {

        }
    });
});


function resetFormFields() {

    $('#editf')[0].reset();

    $('#Id').val('');
    $('#Firstname').val('');
    $('#Lastname').val('');
    $('#Dateofbirth').val('');
    $('#Hobbies').val('');
    $('#Gender').val('');
    $('#SelectedState').val('');
    $('#cityDropdown').val('');
    //$('#UploadImage').val();
    //$('#UploadPdf').val();
    $("#UploadImage").attr("src", "").attr("alt", "");
    $("#UploadPdf").attr("src", "").attr("alt", "");
    $('#editf select').val('');
    $('#editf input[type="checkbox"]').prop('checked', false);
}


async function loadPartialViews(CurrentPage, RecordsPerPage, searchData) {
    try {

        const request1 = $.ajax({
            url: '/Employee/Create',
            type: 'GET'
        });

        const request2 = $.ajax({
            url: '/Employee/GetEmployeeDetails',
            type: 'GET',
            data: {
                CurrentPage: CurrentPage,
                RecordsPerPage: RecordsPerPage,
                SearchTerm: searchData
            }
        });

        const [data1, data2] = await Promise.all([request1, request2]);
        $('#partialViewAddEmployee').html(data1);
        $('#partialViewDisplayEmployee').html(data2);
    }
    catch (error) {
        console.error('Error:', error);
    }
}




$(document).ready(function () {
    $(document).on('click', '.editEmployeeData', function () {


        var recordId = $(this).data("id");


        $.ajax({
            url: '/Employee/Edit',
            type: 'GET',
            data: { id: recordId },
            success: function (data) {

                $('#partialViewAddEmployee').html(data);

                /* GetCityByID();*/



            },
            error: function () {

            }
        });
    });


});


