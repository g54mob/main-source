using UnityEngine;

public class CameraFrameLimiter : CameraLimiter
{
	[SerializeField]
	private int targetFrameRate = -1;

	protected override float FrameInterval => 1f / (float)((targetFrameRate <= 0) ? Application.targetFrameRate : targetFrameRate);
}
