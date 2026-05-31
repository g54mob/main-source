using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CTS.Core
{
	internal class Constructor
	{
		private readonly List<(EGetScope, Type)> _parameters;

		public MethodInfo MethodInfo { get; }

		public Constructor(List<(EGetScope, Type)> parameters, MethodInfo methodInfo)
		{
			_parameters = parameters;
			MethodInfo = methodInfo;
		}

		public void Invoke(MonoBehaviour target)
		{
			object[] array = new object[_parameters.Count];
			for (int i = 0; i < array.Length; i++)
			{
				(EGetScope, Type) tuple = _parameters[i];
				EGetScope item = tuple.Item1;
				Type item2 = tuple.Item2;
				bool isArray = item2.IsArray;
				array[i] = ComponentGetter.GetComponent(target, item, isArray ? item2.GetElementType() : item2, isArray);
			}
			MethodInfo.Invoke(target, array);
		}
	}
}
