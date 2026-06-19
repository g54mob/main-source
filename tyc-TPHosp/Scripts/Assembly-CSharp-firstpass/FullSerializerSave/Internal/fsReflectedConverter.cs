using System;
using System.Collections;

namespace FullSerializerSave.Internal
{
	public class fsReflectedConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			if (type.Resolve().IsArray || typeof(ICollection).IsAssignableFrom(type))
			{
				return false;
			}
			return true;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = fsData.CreateDictionary();
			fsResult success = fsResult.Success;
			fsMetaType fsMetaType2 = fsMetaType.Get(Serializer.Config, instance.GetType());
			fsMetaType2.EmitAotData(throwException: false);
			for (int i = 0; i < fsMetaType2.Properties.Length; i++)
			{
				fsMetaProperty fsMetaProperty2 = fsMetaType2.Properties[i];
				if (fsMetaProperty2.CanRead)
				{
					fsData data;
					fsResult fsResult2 = Serializer.TrySerialize(fsMetaProperty2.StorageType, fsMetaProperty2.OverrideConverterType, fsMetaProperty2.Read(instance), out data);
					success += fsResult2;
					if (fsResult2.HasWarnings)
					{
						success.AddMessage("Warnings found in member: " + instance.GetType().Name + "." + fsMetaProperty2.MemberName);
					}
					if (!fsResult2.Failed)
					{
						serialized.AsDictionary[fsMetaProperty2.JsonName] = data;
					}
				}
			}
			return success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult success = fsResult.Success;
			fsResult fsResult2 = (success += CheckType(data, fsDataType.Object));
			if (fsResult2.Failed)
			{
				return success;
			}
			fsMetaType fsMetaType2 = fsMetaType.Get(Serializer.Config, storageType);
			fsMetaType2.EmitAotData(throwException: false);
			for (int i = 0; i < fsMetaType2.Properties.Length; i++)
			{
				fsMetaProperty fsMetaProperty2 = fsMetaType2.Properties[i];
				if (!fsMetaProperty2.CanWrite || !data.AsDictionary.TryGetValue(fsMetaProperty2.JsonName, out var value))
				{
					continue;
				}
				object result = null;
				if (fsMetaProperty2.CanRead)
				{
					result = fsMetaProperty2.Read(instance);
				}
				fsResult fsResult3 = Serializer.TryDeserialize(value, fsMetaProperty2.StorageType, fsMetaProperty2.OverrideConverterType, ref result);
				success += fsResult3;
				if (!fsResult3.Failed)
				{
					try
					{
						fsMetaProperty2.Write(instance, result);
					}
					catch (Exception ex)
					{
						success += fsResult.Fail($"Couldn't write value to property: {storageType.FullName}.{fsMetaProperty2.MemberName}. Value: {value}. Exception: {ex}");
					}
				}
			}
			return success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(Serializer.Config, storageType).CreateInstance();
		}
	}
}
