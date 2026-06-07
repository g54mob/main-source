namespace CLanguage.Syntax
{
	public class TypeSpecifier
	{
		public TypeSpecifierKind Kind { get; private set; }

		public string Name { get; private set; }

		public Block? Body { get; private set; }

		public TypeSpecifier(TypeSpecifierKind kind, string name, Block? body = null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
