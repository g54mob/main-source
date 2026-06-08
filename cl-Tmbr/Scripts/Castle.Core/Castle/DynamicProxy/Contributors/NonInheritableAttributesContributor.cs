using System;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	internal sealed class NonInheritableAttributesContributor : ITypeContributor
	{
		private readonly Type targetType;

		public NonInheritableAttributesContributor(Type targetType)
		{
			this.targetType = targetType;
		}

		public void Generate(ClassEmitter emitter)
		{
			foreach (CustomAttributeInfo nonInheritableAttribute in targetType.GetNonInheritableAttributes())
			{
				emitter.DefineCustomAttribute(nonInheritableAttribute.Builder);
			}
		}

		public void CollectElementsToProxy(IProxyGenerationHook hook, MetaType model)
		{
		}
	}
}
