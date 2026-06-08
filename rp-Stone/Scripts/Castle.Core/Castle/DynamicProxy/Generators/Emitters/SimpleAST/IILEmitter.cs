using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public interface IILEmitter
	{
		void Emit(IMemberEmitter member, ILGenerator gen);
	}
}
