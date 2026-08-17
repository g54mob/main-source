using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_DualSwordsProjectile_Torrent : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__21_1;

		public static TweenCallback _003C_003E9__21_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnRecycleSelf_003Eb__21_1()
		{
		}

		internal void _003COnRecycleSelf_003Eb__21_2()
		{
		}
	}

	private ParticleSystem FX;

	private const float Radius = 25f;

	private float _spinRadiusX = 1f;

	private float _spinRadiusY = 1f;

	private float _spinSpeed = 0.001f;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private EME_DualSwordsWeapon _trueWeapon;

	private bool _initialisedParticles;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private Timer _DespawnTimer;

	private Timer _hitboxTimer;

	private bool isMoving;

	private float _elapsedSpinTime;

	private float2 _originalPosition;

	public float SpinSpeed
	{
		get
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			float num = _weapon.PSpeed();
			float num2 = default(float);
			float num3;
			if (!(num2 > 5f))
			{
				object obj = 5f & -2147483649L;
				bool flag = (nint)obj <= 2139095040;
				num3 = num2;
				if (flag)
				{
					goto IL_007f;
				}
			}
			num3 = 5f;
			goto IL_007f;
			IL_007f:
			return num3 * _spinSpeed;
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0052: Expected I, but got O
		//IL_005a: Expected I, but got O
		//IL_006a: Expected O, but got I
		//IL_00ea: Expected O, but got I4
		//IL_00a6: Expected O, but got I
		//IL_00dc: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_elapsedSpinTime = 1f;
		if (_initialisedParticles)
		{
			goto IL_00fe;
		}
		Weapon weapon2 = _weapon;
		_initialisedParticles = true;
		bool flag = (object)_weapon == null;
		EME_DualSwordsWeapon trueWeapon = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)typeof(EME_DualSwordsWeapon);
			nint num2 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_DualSwordsWeapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_DualSwordsWeapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v13+FFFFFFF8+v112 @ rax_v9*8]");
				if (0 == (nint)typeof(EME_DualSwordsWeapon))
				{
					obj3 = 1;
					goto IL_0142;
				}
			}
			obj3 = 0;
			goto IL_0142;
		}
		goto IL_0164;
		IL_0142:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = (EME_DualSwordsWeapon)_weapon;
		}
		goto IL_0164;
		IL_0164:
		_trueWeapon = trueWeapon;
		goto IL_00fe;
		IL_00fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 146 Invalid \"Jump target not found in method: 0x1871D9470\"");
	}

	private void InitializeSelf()
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		Weapon weapon = _weapon;
		_initialisedParticles = true;
		EME_DualSwordsWeapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0101;
		}
		nint num = (nint)typeof(EME_DualSwordsWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_DualSwordsWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_DualSwordsWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v15+FFFFFFF8+v45 @ rax_v10*8]");
			if (0 == (nint)typeof(EME_DualSwordsWeapon))
			{
				obj3 = 1;
				goto IL_0110;
			}
		}
		obj3 = 0;
		goto IL_0110;
		IL_0110:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (EME_DualSwordsWeapon)_weapon;
		}
		goto IL_0101;
		IL_0101:
		_trueWeapon = trueWeapon;
	}

	private void OnRecycleSelf()
	{
		//IL_0052: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_015f: Invalid comparison between I4 and F4
		//IL_017f: Expected F4, but got I4
		//IL_01f2: Expected I, but got O
		//IL_0264: Expected O, but got I4
		//IL_033d: Expected O, but got I4
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		//IL_0372: Expected O, but got I4
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_058d: Expected O, but got I4
		//IL_05bc: Expected F4, but got I4
		//IL_05dc: Expected O, but got I4
		//IL_0614: Expected F4, but got I4
		//IL_0634: Expected O, but got I4
		//IL_066c: Expected F4, but got I4
		if ((object)FX != null)
		{
			FX.Play(withChildren: true);
		}
		BaseBody baseBody = body;
		_isCullable = false;
		baseBody._enable = true;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody2 = body.setCircle(25f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num = hitBoxDelay * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		float num2 = _weapon.PArea();
		float num3 = num - 1f;
		if (0f > num3)
		{
			num3 = 0f;
		}
		float num4 = num3 * 0.5f;
		float num5 = num4 + 1f;
		bool flag2 = num5 > 3f;
		float num6 = 3f;
		if (!flag2)
		{
			num6 = num5;
		}
		if (_tween != null)
		{
			_tween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num7 = (nint)array;
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
		tweenConfig.duration = 150f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__21_1;
		if (_003C_003Ec._003C_003E9__21_1 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__21_1 = delegate
			{
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete2 = _003C_003Ec._003C_003E9__21_2;
		if (_003C_003Ec._003C_003E9__21_2 == null)
		{
			onComplete2 = (_003C_003Ec._003C_003E9__21_2 = delegate
			{
			});
		}
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween = tween;
		Weapon weapon = _weapon;
		float2 originalPosition = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Weapon weapon2 = _weapon;
		_originalPosition = originalPosition;
		float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		Weapon weapon3 = _weapon;
		bool flag3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.flipX;
		object obj2 = (flag3 ? 1 : 0) * 2;
		object obj3 = obj2 - 1;
		int num8 = ~_indexInWeapon;
		int num9 = num8 & 1;
		object obj4 = num9 * 2;
		object obj5 = obj4 - 1;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num10 = renderer.width * 0.5f;
			float spinRadiusX = num10 * (float)obj3;
			_spinRadiusX = spinRadiusX;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float num11 = renderer2.height * 0.5f;
				Weapon weapon4 = _weapon;
				float num12 = num11 * (float)obj5;
				float spinRadiusY = num12 - 0.32f;
				_spinRadiusY = spinRadiusY;
				bool flag4 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.flipX;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					if (s_scene3._renderer != null && (object)GM.Core != null)
					{
						PhaserScene s_scene4 = ArcadePhysics.s_scene;
						if (s_scene4._renderer != null)
						{
							float num13 = _weapon.PDuration();
							Action onComplete3 = StartDespawn;
							float duration = (float)obj5 * 0.001f;
							Timer despawnTimer = Timers.Register(duration, onComplete3, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_DespawnTimer = despawnTimer;
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
							soundConfig.Volume = (float?)(object)1;
							soundConfig.Rate = 1f;
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_mwind1, soundConfig, 400f, 12, flag ? 1 : 0);
							SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
							soundConfig2.Volume = (float?)(object)1;
							soundConfig2.Rate = 1f;
							soundConfig2.Detune = -1000f;
							PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_mwind1, soundConfig2, 400f, 12, flag ? 1 : 0);
							SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
							soundConfig3.Volume = (float?)(object)1;
							soundConfig3.Rate = 1f;
							soundConfig3.Detune = -2000f;
							PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.sfx_mwind1, soundConfig3, 400f, 12, flag ? 1 : 0);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_0095: Expected I, but got O
		//IL_0107: Expected O, but got I4
		if ((object)FX != null)
		{
			FX.Stop();
		}
		if (_tween != null)
		{
			_tween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 350f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween = tween;
	}

	public override void Despawn()
	{
		//IL_0100: Expected O, but got I4
		if ((object)FX != null)
		{
			FX.Clear(withChildren: true);
		}
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_DespawnTimer != null)
		{
			_DespawnTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		base.Despawn();
	}

	public override void InternalUpdate()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		float num = _elapsedSpinTime / (float)Math.PI;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		float num2 = num * 0.25f;
		float num3 = num2 + 1f;
		if (!(num3 > 5f))
		{
			object obj = 5f & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_0167;
			}
		}
		num3 = 5f;
		goto IL_0167;
		IL_013f:
		throw new NullReferenceException();
		IL_01a4:
		float num5;
		float num4 = num5 * _spinSpeed;
		float num7;
		float num6 = num4 * num7;
		float num8 = num6 * num3;
		float elapsedSpinTime = num8 + _elapsedSpinTime;
		_elapsedSpinTime = elapsedSpinTime;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			return;
		}
		goto IL_013f;
		IL_0167:
		float deltaTime = PauseSystem.DeltaTime;
		num7 = deltaTime * 1000f;
		if ((object)_weapon == null)
		{
			goto IL_013f;
		}
		float num9 = _weapon.PSpeed();
		if (!(deltaTime > 5f))
		{
			object obj2 = 5f & -2147483649L;
			bool flag2 = (nint)obj2 <= 2139095040;
			num5 = deltaTime;
			if (flag2)
			{
				goto IL_01a4;
			}
		}
		num5 = 5f;
		goto IL_01a4;
	}

	static EME_DualSwordsProjectile_Torrent()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003COnRecycleSelf_003Eb__21_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CStartDespawn_003Eb__22_0()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
	}

	private void _003CStartDespawn_003Eb__22_1()
	{
		Despawn();
	}
}
