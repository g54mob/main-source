using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class TypeConstructorEmitter : ConstructorEmitter
	{
		internal TypeConstructorEmitter(AbstractTypeEmitter mainType)
			: base(mainType, mainType.TypeBuilder.DefineTypeInitializer())
		{
		}

		public override void EnsureValidCodeBlock()
		{
			if (base.CodeBuilder.IsEmpty)
			{
				base.CodeBuilder.AddStatement(new ReturnStatement());
			}
		}
	}
}
