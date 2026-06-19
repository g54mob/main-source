using Aggro.Core;

public class HapticFeedbackPlayer : EntityBehaviourBase
{
	public bool shakeOnEntityCreated = true;

	public ShakeStrength shakeStrength;

	protected override void OnEntityCreated()
	{
		if (shakeOnEntityCreated)
		{
			Shake();
		}
	}

	public void Shake()
	{
		AggroManagerBase<CameraShake>.instance.AddShakeFromPosition(shakeStrength, base.transform.position);
	}
}
