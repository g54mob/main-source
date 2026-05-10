using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Codice.CmdRunner
{
	internal class CodiceCmdRunner : BaseCmdRunner
	{
		private delegate string ReadAsync(StreamReader reader);

		protected bool USE_FILE_COMMUNICATION = true;

		private const int DEFAULT_SPIN_TIME = 10000;

		private const int DEFAULT_MAX_WAIT_TIME = 480000;

		private const int DEFAULT_MAX_WAIT_TIME_ALL = 1800000;

		private int mSpinTime = -1;

		private int mMaxWaitTime = -1;

		private int mMaxWaitTimeAll = -1;

		private const int SECOND = 1000;

		private const int MINUTE = 60000;

		private bool mbTimeOut = true;

		private static string COMMAND_RESULT = "CommandResult";

		protected int ReadFileOutputUnix(Process proc, string outputfile, out string output, out string error)
		{
			bool flag = false;
			int result = 1;
			output = string.Empty;
			error = string.Empty;
			StreamReader streamReader = null;
			try
			{
				while (!flag)
				{
					int tickCount = Environment.TickCount;
					double totSeconds = GetTotalProcessorTime(proc);
					int lastElapsed = Environment.TickCount;
					while (!ReadFileContent(outputfile, ref output) && !proc.HasExited)
					{
						result = RunWait(proc, tickCount, ref lastElapsed, ref totSeconds, out error);
						if (result != 0)
						{
							return result;
						}
					}
					if (output.IndexOf(COMMAND_RESULT) < 0)
					{
						return 1;
					}
					flag = true;
					result = Convert.ToInt32(output.Substring(output.IndexOf(COMMAND_RESULT) + COMMAND_RESULT.Length + 1));
					output = output.Substring(0, output.IndexOf(COMMAND_RESULT));
				}
				return result;
			}
			finally
			{
				streamReader?.Close();
				if (File.Exists(outputfile))
				{
					File.Delete(outputfile);
				}
			}
		}

		protected int ReadFileOutputWindows(Process proc, string outputfile, out string output, out string error)
		{
			bool flag = false;
			int num = 1;
			output = string.Empty;
			error = string.Empty;
			while (!flag)
			{
				int tickCount = Environment.TickCount;
				double totSeconds = GetTotalProcessorTime(proc);
				int lastElapsed = Environment.TickCount;
				StreamReader streamReader = null;
				while (!TryToOpenFile(outputfile, ref streamReader) && !proc.HasExited)
				{
					num = RunWait(proc, tickCount, ref lastElapsed, ref totSeconds, out error);
					if (num != 0)
					{
						return num;
					}
				}
				try
				{
					if (streamReader == null)
					{
						continue;
					}
					while (streamReader.Peek() >= 0 && !flag)
					{
						string text = streamReader.ReadLine();
						if (text.StartsWith(COMMAND_RESULT))
						{
							flag = true;
							num = Convert.ToInt32(text.Substring(COMMAND_RESULT.Length + 1));
						}
						else
						{
							output = output + text + "\n";
						}
					}
				}
				finally
				{
					streamReader?.Close();
					if (File.Exists(outputfile))
					{
						File.Delete(outputfile);
					}
				}
			}
			return num;
		}

		protected int ReadStdOutput(Process proc, out string output, out string error)
		{
			ReadAsync readAsync = ReadALine;
			bool flag = false;
			output = string.Empty;
			error = string.Empty;
			int num = 1;
			while (!flag)
			{
				IAsyncResult asyncResult = readAsync.BeginInvoke(proc.StandardOutput, null, null);
				int tickCount = Environment.TickCount;
				double totSeconds = GetTotalProcessorTime(proc);
				int lastElapsed = Environment.TickCount;
				while (!asyncResult.IsCompleted)
				{
					num = RunWait(proc, tickCount, ref lastElapsed, ref totSeconds, out error);
					if (num != 0)
					{
						return num;
					}
				}
				string text = readAsync.EndInvoke(asyncResult);
				if (text.StartsWith(COMMAND_RESULT))
				{
					flag = true;
					num = Convert.ToInt32(text.Substring(COMMAND_RESULT.Length + 1));
				}
				else
				{
					output = output + text + "\n";
				}
			}
			return num;
		}

		protected int RunWait(Process proc, int initWait, ref int lastElapsed, ref double totSeconds, out string error)
		{
			Thread.Sleep(10);
			error = string.Empty;
			if (!mbTimeOut)
			{
				return 0;
			}
			double totalProcessorTime = GetTotalProcessorTime(proc);
			long num = Environment.TickCount - initWait;
			if (Environment.TickCount - lastElapsed > GetSpinTime())
			{
				WriteLine($"RunAndWait spinning. Time {Environment.TickCount - initWait}. Proc time {totalProcessorTime}");
				lastElapsed = Environment.TickCount;
				if (totalProcessorTime == totSeconds)
				{
					WriteLine("Sending an enter to move things a little bit");
					proc.StandardInput.WriteLine(string.Empty);
				}
			}
			if (num > GetMaxWaitTime())
			{
				if (totSeconds == -1.0)
				{
					if (num > GetMaxWaitTimeAll())
					{
						WriteLine("Too much time waiting for comand result");
						error = "Too much time waiting to command result";
						return 1;
					}
					Thread.Sleep(10);
				}
				else if (totalProcessorTime == totSeconds)
				{
					WriteLine("Too much time waiting to read");
					error = "Too much time waiting to read... FED UP!";
					return 1;
				}
				totSeconds = GetTotalProcessorTime(proc);
			}
			return 0;
		}

		protected string ReadALine(StreamReader reader)
		{
			return reader.ReadLine();
		}

		internal void DontTimeout()
		{
			mbTimeOut = false;
		}

		internal void WorkWithoutFileCommunication()
		{
			USE_FILE_COMMUNICATION = false;
		}

		internal override int RunAndWait(string cmd, string workingdir, out string output, out string error)
		{
			return RunAndWait(cmd, workingdir, out output, out error, true);
		}

		internal override int RunAndWait(string cmd, string workingdir, out string output, out string error, bool bShell)
		{
			if (!bShell || !cmd.StartsWith("cm"))
			{
				return base.RunAndWait(cmd, workingdir, out output, out error);
			}
			workingdir = Path.GetFullPath(workingdir);
			if (mCmdProc == null)
			{
				mCmdProc = InitCmdProc(workingdir);
			}
			string arg = cmd.Substring(3);
			string text = string.Empty;
			if (USE_FILE_COMMUNICATION)
			{
				text = Path.GetTempFileName();
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				string value = $"{arg} -path=\"{workingdir}\" --shelloutputfile=\"{text}\" --stack";
				mCmdProc.StandardInput.WriteLine(value);
			}
			else
			{
				string value2 = $"{arg} -path=\"{workingdir}\"";
				mCmdProc.StandardInput.WriteLine(value2);
			}
			output = string.Empty;
			int num = 0;
			if (USE_FILE_COMMUNICATION)
			{
				if (PlatformIdentifier.IsWindows())
				{
					return ReadFileOutputWindows(mCmdProc, text, out output, out error);
				}
				return ReadFileOutputUnix(mCmdProc, text, out output, out error);
			}
			return ReadStdOutput(mCmdProc, out output, out error);
		}

		private int GetSpinTime()
		{
			if (mSpinTime != -1)
			{
				return mSpinTime;
			}
			mSpinTime = 10000;
			return mSpinTime;
		}

		private int GetMaxWaitTime()
		{
			if (mMaxWaitTime != -1)
			{
				return mMaxWaitTime;
			}
			mMaxWaitTime = 480000;
			return mMaxWaitTime;
		}

		private int GetMaxWaitTimeAll()
		{
			if (mMaxWaitTimeAll != -1)
			{
				return mMaxWaitTimeAll;
			}
			mMaxWaitTimeAll = 1800000;
			return mMaxWaitTimeAll;
		}

		private bool TryToOpenFile(string filename, ref StreamReader streamReader)
		{
			if (!File.Exists(filename))
			{
				return false;
			}
			try
			{
				streamReader = new StreamReader(filename);
				streamReader.Peek();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool ReadFileContent(string filename, ref string output)
		{
			if (!File.Exists(filename))
			{
				return false;
			}
			StreamReader streamReader = null;
			try
			{
				streamReader = new StreamReader(filename);
				output = streamReader.ReadToEnd();
				if (output.IndexOf(COMMAND_RESULT) >= 0)
				{
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				streamReader?.Close();
			}
		}

		private Process InitCmdProc(string workingdir)
		{
			string cmShellCommand = LaunchCommand.Get().GetCmShellCommand();
			cmShellCommand = cmShellCommand.Replace("[GENDATESTAMP]", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
			string clientPath = LaunchCommand.Get().GetClientPath();
			if (clientPath != string.Empty)
			{
				clientPath = Path.GetFullPath(clientPath);
				cmShellCommand = cmShellCommand.Replace("[CLIENTPATH]", clientPath);
			}
			Process process = InternalRun(cmShellCommand, workingdir, bRedirectStreams: true);
			string text;
			do
			{
				text = process.StandardOutput.ReadLine();
				WriteLine(text);
			}
			while (text.IndexOf("Plastic SCM shell") < 0);
			return process;
		}
	}
}
