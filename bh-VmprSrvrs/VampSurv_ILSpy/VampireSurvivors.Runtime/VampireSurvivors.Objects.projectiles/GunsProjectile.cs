using System;
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

public class GunsProjectile : Projectile
{
	protected float[] _firingAngles = new float[4] { 30f, -30f, 210f, -210f };

	private GunsWeapon _trueWeapon;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_0197: Expected I, but got O
		//IL_020d: Expected O, but got F4
		//IL_0249: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_02ae;
		}
		nint num = (nint)typeof(GunsWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.GunsWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.GunsWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v42+FFFFFFF8+v67 @ rax_v37*8]");
			if (0 == (nint)typeof(GunsWeapon))
			{
				obj3 = 1;
				goto IL_02bd;
			}
		}
		obj3 = 0;
		goto IL_02bd;
		IL_02bd:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_02ae;
		IL_02ae:
		_trueWeapon = (GunsWeapon)trueWeapon;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		Weapon weapon2 = _weapon;
		float num4 = weapon2.PArea();
		object obj4 = default(object);
		float xScale = (float)obj4 * 0.5f;
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		float2 float5 = base.position;
		object obj5 = default(object);
		float num5 = (float)obj5 + 0.12f;
		float2 float6 = default(float2);
		base.position = float6;
		float[] firingAngles = _firingAngles;
		int num6 = _indexInWeapon % firingAngles.Length;
		nint num7 = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		BaseBody baseBody2 = body;
		float num8 = firingAngles[num6] * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float num9 = num8 * (float)float6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float num10 = num8 * (float)float6;
		baseBody2._velocity = (float2)num9;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Guns1, soundConfig, 200f, 12, time);
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		OnHasHitAnObjectLogic(target, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable target)
	{
		//IL_009c: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			int bounces = _bounces - 1;
			_bounces = bounces;
			BaseBody baseBody = body;
			float num = (float)baseBody._velocity * -1f;
			baseBody._velocity = (float2)num;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v7 (BaseBody)+74]");
			float num2 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
	{
		//IL_008b: Expected O, but got I4
		//IL_01b2: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		bool flag = !triggerHit;
		IDamageable damageable = target;
		Vector2 typeFromHandle = (Vector2)typeof(IDamageable);
		if (!flag)
		{
			bool flag2 = _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE);
			bool flag3 = !flag2;
			damageable = null;
			typeFromHandle = (Vector2)19;
			if (!flag3)
			{
				Weapon weapon = _weapon;
				GameManager gameMan = weapon._gameMan;
				float2 float5 = base.position;
				Vector2 vector = default(Vector2);
				gameMan._arcanaManager.TriggerFireExplosion(vector);
				damageable = null;
				typeFromHandle = vector;
			}
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				base.Despawn();
			}
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		BaseBody baseBody = body;
		float num = (float)baseBody._velocity * -1f;
		baseBody._velocity = (float2)num;
		BaseBody baseBody2 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v8 (BaseBody)+74]");
		float num2 = 0f * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
