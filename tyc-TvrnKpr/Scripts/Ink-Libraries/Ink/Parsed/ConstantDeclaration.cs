using Ink.Runtime;

namespace Ink.Parsed
{
	public class ConstantDeclaration : Object
	{
		public string constantName { get; protected set; }

		public Expression expression { get; protected set; }

		public override string typeName => null;

		public ConstantDeclaration(string name, Expression assignedExpression)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}
