$(document).ready(function () {

    //$('.datepicker').datepicker();

    //$('#dp3').datepicker();

    $('#datetimepicker1').datetimepicker({
        format: 'DD/MM/YYYY'
    });

    $('#datetimepicker2').datetimepicker({
        format: 'DD/MM/YYYY',
        autoclose: true
    });

    $('#showSeat').click(function () {
        var url = $('#seatModal').data('url');

        $.get(url, function (data) {
            $('#seatContainer').html(data);

            $('#seatModal').modal('show');
        });
    });

    $('#showEmployee').click(function () {
        var url = $('#employeeModal').data('url');

        //$('input.datepicker').Zebra_DatePicker();

        $.get(url, function (data) {
            $('#employeeContainer').html(data);

            $('#employeeModal').modal('show');

            //$('#datepicker-formats').Zebra_DatePicker({
            //    format: 'd/m/Y'
            //});

            //$('#datepicker-formats2').Zebra_DatePicker({
            //    format: 'd/m/Y'
            //});
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

