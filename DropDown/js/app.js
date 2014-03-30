
$(document).ready(function (){
	
	$(".navbar-inner").mouseover(function ()
	{
		$(".navbar-inner ul").fadeIn();
	})

	$(".navbar-inner").mouseleave(function()
	{
		$(".navbar-inner ul").fadeOut();
	})

	$("#input").focus(function (){

		// Clears info box when user is typing something
		$("div#info").html("");
	})

	$("#add").click(function (){

		// Add a new item with the given inputted name

		var input = $("#input").val();

		if (input.length > 0)
		{

			if($(".navbar-inner ul li a").filter(function() {
			    return $(this).text() == input;
			}).length)
			{
				$("div#info").html( "An item with the same name already exists.");

			}
			else
			{
				// format string and add a new menuitem
				var item = "<a href=#;>"+input+"</a>"; 
				$(".navbar-inner ul").append($("<li></li>").html(item));
				$(".navbar-inner ul").slideDown();
				$("div#info").html(input+" has been added!");

			}
		} 

	})

	$("#remove").click(function(){
		$("div#info").html("");
		// remove any item that match the name specificed in the input
		var input = $("#input").val();
		$(".navbar-inner ul li a").filter(function() {
			    return $(this).text() == input;
			}).remove();
	})

	// allows the enter key to also add items.
	$(document).keypress(function(e) {
    	if(e.which == 13) {
       	 $("#add").trigger("click");
    	}
	});

})