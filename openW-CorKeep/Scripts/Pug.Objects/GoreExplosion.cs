using UnityEngine;

public class GoreExplosion : PoolableSimple
{
	public enum ExplosionType
	{
		None = 0,
		Blood = 1,
		Slime = 2,
		Poison = 3
	}

	public ExplosionType explosionType;

	public Animator animator;

	public bool playAdditionalEffects = true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if ((bool)animator)
		{
			switch (explosionType)
			{
			case ExplosionType.Slime:
				animator.SetTrigger("slime");
				break;
			case ExplosionType.Poison:
				animator.SetTrigger("poison");
				break;
			}
		}
		if (playAdditionalEffects)
		{
			AudioManager.SfxFollowTransform(SfxID.cocoonHatch, base.transform, 1f, 1f, 0.1f, reuse: true);
			Manager.camera.ShakeCameraNow();
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		base.transform.localScale = Vector3.one;
		playAdditionalEffects = true;
	}
}
