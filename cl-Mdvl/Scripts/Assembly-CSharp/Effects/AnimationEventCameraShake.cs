using NSEipix.Base;
using NSMedieval;
using NSMedieval.EnvironmentEffects;
using UnityEngine;

namespace Effects
{
	public class AnimationEventCameraShake : MonoBehaviour
	{
		public void CameraShake(CameraShakeStrength shakeStrength)
		{
			MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, shakeStrength);
		}
	}
}
