using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public abstract class Expression : IILEmitter
	{
		public abstract void Emit(IMemberEmitter member, ILGenerator gen);
	}
}
