using System.Diagnostics;
using BuildAgent;

var dest = "/users/jameymcelveen/dev/BuildAgent2";
var work = "/users/jameymcelveen/dev/work";

if (Directory.Exists(dest))
{
    Directory.Delete(dest, true);
}
if (Directory.Exists(work))
{
    Directory.Delete(work, true);
}
var proc = new Process();
proc.StartInfo.FileName = @"git";
proc.StartInfo.Arguments = "clone git@github.com:jameymcelveen/BuildAgent.git " + work;
proc.StartInfo.UseShellExecute = false;
proc.StartInfo.RedirectStandardOutput = true;
proc.Start();
string outPut = proc.StandardOutput.ReadToEnd();
Console.WriteLine(outPut);
proc.WaitForExit();
var exitCode = proc.ExitCode;
proc.Close();

Directory.SetCurrentDirectory(work);
Directory.CreateDirectory(dest);

proc = new Process();
proc.StartInfo.FileName = @"dotnet";
proc.StartInfo.Arguments = "build --configuration Release --output " + dest;
proc.StartInfo.UseShellExecute = false;
proc.StartInfo.RedirectStandardOutput = true;
proc.Start();
outPut = proc.StandardOutput.ReadToEnd();
Console.WriteLine(outPut);
proc.WaitForExit();
exitCode = proc.ExitCode;
proc.Close();