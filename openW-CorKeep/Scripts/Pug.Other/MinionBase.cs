using UnityEngine;

public class MinionBase : EntityMonoBehaviour
{
	public SFXTableIDField spawnSound;

	private bool fading;

	private PlayerController _ownerPC;

	private float fadeOutThreshold = 3f;

	public Color fadeOutColor = Color.white;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (EntityUtility.IsNewlyCreatedObject(base.entity, base.world))
		{
			AudioManager.Sfx(spawnSound.value, base.transform.position);
		}
	}

	protected override float GetAnimSpeed()
	{
		return 1f;
	}

	protected override void OnDeath()
	{
		DeathEffect();
		base.OnDeath();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		float lifespanTimer = EntityUtility.GetComponentData<MinionCD>(base.entity, base.world).lifespanTimer;
		if (lifespanTimer < fadeOutThreshold && lifespanTimer != 0f && hasFlashable && !flashable.isRunning)
		{
			flashable.FlashLinearNoCurve(fadeOutColor, Mathf.Clamp(0.05f + lifespanTimer / 10f, 0.1f, 1f));
		}
	}
}
