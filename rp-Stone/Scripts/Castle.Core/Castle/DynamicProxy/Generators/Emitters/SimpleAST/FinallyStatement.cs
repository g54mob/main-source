using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class FinallyStatement : Statement
	{
		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			gen.BeginFinallyBlock();
		}
	}
}
