using CLanguage.Syntax;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	public class TranslationUnitContext : BlockContext
	{
		public TranslationUnit TranslationUnit { get; }

		public TranslationUnitContext(TranslationUnit translationUnit, ExecutableContext exeContext)
			: base(null, null)
		{
		}

		public override CType ResolveTypeName(string typeName)
		{
			return null;
		}

		public override ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
		{
			return null;
		}
	}
}
