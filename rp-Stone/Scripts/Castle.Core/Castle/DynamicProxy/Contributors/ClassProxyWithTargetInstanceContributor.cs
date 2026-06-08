using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	internal class ClassProxyWithTargetInstanceContributor : ClassProxyInstanceContributor
	{
		public ClassProxyWithTargetInstanceContributor(Type targetType, IList<MethodInfo> methodsToSkip, Type[] interfaces, string typeId)
			: base(targetType, methodsToSkip, interfaces, typeId)
		{
		}

		protected override Reference GetTargetReference(ClassEmitter emitter)
		{
			return emitter.GetField("__target");
		}
	}
}
