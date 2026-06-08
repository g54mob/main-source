using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	public static class TypedExtensible
	{
		public static bool TryGetValue<TValue>(this ITypedExtensible instance, int tag, out TValue value, Type type = null, DataFormat format = DataFormat.Default, TypeModel model = null)
		{
			IExtension extension = GetExtension(instance, type, createIfMissing: false, ref model);
			value = default(TValue);
			bool result = false;
			if (extension != null)
			{
				foreach (TValue extendedValue in ExtensibleUtil.GetExtendedValues(model, typeof(TValue), extension, tag, format, singleton: true))
				{
					value = extendedValue;
					result = true;
				}
			}
			return result;
		}

		public static TValue GetValue<TValue>(this ITypedExtensible instance, int tag, Type type = null, DataFormat format = DataFormat.Default, TypeModel model = null)
		{
			if (!instance.TryGetValue<TValue>(tag, out var value, type, format, model))
			{
				return default(TValue);
			}
			return value;
		}

		public static IEnumerable<TValue> GetValues<TValue>(this ITypedExtensible instance, int tag, Type type = null, DataFormat format = DataFormat.Default, TypeModel model = null)
		{
			IExtension extension = GetExtension(instance, type, createIfMissing: false, ref model);
			if (extension != null)
			{
				return ExtensibleUtil.GetExtendedValues(model, typeof(TValue), extension, tag, format, singleton: false).Cast<TValue>();
			}
			return Enumerable.Empty<TValue>();
		}

		public static void AppendValue<TValue>(this ITypedExtensible instance, int tag, TValue value, Type type = null, DataFormat format = DataFormat.Default, TypeModel model = null)
		{
			object obj = value;
			if (obj == null)
			{
				ThrowHelper.ThrowArgumentNullException("value");
			}
			ExtensibleUtil.AppendExtendValue(model, GetExtension(instance, type, createIfMissing: true, ref model), tag, format, obj);
		}

		private static IExtension GetExtension(ITypedExtensible instance, Type type, bool createIfMissing, ref TypeModel model)
		{
			if (instance == null)
			{
				ThrowHelper.ThrowArgumentNullException("instance");
			}
			Type type2 = instance.GetType();
			if ((object)type == null)
			{
				type = type2;
			}
			if (!type.IsClass)
			{
				ThrowHelper.ThrowNotSupportedException("Extension fields can only be used with class target types ('" + type.NormalizeName() + "' is not valid)");
			}
			if ((object)type != type2)
			{
				if (model == null)
				{
					model = TypeModel.DefaultModel;
				}
				if (type == typeof(object) || type == typeof(Extensible) || !type.IsAssignableFrom(type2) || (!(model is TypeModel.NullModel) && !model.CanSerializeContractType(type)))
				{
					ThrowHelper.ThrowInvalidOperationException("The extension field target type '" + type.NormalizeName() + "' is not a valid base-type of '" + type2.NormalizeName() + "'");
				}
			}
			return instance.GetExtensionObject(type, createIfMissing);
		}
	}
}
