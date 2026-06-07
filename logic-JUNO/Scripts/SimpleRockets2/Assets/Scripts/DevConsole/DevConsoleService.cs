using System;
using Assets.Packages.DevConsole;
using Assets.Packages.DevConsole.Commands.Arguments;
using ModApi.Common.Events;
using ModApi.DevConsole;
using UnityEngine;

namespace Assets.Scripts.DevConsole
{
	public class DevConsoleService : IDevConsole
	{
		private class ArgumentParserBridge<T> : Assets.Packages.DevConsole.Commands.Arguments.IArgumentParser<T>, ModApi.DevConsole.IArgumentParser<T>
		{
			private ModApi.DevConsole.IArgumentParser<T> _parser;

			public string HelpMessage => _parser.HelpMessage;

			public int Priority => _parser.Priority;

			public ArgumentParserBridge(ModApi.DevConsole.IArgumentParser<T> parser)
			{
				_parser = parser;
			}

			public bool TryParse(string value, out T result)
			{
				return _parser.TryParse(value, out result);
			}
		}

		private static DevConsoleService _instance = new DevConsoleService();

		public static DevConsoleService Instance => _instance;

		public event EventHandler<EventArgs> Initialized
		{
			add
			{
				_initialized += WeakEventHandler.Create(value, delegate(EventHandler<EventArgs> x)
				{
					_initialized -= x;
				});
			}
			remove
			{
				_initialized -= WeakEventHandler.FindUnregisterHandler(this._initialized, value);
			}
		}

		private event EventHandler<EventArgs> _initialized;

		public void RaiseInitialized()
		{
			if (this._initialized == null)
			{
				return;
			}
			Delegate[] invocationList = this._initialized.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<EventArgs> eventHandler = (EventHandler<EventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new EventArgs());
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RegisterArgumentParser<T>(ModApi.DevConsole.IArgumentParser<T> parser)
		{
			DevConsoleApi.RegisterArgumentParser(new ArgumentParserBridge<T>(parser));
		}

		public void RegisterCommand<TResult>(string command, Func<TResult> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T, TResult>(string command, Func<T, TResult> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T1, T2, TResult>(string command, Func<T1, T2, TResult> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T1, T2, T3, TResult>(string command, Func<T1, T2, T3, TResult> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T1, T2, T3, T4, TResult>(string command, Func<T1, T2, T3, T4, TResult> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T1, T2, T3, T4>(string command, Action<T1, T2, T3, T4> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T1, T2, T3>(string command, Action<T1, T2, T3> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T1, T2>(string command, Action<T1, T2> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand<T>(string command, Action<T> commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void RegisterCommand(string command, Action commandAction)
		{
			DevConsoleApi.RegisterCommand(command, commandAction);
		}

		public void UnregisterCommand(string command)
		{
			DevConsoleApi.UnregisterCommand(command);
		}
	}
}
