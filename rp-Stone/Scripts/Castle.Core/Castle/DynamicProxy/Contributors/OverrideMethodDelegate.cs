using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Contributors
{
	public delegate MethodEmitter OverrideMethodDelegate(string name, MethodAttributes attributes, MethodInfo methodToOverride);
}
