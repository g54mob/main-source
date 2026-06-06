using UnityEngine;

namespace Property
{
	public class BedFurnitureValidator : FurnitureValidator
	{
		[Header("Bed Settings")]
		[Tooltip("Maximum distance to check for wall behind bed")]
		[SerializeField]
		private float wallCheckDistance;

		[Tooltip("Layer mask for wall detection (Default layer = walls)")]
		[SerializeField]
		private LayerMask wallLayerMask;

		[Header("Couch Distance")]
		[Tooltip("Minimum distance bed must be from any couch")]
		[SerializeField]
		private float minCouchDistance;

		private bool isAgainstWall;

		private bool isTooCloseToCouch;

		private CouchFurnitureValidator nearbyCouch;

		public override FurnitureType FurnitureType => default(FurnitureType);

		private void Awake()
		{
		}

		public override void Validate()
		{
		}
	}
}
