using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Moq.Async;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class LookupOrFallbackDefaultValueProvider : DefaultValueProvider
	{
		private Dictionary<object, Func<Type, Mock, object>> factories;

		protected LookupOrFallbackDefaultValueProvider()
		{
			factories = new Dictionary<object, Func<Type, Mock, object>>
			{
				["System.ValueTuple`1"] = CreateValueTupleOf,
				["System.ValueTuple`2"] = CreateValueTupleOf,
				["System.ValueTuple`3"] = CreateValueTupleOf,
				["System.ValueTuple`4"] = CreateValueTupleOf,
				["System.ValueTuple`5"] = CreateValueTupleOf,
				["System.ValueTuple`6"] = CreateValueTupleOf,
				["System.ValueTuple`7"] = CreateValueTupleOf,
				["System.ValueTuple`8"] = CreateValueTupleOf
			};
		}

		protected void Deregister(Type factoryKey)
		{
			factories[factoryKey] = null;
			factories[factoryKey.FullName] = null;
		}

		protected void Register(Type factoryKey, Func<Type, Mock, object> factory)
		{
			factories[factoryKey] = factory;
		}

		protected internal sealed override object GetDefaultParameterValue(ParameterInfo parameter, Mock mock)
		{
			return GetDefaultValue(parameter.ParameterType, mock);
		}

		protected internal sealed override object GetDefaultReturnValue(MethodInfo method, Mock mock)
		{
			return GetDefaultValue(method.ReturnType, mock);
		}

		protected internal sealed override object GetDefaultValue(Type type, Mock mock)
		{
			Type type2 = (type.IsGenericType ? type.GetGenericTypeDefinition() : (type.IsArray ? typeof(Array) : type));
			if (factories.TryGetValue(type2, out Func<Type, Mock, object> value) || factories.TryGetValue(type2.FullName, out value))
			{
				if (value != null)
				{
					return value(type, mock);
				}
			}
			else
			{
				IAwaitableFactory awaitableFactory = AwaitableFactory.TryGet(type);
				if (awaitableFactory != null)
				{
					Type resultType = awaitableFactory.ResultType;
					object result = ((resultType != typeof(void)) ? GetDefaultValue(resultType, mock) : null);
					return awaitableFactory.CreateCompleted(result);
				}
			}
			return GetFallbackDefaultValue(type, mock);
		}

		protected virtual object GetFallbackDefaultValue(Type type, Mock mock)
		{
			return type.GetDefaultValue();
		}

		private object CreateValueTupleOf(Type type, Mock mock)
		{
			Type[] genericArguments = type.GetGenericArguments();
			object[] array = new object[genericArguments.Length];
			int i = 0;
			for (int num = genericArguments.Length; i < num; i++)
			{
				array[i] = GetDefaultValue(genericArguments[i], mock);
			}
			return Activator.CreateInstance(type, array);
		}
	}
}
