using System;
using Jundroo.DevConsole.Commands;
using Jundroo.DevConsole.Commands.Arguments;

namespace Jundroo.DevConsole
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

		public static void RegisterCommand<T>(string command, Action<T> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T1, T2>(string command, Action<T1, T2> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T1, T2, T3>(string command, Action<T1, T2, T3> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T1, T2, T3, T4>(string command, Action<T1, T2, T3, T4> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T1, T2, T3, T4, TResult>(string command, Func<T1, T2, T3, T4, TResult> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T1, T2, T3, TResult>(string command, Func<T1, T2, T3, TResult> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T1, T2, TResult>(string command, Func<T1, T2, TResult> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
		}

		public static void RegisterCommand<T, TResult>(string command, Func<T, TResult> commandAction)
		{
			CommandEvaluator.RegisterCommand(command, commandAction);
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
