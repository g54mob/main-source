using System.Collections.Generic;

namespace CLanguage.Syntax
{
	public class FunctionDeclarator : Declarator
	{
		public List<ParameterDeclaration> Parameters { get; set; }

		public override string DeclaredIdentifier => null;

		public bool CouldBeCtorCall => false;

		public FunctionDeclarator(Declarator innerDeclarator, List<ParameterDeclaration> parameters)
			: base(null)
		{
		}

		public FunctionDeclarator(List<ParameterDeclaration> parameters)
			: base(null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
