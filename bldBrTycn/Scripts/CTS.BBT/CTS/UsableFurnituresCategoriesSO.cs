using CTS.BBT;
using CTS.BBT.TechTree;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Serialization;

namespace CTS
{
	[CreateAssetMenu(fileName = "New Category", menuName = "CTS/Usable Furnitures/New Category", order = 0)]
	public class UsableFurnituresCategoriesSO : ScriptableObject
	{
		[field: SerializeField]
		public UsableFurnituresCategory CategoryPrefab { get; private set; }

		[field: SerializeField]
		public StringKey SyncKey { get; private set; }

		[field: SerializeField]
		[field: FormerlySerializedAs("CategoryName")]
		public LocalizedString CategoryName { get; private set; }

		[field: SerializeField]
		[field: FormerlySerializedAs("CategoryIcon")]
		public Sprite CategoryIcon { get; private set; }

		[field: SerializeField]
		[field: FormerlySerializedAs("CategoryHeader")]
		public Sprite CategoryHeader { get; private set; }

		[field: SerializeField]
		public FurnitureSO AssociatedFurniture { get; private set; }

		[field: SerializeField]
		[field: FormerlySerializedAs("TechTreeTechnologySO")]
		public TechTreeTechnologySO TechTreeTechnologySO { get; private set; }

		[field: SerializeField]
		public bool ForceLock { get; private set; }
	}
}
