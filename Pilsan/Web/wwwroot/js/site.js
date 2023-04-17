$(document).ready(function () {

    $('#department-shift-table tr').click(function (event) {
        if (event.target.type !== 'checkbox') {
            $(':checkbox', this).trigger('click');
        }
    });

    $(function () {
        $("#ik-table").DataTable({
            "responsive": true, "lengthChange": false, "autoWidth": false, pageLength: 25,
            "buttons": ["excel", "pdf", "print", "colvis"]
        }).buttons().container().appendTo('#ik-table_wrapper .col-md-6:eq(0)');
    });

    $(function () {
        $("#department-table").DataTable({
            "responsive": true, "lengthChange": false, "autoWidth": false, pageLength: 10,
            "buttons": ["excel", "pdf", "print", "colvis"]
        }).buttons().container().appendTo('#department-table_wrapper .col-md-6:eq(0)');
    });

    $(function () {
        $("#department-shift-table").DataTable({
            "responsive": true, "lengthChange": false, "autoWidth": false,
            "paging": false,
            "columnDefs": [{
                "targets": 0,
                "orderable": false
            }],
            order: [[1, 'asc']]
        });
    });

    $(function () {
        $('#department-shift-table_wrapper .col-md-6:eq(0)').append("<div id='radio-buttons' class='btn-group-sm btn-group-toggle col' data-toggle='buttons'><label class='btn btn-outline-dark active col-3 float-left btn-sm'><input type='radio' name='options' id='option1' value='1' autocomplete='off' checked><i class='fa-solid fa-bell fa-xs mr-2'></i> 08:00 - 16:00</label><label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option2' value='2' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i>08:00 - 18:00</label><label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option3' value='5' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 16:00 - 24:00</label><label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option4' value='6' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 00:00 - 08:00</label></div>");

        $('#radio-buttons input').on('change', function () {
            var RadioBtnValue = $('input[name=options]:checked', '#radio-buttons').val();

            $('#shiftID').attr('value', RadioBtnValue);

            if ($('#radio-buttons input').is(':checked')) {
                //Add beat
            }
        });
        //Active
        //<label class='btn btn-outline-dark active col-3 float-left btn-sm'><input type='radio' name='options' id='option1' value='1' autocomplete='off' checked> 08:00-16:00</label>

        //No Active
        //<label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option2' value='2' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 08:00-18:00</label>
        //<label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option3' value='5' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 16:00-24:00</label>
        //<label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option4' value='6' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 00:00-08:00</label>


    });

    $("#department-shift-table tr a").click(function () {
        var RadioBtnVal = $('input[name=options]:checked', '#radio-buttons').val();
        if (RadioBtnVal == 1) {
            $(this).closest("tr").find("strong").text("08:00 - 16:00");
            var x = $(this).closest("tr").find("input").text();
            alert(x);

        }
        if (RadioBtnVal == 2) {
            $(this).closest("tr").find("strong").text("08:00 - 18:00");
            $(this).closest("tr").find("input").text(RadioBtnVal);
        }
        if (RadioBtnVal == 5) {
            $(this).closest("tr").find("strong").text("16:00 - 24:00");
            $(this).closest("tr").find("input").text(RadioBtnVal);
        }
        if (RadioBtnVal == 6) {
            $(this).closest("tr").find("strong").text("00:00 - 08:00");
            $(this).closest("tr").find("input").val();
        }
        $(this).closest("tr").find("a").remove();

    });


    $(function () {
        $("#department-shift-show-table").DataTable({
            "responsive": true, "lengthChange": false, "autoWidth": false,
            "paging": false,
            "buttons": ["excel", "pdf", "print", "colvis"],
            "columnDefs": [{
                "targets": 0,
                "orderable": false
            }],
            order: [[1, 'asc']]
        }).buttons().container().appendTo('#department-shift-show-table_wrapper .col-md-6:eq(0)');
    });

    $('#department-shift-show-table tr').click(function (event) {
        if (event.target.type !== 'checkbox') {
            $(':checkbox', this).trigger('click');
        }
    });


    //Overtime
    $(function () {
        $("#department-overtime-table").DataTable({
            "responsive": true, "lengthChange": false, "autoWidth": false,
            "paging": false,
            "columnDefs": [{
                "targets": 0,
                "orderable": false
            }],
            order: [[1, 'asc']]
        });
    });

    $('#department-overtime-table tr').click(function (event) {
        if (event.target.type !== 'checkbox') {
            $(':checkbox', this).trigger('click');
        }
    });

    $(function () {
        $('#department-overtime-table_wrapper .col-md-6:eq(0)').append("<div id='radio-buttons-overtime' class='btn-group-sm btn-group-toggle col' data-toggle='buttons'><label class='btn btn-outline-dark active col-3 float-left btn-sm'><input type='radio' name='options' id='option1' value='2' autocomplete='off' checked><i class='fa-solid fa-clock fa-xs mr-2'></i> 18:00 </label><label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option2' value='3' autocomplete='off'><i class='fa-solid fa-clock fa-xs mr-2'></i> 20:00 </label><label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option3' value='4' autocomplete='off'><i class='fa-solid fa-clock fa-xs mr-2'></i> 22:00 </label><label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option4' value='5' autocomplete='off'><i class='fa-solid fa-clock fa-xs mr-2'></i> 24:00 </label></div>");

        $('#radio-buttons-overtime input').on('change', function () {
            var RadioBtnOvertimeValue = $('input[name=options]:checked', '#radio-buttons-overtime').val();
            alert(RadioBtnOvertimeValue);

            $('#overtimeID').attr('value', RadioBtnOvertimeValue);

            if ($('#radio-buttons-overtime input').is(':checked')) {
                //Add beat
            }
        });

        //Active
        //<label class='btn btn-outline-dark active col-3 float-left btn-sm'><input type='radio' name='options' id='option1' value='1' autocomplete='off' checked> 08:00-16:00</label>

        //No Active
        //<label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option2' value='2' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 08:00-18:00</label>
        //<label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option3' value='5' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 16:00-24:00</label>
        //<label class='btn btn-outline-dark  col-3 float-left btn-sm'><input type='radio' name='options' id='option4' value='6' autocomplete='off'><i class='fa-solid fa-bell fa-xs mr-2'></i> 00:00-08:00</label>


    });

    $(function () {
        $("#department-overtime-show-table").DataTable({
            "responsive": true, "lengthChange": false, "autoWidth": false,
            "paging": false,
            "buttons": ["excel", "pdf", "print", "colvis"],
            "columnDefs": [{
                "targets": 0,
                "orderable": false
            }],
            order: [[1, 'asc']]

        }).buttons().container().appendTo('#department-overtime-show-table_wrapper .col-md-6:eq(0)');
    });

    $('#department-overtime-show-table tr').click(function (event) {
        if (event.target.type !== 'checkbox') {
            $(':checkbox', this).trigger('click');
        }
    });

});