$(document).ready(function () {

    $('#showSeat').click(function () {
        var url = $('#seatModal').data('url');

        $.get(url, function (data) {
            $('#seatContainer').html(data);

            $('#seatModal').modal('show');
        });
    });

    $('#showEmployee').click(function () {
        var url = $('#employeeModal').data('url');

        $.get(url, function (data) {
            $('#employeeContainer').html(data);

            $('#employeeModal').modal('show');

            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY'
            });

            $('#datetimepicker2').datetimepicker({
                format: 'DD/MM/YYYY',
                autoclose: true,
            });
        });
    });

});
