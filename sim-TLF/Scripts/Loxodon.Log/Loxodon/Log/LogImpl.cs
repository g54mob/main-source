using System;
using UnityEngine;

namespace Loxodon.Log
{
	internal class LogImpl : ILog
	{
		private string name;

		private DefaultLogFactory _factory;

		public string Name => name;

		public virtual bool IsDebugEnabled => IsEnabled(Level.DEBUG);

		public virtual bool IsInfoEnabled => IsEnabled(Level.INFO);

		public virtual bool IsWarnEnabled => IsEnabled(Level.WARN);

		public virtual bool IsErrorEnabled => IsEnabled(Level.ERROR);

		public virtual bool IsFatalEnabled => IsEnabled(Level.FATAL);

		public LogImpl(string name, DefaultLogFactory factory)
		{
			this.name = name;
			_factory = factory;
		}

		protected virtual string Format(object message, string level)
		{
			return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {name} - {message}";
		}

		public virtual void Debug(object message)
		{
			if (_factory.InUnity)
			{
				UnityEngine.Debug.Log(Format(message, "DEBUG"));
			}
			else
			{
				Console.WriteLine(Format(message, "DEBUG"));
			}
		}

		public virtual void Debug(object message, Exception exception)
		{
			Debug($"{message} Exception:{exception}");
		}

		public virtual void DebugFormat(string format, params object[] args)
		{
			Debug(string.Format(format, args));
		}

		public virtual void Info(object message)
		{
			if (_factory.InUnity)
			{
				UnityEngine.Debug.Log(Format(message, "INFO"));
			}
			else
			{
				Console.WriteLine(Format(message, "INFO"));
			}
		}

		public virtual void Info(object message, Exception exception)
		{
			Info($"{message} Exception:{exception}");
		}

		public virtual void InfoFormat(string format, params object[] args)
		{
			Info(string.Format(format, args));
		}

		public virtual void Warn(object message)
		{
			if (_factory.InUnity)
			{
				UnityEngine.Debug.LogWarning(Format(message, "WARN"));
			}
			else
			{
				Console.WriteLine(Format(message, "WARN"));
			}
		}

		public virtual void Warn(object message, Exception exception)
		{
			Warn($"{message} Exception:{exception}");
		}

		public virtual void WarnFormat(string format, params object[] args)
		{
			Warn(string.Format(format, args));
		}

		public virtual void Error(object message)
		{
			if (_factory.InUnity)
			{
				UnityEngine.Debug.LogError(Format(message, "ERROR"));
			}
			else
			{
				Console.WriteLine(Format(message, "ERROR"));
			}
		}

		public virtual void Error(object message, Exception exception)
		{
			Error($"{message} Exception:{exception}");
		}

		public virtual void ErrorFormat(string format, params object[] args)
		{
			Error(string.Format(format, args));
		}

		public virtual void Fatal(object message)
		{
			if (_factory.InUnity)
			{
				UnityEngine.Debug.LogError(Format(message, "FATAL"));
			}
			else
			{
				Console.WriteLine(Format(message, "FATAL"));
			}
		}

		public virtual void Fatal(object message, Exception exception)
		{
			Fatal($"{message} Exception:{exception}");
		}

		public virtual void FatalFormat(string format, params object[] args)
		{
			Fatal(string.Format(format, args));
		}

		protected bool IsEnabled(Level level)
		{
			return level >= _factory.Level;
		}
	}
}
