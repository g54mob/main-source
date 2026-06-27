using System;
using FullSerializer;
using Restory.Data.Locations;
using Zenject;

namespace Restory.Data.SaveLoad.FullSerializerWrappers.GameScenesPresets
{
	public class GameScenesPresetProcessor : fsObjectProcessor
	{
		public class Factory : PlaceholderFactory<GameScenesPresetProcessor>
		{
		}

		public override bool CanProcess(Type type)
		{
			Type typeFromHandle = typeof(GameScenesPreset);
			if (!type.IsSubclassOf(typeFromHandle))
			{
				return typeFromHandle.IsAssignableFrom(type);
			}
			return true;
		}

		public override void OnBeforeSerialize(Type storageType, object instance)
		{
		}

		public override void OnAfterDeserialize(Type storageType, object instance)
		{
		}

		public override void OnAfterSerialize(Type storageType, object instance, ref fsData data)
		{
		}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		public override void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data)
		{
		}
	}
}
