using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AlucardShield_Projectile : Projectile
{
	private float _bodyRadius = 20f;

	private PhaserSprite _displaySprite1;

	private MultiTargetTween _alphaTween1;

	private MultiTargetTween _alphaTween2;

	private Timer _hitBoxTimer;

	private Timer _durationTimer;

	private TP_AlucardShield_Weapon _trueWeapon;

	private Timer _selfDelayTimer;

	protected override void Awake()
	{
		//IL_0095: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_ShieldAlucard01");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
		PhaserSprite displaySprite = phaserSprite2.setScale(1.25f, (float?)(object)0);
		_displaySprite1 = displaySprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0060: Expected I, but got O
		//IL_0068: Expected I, but got O
		//IL_0078: Expected O, but got I
		//IL_00f8: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_047d: Expected O, but got I4
		//IL_00b4: Expected O, but got I
		//IL_0127: Expected O, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected F4, but got Unknown
		//IL_00ea: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_026a: Expected I, but got O
		//IL_02ce: Expected O, but got I4
		//IL_04a3: Expected O, but got F4
		//IL_04df: Expected O, but got I4
		//IL_043a: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite = _displaySprite1.setLocalPosition(localPosition);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0456;
		}
		nint num = (nint)typeof(TP_AlucardShield_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardShield_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardShield_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v89+FFFFFFF8+v293 @ rax_v84*8]");
			if (0 == (nint)typeof(TP_AlucardShield_Weapon))
			{
				obj3 = 1;
				goto IL_0465;
			}
		}
		obj3 = 0;
		goto IL_0465;
		IL_0465:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0456;
		IL_0456:
		_trueWeapon = (TP_AlucardShield_Weapon)trueWeapon;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float bodyRadius = _bodyRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num4 = bodyRadius ^ 0;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		float num5 = _weapon.PArea();
		if (!(1f < num4) || num4 < 4f)
		{
		}
		PhaserSprite phaserSprite2 = _displaySprite1.setAlpha(0f);
		ArcadeSprite arcadeSprite2 = setScale(num4, (float?)(object)0);
		UpdatePosition();
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite1 != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite3 = _displaySprite1.setAlpha(0f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween1 = alphaTween;
		float hitBoxDelay = weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num7 = hitBoxDelay * 0.001f;
		bool flag2 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitBoxTimer = Timers.Register(num7, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitBoxTimer = hitBoxTimer;
		float num8 = weapon.PDuration();
		Action onComplete2 = StartDespawn;
		float num9 = num7 * 0.001f;
		Timer durationTimer = Timers.Register(num9, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_durationTimer = durationTimer;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj5 = UnityEngine.Random.value;
		float num10 = num9 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num10 * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_AlucardShield1, soundConfig, 200f, 10, flag2 ? 1 : 0);
	}

	public void StartDespawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite1 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_AlucardShield_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween1 = alphaTween;
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		//IL_020f: Expected O, but got I4
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0312->IL01fb: Incompatible stack heights: 1 vs 0
		//IL_0152->IL01fb: Incompatible stack heights: 1 vs 0
		//IL_0181->IL01fb: Incompatible stack heights: 1 vs 0
		//IL_0398->IL01fb: Incompatible stack heights: 2 vs 0
		//IL_01d4->IL01fb: Incompatible stack heights: 2 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			TP_AlucardShield_Weapon trueWeapon = _trueWeapon;
			ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)_trueWeapon != null)
			{
				float num = (float)trueWeapon.SlotNumber / 3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				bool flag = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
				if (!flag)
				{
					bool flag2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
					bool flag3 = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
					if (!flag)
					{
						flag3 = flag2;
					}
					object obj = (flag3 ? 1 : 0) + (flag3 ? 1 : 0);
					object obj2 = obj - 1;
					object obj3 = obj ^ 1;
					object obj4 = obj ^ obj2;
					object obj5 = obj3 & obj4;
					bool flag4 = (nint)obj5 < 0;
					bool flag5 = (nint)obj2 < 0;
					bool flag6 = obj2 == null;
					bool flag7 = flag5 == flag4;
					bool flag8 = !flag6;
					bool flag9 = flag8 & flag7;
					((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag10 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							if (body != null)
							{
								float num2 = base.scale;
								((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag11 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
										if ((nint)obj > 1)
										{
										}
										float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
										float2 float6 = default(float2);
										base.position = float6;
										if ((object)_displaySprite1 != null)
										{
											PhaserSprite phaserSprite = _displaySprite1.setFlipX(flag9);
											int num3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
											if ((object)_displaySprite1 != null)
											{
												int num4 = num3 + 1;
												PhaserSprite phaserSprite2 = _displaySprite1.setDepth(num4);
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
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_selfDelayTimer != null)
		{
			_selfDelayTimer.Cancel();
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		if (_alphaTween2 != null)
		{
			_alphaTween2.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__9_1()
	{
		PhaserSprite phaserSprite = _displaySprite1.setAlpha(0f);
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
