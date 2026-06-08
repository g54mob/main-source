using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	internal static class ExtensibleUtil
	{
		internal static IEnumerable<TValue> GetExtendedValues<TValue>(TypeModel model, IExtensible instance, int tag, DataFormat format, bool singleton, bool allowDefinedTag)
		{
			foreach (TValue extendedValue in GetExtendedValues(model, typeof(TValue), instance, tag, format, singleton, allowDefinedTag))
			{
				yield return extendedValue;
			}
		}

		internal static IEnumerable GetExtendedValues(TypeModel model, Type type, IExtensible instance, int tag, DataFormat format, bool singleton, bool allowDefinedTag)
		{
			if (instance == null)
			{
				ThrowHelper.ThrowArgumentNullException("instance");
			}
			if (tag <= 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException("tag");
			}
			return GetExtendedValues(model, type, instance.GetExtensionObject(createIfMissing: false), tag, format, singleton);
		}

		internal static IEnumerable GetExtendedValues(TypeModel model, Type type, IExtension extn, int tag, DataFormat format, bool singleton)
		{
			if (model == null)
			{
				model = TypeModel.DefaultModel;
			}
			if (extn == null)
			{
				yield break;
			}
			Stream stream = extn.BeginQuery();
			try
			{
				object value = null;
				SerializationContext userState = new SerializationContext();
				ProtoReader.SolidState state = ProtoReader.State.Create(stream, model, userState, -1L).Solidify();
				try
				{
					while (model.TryDeserializeAuxiliaryType(ref state, format, tag, type, ref value, skipOtherFields: true, asListItem: true, autoCreate: false, insideList: false, null, isRoot: false) && value != null)
					{
						if (!singleton)
						{
							yield return value;
							value = null;
						}
					}
					if (singleton && value != null)
					{
						yield return value;
					}
				}
				finally
				{
					state.Dispose();
				}
			}
			finally
			{
				extn.EndQuery(stream);
			}
		}

		internal static void AppendExtendValue(TypeModel model, IExtensible instance, int tag, DataFormat format, object value)
		{
			if (instance == null)
			{
				ThrowHelper.ThrowArgumentNullException("instance");
			}
			if (value == null)
			{
				ThrowHelper.ThrowArgumentNullException("value");
			}
			AppendExtendValue(model, instance.GetExtensionObject(createIfMissing: true), tag, format, value);
		}

		internal static void AppendExtendValue(TypeModel model, IExtension extn, int tag, DataFormat format, object value)
		{
			if (model == null)
			{
				model = TypeModel.DefaultModel;
			}
			if (extn == null)
			{
				ThrowHelper.ThrowInvalidOperationException("No extension object available; appended data would be lost.");
			}
			bool commit = false;
			Stream stream = extn.BeginAppend();
			try
			{
				ProtoWriter.State state = ProtoWriter.State.Create(stream, model);
				try
				{
					model.TrySerializeAuxiliaryType(ref state, null, format, tag, value, isInsideList: false, null, isRoot: false);
					state.Close();
				}
				catch
				{
					state.Abandon();
					throw;
				}
				finally
				{
					state.Dispose();
				}
				commit = true;
			}
			finally
			{
				extn.EndAppend(stream, commit);
			}
		}
	}
}
