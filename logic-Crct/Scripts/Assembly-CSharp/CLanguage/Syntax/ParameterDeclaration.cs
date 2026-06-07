namespace CLanguage.Syntax
{
	public class ParameterDeclaration
	{
		public string Name { get; private set; }

		public DeclarationSpecifiers? DeclarationSpecifiers { get; private set; }

		public Declarator? Declarator { get; private set; }

		public Expression? DefaultValue { get; }

		public Expression? CtorArgumentValue { get; private set; }

		public ParameterDeclaration(string name)
		{
		}

		public ParameterDeclaration(Expression ctorArgumentValue)
		{
		}

		public ParameterDeclaration(DeclarationSpecifiers specs)
		{
		}

		public ParameterDeclaration(DeclarationSpecifiers specs, Declarator dec)
		{
		}

		public ParameterDeclaration(DeclarationSpecifiers specs, Declarator dec, Expression defaultValue)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
