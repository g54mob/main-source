using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace Codice.CmdRunner
{
	public class CmdRunner
	{
		private static bool bSetBotMode = false;

		private static CodiceCmdRunner runner = new CodiceCmdRunner();

		public static void InitConsole(IConsoleWriter writer)
		{
			runner.InitConsole(writer);
		}

		public static void SetBotWorkingMode()
		{
			if (!bSetBotMode)
			{
				runner.DontTimeout();
				runner.WorkWithoutFileCommunication();
				bSetBotMode = true;
			}
		}

		public static void TerminateShell()
		{
			try
			{
				if (runner.mCmdProc != null)
				{
					runner.mCmdProc.StandardInput.WriteLine("exit");
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine("!!!!!CmdRunner capturing exception while closing shell. {0} {1}", ex.Message, ex.StackTrace);
			}
			if (runner.mCmdProc != null)
			{
				runner.mCmdProc.WaitForExit();
				runner.mCmdProc.Close();
				runner.mCmdProc = null;
			}
		}

		public static Process Run(string cmd, string workingdir)
		{
			return runner.InternalRun(cmd, workingdir, bRedirectStreams: true);
		}

		public static void ExecuteCommand(string command, string path)
		{
			if (runner.InternalExecuteCommand(command, path, null, out var output, out var _, bUseCmShell: true) != 0)
			{
				throw new Exception(output);
			}
		}

		public static int ExecuteCommandWithInput(string command, string path, string input)
		{
			string output;
			string error;
			return runner.InternalExecuteCommand(command, path, input, out output, out error, bUseCmShell: true);
		}

		public static int ExecuteCommandWithResult(string command, string path)
		{
			string output;
			string error;
			return runner.InternalExecuteCommand(command, path, null, out output, out error, bUseCmShell: true);
		}

		public static int ExecuteCommandWithResult(string command, string path, out string output, out string error, bool bUseCmShell)
		{
			return runner.InternalExecuteCommand(command, path, null, out output, out error, bUseCmShell);
		}

		public static string ExecuteCommandWithStringResult(string command, string path)
		{
			return ExecuteCommandWithStringResult(command, path, bUseShell: true);
		}

		public static string ExecuteCommandWithStringResult(string command, string path, bool bUseShell)
		{
			runner.InternalExecuteCommand(command, path, null, out var output, out var _, bUseShell);
			return output;
		}

		public static void SetEnvironmentVariables(Hashtable envVars)
		{
			runner.SetEnvironmentVariables(envVars);
		}

		public static void ExecuteCommandWithoutOutput(string command, string path)
		{
			if (runner.InternalExecuteCommand(command, path) != 0)
			{
				throw new Exception("Bad internal execution");
			}
		}

		public static int RunAndWait(string cmd, string workingdir, out string output, out string error)
		{
			return runner.RunAndWait(cmd, workingdir, out output, out error);
		}
	}
}
