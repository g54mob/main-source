using UnityEngine;
using UnityEngine.XR;

namespace VRTK
{
	public class SDK_UnityCameraRig : MonoBehaviour
	{
		[Tooltip("Automatically set the Unity Physics Fixed Timestep value based on the HMD render frequency.")]
		public bool lockPhysicsUpdateRateToRenderFrequency = true;

		protected virtual void Update()
		{
			if (lockPhysicsUpdateRateToRenderFrequency && Time.timeScale > 0f)
			{
				Time.fixedDeltaTime = Time.timeScale / XRDevice.refreshRate;
			}
		}
	}
}
