using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MechProjectile_HailstormNew : Projectile
{
	private ParticleSystem _MissileVFX;

	private TrailRenderer _Trail;

	private const float VFXScale = 0.75f;

	private const float TrailDuration = 800f;

	private const float AccelRate = 1.5f;

	private const float BaseTurnSpeed = 425f;

	private const float TurnSpeedModifier = 15f;

	private const float InitialAngleModifier = 5f;

	private const float MinTimeToExplode = 150f;

	private const float MaxTimeToExplode = 250f;

	private bool _isTurning;

	private float _currentTurnSpeed;

	private float _currentSpeed;

	private float _currentAngle;

	private float _scaledTurnSpeed;

	private float _cachedWeaponSpeed;

	private Timer _movementTimer;

	private Timer _expireTimer;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0118: Expected O, but got I4
		//IL_0471: Expected O, but got I4
		//IL_027e: Expected F4, but got I4
		//IL_00db->IL00db: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			SetupTrail();
		}
		ParticleSystem missileVFX = _MissileVFX;
		float num4 = default(float);
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_MissileVFX == null)
			{
				goto IL_0283;
			}
			Transform transform = _MissileVFX.transform;
			float num2 = default(float);
			float num = num2 * 0.75f;
			float num3 = (float)Vector3.oneVector * 0.75f;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			_MissileVFX.Play(withChildren: true);
			num4 = num2;
		}
		if ((object)_weapon != null)
		{
			float num5 = _weapon.PArea();
			ArcadeSprite arcadeSprite = setScale(num4, (float?)(object)0);
			BaseBody baseBody = body;
			_isCullable = false;
			if (body != null)
			{
				baseBody._enable = true;
				_speed = 2f;
				if ((object)_weapon != null)
				{
					float num6 = _weapon.PSpeed();
					if (!(num4 > 0.01f))
					{
						num4 = 0.01f;
					}
					_cachedWeaponSpeed = num4;
					float projectileSpeed = base.ProjectileSpeed;
					_currentSpeed = num4;
					int num7 = index / 2;
					int num8 = index % 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
					int num9 = index / 2;
					int num10 = index % 2;
					object obj = default(object);
					float num11 = (float)obj * 15f;
					float scaledTurnSpeed = (_currentTurnSpeed = 425f - num11) * _cachedWeaponSpeed;
					_scaledTurnSpeed = scaledTurnSpeed;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
					object obj2 = default(object);
					float num12 = (float)obj2 * 5f;
					float num13 = (_currentAngle = num12 + 90f);
					if (num8 == 1)
					{
						float currentAngle = 180f - num13;
						_currentAngle = currentAngle;
					}
					_isTurning = true;
					float num14 = 425f / _cachedWeaponSpeed;
					if (_movementTimer != null)
					{
						_movementTimer.Cancel();
					}
					Action onComplete = delegate
					{
						//IL_0025: Expected O, but got I
						//IL_0086: Expected O, but got I8
						Timer expireTimer = _expireTimer;
						_isTurning = false;
						if (_expireTimer != null)
						{
							_expireTimer.Cancel();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj3 == null)
							{
								MissingMethodException ex = new MissingMethodException();
								throw ex;
							}
							expireTimer = (Timer)6573110936L;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v62 @ rax_v4 (should have been resolved before IL gen)");
						float num15 = 150f / _cachedWeaponSpeed;
						Action onComplete2 = Explode;
						float duration2 = num15 * 0.001f;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						Timer expireTimer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
						_expireTimer = expireTimer2;
					};
					float duration = num14 * 0.001f;
					bool flag2 = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer movementTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_movementTimer = movementTimer;
					UpdateVelocity();
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					float detune = (float)_indexInWeapon * -50f;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 5, flag2 ? 1 : 0);
					return;
				}
			}
		}
		goto IL_0283;
		IL_0283:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		UpdateVelocity();
	}

	private void UpdateVelocity()
	{
		//IL_005e: Expected O, but got I4
		//IL_0080: Expected I4, but got I8
		//IL_00fe: Expected O, but got F4
		//IL_019f: Expected O, but got I8
		//IL_0230: Expected O, but got I4
		//IL_00b0: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected I4, but got Unknown
		//IL_00da: Expected O, but got I4
		//IL_0243: Expected F4, but got O
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_isTurning;
		float num = deltaTime * 1.5f;
		float num2 = num + 1f;
		float currentSpeed = num2 * _currentSpeed;
		_currentSpeed = currentSpeed;
		object obj = 0;
		if (!flag)
		{
			int num3 = (int)(_indexInWeapon & 0x80000001L);
			if ((_isTurning ? 1 : 0) < (false ? 1 : 0))
			{
				object obj2 = num3 - 1;
				object obj3 = obj2 | -2;
				num3 = obj3 + 1;
			}
			bool flag2 = num3 == 1;
			object obj4 = 4294967295L;
			if (!flag2)
			{
				obj4 = 1;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num4 = (float)obj4 * _scaledTurnSpeed;
			float num5 = deltaTime2 * num4;
			float currentAngle = _currentAngle - num5;
			_currentAngle = currentAngle;
			obj = 0;
		}
		float num6 = _currentAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num7 = num6 * _currentSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		ArcadeSprite sprite = _sprite;
		float num8 = num6 * _currentSpeed;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num7;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void SetMovementPattern()
	{
		_isTurning = true;
		float num = 425f / _cachedWeaponSpeed;
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		Action onComplete = delegate
		{
			//IL_0025: Expected O, but got I
			//IL_0086: Expected O, but got I8
			Timer expireTimer = _expireTimer;
			_isTurning = false;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				expireTimer = (Timer)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v62 @ rax_v4 (should have been resolved before IL gen)");
			float num2 = 150f / _cachedWeaponSpeed;
			Action onComplete2 = Explode;
			float duration2 = num2 * 0.001f;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer expireTimer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer2;
		};
		float duration = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer movementTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_movementTimer = movementTimer;
	}

	private void SetupTrail()
	{
		//IL_0315->IL0291: Incompatible stack heights: 1 vs 0
		//IL_0364->IL0291: Incompatible stack heights: 1 vs 0
		//IL_01ea->IL0291: Incompatible stack heights: 3 vs 0
		//IL_0268->IL0291: Incompatible stack heights: 5 vs 0
		float saturationMax = default(float);
		float valueMin = default(float);
		float valueMax = default(float);
		float alphaMin = default(float);
		Color color = UnityEngine.Random.ColorHSV(0.5f, 0.6f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_Trail != null)
		{
			_Trail.time = 0.8f;
			if ((object)_Trail != null)
			{
				_Trail.startWidth = 0.05f;
				if ((object)_Trail != null)
				{
					_Trail.endWidth = 0.025f;
					Sprite sprite = default(Sprite);
					RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
					if ((object)_Trail != null)
					{
						Material material = ((Renderer)_Trail).GetMaterial();
						RenderingExtensions.SetAlpha(material, 1f);
						Renderer trail = _Trail;
						if ((object)_Trail != null)
						{
							bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
							TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
							if ((object)_Trail != null)
							{
								_Trail.emitting = true;
								Gradient gradient = new Gradient();
								IntPtr ptr = Gradient.Init();
								gradient.m_Ptr = ptr;
								gradient.m_RequiresNativeCleanup = true;
								GradientColorKey[] array = new GradientColorKey[2];
								if (array != null)
								{
									bool flag2 = array.Length <= 0;
									_ = color.r;
									_ = 0;
									bool flag3 = array.Length <= 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
									_ = 0;
									_ = 1f;
									GradientAlphaKey[] array2 = new GradientAlphaKey[2];
									if (array2 != null)
									{
										bool flag4 = array2.Length <= 0;
										_ = 1061997773;
										bool flag5 = array2.Length <= 1;
										_ = 0;
										_ = 1065353216;
										gradient.SetKeys(array, array2);
										if ((object)_Trail != null)
										{
											_Trail.colorGradient = gradient;
											TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
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

	private void Explode()
	{
		//IL_008a: Expected I, but got O
		//IL_0092: Expected I, but got O
		//IL_00a2: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_011b: Expected O, but got I
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0190: Expected O, but got I
		//IL_01de: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		ParticleSystem missileVFX = _MissileVFX;
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			_MissileVFX.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
		Weapon weapon = _weapon;
		nint num = (nint)typeof(EME_Mech2Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech2Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v11+FFFFFFF8+v86 @ rax_v10*8]");
			if (0 == (nint)typeof(EME_Mech2Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech2Weapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v11+FFFFFFF8+v336 @ rcx_v9*8]");
				object obj4 = 0 - typeof(EME_Mech2Weapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				Weapon weapon2 = null;
				if (!flag2)
				{
					weapon2 = weapon;
				}
				float2 float5 = base.position;
				float2 float6 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v11 (VampireSurvivors.Objects.Weapons.Weapon)+200]");
				float2 pos = default(float2);
				Projectile projectile = ((BulletPool)0).SpawnAt(pos, _weapon);
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile_HailstormNew>)+370]");
				Action onComplete = new Action(this, (IntPtr)0);
				nint num4 = (nint)this;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer expireTimer = Timers.Register(0.8f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_expireTimer = expireTimer;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -50f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 5, time);
	}

	public override void Despawn()
	{
		ParticleSystem missileVFX = _MissileVFX;
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			_MissileVFX.Clear(withChildren: true);
		}
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	private void _003CSetMovementPattern_003Eb__21_0()
	{
		//IL_0025: Expected O, but got I
		//IL_0086: Expected O, but got I8
		Timer expireTimer = _expireTimer;
		_isTurning = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			expireTimer = (Timer)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v62 @ rax_v4 (should have been resolved before IL gen)");
		float num = 150f / _cachedWeaponSpeed;
		Action onComplete = Explode;
		float duration = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer2 = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer2;
	}
}
