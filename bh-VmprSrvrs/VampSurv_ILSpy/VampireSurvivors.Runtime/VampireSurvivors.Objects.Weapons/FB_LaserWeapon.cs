using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_LaserWeapon : Weapon
{
	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			_explodeOnExpire = true;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.15f;
			}
		}
		CheckBeginningArcana();
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_010c: Expected F4, but got I4
		BulletPool bulletPool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, bulletPool);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			if (((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
			{
				float2 firingVector = base.GetFiringVector();
				float projectileSpeed = projectile.ProjectileSpeed;
				BaseBody body = projectile.body;
				object obj = default(object);
				float2 velocity = (object)firingVector * obj;
				object obj3 = default(object);
				object obj2 = obj3 * obj;
				if (projectile.body == null)
				{
					return (Projectile)(object)new NullReferenceException();
				}
				body._velocity = velocity;
			}
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_LaserShot, 100f, 10, 0f, (float?)bulletPool, rate, detune, loop, 1f);
		}
		else
		{
			projectile = null;
		}
		return projectile;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}
}
