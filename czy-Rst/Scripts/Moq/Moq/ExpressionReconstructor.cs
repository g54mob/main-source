using System;
using System.Linq.Expressions;

namespace Moq
{
	internal abstract class ExpressionReconstructor
	{
		private static ExpressionReconstructor instance = new ActionObserver();

		public static ExpressionReconstructor Instance
		{
			get
			{
				return instance;
			}
			set
			{
				instance = value ?? throw new ArgumentNullException("value");
			}
		}

		public abstract Expression<Action<T>> ReconstructExpression<T>(Action<T> action, object[] ctorArgs = null);
	}
}
