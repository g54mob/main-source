using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace Codice.CmdRunner
{
	internal class BaseCmdRunner
	{
		private Hashtable mEnvironmentVariables;

		private static IConsoleWriter mConsoleWriter;

		internal Process mCmdProc;

		public void InitConsole(IConsoleWriter writer)
		{
			mConsoleWriter = writer;
		}

		public int InternalExecuteCommand(string command, string path)
		{
			WriteCommand(path, command);
			try
			{
				int result = RunAndWait(command, path);
				ProcessCommandResult(command, result);
				return result;
			}
			catch (Exception e)
			{
				return ManageException(command, path, e);
			}
		}

		public int InternalExecuteCommand(string command, string path, string input, out string output, out string error, bool bUseCmShell)
		{
			output = string.Empty;
			error = string.Empty;
			WriteCommand(path, command);
			try
			{
				int num = ((input == null) ? RunAndWait(command, path, out output, out error, bUseCmShell) : RunAndWaitWithInput(command, path, input, out output, out error));
				WriteLine(output);
				if (num != 0)
				{
					WriteLine(error);
				}
				ProcessCommandResult(command, num);
				return num;
			}
			catch (Exception e)
			{
				return ManageException(command, path, e);
			}
		}

		protected void WriteLine(string s)
		{
			if (mConsoleWriter != null)
			{
				mConsoleWriter.WriteLine(s);
			}
		}

		protected double GetTotalProcessorTime(Process proc)
		{
			try
			{
				return proc.TotalProcessorTime.TotalSeconds;
			}
			catch
			{
				return -1.0;
			}
		}

		internal Process InternalRun(string cmd, string workingdir, bool bRedirectStreams)
		{
			Process process = new Process();
			string[] array = cmd.Split(' ');
			process.StartInfo.FileName = array[0];
			process.StartInfo.WorkingDirectory = workingdir;
			process.StartInfo.Arguments = EscapeArgs(cmd.Substring(array[0].Length));
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardOutput = bRedirectStreams;
			process.StartInfo.RedirectStandardInput = bRedirectStreams;
			process.StartInfo.RedirectStandardError = bRedirectStreams;
			process.StartInfo.UseShellExecute = false;
			if (mEnvironmentVariables != null)
			{
				foreach (string key in mEnvironmentVariables.Keys)
				{
					process.StartInfo.EnvironmentVariables[key] = mEnvironmentVariables[key] as string;
				}
			}
			process.Start();
			return process;
		}

		internal void SetEnvironmentVariables(Hashtable variables)
		{
			mEnvironmentVariables = variables;
		}

		internal virtual int RunAndWait(string cmd, string workingdir, out string output, out string error, bool bUseCmShell)
		{
			return RunAndWaitWithInput(cmd, workingdir, null, out output, out error);
		}

		internal virtual int RunAndWait(string cmd, string workingdir, out string output, out string error)
		{
			return RunAndWaitWithInput(cmd, workingdir, null, out output, out error);
		}

		internal virtual int RunAndWaitWithInput(string cmd, string workingdir, string input, out string output, out string error)
		{
			Process process = InternalRun(cmd, workingdir, bRedirectStreams: true);
			try
			{
				if (input != null && input != string.Empty)
				{
					if (!PlatformIdentifier.IsWindows())
					{
						byte[] bytes = Encoding.UTF8.GetBytes(input);
						process.StandardInput.BaseStream.Write(bytes, 0, bytes.Length);
					}
					else
					{
						process.StandardInput.Write(input);
					}
					process.StandardInput.Flush();
					process.StandardInput.Close();
				}
				output = process.StandardOutput.ReadToEnd();
				error = process.StandardError.ReadToEnd();
				process.WaitForExit();
				return process.ExitCode;
			}
			finally
			{
				process.Close();
			}
		}

		internal virtual int RunAndWait(string cmd, string workingdir)
		{
			Process process = InternalRun(cmd, workingdir, bRedirectStreams: false);
			try
			{
				process.WaitForExit();
				return process.ExitCode;
			}
			finally
			{
				process.Close();
			}
		}

		private bool IsWindows()
		{
			PlatformID platform = Environment.OSVersion.Platform;
			if ((uint)(platform - 1) <= 1u)
			{
				return true;
			}
			return false;
		}

		private string EscapeArgs(string args)
		{
			if (IsWindows())
			{
				return args;
			}
			return args.Replace("#", "\\#");
		}

		private int ManageException(string command, string path, Exception e)
		{
			string s = $"Error executing command {command} on path {path}. Error = {e.Message + e.StackTrace}";
			WriteLine(s);
			return 1;
		}

		private void WriteCommand(string path, string command)
		{
			string s = $"{path}$ {command}";
			WriteLine(s);
		}

		private void ProcessCommandResult(string command, int result)
		{
			if (result != 0)
			{
				WriteLine($"Command {command} failed with error code {result}");
			}
		}
	}
}
