using System;
using System.Collections;
using System.Collections.Generic;

namespace FullSerializer.Internal
{
	public class fsArrayConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			if (type.IsArray)
			{
				return type.GetArrayRank() == 1;
			}
			return false;
		}

		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			IList list = (Array)instance;
			Type elementType = storageType.GetElementType();
			fsResult success = fsResult.Success;
			serialized = fsData.CreateList(list.Count);
			List<fsData> asList = serialized.AsList;
			for (int i = 0; i < list.Count; i++)
			{
				object instance2 = list[i];
				fsData data;
				fsResult fsResult2 = Serializer.TrySerialize(elementType, null, instance2, out data);
				success += fsResult2;
				if (!fsResult2.Failed)
				{
					asList.Add(data);
				}
			}
			return success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult success = fsResult.Success;
			fsResult fsResult2 = (success += CheckType(data, fsDataType.Array));
			if (fsResult2.Failed)
			{
				return success;
			}
			Type elementType = storageType.GetElementType();
			List<fsData> asList = data.AsList;
			ArrayList arrayList = new ArrayList(asList.Count);
			_ = arrayList.Count;
			for (int i = 0; i < asList.Count; i++)
			{
				fsData data2 = asList[i];
				object result = null;
				fsResult fsResult3 = Serializer.TryDeserialize(data2, elementType, null, ref result);
				success += fsResult3;
				arrayList.Add(result);
			}
			try
			{
				instance = arrayList.ToArray(elementType);
			}
			catch (InvalidCastException arg)
			{
				success += fsResult.Fail($"Failed to convert list to array because they have incompatible types. Element type: {elementType.FullName}. Serialized elemept type: {asList[0].Type}, Exception: {arg}");
			}
			catch (Exception arg2)
			{
				success += fsResult.Fail($"Failed to convert list to array. Exception: {arg2}");
			}
			return success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(Serializer.Config, storageType).CreateInstance();
		}
	}
}
