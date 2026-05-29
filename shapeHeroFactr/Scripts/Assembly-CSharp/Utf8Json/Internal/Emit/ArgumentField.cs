using System;
using System.Reflection.Emit;

namespace Utf8Json.Internal.Emit
{
	internal struct ArgumentField
	{
		private readonly int i;

		private readonly bool @ref;

		private readonly ILGenerator il;

		public ArgumentField(ILGenerator il, int i, bool @ref = false)
		{
			this.i = 0;
			this.@ref = false;
			this.il = null;
		}

		public ArgumentField(ILGenerator il, int i, Type type)
		{
			this.i = 0;
			@ref = false;
			this.il = null;
		}

		public void EmitLoad()
		{
		}

		public void EmitStore()
		{
		}
	}
}
