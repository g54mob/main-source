using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class ExpressionCompiler
	{
		private static ExpressionCompiler instance = DefaultExpressionCompiler.Instance;

		public static ExpressionCompiler Default => DefaultExpressionCompiler.Instance;

		public static ExpressionCompiler Instance
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

		public abstract Delegate Compile(LambdaExpression expression);

		public abstract TDelegate Compile<TDelegate>(Expression<TDelegate> expression) where TDelegate : Delegate;
	}
}
