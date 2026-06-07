using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CIntType : CBasicType
	{
		public override bool IsIntegral => false;

		public override int NumValues => 0;

		public CIntType(string name, Signedness signedness, string size)
			: base(null, default(Signedness), null)
		{
		}

		public int GetByteSize(MachineInfo c)
		{
			return 0;
		}

		public override int GetByteSize(EmitContext c)
		{
			return 0;
		}

		public override int ScoreCastTo(CType otherType)
		{
			return 0;
		}

		public override object GetClrValue(Value[] values, MachineInfo machineInfo)
		{
			return null;
		}
	}
}
