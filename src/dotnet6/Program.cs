// See https://aka.ms/new-console-template for more information

using System.Text;
using Pty.Net;

Console.WriteLine("Create Options");
PtyOptions options = new PtyOptions
                     {
                         App = "/bin/bash",
                         Cwd = Environment.CurrentDirectory
                     };
Console.WriteLine("SpawnAsync");
IPtyConnection connection = await PtyProvider.SpawnAsync(options, CancellationToken.None);
Console.WriteLine("Write 'exit\\n' to stdin");
connection.WriterStream.Write(Encoding.UTF8.GetBytes("exit\n"));
Console.WriteLine("Flush stdin");
connection.WriterStream.Flush();
Console.WriteLine("Wait for exit");
connection.WaitForExit(100);
Console.WriteLine("Done");