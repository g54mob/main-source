using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NSubstitute.Routing.AutoValues
{
	public class AutoTaskProvider : IAutoValueProvider
	{
		private readonly Lazy<IReadOnlyCollection<IAutoValueProvider>> _autoValueProviders;

		public AutoTaskProvider(Lazy<IReadOnlyCollection<IAutoValueProvider>> autoValueProviders)
		{
			_autoValueProviders = autoValueProviders;
		}

		public bool CanProvideValueFor(Type type)
		{
			return typeof(Task).IsAssignableFrom(type);
		}

		public object GetValue(Type type)
		{
			if (!CanProvideValueFor(type))
			{
				throw new InvalidOperationException();
			}
			if (type.GetTypeInfo().IsGenericType)
			{
				Type taskType = type.GetGenericArguments()[0];
				IAutoValueProvider autoValueProvider = _autoValueProviders.Value.FirstOrDefault((IAutoValueProvider vp) => vp.CanProvideValueFor(taskType));
				object obj = ((autoValueProvider == null) ? GetDefault(type) : autoValueProvider.GetValue(taskType));
				Type type2 = typeof(TaskCompletionSource<>).MakeGenericType(taskType);
				object obj2 = Activator.CreateInstance(type2);
				type2.GetMethod("SetResult").Invoke(obj2, new object[1] { obj });
				return type2.GetProperty("Task").GetValue(obj2, null);
			}
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			taskCompletionSource.SetResult(null);
			return taskCompletionSource.Task;
		}

		private static object? GetDefault(Type type)
		{
			if (!type.GetTypeInfo().IsValueType)
			{
				return null;
			}
			return Activator.CreateInstance(type);
		}
	}
}
