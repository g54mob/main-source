using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public class TypeConstructorEmitter : ConstructorEmitter
	{
		internal TypeConstructorEmitter(AbstractTypeEmitter maintype)
			: base(maintype, maintype.TypeBuilder.DefineTypeInitializer())
		{
		}

		public override void EnsureValidCodeBlock()
		{
			if (CodeBuilder.IsEmpty)
			{
				CodeBuilder.AddStatement(new ReturnStatement());
			}
		}
	}
}
