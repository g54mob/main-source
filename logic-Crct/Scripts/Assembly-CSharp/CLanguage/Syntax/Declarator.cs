namespace CLanguage.Syntax
{
	public abstract class Declarator
	{
		public abstract string DeclaredIdentifier { get; }

		public bool StrongBinding { get; set; }

		public Declarator? InnerDeclarator { get; set; }

		protected Declarator(Declarator? innerDeclarator)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
