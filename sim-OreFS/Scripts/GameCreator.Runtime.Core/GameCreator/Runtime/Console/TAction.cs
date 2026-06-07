using System;

namespace GameCreator.Runtime.Console
{
	public abstract class TAction<T> : IAction
	{
		public string Name { get; }

		public string Description { get; }

		private Func<string, T> Execute { get; }

		protected TAction(string name, string description, Func<string, T> method)
		{
			Name = name.ToLowerInvariant();
			Description = description;
			Execute = method;
		}

		public T Run(string value)
		{
			if (Execute == null)
			{
				return default(T);
			}
			return Execute(value);
		}
	}
}
