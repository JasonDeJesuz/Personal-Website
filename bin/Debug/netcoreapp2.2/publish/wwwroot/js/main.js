;( function( $ ) {

	$('.intro_container').show();

	/**TYPEWRITER EFFECT FOR HEADER */
	var i = 0;
	var j = 0;
	// var heading = "Hello, i'm Jason De Jesuz";
	var Subheading = 'I design and code extraordinary things!';
	var speed = 75; /* The speed/duration of the effect in milliseconds */

	findheight();
	setTimeout(addbtn, 1500);
	// setTimeout(headingtypeWriter, 500);
	setTimeout(subheadingtypewriter, 500);

	window.addEventListener("resize", findheight);

	window.onscroll = function() {stick()};
	var navbar = document.getElementById("navbar_div");
	var sticky = navbar.offsetTop;

	/* ADD BUTTON TO HEADER PAGE */
	function addbtn()	{
		// $('#learnmore_btn').css("display", "block");
		// $('#downarrow').css("display", "inline");
		$('#learnmore_btn').fadeToggle(5000);
		$('#downarrow').fadeToggle(5000);
	}

	 /** ASSIGNING THE WINDOW HEIGHT TO THE HEADER CONTAINER */
	function findheight()	{
		var height = $(window).innerHeight();
		height = height +"px";
		$('.intro_container').css("height", height);
		// console.log(height);
	}

	function stick()	{

		if	(window.pageYOffset >= sticky)	{
			console.log("Sticky");
			navbar.classList.add("Sticky");
		}	else	{
			navbar.classList.remove("Sticky");
		}
	}

	// $(window).scroll(function()	{
	// 	var hT = $('#Skills').offset().top,
	// 			hH = $('#Skills').outerHeight(),
	// 			wH = $(window).height(),
	// 			wS = $(this).scrollTop();
	// 		if	(wS > (hT+hH-wH))	{
	// 			console.log("Skills");
	// 			skillsappear();
	// 		}
	// });

	// //Initialize on scroll to About section
	// var once = true;
	// $(window).scroll(function() {
	// 	// console.log(once);
	// 	if	(once)
	// 	{
	// 		var hT = $('#Skills').offset().top,
	// 		hH = $('#Skills').outerHeight(),
	// 		wH = $(window).height(),
	// 		wS = $(this).scrollTop();
	// 		if (wS > (hT+hH-wH)){
	// 			console.log("Skills");
	// 			skillsappear();
	// 			once = false;
	// 		}
	// 		// console.log(once);
	// 	}

	//  });

	 /* WRITING THE SUBHEADING IN HEADER */
	function subheadingtypewriter()	{
		if (j < Subheading.length) {
			document.getElementById('desc').innerHTML += Subheading.charAt(j);
			j++;
			setTimeout(subheadingtypewriter, speed);
		}
	}

	// Count the Numbers when the user scroll to statistics
	var a = 0;
	$(window).scroll(function() {
	
	  var oTop = $('#stats').offset().top - window.innerHeight;
	  if (a == 0 && $(window).scrollTop() > oTop) {
		$('.des').each(function() {
		  var $this = $(this),
			countTo = $this.attr('data-count');
		  $({
			countNum: $this.text()
		  }).animate({
			  countNum: countTo
			},
	
			{
	
			  duration: 2500,
			  easing: 'swing',
			  step: function() {
				$this.text(Math.floor(this.countNum));
			  },
			  complete: function() {
				$this.text(this.countNum);
				//alert('finished');
			  }
	
			});
		});
		a = 1;
	  }
	
	});
	
})( jQuery );