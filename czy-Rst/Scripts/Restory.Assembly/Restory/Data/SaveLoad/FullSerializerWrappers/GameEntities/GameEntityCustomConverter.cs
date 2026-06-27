using System;
using System.Collections.Generic;
using FullSerializer;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.GameEntities;
using UnityEngine;
using Zenject;

namespace Restory.Data.SaveLoad.FullSerializerWrappers.GameEntities
{
	public class GameEntityCustomConverter : fsConverter
	{
		public class Factory : PlaceholderFactory<GameEntityCustomConverter>
		{
		}

		private GameEntityDataBaseProvider dataBaseProvider;

		private const string ITEM_OBJECT_ID = "ItemObjectID";

		public override bool CanProcess(Type type)
		{
			Type typeFromHandle = typeof(RestoryEntityInfoBase);
			if (!type.IsSubclassOf(typeFromHandle))
			{
				return typeFromHandle.IsAssignableFrom(type);
			}
			return true;
		}

		[Inject]
		private void Construct(GameEntityDataBaseProvider dataBaseProvider)
		{
			this.dataBaseProvider = dataBaseProvider;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
			string iD = (instance as RestoryEntityInfoBase).ID;
			dictionary.Add("ItemObjectID", new fsData(iD));
			serialized = new fsData(dictionary);
			return fsResult.Success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (data.AsDictionary.TryGetValue("ItemObjectID", out var value))
			{
				GameEntityDataBase asset = dataBaseProvider.Asset;
				string asString = value.AsString;
				if (asset.TryGetValue(asString, out var gameEntity))
				{
					instance = gameEntity;
				}
				else
				{
					Debug.LogError("[GameEntityCustomConverter] can't find GameEntity with ID: " + asString);
				}
			}
			return fsResult.Success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			if (data.AsDictionary.TryGetValue("ItemObjectID", out var value))
			{
				GameEntityDataBase asset = dataBaseProvider.Asset;
				string asString = value.AsString;
				return asset[asString];
			}
			throw new Exception("GameEntityCustomConverter must create any instance!");
		}

		public override bool RequestCycleSupport(Type storageType)
		{
			return true;
		}
	}
}
