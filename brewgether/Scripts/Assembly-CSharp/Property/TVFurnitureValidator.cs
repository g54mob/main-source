using UnityEngine;

namespace Property
{
	public class TVFurnitureValidator : FurnitureValidator
	{
		[Header("TV Settings")]
		[Tooltip("Distance to raycast down when checking for a table surface")]
		[SerializeField]
		private float surfaceCheckDistance;

		[Tooltip("Max horizontal distance for proximity fallback check")]
		[SerializeField]
		private float proximityHorizontalDistance;

		[Tooltip("Min/Max vertical distance for proximity fallback (TV must be above table)")]
		[SerializeField]
		private float proximityMinVertical;

		[SerializeField]
		private float proximityMaxVertical;

		private TVTableFurnitureValidator onTable;

		public override FurnitureType FurnitureType => default(FurnitureType);

		public TVTableFurnitureValidator OnTable => null;

		public override void Validate()
		{
		}

		private TVTableFurnitureValidator FindTableUnderneath()
		{
			return null;
		}
	}
}
