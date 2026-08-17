using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_HomingAltProjectile : Projectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0033: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_HomingShot, 100f, 12, 0f, volume, rate, detune, loop, 1f);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			if (_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
			{
				Weapon weapon = _weapon;
				GameManager gameMan = weapon._gameMan;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				gameMan._arcanaManager.TriggerFireExplosion(pos);
			}
			if (--_penetrating <= 0)
			{
				base.Despawn();
			}
		}
	}
}
