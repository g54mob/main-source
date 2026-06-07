using System;
using UnityEngine;

public class Cross : Weapon
{
	public Projectile beam;

	private GameObject proj;

	private int f;

	public override void ProcessFrame()
	{
		if (f > 0)
		{
			f--;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			ShootBeam();
		}
		base.ProcessFrame();
	}

	public void ShootBeam()
	{
		if (f <= 0)
		{
			f = 1;
			owner.dungeon.animationManager.BounceZoom(base.gameObject, 0.125f, 4);
			owner.dungeon.animationManager.FlashSprite(GetComponent<SpriteRenderer>());
			PlaySound(AudioManager.Sound.Beam);
			for (int i = 0; i < 4; i++)
			{
				Projectile component = UnityEngine.Object.Instantiate(beam).GetComponent<Projectile>();
				component.source = this;
				component.transform.position = base.transform.position;
				component.transform.localEulerAngles = base.transform.localEulerAngles + new Vector3(0f, 0f, i * 90);
				component.transform.localScale = base.transform.localScale;
				float num = (base.transform.localEulerAngles.z + 45f + (float)(90 * i)) * MathF.PI / 180f;
				Vector3 normalized = (base.transform.position + new Vector3(Mathf.Cos(num), Mathf.Sin(num)) - base.transform.position).normalized;
				owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.4f);
				owner.dungeon.animationManager.Fade(component.gameObject, 2, 120);
				owner.dungeon.animationManager.FlashSprite(component.GetComponent<SpriteRenderer>());
				owner.dungeon.animationManager.BounceZoom(component.gameObject, 0.125f, 4);
				proj = component.gameObject;
			}
		}
	}
}
