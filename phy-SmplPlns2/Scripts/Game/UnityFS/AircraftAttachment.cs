using UnityEngine;

namespace UnityFS
{
	[AddComponentMenu("UnityFS/Base/AircraftAttachment")]
	public class AircraftAttachment : MonoBehaviour
	{
		protected bool Controllable;

		public void SetControllable(bool enable)
		{
			Controllable = enable;
		}
	}
}
