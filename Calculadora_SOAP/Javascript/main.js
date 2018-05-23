$('#input')
    .on('keypress', (e) => {

        if(e.key !== 'Enter') return true;


        let expression = getExpression(e.target.value);

        run(expression);

    })
;

function getExpression(val){

    let expression = {};

    if (val.includes('²')){
        expression.fo = val.split('²')[0];
        expression.op = 'quadrado';
    }

    if (val.includes('³')){
        expression.fo = val.split('³')[0];
        expression.op = 'cubo';
    }

    if (val.includes('+')){
        expression.fo = Number(val.split('+')[0]);
        expression.op = 'soma';
        expression.so = Number(val.split('+')[1]);
    }

    if(val.includes('-')){
        expression.fo = Number(val.split('-')[0]);
        expression.op = 'subtracao';
        expression.so = Number(val.split('-')[2]);
    }

    if(val.includes('*')){
        expression.fo= Number(val.split('*')[0]);
        expression.op = 'multiplicacao';
        expression.so = Number(val.split('*')[1]);
    }

    if(val.includes('/')){
        expression.fo = Number(val.split('/')[0]);
        expression.op = 'divisao';
        expression.so = Number(val.split('/')[1]);
    }

    return expression;
}

function run(expression){

    $('#input').addClass('hide');
    $('#loading').removeClass('hide');

    $.ajax({
        type: 'POST',
        url: '/Home/Calcular',
        data: {
            'expression': JSON.stringify(expression)
        },
        success: (res, status, xhr) => {

            $('#input > input').val(res);

            $('#loading').addClass('hide');
            $('#input').removeClass('hide');

            $('#input > input').focus();
        },
        error: (xhr, status, err) => {
            console.log('error!', err);
        }
    });

}