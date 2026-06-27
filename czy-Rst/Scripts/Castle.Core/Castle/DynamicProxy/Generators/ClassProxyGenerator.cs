using System;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators
{
	internal sealed class ClassProxyGenerator : BaseClassProxyGenerator
	{
		protected override FieldReference TargetField => null;

		public ClassProxyGenerator(ModuleScope scope, Type targetType, Type[] interfaces, ProxyGenerationOptions options)
			: base(scope, targetType, interfaces, options)
		{
		}

		protected override CacheKey GetCacheKey()
		{
			return new CacheKey(targetType, interfaces, base.ProxyGenerationOptions);
		}

		protected override CompositeTypeContributor GetProxyTargetContributor(INamingScope namingScope)
		{
			return new ClassProxyTargetContributor(targetType, namingScope)
			{
				Logger = base.Logger
			};
		}

		protected override ProxyTargetAccessorContributor GetProxyTargetAccessorContributor()
		{
			return new ProxyTargetAccessorContributor(() => SelfReference.Self, targetType);
		}
	}
}
