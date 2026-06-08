using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("argument {Type}")]
	internal class ArgumentReference : TypeReference
	{
		internal int Position { get; set; }

		public ArgumentReference(Type argumentType)
			: base(argumentType)
		{
			Position = -1;
		}

		public ArgumentReference(Type argumentType, int position)
			: base(argumentType)
		{
			Position = position;
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
			throw new NotSupportedException();
		}

		public override void LoadReference(ILGenerator gen)
		{
			if (Position == -1)
			{
				throw new InvalidOperationException("ArgumentReference uninitialized");
			}
			switch (Position)
			{
			case 0:
				gen.Emit(OpCodes.Ldarg_0);
				break;
			case 1:
				gen.Emit(OpCodes.Ldarg_1);
				break;
			case 2:
				gen.Emit(OpCodes.Ldarg_2);
				break;
			case 3:
				gen.Emit(OpCodes.Ldarg_3);
				break;
			default:
				gen.Emit(OpCodes.Ldarg_S, Position);
				break;
			}
		}

		public override void StoreReference(ILGenerator gen)
		{
			if (Position == -1)
			{
				throw new InvalidOperationException("ArgumentReference uninitialized");
			}
			gen.Emit(OpCodes.Starg, Position);
		}
	}
}
