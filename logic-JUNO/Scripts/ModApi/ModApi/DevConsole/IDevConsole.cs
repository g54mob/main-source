using System;

namespace ModApi.DevConsole
{
	public interface IDevConsole
	{
		event EventHandler<EventArgs> Initialized;

		void RegisterArgumentParser<T>(IArgumentParser<T> parser);

		void RegisterCommand(string command, Action commandAction);

		void RegisterCommand<T>(string command, Action<T> commandAction);

		void RegisterCommand<T1, T2>(string command, Action<T1, T2> commandAction);

		void RegisterCommand<T1, T2, T3>(string command, Action<T1, T2, T3> commandAction);

		void RegisterCommand<T1, T2, T3, T4>(string command, Action<T1, T2, T3, T4> commandAction);

		void RegisterCommand<T1, T2, T3, T4, TResult>(string command, Func<T1, T2, T3, T4, TResult> commandAction);

		void RegisterCommand<T1, T2, T3, TResult>(string command, Func<T1, T2, T3, TResult> commandAction);

		void RegisterCommand<T1, T2, TResult>(string command, Func<T1, T2, TResult> commandAction);

		void RegisterCommand<T, TResult>(string command, Func<T, TResult> commandAction);

		void RegisterCommand<TResult>(string command, Func<TResult> commandAction);

		void UnregisterCommand(string command);
	}
}
