using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Pug.UnityExtensions;
using PugMod;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Scripting;

public class CollectionsCommands : MonoBehaviour
{
	[Serializable]
	public class Collection
	{
		[Serializable]
		public struct CollectionItem
		{
			public ObjectID id;
		}

		public string name;

		[ArrayElementTitle("id")]
		public List<CollectionItem> items = new List<CollectionItem>();
	}

	public QuantumConsole quantumConsole;

	[ArrayElementTitle("name")]
	public List<Collection> Collections = new List<Collection>();

	[Header("This list is auto-populated from object categories. Don't edit it manually. Use the list above instead for custom collections.")]
	[ReadOnly]
	[ArrayElementTitle("name")]
	public List<Collection> categoryCollections = new List<Collection>();

	public void Awake()
	{
		UpdateObjectIDCategoryCollections();
	}

	public void OnValidate()
	{
		UpdateObjectIDCategoryCollections();
	}

	[Preserve]
	[CommandWithModSupport("spawnCollection", "Spawns a predefined collection of items", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void CollectionCommand([CollectionName] string collectionName, int amount = 1)
	{
		if (!ConsoleCommands.CanUseConsoleCommands())
		{
			return;
		}
		if (amount < 1)
		{
			quantumConsole.LogToConsole(PugText.ProcessText("ConsoleCommands/AmountMustBeLargerThanZero", null, shouldLocalize: true, shouldLocalizeFormatFields: false));
			return;
		}
		Collection collection = Collections.Find((Collection collection2) => collection2.name.Equals(collectionName, StringComparison.OrdinalIgnoreCase)) ?? categoryCollections.Find((Collection collection2) => collection2.name.Equals(collectionName, StringComparison.OrdinalIgnoreCase));
		if (collection == null)
		{
			quantumConsole.LogToConsole("Cannot spawn " + collectionName + ": no collection with this name exists.");
			return;
		}
		PlayerController player = Manager.main.player;
		foreach (Collection.CollectionItem item in collection.items)
		{
			player.playerCommandSystem.DebugCreateAndDropEntity(item.id, player.WorldPosition, amount, player.entity);
			Manager.menu.quantumConsole.LogToConsole($"Spawned {item.id} x{amount.ToString()}.");
		}
	}

	private void UpdateObjectIDCategoryCollections()
	{
		categoryCollections.Clear();
		foreach (ObjectIDCategory subCategory in ObjectIDCategoryManager.SubCategories)
		{
			Collection collection = new Collection
			{
				name = subCategory.name
			};
			foreach (ObjectID objectId in subCategory.ObjectIds)
			{
				collection.items.Add(new Collection.CollectionItem
				{
					id = objectId
				});
			}
			categoryCollections.Add(collection);
		}
	}
}
