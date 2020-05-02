var i, cnt;
i = cnt = 2;
function nextLog() {
  i++;
  if (i > cnt) {
    i = 0;
  }
  loadLog();
}

function prevLog() {
  i--;
  if (i < 0) {
    i = cnt;
  }
  loadLog();
}

function loadLog() {
  if (i == cnt){
    $("#nextBtn").css("display", "none");
  }
  else {
    $("#nextBtn").css("display", "block");
  }

  if (i == 0) {
    $("#prevBtn").css("display", "none");
    $("#openBtn").css("display", "none");
  }
  else {
    $("#prevBtn").css("display", "block");
    $("#openBtn").css("display", "block");
  }

  $("#log").load("/logs/log" + i + ".html");
}

function openLog() {
  window.location.href = "/logs/log" + i + ".html";
}