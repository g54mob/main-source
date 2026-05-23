using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Namotion.Reflection
{
	public class ContextualPropertyInfo : ContextualAccessorInfo
	{
		private string? _name;

		private bool? _canWrite;

		private bool? _canRead;

		private IPropertyReader? _propertyReader;

		private IPropertyWriter? _propertyWriter;

		public PropertyInfo PropertyInfo { get; }

		public override ContextualType AccessorType => PropertyType;

		public ContextualType PropertyType { get; private set; }

		public override string Name => _name ?? (_name = PropertyInfo.Name);

		public override MemberInfo MemberInfo => PropertyInfo;

		public bool CanWrite
		{
			get
			{
				bool? canWrite = _canWrite;
				if (!canWrite.HasValue)
				{
					bool? flag = (_canWrite = PropertyInfo.CanWrite);
					return flag.Value;
				}
				return canWrite == true;
			}
		}

		public bool CanRead
		{
			get
			{
				bool? canRead = _canRead;
				if (!canRead.HasValue)
				{
					bool? flag = (_canRead = PropertyInfo.CanRead);
					return flag.Value;
				}
				return canRead == true;
			}
		}

		internal ContextualPropertyInfo(PropertyInfo propertyInfo, ref int nullableFlagsIndex, byte[]? nullableFlags)
		{
			PropertyInfo = propertyInfo;
			NullableFlagsSource[] customAttributeProviders = ((!propertyInfo.DeclaringType.IsNested) ? new NullableFlagsSource[1] { NullableFlagsSource.Create(propertyInfo.DeclaringType, propertyInfo.DeclaringType.GetTypeInfo().Assembly) } : new NullableFlagsSource[2]
			{
				NullableFlagsSource.Create(propertyInfo.DeclaringType),
				NullableFlagsSource.Create(propertyInfo.DeclaringType.DeclaringType, propertyInfo.DeclaringType.GetTypeInfo().Assembly)
			});
			PropertyType = new ContextualType(propertyInfo.PropertyType, propertyInfo.GetCustomAttributes(inherit: true).OfType<Attribute>().ToArray(), null, ref nullableFlagsIndex, nullableFlags, customAttributeProviders);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override object? GetValue(object? obj)
		{
			if (_propertyReader == null)
			{
				lock (this)
				{
					if (_propertyReader == null)
					{
						_propertyReader = PropertyReader.Create(PropertyInfo.DeclaringType, PropertyType.OriginalType, PropertyInfo);
					}
				}
			}
			return _propertyReader.GetValue(obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void SetValue(object? obj, object? value)
		{
			if (_propertyWriter == null)
			{
				lock (this)
				{
					if (_propertyWriter == null)
					{
						_propertyWriter = PropertyWriter.Create(PropertyInfo.DeclaringType, PropertyType.OriginalType, PropertyInfo);
					}
				}
			}
			_propertyWriter.SetValue(obj, value);
		}
	}
}
