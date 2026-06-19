using System;
using System.Collections;
using System.Collections.Generic;

namespace FullSerializer.Internal
{
	public class fs2DArrayConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			if (type.IsArray)
			{
				return type.GetArrayRank() == 2;
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
			Array array = (Array)instance;
			IList list = array;
			Type elementType = storageType.GetElementType();
			fsResult success = fsResult.Success;
			serialized = fsData.CreateDictionary();
			Dictionary<string, fsData> asDictionary = serialized.AsDictionary;
			fsData fsData2 = fsData.CreateList(list.Count);
			asDictionary.Add("c", new fsData(array.GetLength(1)));
			asDictionary.Add("r", new fsData(array.GetLength(0)));
			asDictionary.Add("a", fsData2);
			List<fsData> asList = fsData2.AsList;
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					object value = array.GetValue(i, j);
					fsData data;
					fsResult fsResult2 = Serializer.TrySerialize(elementType, null, value, out data);
					success += fsResult2;
					if (!fsResult2.Failed)
					{
						asList.Add(data);
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
			Type elementType = storageType.GetElementType();
			Dictionary<string, fsData> asDictionary = data.AsDictionary;
			if ((success += DeserializeMember<int>(asDictionary, null, "c", out var value)).Failed)
			{
				return success;
			}
			if ((success += DeserializeMember<int>(asDictionary, null, "r", out var value2)).Failed)
			{
				return success;
			}
			if (!asDictionary.TryGetValue("a", out var value3))
			{
				return success + fsResult.Fail("Failed to get flattened list");
			}
			if ((success += CheckType(value3, fsDataType.Array)).Failed)
			{
				return success;
			}
			Array array = Array.CreateInstance(elementType, value2, value);
			List<fsData> asList = value3.AsList;
			if (value * value2 > asList.Count)
			{
				success.AddMessage("Serialised list has more items than can fit in multidimensional array");
			}
			for (int i = 0; i < value2; i++)
			{
				for (int j = 0; j < value; j++)
				{
					fsData data2 = asList[j + i * value];
					object result = null;
					fsResult fsResult3 = Serializer.TryDeserialize(data2, elementType, null, ref result);
					success += fsResult3;
					array.SetValue(result, i, j);
				}
			}
			instance = array;
			return success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(Serializer.Config, storageType).CreateInstance();
		}
	}
}
