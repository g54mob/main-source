using Ink.Runtime;

namespace Ink.Parsed
{
	public class VariableAssignment : Object
	{
		private Ink.Runtime.VariableAssignment _runtimeAssignment;

		public string variableName { get; protected set; }

		public Expression expression { get; protected set; }

		public ListDefinition listDefinition { get; protected set; }

		public bool isGlobalDeclaration { get; set; }

		public bool isNewTemporaryDeclaration { get; set; }

		public bool isDeclaration => false;

		public override string typeName => null;

		public VariableAssignment(string variableName, Expression assignedExpression)
		{
		}

		public VariableAssignment(string variableName, ListDefinition listDef)
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
