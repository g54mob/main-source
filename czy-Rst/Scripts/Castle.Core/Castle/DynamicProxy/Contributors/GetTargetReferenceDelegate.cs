using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	internal delegate Reference GetTargetReferenceDelegate(ClassEmitter @class, MethodInfo method);
}
