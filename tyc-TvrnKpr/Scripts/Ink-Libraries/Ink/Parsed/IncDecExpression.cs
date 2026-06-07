using Ink.Runtime;

namespace Ink.Parsed
{
	public class IncDecExpression : Expression
	{
		public string varName;

		public bool isInc;

		public Expression expression;

		private Ink.Runtime.VariableAssignment _runtimeAssignment;

		private string incrementDecrementWord => null;

		public IncDecExpression(string varName, bool isInc)
		{
		}

		public IncDecExpression(string varName, Expression expression, bool isInc)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
