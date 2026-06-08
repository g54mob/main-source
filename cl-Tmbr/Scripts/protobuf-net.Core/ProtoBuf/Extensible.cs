using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	public abstract class Extensible : ITypedExtensible, IExtensible
	{
		private IExtension extensionObject;

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return GetExtensionObject(createIfMissing);
		}

		IExtension ITypedExtensible.GetExtensionObject(Type type, bool createIfMissing)
		{
			if ((object)type != GetType())
			{
				return GetExtensionObject(ref extensionObject, type, createIfMissing);
			}
			return GetExtensionObject(createIfMissing);
		}

		[Obsolete("This API is considered, and may no longer be used in all scenarios (in particular when inheritance is involved); it is not recommended to rely on this API")]
		protected virtual IExtension GetExtensionObject(bool createIfMissing)
		{
			return GetExtensionObject(ref extensionObject, GetType(), createIfMissing);
		}

		public static IExtension GetExtensionObject(ref IExtension extensionObject, Type type, bool createIfMissing)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException("type");
			}
			BufferExtension bufferExtension = extensionObject as BufferExtension;
			BufferExtension bufferExtension2 = bufferExtension;
			if (bufferExtension == null)
			{
				if (extensionObject != null)
				{
					ThrowHelper.ThrowNotSupportedException("Custom extension implementations should not be passed to GetExtensionObject");
				}
			}
			else
			{
				while (bufferExtension2 != null)
				{
					Type type2 = bufferExtension2.Type;
					if ((object)type2 == null)
					{
						ThrowHelper.ThrowInvalidOperationException("Typed and untyped extension data cannot be mixed");
					}
					if ((object)type2 == type)
					{
						return bufferExtension2;
					}
					bufferExtension2 = bufferExtension2.Tail;
				}
			}
			if (createIfMissing)
			{
				BufferExtension bufferExtension3 = new BufferExtension();
				bufferExtension3.SetTail(type, bufferExtension);
				bufferExtension2 = (BufferExtension)(extensionObject = bufferExtension3);
			}
			return bufferExtension2;
		}

		public static IExtension GetExtensionObject(ref IExtension extensionObject, bool createIfMissing)
		{
			if (extensionObject == null)
			{
				if (createIfMissing)
				{
					extensionObject = new BufferExtension();
				}
			}
			else if (extensionObject is BufferExtension { Type: not null })
			{
				ThrowHelper.ThrowInvalidOperationException("Typed and untyped extension data cannot be mixed");
			}
			return extensionObject;
		}

		public static void AppendValue<TValue>(IExtensible instance, int tag, TValue value)
		{
			ExtensibleUtil.AppendExtendValue(null, instance, tag, DataFormat.Default, value);
		}

		public static void AppendValue<TValue>(IExtensible instance, int tag, DataFormat format, TValue value)
		{
			ExtensibleUtil.AppendExtendValue(null, instance, tag, format, value);
		}

		public static void AppendValue<TValue>(TypeModel model, IExtensible instance, int tag, TValue value, DataFormat format = DataFormat.Default)
		{
			ExtensibleUtil.AppendExtendValue(model, instance, tag, format, value);
		}

		public static TValue GetValue<TValue>(IExtensible instance, int tag)
		{
			return GetValue<TValue>(null, instance, tag);
		}

		public static TValue GetValue<TValue>(IExtensible instance, int tag, DataFormat format)
		{
			return GetValue<TValue>(null, instance, tag, format);
		}

		public static TValue GetValue<TValue>(TypeModel model, IExtensible instance, int tag, DataFormat format = DataFormat.Default)
		{
			if (!TryGetValue<TValue>(model, instance, tag, out var value, format))
			{
				return default(TValue);
			}
			return value;
		}

		public static bool TryGetValue<TValue>(IExtensible instance, int tag, out TValue value)
		{
			return TryGetValue<TValue>(null, instance, tag, out value);
		}

		public static bool TryGetValue<TValue>(IExtensible instance, int tag, DataFormat format, out TValue value)
		{
			return TryGetValue<TValue>(null, instance, tag, out value, format);
		}

		public static bool TryGetValue<TValue>(IExtensible instance, int tag, DataFormat format, bool allowDefinedTag, out TValue value)
		{
			return TryGetValue<TValue>(null, instance, tag, out value, format, allowDefinedTag);
		}

		public static bool TryGetValue<TValue>(TypeModel model, IExtensible instance, int tag, out TValue value, DataFormat format = DataFormat.Default, bool allowDefinedTag = false)
		{
			value = default(TValue);
			bool result = false;
			foreach (TValue extendedValue in ExtensibleUtil.GetExtendedValues<TValue>(model, instance, tag, format, singleton: true, allowDefinedTag))
			{
				value = extendedValue;
				result = true;
			}
			return result;
		}

		public static IEnumerable<TValue> GetValues<TValue>(IExtensible instance, int tag)
		{
			return ExtensibleUtil.GetExtendedValues<TValue>(null, instance, tag, DataFormat.Default, singleton: false, allowDefinedTag: false);
		}

		public static IEnumerable<TValue> GetValues<TValue>(IExtensible instance, int tag, DataFormat format)
		{
			return ExtensibleUtil.GetExtendedValues<TValue>(null, instance, tag, format, singleton: false, allowDefinedTag: false);
		}

		public static IEnumerable<TValue> GetValues<TValue>(TypeModel model, IExtensible instance, int tag, DataFormat format = DataFormat.Default)
		{
			return ExtensibleUtil.GetExtendedValues<TValue>(model, instance, tag, format, singleton: false, allowDefinedTag: false);
		}

		public static bool TryGetValue(TypeModel model, Type type, IExtensible instance, int tag, DataFormat format, bool allowDefinedTag, out object value)
		{
			value = null;
			bool result = false;
			foreach (object extendedValue in ExtensibleUtil.GetExtendedValues(model, type, instance, tag, format, singleton: true, allowDefinedTag))
			{
				value = extendedValue;
				result = true;
			}
			return result;
		}

		public static IEnumerable GetValues(TypeModel model, Type type, IExtensible instance, int tag, DataFormat format = DataFormat.Default)
		{
			return ExtensibleUtil.GetExtendedValues(model, type, instance, tag, format, singleton: false, allowDefinedTag: false);
		}

		public static void AppendValue(TypeModel model, IExtensible instance, int tag, DataFormat format, object value)
		{
			ExtensibleUtil.AppendExtendValue(model, instance, tag, format, value);
		}
	}
}
