using System;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Unused_TP_Savrog2_Projectile : TP_Savrog_Projectile
{
	private TrailRenderer _Trail;

	private TrailRenderer _Trail2;

	private Unused_TP_Savrog2_Weapon _trueWeapon;

	private bool _isYeeted;

	private MultiTargetTween _tintTween;

	private int _tintCounter;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		Unused_TP_Savrog2_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0148;
		}
		nint num = (nint)typeof(Unused_TP_Savrog2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Savrog2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Savrog2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v21+FFFFFFF8+v59 @ rax_v16*8]");
			if (0 == (nint)typeof(Unused_TP_Savrog2_Weapon))
			{
				obj3 = 1;
				goto IL_0157;
			}
		}
		obj3 = 0;
		goto IL_0157;
		IL_0157:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (Unused_TP_Savrog2_Weapon)_weapon;
		}
		goto IL_0148;
		IL_0148:
		_trueWeapon = trueWeapon;
		_isYeeted = false;
		InitTrails();
		PhaserSprite phaserSprite = _spikeSprite.setTint(16777215u);
		_tintCounter = 0;
		DoTintTween();
	}

	private void InitTrails()
	{
		//IL_0256->IL01e9: Incompatible stack heights: 1 vs 0
		//IL_00ab->IL01e9: Incompatible stack heights: 1 vs 0
		//IL_00d9->IL01e9: Incompatible stack heights: 1 vs 0
		//IL_0111->IL01e9: Incompatible stack heights: 1 vs 0
		//IL_02a1->IL01e9: Incompatible stack heights: 2 vs 0
		//IL_0163->IL01e9: Incompatible stack heights: 2 vs 0
		//IL_01a1->IL01e9: Incompatible stack heights: 2 vs 0
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			TrailRenderer trail = _Trail;
			object obj = default(object);
			float num2 = (float)obj * 4f;
			float num3 = num2 * 0.01f;
			if ((object)_Trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if ((object)_Trail != null)
				{
					_Trail.enabled = false;
					TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_Trail, 1f);
					if ((object)_Trail != null)
					{
						_Trail.startWidth = num3;
						if ((object)_Trail != null)
						{
							_Trail.endWidth = num3;
							TrailRenderer trail2 = _Trail2;
							if ((object)_Trail2 != null)
							{
								bool flag2 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
								TrailRenderer.Clear_Injected(((UnityEngine.Object)trail2).m_CachedPtr);
								if ((object)_Trail2 != null)
								{
									_Trail2.enabled = false;
									TrailRenderer trailRenderer2 = RenderingExtensions.SetAlpha(_Trail2, 1f);
									if ((object)_Trail2 != null)
									{
										float startWidth = num3 * 0.5f;
										_Trail2.startWidth = startWidth;
										if ((object)_Trail2 != null)
										{
											float endWidth = num3 * 0.5f;
											_Trail2.endWidth = endWidth;
											TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
											TrailRendererPauseController trailRendererPauseController2 = RenderingExtensions.AddPauseController(_Trail2);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateTrailTints()
	{
		//IL_003b: Expected O, but got I4
		//IL_0066: Invalid comparison between I4 and F4
		//IL_0156: Invalid comparison between I4 and F4
		//IL_0186: Invalid comparison between I4 and F4
		//IL_01b6: Invalid comparison between I4 and F4
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected I4, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected I4, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected I4, but got Unknown
		//IL_011c: Expected I4, but got I8
		Unused_TP_Savrog2_Weapon trueWeapon = _trueWeapon;
		Color[] trailColours = trueWeapon._TrailColours;
		int num = _tintCounter % trailColours.Length;
		object obj = num + 2;
		object obj2 = obj + obj;
		object obj3 = default(object);
		float num2 = (float)obj3 * 255f;
		if (0f > num2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rbx,xmm0\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v5 (UnityEngine.Color[])+v125 @ rax_v10*8]");
		float num3 = 0f * 255f;
		if (0f > num3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdx,xmm0\"");
		}
		float num4 = (float)obj3 * 255f;
		if (0f > num4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
		}
		float num5 = (float)obj3 * 255f;
		if (0f > num5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm6\"");
		}
		object obj5 = default(object);
		object obj4 = obj5 << 8;
		int num6 = obj4 | num;
		int num7 = num6 << 8;
		int num8 = num7 | typeof(ColorUtils);
		int num9 = num8 << 8;
		uint tint = (uint)(num9 | obj2);
		TrailRenderer trailRenderer = RenderingExtensions.SetTint(_Trail, tint);
		TrailRenderer trailRenderer2 = RenderingExtensions.SetTint(_Trail2, 4278190080u);
	}

	private void DoTintTween()
	{
		//IL_003b: Expected O, but got I4
		//IL_0066: Invalid comparison between I4 and F4
		//IL_023a: Invalid comparison between I4 and F4
		//IL_026a: Invalid comparison between I4 and F4
		//IL_029a: Invalid comparison between I4 and F4
		//IL_014e: Expected I, but got O
		//IL_01c0: Expected O, but got I4
		Unused_TP_Savrog2_Weapon trueWeapon = _trueWeapon;
		Color[] spriteColours = trueWeapon._SpriteColours;
		int num = _tintCounter % spriteColours.Length;
		object obj = num + 2;
		object obj2 = obj + obj;
		object obj3 = default(object);
		float num2 = (float)obj3 * 255f;
		if (0f > num2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rbx,xmm0\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v7 (UnityEngine.Color[])+v170 @ rax_v13*8]");
		float num3 = 0f * 255f;
		if (0f > num3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdx,xmm0\"");
		}
		float num4 = (float)obj3 * 255f;
		if (0f > num4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
		}
		float num5 = (float)obj3 * 255f;
		if (0f > num5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm6\"");
		}
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_spikeSprite != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.tint = (uint?)(object)1;
		TweenCallback onComplete = delegate
		{
			int tintCounter = _tintCounter + 1;
			_tintCounter = tintCounter;
			DoTintTween();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tintTween = Tweens.Add(tweenConfig);
		_tintTween = tintTween;
	}

	public unsafe void Yeet(Vector2 vector)
	{
		//IL_0049: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_00f9: Invalid comparison between I4 and F4
		//IL_0389: Invalid comparison between I4 and F4
		//IL_03b9: Invalid comparison between I4 and F4
		//IL_03e9: Invalid comparison between I4 and F4
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected I4, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected I4, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected I4, but got Unknown
		//IL_01af: Expected I4, but got I8
		//IL_0218: Expected I, but got O
		//IL_0278: Expected O, but got I4
		//IL_02a3: Expected O, but got I4
		if (_isYeeted)
		{
			return;
		}
		_isYeeted = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		object obj = default(object);
		float num = (float)obj * 57.29578f;
		base.angle = num;
		setVelocity(0f, (float?)(object)0);
		_Trail.Clear();
		_Trail.enabled = true;
		_Trail2.Clear();
		_Trail2.enabled = true;
		Unused_TP_Savrog2_Weapon trueWeapon = _trueWeapon;
		Color[] trailColours = trueWeapon._TrailColours;
		int num2 = _tintCounter % trailColours.Length;
		object obj2 = num2 + 2;
		object obj3 = obj2 + obj2;
		object obj4 = default(object);
		float num3 = (float)obj4 * 255f;
		if (0f > num3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rsi,xmm0\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rcx_v15 (UnityEngine.Color[])+v493 @ rax_v23*8]");
		float num4 = 0f * 255f;
		if (0f > num4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdx,xmm0\"");
		}
		float num5 = (float)obj4 * 255f;
		if (0f > num5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
		}
		float num6 = (float)obj4 * 255f;
		if (0f > num6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm6\"");
		}
		object obj6 = default(object);
		object obj5 = obj6 << 8;
		int num7 = obj5 | num2;
		int num8 = num7 << 8;
		int num9 = num8 | typeof(ColorUtils);
		int num10 = num9 << 8;
		uint tint = (uint)(num10 | obj3);
		TrailRenderer trailRenderer = RenderingExtensions.SetTint(_Trail, tint);
		TrailRenderer trailRenderer2 = RenderingExtensions.SetTint(_Trail2, 4278190080u);
		float2 float5 = base.position;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num11 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		tweenConfig.x = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		tweenConfig.duration = 150f;
		tweenConfig.y = (float?)(object)1;
		tweenConfig.ease = Ease.InOutSine;
		float delay = (float)_indexInWeapon * 50f;
		tweenConfig.delay = delay;
		TweenCallback onStart = delegate
		{
			//IL_0026: Expected O, but got Ref
			Transform transform2 = _spikeSprite.transform;
			object obj8 = default(object);
			transform2.localEulerAngles = (Vector3)(&obj8);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = base.FadeOut;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public override void Despawn()
	{
		//IL_00e0: Expected O, but got I4
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		if (base._expireTimer != null)
		{
			base._expireTimer.Cancel();
		}
		if (base._hitboxTimer != null)
		{
			base._hitboxTimer.Cancel();
		}
		if (base._tween1 != null)
		{
			base._tween1.Kill();
		}
		PhaserSprite phaserSprite = _spikeSprite.setVisible(visible: false);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		((Projectile)this).Despawn();
	}

	public Unused_TP_Savrog2_Projectile()
	{
		base._radius = 8f;
		((Projectile)this)._002Ector();
	}

	private void _003CDoTintTween_003Eb__9_0()
	{
		int tintCounter = _tintCounter + 1;
		_tintCounter = tintCounter;
		DoTintTween();
	}

	private unsafe void _003CYeet_003Eb__10_0()
	{
		//IL_0026: Expected O, but got Ref
		Transform transform = _spikeSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}
}
