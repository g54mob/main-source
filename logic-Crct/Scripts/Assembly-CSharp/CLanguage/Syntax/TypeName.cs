namespace CLanguage.Syntax
{
	public class TypeName
	{
		public DeclarationSpecifiers Specifiers { get; }

		public Declarator? Declarator { get; }

		public TypeName(DeclarationSpecifiers specifiers, Declarator? declarator)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
