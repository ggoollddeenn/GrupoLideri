// version 0.1.2
// visit: http://oliver-j.github.io/jcolumn/
;(function ($, win, doc) { 'use strict';
    $.fn.jcolumn = function (options) { 
                
    var elements = this,
    
    
    defaults = {
        delay: 500,
        maxWidth: 767,
        callback: function (elemH) {},
        resize: true
    }, 
    
    settings = $.extend( {}, defaults, options),
    
    // otherwise the event would trigger the function to fast
    delay = (function () {
		var timer = 0;
	  	return function(callback, ms){
	    	clearTimeout(timer);
	    	timer = setTimeout(callback, ms);
	  	};
	})(), 

	resizeColumnHeight = function (rows) { 
		var elemH = 0;
            
		if ($(doc).width() >= settings.maxWidth) {
            rows.each(function () {
			    var $this = $(this);
			    $this.height('auto');
                
			    if ($this.height() > elemH) {
				    elemH = $this.height();
			    }
		    });
            
			rows.each(function () {
				$(this).height(elemH);
			});
            
            settings.callback(elemH);   
		}
	},
    
    // wrapper function for init and event
    jColumn = function () { 
        delay(resizeColumnHeight(elements), settings.delay); 
    };
    
    if (settings.resize) {
	    win.addEventListener('resize', jColumn);
    }
    
    jColumn();
return this; };}(jQuery, window, document));