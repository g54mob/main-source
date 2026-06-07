using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CArrayType : CType
	{
		public CType ElementType { get; }

		public int? Length { get; }

		public override int NumValues => 0;

		public CArrayType(CType elementType, int? length)
		{
		}

		protected override CPointerType CreatePointerType()
		{
			return null;
		}

		public override int GetByteSize(EmitContext c)
		{
			return 0;
		}

		public override int ScoreCastTo(CType otherType)
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
