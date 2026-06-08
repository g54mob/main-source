using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.CodeBuilders
{
	public class MethodCodeBuilder : AbstractCodeBuilder
	{
		public MethodCodeBuilder(ILGenerator generator)
			: base(generator)
		{
		}
	}
}
