using UnityEngine;

namespace Brewery.Systems
{
	[CreateAssetMenu(menuName = "Brewery/Config/Money Config")]
	public class MoneyConfig : ScriptableObject
	{
		[Header("Core")]
		[Tooltip("Currency each visual stack child represents")]
		public int currencyPerChild;

		[Header("Player Inventory")]
		public int playerMaxPerSlot;

		[Header("Shelf Stack")]
		public int shelfChildCount;

		public GameObject shelfStackPrefab;

		[Header("Crate Stack")]
		public int crateChildCount;

		public GameObject crateStackPrefab;

		public Vector3 crateStackPositionOffset;

		public Vector3 crateStackRotation;

		public float crateStackScale;

		[Header("Safe Stack")]
		public int safeChildCount;

		public int ShelfMaxCurrency => 0;

		public int CrateMaxCurrency => 0;

		public int SafeMaxCurrency => 0;

		public int DropAmount => 0;
	}
}
