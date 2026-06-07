using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public abstract class Statement
	{
		public Location Location { get; protected set; }

		public abstract bool AlwaysReturns { get; }

		public void Emit(EmitContext ec)
		{
		}

		protected abstract void DoEmit(EmitContext ec);

		public Block ToBlock()
		{
			return null;
		}

		public abstract void AddDeclarationToBlock(BlockContext context);
	}
}
