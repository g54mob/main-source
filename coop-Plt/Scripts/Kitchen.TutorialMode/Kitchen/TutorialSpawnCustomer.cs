using UnityEngine;

namespace Kitchen
{
	public class TutorialSpawnCustomer : TutorialAction
	{
		public Vector3 Position;

		public int Count;

		public bool OrderSides;

		public bool LowPatience;

		public TutorialSpawnCustomer(Vector3 pos, int count, bool order_sides = false, bool low_patience = false)
		{
			Position = pos;
			Count = count;
			OrderSides = order_sides;
			LowPatience = low_patience;
		}
	}
}
