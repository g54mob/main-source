using System;
using System.IO;

namespace Castle.Core.Logging
{
	public abstract class AbstractLoggerFactory : ILoggerFactory
	{
		public virtual ILogger Create(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return Create(type.FullName);
		}

		public virtual ILogger Create(Type type, LoggerLevel level)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return Create(type.FullName, level);
		}

		public abstract ILogger Create(string name);

		public abstract ILogger Create(string name, LoggerLevel level);

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
