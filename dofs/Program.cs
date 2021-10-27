using System;
using System.IO;

namespace DOFS
{
  class Program
  {
    enum Tags
    {
      hands,
      eyes
    }
    [Serializable]
    class DOF
    {
      public DateTime licenseDate;
      public string name;

      public DOF(DateTime licenseDate, string name)
      {
        this.licenseDate = licenseDate;
        this.name = name;
      }

      public override string ToString()
      {
        return $"{licenseDate} {name}";
      }
    }


    static void Main(string[] args)
    {
      DOF[] dofs = new DOF[] {
        new DOF(new DateTime(2018, 10, 07), "stretch-cursor"),
        new DOF(new DateTime(2019, 03, 14), "oriel"),
        new DOF(new DateTime(2019, 05, 31), "color-cube"),
        new DOF(new DateTime(2019, 10, 17), "orbital-view"),
        new DOF(new DateTime(2019, 10, 28), "offset-cursor"),
        new DOF(new DateTime(2019, 11, 03), "fullstick"),
        new DOF(new DateTime(2020, 04, 21), "trackballer"),
        new DOF(new DateTime(2021, 10, 15), "parabolizer"),
        new DOF(new DateTime(2021, 10, 15), "twist-cursor"),
        new DOF(new DateTime(2021, 10, 18), "cubic-flow"),
      };
      // Console.WriteLine(dofs[0].ToString());

      string dofsJS = "const dofTree = [";
      // make html file for each dof in dofs
      for (int i = 0; i < dofs.Length; i++)
      {
        DOF dof = dofs[i];
        // directory first
        if (!File.Exists($"{dof.name}/")) { Directory.CreateDirectory(dof.name); }

        string pathContent = $"{dof.name}/content.html";
        if (!File.Exists(pathContent))
        {
          string htmlContent = "<pre class='psuedo'><span class='comment'></span></pre>";
          htmlContent += "<div id='fdeg'>&conint;</div>";
          File.WriteAllText(pathContent, htmlContent);
        }
        string content = File.ReadAllText(pathContent);

        DateTime lastUpdated = File.GetLastWriteTime(pathContent);
        DateTime currentDate = DateTime.Now;
        double daysAlive = Math.Max((currentDate - dof.licenseDate).TotalDays, 1);
        // Console.WriteLine($"{dof.name} has been alive for {daysAlive} days");
        double daysSince = Math.Max((lastUpdated - dof.licenseDate).TotalDays, 1);
        // Console.WriteLine($"{dof.name} has been updated for {daysSince} days");
        double t = daysSince / daysAlive;
        // t = 0.05;
        // Console.WriteLine($"t: {t.ToString("0.000")}");

        string html = "<head>";

        int v = int.Parse(File.ReadAllText("version.txt")) + 1; // increment
        File.WriteAllText("version.txt", v.ToString());
        html += "<meta name='viewport' content='width=device-width, initial-scale=1'>";
        html += $"<link rel='stylesheet' href='/style.css?v{v}'>";
        html += "<script src='https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js'></script>";
        html += "<script src='/in-view.min.js'></script>";
        html += $"<script src='/includes/includer.js?v{v}'></script>";
        html += "</head>";
        html += "<body>";
        html += "<div id='navElement'></div>";
        html += $"<img src='{dof.name}.gif' />";
        float licenseGrow = MathF.Max((float)t - 0.5f, 0) * 2;
        float lastGrow = MathF.Max(0.5f - (float)t, 0) * 2;
        html += "<div style='display: flex; justify-content: space-between; background: black;'>";
        html += $"<div class='l'>{dof.licenseDate.ToString("yyyy.MM.dd")}</div>";
        html += $"<div class='l'>{currentDate.ToString("yyyy.MM.dd")}</div>";
        html += "</div>";
        html += "<div style='display: flex; height: 2px;'>";
        html += $"<div style='background: green; flex-grow: {t}'></div>";
        html += $"<div style='background: yellow; flex-grow: 0.01'></div>";
        html += $"<div style='background: red; flex-grow: {1 - t}'></div>";
        html += "</div>";
        html += "<div style='display: flex;'>";
        html += $"<div class='l' style='flex-grow: {t};'></div>";
        html += $"<div class='l'>{lastUpdated.ToString("yyyy.MM.dd")}</div>";
        html += "</div>";
        html += $"<h2 style='color: var(--white);text-decoration: none;'>°{dof.name}</h2>";
        html += $"{content}";
        html += $"";
        html += "</body>";

        string path = $"{dof.name}/index.html";
        File.WriteAllText(path, html);

        // merge with the old
        // by transferring the data and regenerating the html
        // *open these pages in new tab

        dofsJS += $"'{dof.name}',";
      }
      dofsJS += "];";

      File.WriteAllText("dofs.js", dofsJS);


      // go through all html files in project and update version number '?v1'

      // string txt = File.ReadAllText("index.html");
      // txt = 
    }
  }
}
