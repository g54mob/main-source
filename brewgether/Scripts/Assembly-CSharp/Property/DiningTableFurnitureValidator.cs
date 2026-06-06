using UnityEngine;

namespace Property
{
	public class DiningTableFurnitureValidator : FurnitureValidator
	{
		[Header("Dining Table Settings")]
		[Tooltip("Minimum distance from any couch (dining area must be separate)")]
		[SerializeField]
		private float minDistanceFromCouch;

		[Tooltip("Minimum distance from any TV (not in living room)")]
		[SerializeField]
		private float minDistanceFromTV;

		private bool tooCloseToCouch;

		private bool tooCloseToTV;

		public override FurnitureType FurnitureType => default(FurnitureType);

		public override void Validate()
		{
		}
	}
}
