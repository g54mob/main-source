using UnityEngine;

namespace Property
{
	public class DiningChairFurnitureValidator : FurnitureValidator
	{
		[Header("Dining Chair Settings")]
		[Tooltip("Maximum distance from a dining table")]
		[SerializeField]
		private float maxDistanceFromTable;

		[Tooltip("Angle tolerance for facing the table (degrees)")]
		[SerializeField]
		private float facingAngleTolerance;

		private DiningTableFurnitureValidator nearbyTable;

		private bool isFacingTable;

		public override FurnitureType FurnitureType => default(FurnitureType);

		public DiningTableFurnitureValidator NearbyTable => null;

		public override void Validate()
		{
		}
	}
}
