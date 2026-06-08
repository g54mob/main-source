using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class LiteralIntExpression : Expression
	{
		private readonly int value;

		public LiteralIntExpression(int value)
		{
			this.value = value;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			switch (value)
			{
			case -1:
				gen.Emit(OpCodes.Ldc_I4_M1);
				break;
			case 0:
				gen.Emit(OpCodes.Ldc_I4_0);
				break;
			case 1:
				gen.Emit(OpCodes.Ldc_I4_1);
				break;
			case 2:
				gen.Emit(OpCodes.Ldc_I4_2);
				break;
			case 3:
				gen.Emit(OpCodes.Ldc_I4_3);
				break;
			case 4:
				gen.Emit(OpCodes.Ldc_I4_4);
				break;
			case 5:
				gen.Emit(OpCodes.Ldc_I4_5);
				break;
			case 6:
				gen.Emit(OpCodes.Ldc_I4_6);
				break;
			case 7:
				gen.Emit(OpCodes.Ldc_I4_7);
				break;
			case 8:
				gen.Emit(OpCodes.Ldc_I4_8);
				break;
			default:
				gen.Emit(OpCodes.Ldc_I4, value);
				break;
			}
		}
	}
}
