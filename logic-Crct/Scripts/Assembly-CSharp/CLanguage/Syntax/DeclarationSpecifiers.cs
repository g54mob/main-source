using System.Collections.Generic;

namespace CLanguage.Syntax
{
	public class DeclarationSpecifiers
	{
		public StorageClassSpecifier StorageClassSpecifier { get; set; }

		public List<TypeSpecifier> TypeSpecifiers { get; private set; }

		public FunctionSpecifier FunctionSpecifier { get; set; }

		public TypeQualifiers TypeQualifiers { get; set; }

		public override string ToString()
		{
			return null;
		}
	}
}
