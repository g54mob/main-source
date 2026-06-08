using System;
using System.Linq;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public class ParameterProvider : IParameterProvider
	{
		private readonly IInstanceBank _instanceBank;

		private readonly IMultiBindingService _multiBindingService;

		public ParameterProvider(IInstanceBank instanceBank, IMultiBindingService multiBindingService)
		{
			_instanceBank = instanceBank;
			_multiBindingService = multiBindingService;
		}

		public object[] GetParameters(MethodBase method)
		{
			ParameterInfo[] parameters = method.GetParameters();
			object[] array = new object[parameters.Length];
			int num = 0;
			ParameterInfo[] array2 = parameters;
			foreach (ParameterInfo parameterInfo in array2)
			{
				if (TryGetParameter(parameterInfo.ParameterType, out var parameter))
				{
					array[num++] = parameter;
					continue;
				}
				throw new InvalidOperationException("Can't get parameter " + TypeFormatting.Format(parameterInfo.ParameterType) + " of method " + TypeFormatting.Format(method.DeclaringType) + "." + method.Name + ".");
			}
			return array;
		}

		private bool TryGetParameter(Type parameterType, out object parameter)
		{
			if (_multiBindingService.IsMultiBound(parameterType, out var multiBoundType))
			{
				parameter = ReturnMultiBoundParameter(multiBoundType);
				return true;
			}
			return _instanceBank.TryGetInstance(parameterType, out parameter);
		}

		private object ReturnMultiBoundParameter(Type type)
		{
			object[] array = _instanceBank.GetInstances(type).ToArray();
			Array array2 = Array.CreateInstance(type, array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				array2.SetValue(array[i], i);
			}
			return array2;
		}
	}
}
