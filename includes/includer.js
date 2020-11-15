$(document).ready(function () {
  $("#navElement").load("/includes/nav.html");
  $("#footerElement").load("/includes/footer.html");

  inView('.gif')
    .on('enter', el => {
      $(el).css('background-image', 'url(' + $(el).attr('href') + ')')
    })
    .on('exit', el => {
      $(el).css('background-image', '')
    })
});