using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CFloatType : CBasicType
	{
		public int Bits { get; }

		public override int NumValues => 0;

		public CFloatType(string name, int bits)
			: base(null, default(Signedness), null)
		{
		}

		public override int GetByteSize(EmitContext c)
		{
			return 0;
		}

		public override int ScoreCastTo(CType otherType)
		{
			return 0;
		}
	}
}
