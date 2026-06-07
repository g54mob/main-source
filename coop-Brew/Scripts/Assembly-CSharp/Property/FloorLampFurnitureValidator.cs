using UnityEngine;

namespace Property
{
	public class FloorLampFurnitureValidator : FurnitureValidator
	{
		[Header("Floor Lamp Settings")]
		[Tooltip("Maximum distance from a bed to be considered valid")]
		[SerializeField]
		private float maxDistanceFromBed;

		[Tooltip("Also allow placement near a couch (living room lighting)")]
		[SerializeField]
		private bool allowNearCouch;

		[Tooltip("Maximum distance from a couch if allowed")]
		[SerializeField]
		private float maxDistanceFromCouch;

		private BedFurnitureValidator nearbyBed;

		private CouchFurnitureValidator nearbyCouch;

		public override FurnitureType FurnitureType => default(FurnitureType);

		public BedFurnitureValidator NearbyBed => null;

		public CouchFurnitureValidator NearbyCouch => null;

		public override void Validate()
		{
		}
	}
}
