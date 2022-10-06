$(document).ready(function () {
  $("#navElement").load("/includes/nav.xml?v18", function () {
    $("#nav [href]").each(function () {
      if (window.location.href.includes(this.href)) {
        if (window.location.href == this.href) {
          if ($(this).attr('id') == 'home') {
            this.href = '/dofs'
          }
          return false
        }
        
        if ($(this).attr('id') != 'home') {
          $(this).addClass("active")
        }
      }
    })
    console.log($("#home").attr('href'))
  })

  // if exists
  if ($("#dofElement") != null) {
    $("head").append("<script src='/dofs/dofs.js?v20'></script>")
    $("#dofElement").load("/dofs/content.html?v20")
  }
    
  $("#footerElement").load("/includes/footer.html?v18")


  // $("#feeds").load("feeds.php", { limit: 25 }, function () {
  //   alert("The last 25 entries in the feed have been loaded");
  // });

  // go to console in browser and type: document.designMode = "on"
  
  inView('.gif')
  .on('enter', el => {
    $(el).css('background-image', 'url(' + $(el).attr('href') + ')')
  })
  .on('exit', el => {
    $(el).css('background-image', '')
  })
})

function toggleGif(el) {
	if (el.src.includes('svg')) {
		el.src = el.src.replace('svg', 'gif')
	} else {
		el.src = el.src.replace('gif', 'svg')
	}
}