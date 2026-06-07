using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CBoolType : CBasicType
	{
		public override bool IsIntegral => false;

		public override int NumValues => 0;

		public CBoolType()
			: base(null, default(Signedness), null)
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
	}
}
