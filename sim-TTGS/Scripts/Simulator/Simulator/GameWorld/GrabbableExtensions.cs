using UnityEngine;

namespace Simulator.GameWorld
{
	public static class GrabbableExtensions
	{
		public static void Anchor(this IGrabbable grabbable, Transform anchor)
		{
			grabbable.transform.Anchor(anchor);
		}
	}
}
