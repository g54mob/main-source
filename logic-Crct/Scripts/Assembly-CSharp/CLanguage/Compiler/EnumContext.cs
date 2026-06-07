using CLanguage.Syntax;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	public class EnumContext : EmitContext
	{
		private TypeSpecifier enumTs;

		private CEnumType et;

		private EmitContext emitContext;

		public EnumContext(TypeSpecifier enumTs, CEnumType et, EmitContext parentContext)
			: base(null)
		{
		}

		public override ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
		{
			return null;
		}
	}
}
