using System.Reflection;
using System.Reflection.Emit;

namespace Utf8Json.Internal.Emit
{
	internal class InnerExceptionMetaMember : MetaMember
	{
		private static readonly MethodInfo getInnerException;

		private static readonly MethodInfo nongenericSerialize;

		internal ArgumentField argWriter;

		internal ArgumentField argValue;

		internal ArgumentField argResolver;

		public InnerExceptionMetaMember(string name)
			: base(null, null, null, isWritable: false, isReadable: false)
		{
		}

		public override void EmitLoadValue(ILGenerator il)
		{
		}

		public override void EmitStoreValue(ILGenerator il)
		{
		}

		public void EmitSerializeDirectly(ILGenerator il)
		{
		}
	}
}
