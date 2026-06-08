using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public interface IMethodRetriever
	{
		IEnumerable<MethodInfo> GetInjectedMethods(Type type);
	}
}
