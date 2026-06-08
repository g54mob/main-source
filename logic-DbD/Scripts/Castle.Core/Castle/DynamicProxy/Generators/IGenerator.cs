using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Generators
{
	internal interface IGenerator<T>
	{
		T Generate(ClassEmitter @class, INamingScope namingScope);
	}
}
