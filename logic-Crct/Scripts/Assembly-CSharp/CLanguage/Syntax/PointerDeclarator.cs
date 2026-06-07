namespace CLanguage.Syntax
{
	public class PointerDeclarator : Declarator
	{
		public Pointer Pointer { get; private set; }

		public override string DeclaredIdentifier => null;

		public PointerDeclarator(Pointer pointer, Declarator decl)
			: base(null)
		{
		}
	}
}
