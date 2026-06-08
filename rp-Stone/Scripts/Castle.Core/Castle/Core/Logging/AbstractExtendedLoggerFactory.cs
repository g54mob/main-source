using System;
using System.IO;

namespace Castle.Core.Logging
{
	public abstract class AbstractExtendedLoggerFactory : MarshalByRefObject, IExtendedLoggerFactory, ILoggerFactory
	{
		public virtual IExtendedLogger Create(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return Create(type.FullName);
		}

		public abstract IExtendedLogger Create(string name);

		public virtual IExtendedLogger Create(Type type, LoggerLevel level)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return Create(type.FullName, level);
		}

		public abstract IExtendedLogger Create(string name, LoggerLevel level);

		ILogger ILoggerFactory.Create(Type type)
		{
			return Create(type);
		}

		ILogger ILoggerFactory.Create(string name)
		{
			return Create(name);
		}

		ILogger ILoggerFactory.Create(Type type, LoggerLevel level)
		{
			return Create(type, level);
		}

		ILogger ILoggerFactory.Create(string name, LoggerLevel level)
		{
			return Create(name, level);
		}

		protected static FileInfo GetConfigFile(string fileName)
		{
			if (Path.IsPathRooted(fileName))
			{
				return new FileInfo(fileName);
			}
			return new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
		}
	}
}
