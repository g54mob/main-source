using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Unused_TP_AuraBlast1Slam_Projectile : Projectile
{
	private SpriteAnimation _anim;

	protected override void Awake()
	{
		//IL_007b: Expected I, but got O
		base.Awake();
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Big Fuzzy Fist-Impact 2-F", 1, 4, "firstBlood", num);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Unused_TP_AuraBlast1Slam_Projectile>)+370]");
		Action action = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4787]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = true;
		_anim.SetAnimation("idle");
	}
}
