
    $(document).ready(function () {

        $("#jqg").jqGrid({
            url: '',
            datatype: "json",
            colNames: ['Клиент', 'Оператор', 'Время', 'Текст', 'Статус', 'Исполнитель', 'КомментарийИсп'],
            colModel: [
                { name: 'ClientName', index: 'ClientName', width: 30, stype: 'text', sortable: true },
                { name: 'Operator', index: 'Operator', width: 30, stype: 'text', sortable: true },
                { name: 'Time', index: 'Time', width: 150, sortable: true },
                { name: 'Text', index: 'Text', width: 150, stype: 'text' },
                { name: 'State', index: 'State', width: 150, sortable: true },
                { name: 'Executor', index: 'Executor', width: 100, stype: 'text', sortable: false },
                { name: 'SolutionComment', index: 'SolutionComment', width: 150, stype: 'text' }
            ],
            pager: "#pager",
            rowNum: 5,
            loadonce: true,
            sortname: 'Time',
            sortorder: "desc",
            caption: "Запросы",
            viewrecords: true,
            gridview: true,
            autoencode: true
        });
    });
