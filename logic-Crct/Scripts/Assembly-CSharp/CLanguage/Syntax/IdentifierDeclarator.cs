using System.Collections.Generic;

namespace CLanguage.Syntax
{
	public class IdentifierDeclarator : Declarator
	{
		public string Identifier { get; private set; }

		public List<string> Context { get; }

		public override string DeclaredIdentifier => null;

		public IdentifierDeclarator(string id)
			: base(null)
		{
		}

		public IdentifierDeclarator Push(string id)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
