using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Contributors
{
	internal interface ITypeContributor
	{
		void CollectElementsToProxy(IProxyGenerationHook hook, MetaType model);

		void Generate(ClassEmitter @class);
	}
}
