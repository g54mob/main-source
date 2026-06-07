using ModApi.GameLoop;
using UnityEngine;

namespace UnityFS
{
	[AddComponentMenu("UnityFS/Base/AircraftAttachment")]
	public class AircraftAttachment : MonoBehaviourBase
	{
		protected bool Controllable;

		public void SetControllable(bool enable)
		{
			Controllable = enable;
		}
	}
}
