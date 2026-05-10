using SmoothShakeFree;
using UnityEngine;

public class CameraShakeAnimationEvent : MonoBehaviour
{
	[SerializeField]
	private SmoothShakeFreePreset shakePreset;

	public void AnimationEventCameraShake()
	{
		LTFunctionLibrary.GetLTPlayerController().ShakeCameraFromPosition(base.transform.position, 1f, shakePreset);
	}
}
