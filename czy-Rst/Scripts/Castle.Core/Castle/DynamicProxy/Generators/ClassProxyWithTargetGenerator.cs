using System;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators
{
	internal sealed class ClassProxyWithTargetGenerator : BaseClassProxyGenerator
	{
		private FieldReference targetField;

		protected override FieldReference TargetField => targetField;

		public ClassProxyWithTargetGenerator(ModuleScope scope, Type targetType, Type[] interfaces, ProxyGenerationOptions options)
			: base(scope, targetType, interfaces, options)
		{
		}

		protected override CacheKey GetCacheKey()
		{
			return new CacheKey(targetType, targetType, interfaces, base.ProxyGenerationOptions);
		}

		protected override void CreateFields(ClassEmitter emitter)
		{
			base.CreateFields(emitter);
			CreateTargetField(emitter);
		}

		protected override CompositeTypeContributor GetProxyTargetContributor(INamingScope namingScope)
		{
			return new ClassProxyWithTargetTargetContributor(targetType, namingScope)
			{
				Logger = base.Logger
			};
		}

		protected override ProxyTargetAccessorContributor GetProxyTargetAccessorContributor()
		{
			return new ProxyTargetAccessorContributor(() => targetField, targetType);
		}

		private void CreateTargetField(ClassEmitter emitter)
		{
			targetField = emitter.CreateField("__target", targetType);
		}
	}
}
