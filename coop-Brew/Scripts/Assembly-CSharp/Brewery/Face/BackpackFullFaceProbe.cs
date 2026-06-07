using InventorySystem;
using UnityEngine;

namespace Brewery.Face
{
	public class BackpackFullFaceProbe : FaceStateProbe
	{
		[Tooltip("Free-slot count at or below which the stress face is fully on (require InventoryManager exposing GetFreeSlotCount or similar; left as a placeholder until that API exists).")]
		[SerializeField]
		private float fullStressFreeSlots;

		private InventoryManager _inventory;

		public override string ProbeId => null;

		private void Awake()
		{
		}

		public override float Evaluate01()
		{
			return 0f;
		}
	}
}
