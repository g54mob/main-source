using UnityEngine;

public class CameraTickRateLimiter : CameraLimiter
{
	protected override float FrameInterval => 1f / Mathf.Max(1f, Database.State.Resources.TickRate.Value);
}
