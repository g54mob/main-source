using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CPointerType : CType
	{
		public static readonly CPointerType PointerToConstChar;

		public static readonly CPointerType PointerToVoid;

		public CType InnerType { get; private set; }

		public override int NumValues => 0;

		public CPointerType(CType innerType)
		{
		}

		public override int GetByteSize(EmitContext c)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
