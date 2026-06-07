using System;
using NGenerics.Util;

namespace NGenerics.Patterns.Visitor
{
	public class ActionVisitor<T> : IVisitor<T>
	{
		private readonly Action<T> action;

		public bool HasCompleted
		{
			get
			{
				return false;
			}
		}

		public ActionVisitor(Action<T> action)
		{
			Guard.ArgumentNotNull(action, "action");
			this.action = action;
		}

		public void Visit(T obj)
		{
			action(obj);
		}
	}
}
