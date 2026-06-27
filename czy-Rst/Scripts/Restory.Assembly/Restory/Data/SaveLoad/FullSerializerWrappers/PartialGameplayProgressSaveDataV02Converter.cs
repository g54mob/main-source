using System;
using System.Collections.Generic;
using FullSerializer;
using Restory.Data.Locations;
using Restory.Data.SaveLoad.Containers;

namespace Restory.Data.SaveLoad.FullSerializerWrappers
{
	public class PartialGameplayProgressSaveDataV02Converter : fsConverter
	{
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			throw new NotImplementedException();
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			Dictionary<string, fsData> asDictionary = data.AsDictionary;
			object result = new object();
			if (Serializer.TryDeserialize(asDictionary["ActivePreset"], typeof(GameScenesPreset), ref result).Succeeded)
			{
				((GameplayProgressSaveData)instance).ActivePreset = (GameScenesPreset)result;
				return fsResult.Success;
			}
			return fsResult.Fail("");
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return new GameplayProgressSaveData();
		}

		public override bool CanProcess(Type type)
		{
			Type typeFromHandle = typeof(GameplayProgressSaveData);
			if (!type.IsSubclassOf(typeFromHandle))
			{
				return typeFromHandle.IsAssignableFrom(type);
			}
			return true;
		}
	}
}
