using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Utility
{
	public class ProcessHelper
	{
		public string Application;

		public string Arguments;

		public string StdOut;

		public string StdErr;

		public ProcessHelper(string application, bool path_is_relative = false)
		{
			if (path_is_relative)
			{
				application = Path.Combine(Environment.CurrentDirectory, application);
			}
			Application = application;
		}

		public ProcessHelper AddArg(string key)
		{
			Arguments = Arguments + " \"" + key + "\"";
			return this;
		}

		public ProcessHelper AddArg(string key, string value)
		{
			Arguments = Arguments + " " + key;
			Arguments = Arguments + " \"" + value + "\"";
			return this;
		}

		public bool Run()
		{
			Process process = Process.Start(new ProcessStartInfo(Application, Arguments)
			{
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true,
				UseShellExecute = false
			});
			StdOut = "";
			while (!process.HasExited)
			{
				StdOut += process.StandardOutput.ReadToEnd();
				Thread.Sleep(100);
			}
			StdOut += process.StandardOutput.ReadToEnd();
			StdErr = process.StandardError.ReadToEnd();
			return process.ExitCode == 0;
		}
	}
}
