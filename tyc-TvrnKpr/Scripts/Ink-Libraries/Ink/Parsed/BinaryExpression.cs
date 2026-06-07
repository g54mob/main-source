using Ink.Runtime;

namespace Ink.Parsed
{
	public class BinaryExpression : Expression
	{
		public Expression leftExpression;

		public Expression rightExpression;

		public string opName;

		public BinaryExpression(Expression left, Expression right, string opName)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}

		private string NativeNameForOp(string opName)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
