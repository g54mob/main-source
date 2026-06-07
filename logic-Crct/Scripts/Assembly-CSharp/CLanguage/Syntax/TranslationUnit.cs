using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class TranslationUnit : Block
	{
		public string Name { get; }

		public TranslationUnit(string name)
			: base(default(VariableScope), null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
