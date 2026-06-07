using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Namotion.Reflection
{
	internal static class PropertyWriter
	{
		private static Type GenericTypeDefinition = typeof(PropertyWriter<object, object>).GetGenericTypeDefinition();

		public static IPropertyWriter Create(Type objectType, Type valueType, PropertyInfo propertyInfo)
		{
			return (IPropertyWriter)Activator.CreateInstance(GenericTypeDefinition.MakeGenericType(objectType, valueType), propertyInfo);
		}
	}
	internal sealed class PropertyWriter<TObject, TValue> : IPropertyWriter
	{
		private readonly PropertyInfo _propertyInfo;

		private Action<TObject?, TValue?>? _setter;

		public PropertyWriter(PropertyInfo propertyInfo)
		{
			_propertyInfo = propertyInfo;
			MethodInfo setMethod = propertyInfo.SetMethod;
			_setter = ((setMethod != null) ? ((Action<TObject, TValue>)Delegate.CreateDelegate(typeof(Action<TObject, TValue>), null, setMethod)) : null);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetValue(TObject? obj, TValue? value)
		{
			if (_setter != null)
			{
				_setter(obj, value);
			}
			else
			{
				_propertyInfo.SetValue(obj, value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		void IPropertyWriter.SetValue(object? obj, object? value)
		{
			SetValue((TObject)obj, (TValue)value);
		}
	}
}
