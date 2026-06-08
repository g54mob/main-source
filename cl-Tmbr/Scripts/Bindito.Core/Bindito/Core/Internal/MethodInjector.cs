using System;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public class MethodInjector : IMethodInjector
	{
		private readonly IParameterProvider _parameterProvider;

		private readonly IMethodRetriever _methodRetriever;

		private readonly IInjectionListenerNotifier _injectionListenerNotifier;

		public MethodInjector(IParameterProvider parameterProvider, IMethodRetriever methodRetriever, IInjectionListenerNotifier injectionListenerNotifier)
		{
			_parameterProvider = parameterProvider;
			_methodRetriever = methodRetriever;
			_injectionListenerNotifier = injectionListenerNotifier;
		}

		public void Inject(object injectee)
		{
			Type type = injectee.GetType();
			foreach (MethodInfo injectedMethod in _methodRetriever.GetInjectedMethods(type))
			{
				InjectMethod(injectee, injectedMethod);
			}
			_injectionListenerNotifier.NotifyAllListeners(injectee);
		}

		private void InjectMethod(object injectee, MethodBase method)
		{
			object[] parameters = _parameterProvider.GetParameters(method);
			method.Invoke(injectee, parameters);
		}
	}
}
