using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_RPG2_Projectile : Projectile
{
	private MultiTargetTween _speedTween;

	private TP_RPG1_Weapon _rpgWeapon;

	[NonSerialized]
	public float SpeedMulti;

	private Timer _durationTimer;

	private Vector2 startingVelocity;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("p_wp66_p000", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0026: Expected O, but got I4
		//IL_006e: Expected I, but got O
		//IL_0076: Expected I, but got O
		//IL_0086: Expected O, but got I
		//IL_0106: Expected O, but got I4
		//IL_00c2: Expected O, but got I
		//IL_00f8: Expected O, but got I4
		//IL_01d3: Expected I, but got O
		//IL_02d2: Invalid comparison between F4 and I4
		//IL_0313: Expected O, but got Ref
		//IL_02fb: Expected O, but got Ref
		//IL_03eb: Expected O, but got F4
		//IL_0421: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		Weapon weapon2 = _weapon;
		TP_RPG1_Weapon rpgWeapon;
		if ((object)_weapon == null)
		{
			rpgWeapon = null;
			goto IL_03a2;
		}
		nint num2 = (nint)typeof(TP_RPG1_Weapon);
		nint num3 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ r8_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ r8_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v73+FFFFFFF8+v346 @ rax_v68*8]");
			if (0 == (nint)typeof(TP_RPG1_Weapon))
			{
				obj3 = 1;
				goto IL_03b1;
			}
		}
		obj3 = 0;
		goto IL_03b1;
		IL_03b1:
		bool flag = obj3 == null;
		rpgWeapon = null;
		if (!flag)
		{
			rpgWeapon = (TP_RPG1_Weapon)_weapon;
		}
		goto IL_03a2;
		IL_03a2:
		_rpgWeapon = rpgWeapon;
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
		float2 float5 = base.position;
		object obj4 = default(object);
		float num5 = (float)obj4 + 0.24f;
		float2 float6 = default(float2);
		base.position = float6;
		SpeedMulti = 0.5f;
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num6 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"SpeedMulti", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.ease = Ease.InQuart;
			tweenConfig.duration = 500f;
			MultiTargetTween speedTween = Tweens.Add(tweenConfig);
			_speedTween = speedTween;
			Weapon weapon3 = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
			object obj6 = default(object);
			if (!(characterController._walked > 0f))
			{
				Transform transform = base.AimForNearestEnemyFrom(_cachedTransform, rotate: true, (Vector3?)(object)(&obj6));
			}
			else
			{
				ApplyPlayerFacingVelocity((Vector3)(&obj6));
			}
			BaseBody baseBody2 = body;
			startingVelocity = baseBody2._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v37 (BaseBody)+74]");
			_ = 0;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj7 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v37 (BaseBody)+74]");
			float num7 = 0f - 0.5f;
			float detune = num7 * 500f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordFire, soundConfig, 200f, 3, time);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		//IL_0048: Expected O, but got F4
		float num = (float)startingVelocity * SpeedMulti;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_RPG2_Projectile)+F4]");
		float num2 = 0f * SpeedMulti;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00b6: Expected O, but got F4
		//IL_00e4: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			ArcadeSprite arcadeSprite = setVisible(visible: false);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 2f;
			object obj2 = UnityEngine.Random.value;
			object obj3 = default(object);
			float num = (float)obj3 - 0.5f;
			float detune = num * 200f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ImpactHeavy, soundConfig, 200f, 3, time);
			float2 float5 = base.position;
			Vector2 vector = default(Vector2);
			_rpgWeapon.SpawnExplosionWavesAt(vector, vector);
			Despawn();
		}
	}

	protected void Explode()
	{
		//IL_0082: Expected O, but got F4
		//IL_00b0: Expected O, but got I4
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 2f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ImpactHeavy, soundConfig, 200f, 3, time);
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		_rpgWeapon.SpawnExplosionWavesAt(vector, vector);
		Despawn();
	}

	public override void Despawn()
	{
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		base.Despawn();
	}
}
