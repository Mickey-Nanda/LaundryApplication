
function onItemsChanged() {
    var MensDryCleanTShirts = parseInt(document.querySelector("[name='MensDryCleanTShirtQuantity']").value);
    var MensDryCleanJeans = parseInt(document.querySelector("[name='MensDryCleanJeansQuantity']").value);
    var MensDryCleanKurtas = parseInt(document.querySelector("[name='MensDryCleanKurtaQuantity']").value);

    var CartTShirts = document.querySelector("[name='cartTShirtQuantity']");
    var CartJeans = document.querySelector("[name='cartJeansQuantity']");
    var CartKurtas = document.querySelector("[name='cartKurtaQuantity']");

    var CartTShirtCost = document.querySelector("[name='CartTShirtCost']");
    var CartJeansCost = document.querySelector("[name='CartJeansCost']");
    var CartKurtaCost = document.querySelector("[name='CartKurtaCost']");
    var CartSubTotal = document.querySelector("[name='CartSubTotal']");

    var TotalTShirtsElem = document.getElementById('TotalTShirts');
    // NOT HANDLING ADDONS NOW!
    // var CartAddOn = document.querySelector("[name='CartAddOn']");

    // For now DryCleanMens is the only Option Working
    TotalTShirts = MensDryCleanTShirts;
    TotalJeans = MensDryCleanJeans;
    TotalKurtas = MensDryCleanKurtas;

    CartTShirts.value = TotalTShirts;
    CartJeans.value = TotalJeans;
    CartKurtas.value = TotalKurtas;

    var Rupees = '\u20B9';

    // again, for now, just Mens Dry Cleaning is working
    var MensDryCleanTShirtCost = MensDryCleanTShirts * MensDryCleanTShirtRate;
    var MensDryCleanJeansCost = MensDryCleanJeans * MensDryCleanJeansRate;
    var MensDryCleanKurtaCost = MensDryCleanKurtas * MensDryCleanKurtaRate;

    TotalTShirtCost = MensDryCleanTShirtCost;
    TotalJeanCost = MensDryCleanJeansCost;
    TotalKurtaCost = MensDryCleanKurtaCost;
    Subtotal = (MensDryCleanTShirtCost + MensDryCleanJeansCost + MensDryCleanKurtaCost);

    CartTShirtCost.textContent = Rupees;
    CartTShirtCost.textContent += " ";
    CartTShirtCost.textContent += TotalTShirtCost;

    CartJeansCost.textContent = Rupees;
    CartJeansCost.textContent += " ";
    CartJeansCost.textContent += TotalJeanCost;

    CartKurtaCost.textContent = Rupees;
    CartKurtaCost.textContent += " ";
    CartKurtaCost.textContent += TotalKurtaCost;

    CartSubTotal.textContent = Rupees;
    CartSubTotal.textContent += " ";
    CartSubTotal.textContent += Subtotal;
}

function beginCheckout(initURL) {
    var CartTShirts = document.querySelector("[name='cartTShirtQuantity']");
    var url = initURL;

    url = url.replace("Param1", TotalTShirts);
    url = url.replace("Param2", TotalJeans);
    url = url.replace("Param3", TotalKurtas);
    url = url.replace("Param4", TotalTShirtCost);
    url = url.replace("Param5", TotalJeanCost);
    url = url.replace("Param6", TotalKurtaCost);
    url = url.replace("Param7", Subtotal);

    window.location.href = url;
}

$(document).ready(function () {
    $('.minus').click(function () {
        var $input = $(this).parent().find('input');
        var count = parseInt($input.val()) - 1;
        count = count < 1 ? 0 : count;
        $input.val(count);
        $input.change();
        onItemsChanged();
        return false;
    });
    $('.plus').click(function () {
        var $input = $(this).parent().find('input');
        $input.val(parseInt($input.val()) + 1);
        $input.change();
        onItemsChanged();
        return false;
    });
});
