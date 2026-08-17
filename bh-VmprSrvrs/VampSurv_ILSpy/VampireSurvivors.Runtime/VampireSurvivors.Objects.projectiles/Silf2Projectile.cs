using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Silf2Projectile : SilfProjectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("HitBlack1", "vfx");
		_renderer.sprite = sprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		_trailAlpha = 0.8f;
		base.InitProjectile(pool, weapon, index);
	}

	protected override string GetTrailTextureName()
	{
		//IL_004b: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4CEE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			object obj = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.5f);
			string result = "Gradient4_6px";
			if (!flag)
			{
				result = "Gradient4_4px";
			}
			return result;
		}
		return (string)(object)new NullReferenceException();
	}
}
