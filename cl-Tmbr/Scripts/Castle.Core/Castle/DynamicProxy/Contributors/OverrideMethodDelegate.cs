using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Contributors
{
	internal delegate MethodEmitter OverrideMethodDelegate(string name, MethodAttributes attributes, MethodInfo methodToOverride);
}
