using Ink.Runtime;

namespace Ink.Parsed
{
	public class UnaryExpression : Expression
	{
		public Expression innerExpression;

		public string op;

		private string nativeNameForOp => null;

		public static Expression WithInner(Expression inner, string op)
		{
			return null;
		}

		public UnaryExpression(Expression inner, string op)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
