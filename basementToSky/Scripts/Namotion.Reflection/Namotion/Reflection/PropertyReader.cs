using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Namotion.Reflection
{
	internal static class PropertyReader
	{
		private static Type GenericTypeDefinition = typeof(PropertyReader<object, object>).GetGenericTypeDefinition();

		public static IPropertyReader Create(Type objectType, Type valueType, PropertyInfo propertyInfo)
		{
			return (IPropertyReader)Activator.CreateInstance(GenericTypeDefinition.MakeGenericType(objectType, valueType), propertyInfo);
		}
	}
	internal sealed class PropertyReader<TObject, TValue> : IPropertyReader
	{
		private readonly PropertyInfo _propertyInfo;

		private Func<TObject?, TValue?>? _getter;

		public PropertyReader(PropertyInfo propertyInfo)
		{
			_propertyInfo = propertyInfo;
			MethodInfo getMethod = propertyInfo.GetMethod;
			_getter = ((getMethod != null) ? ((Func<TObject, TValue>)Delegate.CreateDelegate(typeof(Func<TObject, TValue>), null, getMethod)) : null);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public TValue? GetValue(TObject? obj)
		{
			if (_getter == null)
			{
				return (TValue)_propertyInfo.GetValue(obj);
			}
			return _getter(obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		object? IPropertyReader.GetValue(object? obj)
		{
			return GetValue((TObject)obj);
		}
	}
}
