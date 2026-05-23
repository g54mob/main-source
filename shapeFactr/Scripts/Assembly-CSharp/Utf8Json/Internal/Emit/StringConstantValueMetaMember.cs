using System.Reflection.Emit;

namespace Utf8Json.Internal.Emit
{
	internal class StringConstantValueMetaMember : MetaMember
	{
		private readonly string constant;

		public StringConstantValueMetaMember(string name, string constant)
			: base(null, null, null, isWritable: false, isReadable: false)
		{
		}

		public override void EmitLoadValue(ILGenerator il)
		{
		}

		public override void EmitStoreValue(ILGenerator il)
		{
		}
	}
}
