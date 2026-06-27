using System;
using System.Linq;
using FullSerializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Restory.AssetManagement;
using Restory.Data.EntityMigrations;
using Zenject;

namespace Restory.Data.SaveLoad.FullSerializerWrappers
{
	public class GameplayProgressSaveDataProcessor : fsObjectProcessor
	{
		public class Factory : PlaceholderFactory<GameplayProgressSaveDataProcessor>
		{
		}

		private readonly Type[] supportedTypes = new Type[0];

		private GameEntityDataBaseProvider dataBaseProvider;

		private GameplayDataMigrationScheme[] gameplayDataMigrationSchemes;

		public override bool CanProcess(Type type)
		{
			Type[] array = supportedTypes;
			foreach (Type type2 in array)
			{
				if (type2 == type || type.IsSubclassOf(type2) || type2.IsAssignableFrom(type))
				{
					return true;
				}
			}
			return false;
		}

		[Inject]
		private void Construct(GameEntityDataBaseProvider dataBaseProvider, [Inject(Optional = true)] GameplayDataMigrationScheme[] gameplayDataMigrationSchemes)
		{
			this.dataBaseProvider = dataBaseProvider;
			this.gameplayDataMigrationSchemes = gameplayDataMigrationSchemes;
		}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
			string name = storageType.Name;
			JObject jObject = JObject.Parse(data.ToString());
			GameEntityMigration(name, jObject);
			CommonMigration(name, jObject);
			fsJsonParser.Parse(jObject.ToString(Formatting.None), out data);
		}

		private void CommonMigration(string storageTypeName, JObject jsonObject)
		{
			GameplayDataMigrationScheme[] array = gameplayDataMigrationSchemes;
			foreach (GameplayDataMigrationScheme gameplayDataMigrationScheme in array)
			{
				if (!gameplayDataMigrationScheme.OriginalTypeNames.Contains(storageTypeName))
				{
					continue;
				}
				GameplayDataMigrationScheme.Entry[] entries = gameplayDataMigrationScheme.Entries;
				foreach (GameplayDataMigrationScheme.Entry entry in entries)
				{
					JToken jToken = FindTokenByValue(jsonObject, "ID", entry.JsonParentContainerName);
					if (jToken != null)
					{
						JContainer parent = jToken.Parent.Parent;
						RemoveIdsFromContainer(parent, entry.RemoveByIdentificatorRules);
					}
				}
			}
		}

		private static JToken FindTokenByValue(JToken token, string propertyName, string targetName)
		{
			if (token.Type == JTokenType.Object)
			{
				foreach (JProperty item in token.Children<JProperty>())
				{
					if (item.Name == propertyName && item.Value.ToString() == targetName)
					{
						return item.Parent;
					}
					JToken jToken = FindTokenByValue(item.Value, propertyName, targetName);
					if (jToken != null)
					{
						return jToken;
					}
				}
			}
			else if (token.Type == JTokenType.Array)
			{
				foreach (JToken item2 in token.Children())
				{
					JToken jToken2 = FindTokenByValue(item2, propertyName, targetName);
					if (jToken2 != null)
					{
						return jToken2;
					}
				}
			}
			return null;
		}

		private void RemoveIdsFromContainer(JToken parentToken, RemoveRule[] schemeEntryRemoveByIdentificatorRules)
		{
			if (parentToken == null || schemeEntryRemoveByIdentificatorRules == null)
			{
				return;
			}
			foreach (RemoveRule removeRule in schemeEntryRemoveByIdentificatorRules)
			{
				foreach (JToken item in parentToken.SelectTokens("$..[?(@.ID == '" + removeRule.DeprecatedID + "')]").ToList())
				{
					item?.Parent?.Remove();
				}
			}
		}

		private void GameEntityMigration(string storageTypeName, JObject jsonObject)
		{
			GameEntityMigrationScheme gameEntityMigrationScheme = dataBaseProvider.MigrationSchemes.FirstOrDefault((GameEntityMigrationScheme x) => string.Equals(x.OriginalTypeName, storageTypeName, StringComparison.CurrentCultureIgnoreCase));
			if (gameEntityMigrationScheme != null)
			{
				RenameRule[] renameRules = gameEntityMigrationScheme.RenameRules;
				foreach (RenameRule renameRule in renameRules)
				{
					ReplaceGameEntity(jsonObject, renameRule.OldID, renameRule.NewID);
				}
				RemoveRule[] removeRules = gameEntityMigrationScheme.RemoveRules;
				foreach (RemoveRule removeRule in removeRules)
				{
					RemoveGameEntity(jsonObject, removeRule.DeprecatedID);
				}
				ChangeItemObjectTypeRule[] changeItemObjectTypeRules = gameEntityMigrationScheme.ChangeItemObjectTypeRules;
				foreach (ChangeItemObjectTypeRule changeItemObjectTypeRule in changeItemObjectTypeRules)
				{
					ReplaceItemObjectType(jsonObject, changeItemObjectTypeRule.ItemObjectID, changeItemObjectTypeRule.OldType, changeItemObjectTypeRule.NewType);
				}
			}
		}

		private static void ReplaceItemObjectType(JToken token, string itemObjectIdValue, string oldTypeValue, string newTypeValue)
		{
			if (token.Type == JTokenType.Object)
			{
				foreach (JProperty item in token.Children<JProperty>().ToList())
				{
					ReplaceItemObjectType(item.Value, itemObjectIdValue, oldTypeValue, newTypeValue);
					if (item.Name == "ItemObjectID" && item.Value.ToString() == itemObjectIdValue)
					{
						JToken jToken = item.Parent["$type"];
						if (jToken != null && jToken.ToString() == oldTypeValue)
						{
							item.Parent["$type"] = newTypeValue;
						}
					}
				}
				return;
			}
			if (token.Type != JTokenType.Array)
			{
				return;
			}
			foreach (JToken item2 in token.Children())
			{
				ReplaceItemObjectType(item2, itemObjectIdValue, oldTypeValue, newTypeValue);
			}
		}

		private static void ReplaceGameEntity(JToken token, string targetValue, string replacementValue)
		{
			if (token.Type == JTokenType.Object)
			{
				foreach (JProperty item in token.Children<JProperty>().ToList())
				{
					ReplaceGameEntity(item.Value, targetValue, replacementValue);
					if (item.Name == "ItemObjectID" && item.Value.ToString() == targetValue)
					{
						item.Value = replacementValue;
					}
				}
				return;
			}
			if (token.Type != JTokenType.Array)
			{
				return;
			}
			foreach (JToken item2 in token.Children())
			{
				ReplaceGameEntity(item2, targetValue, replacementValue);
			}
		}

		private static void RemoveGameEntity(JToken token, string targetValue)
		{
			if (token.Type == JTokenType.Object)
			{
				bool flag = false;
				foreach (JProperty item in token.Children<JProperty>().ToList())
				{
					RemoveGameEntity(item.Value, targetValue);
					if (item.Name == "ItemObjectID" && item.Value.ToString() == targetValue)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					token.Remove();
				}
			}
			else
			{
				if (token.Type != JTokenType.Array)
				{
					return;
				}
				for (int num = token.Count() - 1; num >= 0; num--)
				{
					RemoveGameEntity(token[num], targetValue);
					if (token[num].Type == JTokenType.Object && token[num]["ItemObjectID"] != null && token[num]["ItemObjectID"].ToString() == targetValue)
					{
						token[num].Remove();
					}
				}
			}
		}
	}
}
