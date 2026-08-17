using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Shuriken_Projectile : Projectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected I4, but got Unknown
		//IL_01e2: Expected O, but got I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		_speed = 4f;
		SetScaleToArea();
		Weapon weapon2 = _weapon;
		int num = ((Equipment)weapon2)._003COwner_003Ek__BackingField.depth;
		object obj = index + 1;
		int sortingOrder = obj + num;
		_renderer.sortingOrder = sortingOrder;
		Weapon weapon3 = _weapon;
		WeaponData currentWeaponData = weapon3._currentWeaponData;
		if ((object)currentWeaponData._003Cvolume_003Ek__BackingField != null)
		{
			Weapon weapon4 = _weapon;
			if (weapon4._currentWeaponData == null)
			{
				throw new NullReferenceException();
			}
			bool flag = 3221225472L < 0L;
			bool flag2 = !flag;
			object obj2 = (_003F?)currentWeaponData._003Cvolume_003Ek__BackingField & flag2;
			if (obj2 != null && (object)currentWeaponData._003Cvolume_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -50f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Shuriken2, soundConfig, 200f, 10, time);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_0068: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			float speed = _speed * 1.1f;
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			_speed = speed;
			Transform transform = base.AimForRandomEnemy(rotate: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_00c0: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				base.Despawn();
			}
			return;
		}
		float speed = _speed * 1.1f;
		nint num = (nint)this;
		int bounces = _bounces - 1;
		_bounces = bounces;
		_speed = speed;
		Transform transform = base.AimForRandomEnemy(rotate: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
