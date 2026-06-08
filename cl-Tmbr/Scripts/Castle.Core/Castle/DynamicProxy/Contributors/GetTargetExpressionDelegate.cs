using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	internal delegate IExpression GetTargetExpressionDelegate(ClassEmitter @class, MethodInfo method);
}
