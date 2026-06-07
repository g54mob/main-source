using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CVoidType : CType
	{
		public override bool IsVoid => false;

		public override int NumValues => 0;

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
