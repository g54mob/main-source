using System;
using System.Collections.Generic;
using FullSerializer;
using Restory.Data.Locations;
using UnityEngine;
using Zenject;

namespace Restory.Data.SaveLoad.FullSerializerWrappers.GameScenesPresets
{
	public class GameScenesPresetCustomConverter : fsConverter
	{
		public class Factory : PlaceholderFactory<GameScenesPresetCustomConverter>
		{
		}

		private GameScenesPresetDataBase dataBase;

		private const string ITEM_OBJECT_ID = "ItemObjectID";

		public override bool CanProcess(Type type)
		{
			Type typeFromHandle = typeof(GameScenesPreset);
			if (!type.IsSubclassOf(typeFromHandle))
			{
				return typeFromHandle.IsAssignableFrom(type);
			}
			return true;
		}

		[Inject]
		private void Construct(GameScenesPresetDataBase dataBase)
		{
			this.dataBase = dataBase;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
			string iD = (instance as GameScenesPreset).ID;
			dictionary.Add("ItemObjectID", new fsData(iD));
			serialized = new fsData(dictionary);
			return fsResult.Success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (data.AsDictionary.TryGetValue("ItemObjectID", out var value))
			{
				string asString = value.AsString;
				if (dataBase.TryGetValue(asString, out var gameEntity))
				{
					instance = gameEntity;
				}
				else
				{
					Debug.LogError("[GameScenesPresetCustomConverter] can't find GameEntity with ID: " + asString);
				}
			}
			return fsResult.Success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			if (data.AsDictionary.TryGetValue("ItemObjectID", out var value))
			{
				string asString = value.AsString;
				return dataBase[asString];
			}
			throw new Exception("GameScenesPresetCustomConverter must create any instance!");
		}

		public override bool RequestCycleSupport(Type storageType)
		{
			return true;
		}
	}
}
