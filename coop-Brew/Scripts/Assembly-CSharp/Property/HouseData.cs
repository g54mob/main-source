using UnityEngine;

namespace Property
{
	[CreateAssetMenu(fileName = "House_New", menuName = "Brewery/Property/House Data")]
	public class HouseData : ScriptableObject
	{
		[Header("Identity")]
		[Tooltip("Unique identifier for this house (e.g., 'House_MarketSquare_1')")]
		[SerializeField]
		private string houseId;

		[Tooltip("Display name shown in UI")]
		[SerializeField]
		private string displayName;

		[SerializeField]
		private string displayNameKey;

		[Tooltip("Description for info panels")]
		[TextArea(2, 4)]
		[SerializeField]
		private string description;

		[SerializeField]
		private string descriptionKey;

		[Header("Pricing")]
		[Tooltip("Cost to purchase this house")]
		[SerializeField]
		private int basePurchasePrice;

		[Header("Rent Configuration")]
		[Tooltip("Base daily rent when house has no correctly placed furniture (100 for small, 200 for large)")]
		[SerializeField]
		private int baseRent;

		[Tooltip("Bonus rent per correctly placed furniture item")]
		[SerializeField]
		private int furnitureRentBonus;

		[Header("Location")]
		[Tooltip("World-space center of the house interior for furniture validation")]
		[SerializeField]
		private Vector3 furnitureBoundsCenter;

		[Tooltip("Size of the area to check for furniture")]
		[SerializeField]
		private Vector3 furnitureBoundsSize;

		[Header("Furniture Requirements")]
		[Tooltip("Furniture types required for full value bonus")]
		[SerializeField]
		private FurnitureRequirement[] furnitureRequirements;

		public string HouseId => null;

		public string DisplayName => null;

		public string Description => null;

		public int BasePurchasePrice => 0;

		public int BaseRent => 0;

		public int FurnitureRentBonus => 0;

		public Vector3 FurnitureBoundsCenter => default(Vector3);

		public Vector3 FurnitureBoundsSize => default(Vector3);

		public FurnitureRequirement[] FurnitureRequirements => null;

		public Bounds GetFurnitureBounds()
		{
			return default(Bounds);
		}

		public int CalculateTotalRent(int correctFurnitureCount)
		{
			return 0;
		}

		public int GetMaxPossibleRent()
		{
			return 0;
		}
	}
}
