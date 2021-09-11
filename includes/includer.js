$(document).ready(function () {
  $("#navElement").load("/includes/nav.xml?v2", function () {
    $("#nav [href]").each(function () {
      if (window.location.href.includes(this.href)) {
        $(this).addClass("active");
      }
    });
  });
    
  $("#footerElement").load("/includes/footer.html?v2");

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
});