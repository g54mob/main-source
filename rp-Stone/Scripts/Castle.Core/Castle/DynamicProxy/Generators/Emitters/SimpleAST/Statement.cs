using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public abstract class Statement : IILEmitter
	{
		public abstract void Emit(IMemberEmitter member, ILGenerator gen);
	}
}
