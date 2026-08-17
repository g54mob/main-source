using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Confodere1_Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeTween;

	private TP_Confodere1_Weapon _trueWeapon;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ex_red_slash", "vfx");
		_renderer.sprite = sprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00d9: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		TP_Confodere1_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0179;
		}
		nint num = (nint)typeof(TP_Confodere1_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v28+FFFFFFF8+v62 @ rax_v23*8]");
			if (0 == (nint)typeof(TP_Confodere1_Weapon))
			{
				obj3 = 1;
				goto IL_0188;
			}
		}
		obj3 = 0;
		goto IL_0188;
		IL_0188:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (TP_Confodere1_Weapon)_weapon;
		}
		goto IL_0179;
		IL_0179:
		_trueWeapon = trueWeapon;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_renderer).SetMaterial(material);
		ArcadeSprite arcadeSprite2 = setDepth(240);
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		base.Despawn();
	}

	public override void SetNullTarget()
	{
		Despawn();
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_04bd: Expected O, but got I4
		//IL_0177: Expected O, but got Ref
		//IL_0508: Expected O, but got I
		//IL_054f: Expected O, but got I4
		//IL_01b1: Expected O, but got I8
		//IL_0288: Expected I, but got O
		//IL_034c: Expected I, but got O
		//IL_03dc: Expected O, but got I4
		//IL_01b6->IL0535: Incompatible stack heights: 6 vs 5
		//IL_0258->IL0258: Incompatible stack heights: 7 vs 6
		//IL_036f->IL036f: Incompatible stack heights: 9 vs 8
		Transform transform = default(Transform);
		_targetTransform = transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul esi\"");
		object obj = (object)transform >> 31;
		object obj2 = (object)transform + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 + obj4;
		object obj6 = _indexInWeapon - obj5;
		if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			float2 float5 = default(float2);
			base.position = float5;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
			{
				Rate = 0.8f,
				Volume = (float?)(object)1
			};
			float detune = (float)_indexInWeapon * 100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory1, soundConfig, 200f, 10, time);
			ArcadeSprite arcadeSprite = setAlpha(0.75f);
			TP_Confodere1_Weapon trueWeapon = _trueWeapon;
			bool flag2 = (object)_trueWeapon == null;
			int[] fireAngles = trueWeapon._FireAngles;
			bool flag3 = trueWeapon._FireAngles == null;
			bool flag4 = (nint)obj6 >= fireAngles.Length;
			Transform transform2 = base.transform;
			bool flag5 = (object)transform2 == null;
			transform2.localEulerAngles = (Vector3)(&ret);
			int height = Screen.height;
			ArcadeSprite arcadeSprite2 = setDepth(height);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag6 = (nint)0 != 0;
			ArcadeSprite arcadeSprite3 = this;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag7 = obj7 == null;
				arcadeSprite3 = (ArcadeSprite)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v980 @ rax_v53 (should have been resolved before IL gen)");
			ArcadeSprite arcadeSprite4 = setScale(0.5f, (float?)(object)1);
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform3 = base.transform;
			bool flag8 = array == null;
			if ((object)transform3 != null)
			{
				void* value = ((IntPtr*)(&array))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj8 = default(object);
				bool flag9 = obj8 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			bool flag10 = tweenConfig == null;
			((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
			_ = 1132068864;
			_ = 1;
			_ = 1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_fadeTween != null)
			{
				_fadeTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			bool flag11 = array2 == null;
			if ((object)_renderer != null)
			{
				nint num = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				bool flag12 = obj9 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			bool flag13 = tweenConfig2 == null;
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 150f;
			tweenConfig2.ease = Ease.Linear;
			tweenConfig2.delay = 100f;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Despawn();
			};
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween fadeTween = Tweens.Add(tweenConfig2);
			_fadeTween = fadeTween;
		}
		else
		{
			Despawn();
		}
	}

	private void _003CSetTarget_003Eb__7_0()
	{
		Despawn();
	}
}
