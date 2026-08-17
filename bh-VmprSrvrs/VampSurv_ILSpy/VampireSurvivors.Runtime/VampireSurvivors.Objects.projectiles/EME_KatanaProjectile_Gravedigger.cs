using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KatanaProjectile_Gravedigger : Projectile
{
	private ParticleSystem _ParticleVFX;

	private const float VFXScale = 1f;

	private const float VFXDuration = 1700f;

	private const float MaxAreaLimit = 2.5f;

	private float2 _bodySize;

	private float2 _bodyOffset;

	private bool _cachedFlipX;

	private Timer _bodyTimer;

	private Timer _rockTimer;

	private Timer _expireTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00f8: Expected O, but got I8
		//IL_0114: Expected O, but got I4
		//IL_0405: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_0449: Expected O, but got I4
		//IL_0224: Expected F4, but got I4
		//IL_02f8: Expected I, but got O
		//IL_0090->IL0090: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		ParticleSystem particleVFX = _ParticleVFX;
		float num = default(float);
		if ((object)_ParticleVFX != null && ((UnityEngine.Object)particleVFX).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_ParticleVFX == null)
			{
				goto IL_0340;
			}
			Transform transform = _ParticleVFX.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			_ParticleVFX.Play(withChildren: true);
			float num2 = default(float);
			num = num2;
		}
		if ((object)weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				_cachedFlipX = characterController._isFlipped;
				ParticleSystem particleSystem = (ParticleSystem)4294967295L;
				if (!characterController._isFlipped)
				{
					particleSystem = (ParticleSystem)1;
				}
				if ((object)_weapon != null)
				{
					float num3 = _weapon.PArea();
					if (!(2.5f > num))
					{
						num = 2.5f;
					}
					float xScale = (float)particleSystem * num;
					ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
					BaseBody baseBody = body;
					if (body != null)
					{
						baseBody._enable = true;
						_bodySize = (float2)1114636288;
						_bodyOffset = (float2)0;
						UpdateBody();
						if (_bodyTimer != null)
						{
							_bodyTimer.Cancel();
						}
						Action onComplete = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
							Action onComplete4 = delegate
							{
								BaseBody baseBody2 = body;
								baseBody2._enable = false;
							};
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							Timer bodyTimer2 = Timers.Register(0.25f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							_bodyTimer = bodyTimer2;
						};
						bool flag2 = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer bodyTimer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_bodyTimer = bodyTimer;
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Rate = 1f;
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_gravedigger, soundConfig, 500f, 1, flag2 ? 1 : 0);
						if (_rockTimer != null)
						{
							_rockTimer.Cancel();
						}
						Action onComplete2 = FireRocks;
						Timer rockTimer = Timers.Register(0.45000002f, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_rockTimer = rockTimer;
						if (_expireTimer != null)
						{
							_expireTimer.Cancel();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_Gravedigger>)+370]");
						Action onComplete3 = new Action(this, (IntPtr)0);
						nint num4 = (nint)this;
						Timer expireTimer = Timers.Register(1.7f, onComplete3, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_expireTimer = expireTimer;
						return;
					}
				}
			}
		}
		goto IL_0340;
		IL_0340:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		UpdateBody();
	}

	private void UpdateBody()
	{
		//IL_009f: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_01a0: Expected O, but got F4
		//IL_01bd: Expected O, but got I
		//IL_011b: Expected O, but got I4
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 150f;
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_Gravedigger)+DC]");
			float num3 = num2 + 0f;
			if (num3 > 115f)
			{
				num3 = 115f;
			}
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			float num4;
			float2 float5;
			if (_cachedFlipX)
			{
				num4 = (float)_bodySize + 115f;
				float5 = _bodySize;
			}
			else
			{
				float5 = (float2)0;
				num4 = 115f;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num5 = (float)float5 + 230f;
			float num6 = deltaTime2 * num5;
			float num7 = num6 + (float)_bodyOffset;
			if (num7 > num4)
			{
				num7 = num4;
			}
			_bodyOffset = (float2)num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_Gravedigger)+DC]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num8 ^ 0;
			BaseBody baseBody3 = body.setOffset(num7, (float?)(object)1);
		}
	}

	public void FireRocks()
	{
		//IL_0020: Expected O, but got I8
		//IL_0039: Expected O, but got I4
		//IL_008d: Expected I, but got O
		//IL_0095: Expected I, but got O
		//IL_00a5: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_011e: Expected O, but got I
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0191: Expected O, but got I
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		float2 float5 = base.position;
		Weapon weapon = _weapon;
		float num = weapon.PArea();
		object obj = 4294967295L;
		if (!_cachedFlipX)
		{
			obj = 1;
		}
		float2 float6 = base.position;
		float num2 = _weapon.PAmount();
		object obj2 = obj + obj;
		bool flag = (nint)obj2 <= 0;
		Weapon weapon2 = null;
		if (flag)
		{
			return;
		}
		float2 pos = default(float2);
		while (true)
		{
			Weapon weapon3 = _weapon;
			nint num3 = (nint)typeof(EME_Katana1Weapon);
			nint num4 = (nint)weapon3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+130]");
			if (num5 < 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v14+FFFFFFF8+v117 @ rax_v13*8]");
			if (0 != (nint)typeof(EME_Katana1Weapon))
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v14+FFFFFFF8+v308 @ rcx_v10*8]");
			object obj6 = 0 - typeof(EME_Katana1Weapon);
			bool flag2 = obj6 == null;
			bool flag3 = !flag2;
			Weapon weapon4 = null;
			if (!flag3)
			{
				weapon4 = weapon3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v12 (VampireSurvivors.Objects.Weapons.Weapon)+1F0]");
			Projectile projectile = ((BulletPool)0).SpawnAt(pos, weapon3);
			weapon2 = (Weapon)(weapon2 + 1);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<Weapon, UIntPtr>(ref weapon2))
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void PlaySfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_gravedigger, soundConfig, 500f, 1, time);
	}

	public override void Despawn()
	{
		ParticleSystem particleVFX = _ParticleVFX;
		if ((object)_ParticleVFX != null && ((UnityEngine.Object)particleVFX).m_CachedPtr != (IntPtr)0)
		{
			_ParticleVFX.Clear(withChildren: true);
		}
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		if (_rockTimer != null)
		{
			_rockTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Action onComplete = delegate
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
	}

	private void _003CInitProjectile_003Eb__11_1()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
