using System;
using System.Collections.Generic;

namespace Loxodon.Log
{
	public class DefaultLogFactory : ILogFactory
	{
		private Dictionary<string, ILog> repositories = new Dictionary<string, ILog>();

		private bool inUnity = true;

		private Level _level;

		public Level Level
		{
			get
			{
				return _level;
			}
			set
			{
				_level = value;
			}
		}

		public bool InUnity
		{
			get
			{
				return inUnity;
			}
			set
			{
				inUnity = value;
			}
		}

		public ILog GetLogger<T>()
		{
			return GetLogger(typeof(T));
		}

		public ILog GetLogger(Type type)
		{
			if (repositories.TryGetValue(type.FullName, out var value))
			{
				return value;
			}
			value = new LogImpl(type.Name, this);
			repositories[type.FullName] = value;
			return value;
		}

		public ILog GetLogger(string name)
		{
			if (repositories.TryGetValue(name, out var value))
			{
				return value;
			}
			value = new LogImpl(name, this);
			repositories[name] = value;
			return value;
		}
	}
}
