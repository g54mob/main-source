namespace Ink.Runtime
{
	public class VariableAssignment : Object
	{
		public string variableName { get; protected set; }

		public bool isNewDeclaration { get; protected set; }

		public bool isGlobal { get; set; }

		public VariableAssignment(string variableName, bool isNewDeclaration)
		{
		}

		public VariableAssignment()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
