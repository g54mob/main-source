using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class NullExpression : Expression
	{
		public static readonly NullExpression Instance = new NullExpression();

		protected NullExpression()
		{
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldnull);
		}
	}
}
