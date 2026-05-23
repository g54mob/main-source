using System;
using System.Collections.Generic;
using System.Linq;
using Data.Operator;
using NaughtyAttributes;
using UnityEngine;

namespace Data.FactoryFloor.Islands
{
	[CreateAssetMenu(menuName = "Factory/EnvironmentObjectsDatabase", fileName = "EnvironmentObjectsDatabase", order = 0)]
	public class EnvironmentObjectsDatabase : ScriptableObject
	{
		[Serializable]
		public class ItemCollection
		{
			public string Name;

			public Sprite Sprite;

			public Color SpriteColour = Color.white;

			public List<Item> Items;
		}

		[Serializable]
		public class Item
		{
			public FactoryObjectData FactoryObjectData;

			public Sprite Sprite;

			public Color SpriteColour = Color.white;
		}

		public List<ItemCollection> EnvironmentObjectCollections;

		[SerializeField]
		private List<EnvironmentBrushData> _environmentBrushDatas = new List<EnvironmentBrushData>();

		public IEnumerable<ItemCollection> AllCollections => EnvironmentObjectCollections;

		public EnvironmentBrushData GetBrushDataWithId(int id)
		{
			return _environmentBrushDatas.FirstOrDefault((EnvironmentBrushData x) => x.ID == id);
		}

		public IEnumerable<FactoryObjectData> GetAllFactoryObjectDatas()
		{
			foreach (ItemCollection environmentObjectCollection in EnvironmentObjectCollections)
			{
				foreach (Item item in environmentObjectCollection.Items)
				{
					yield return item.FactoryObjectData;
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateRelativePositions()
		{
			foreach (FactoryObjectData allFactoryObjectData in GetAllFactoryObjectDatas())
			{
				allFactoryObjectData.UpdateRelativePositions();
			}
		}
	}
}
