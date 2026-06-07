using System;
using Assets.Packages.DevConsole.Commands;
using Assets.Packages.DevConsole.Commands.Arguments;

namespace Assets.Packages.DevConsole
{
	public static class DevConsoleApi
	{
		public static void RegisterArgumentParser<T>(IArgumentParser<T> parser)
		{
			CommandEvaluator.RegisterArgumentParser(parser);
		}

		public static void RegisterCommand(string command, Action commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T>(string command, Action<T> commandAction, string parameterName = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName);
		}

		public static void RegisterCommand<T1, T2>(string command, Action<T1, T2> commandAction, string parameterName1 = null, string parameterName2 = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName1, parameterName2);
		}

		public static void RegisterCommand<T1, T2, T3>(string command, Action<T1, T2, T3> commandAction, string parameterName1 = null, string parameterName2 = null, string parameterName3 = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName1, parameterName2, parameterName3);
		}

		public static void RegisterCommand<T1, T2, T3, T4>(string command, Action<T1, T2, T3, T4> commandAction, string parameterName1 = null, string parameterName2 = null, string parameterName3 = null, string parameterName4 = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName1, parameterName2, parameterName3, parameterName4);
		}

		public static void RegisterCommand<T1, T2, T3, T4, TResult>(string command, Func<T1, T2, T3, T4, TResult> commandAction, string parameterName1 = null, string parameterName2 = null, string parameterName3 = null, string parameterName4 = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName1, parameterName2, parameterName3, parameterName4);
		}

		public static void RegisterCommand<T1, T2, T3, TResult>(string command, Func<T1, T2, T3, TResult> commandAction, string parameterName1 = null, string parameterName2 = null, string parameterName3 = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName1, parameterName2, parameterName3);
		}

		public static void RegisterCommand<T1, T2, TResult>(string command, Func<T1, T2, TResult> commandAction, string parameterName1 = null, string parameterName2 = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName1, parameterName2);
		}

		public static void RegisterCommand<T, TResult>(string command, Func<T, TResult> commandAction, string parameterName = null)
		{
			CommandEvaluator.RegisterCommand(command, commandAction, parameterName);
		}

		public static void RegisterCommand<TResult>(string command, Func<TResult> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void UnregisterCommand(string command)
		{
			CommandEvaluator.UnregisterCommand(command);
		}
	}
}
