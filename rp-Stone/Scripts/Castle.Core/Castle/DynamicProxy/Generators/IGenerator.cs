using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Generators
{
	public interface IGenerator<T>
	{
		T Generate(ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope);
	}
}
