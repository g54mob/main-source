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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_GreatswordProjectile_AbsetzenBeam : Projectile
{
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public EME_GreatswordProjectile_AbsetzenBeam _003C_003E4__this;

		public float angleRad;

		public float velocity;

		internal void _003CMoveAtFinalAngle_003Eb__0()
		{
			//IL_008d: Expected I, but got O
			//IL_0067: Expected O, but got I
			EME_GreatswordProjectile_AbsetzenBeam eME_GreatswordProjectile_AbsetzenBeam = _003C_003E4__this;
			eME_GreatswordProjectile_AbsetzenBeam._Trail.emitting = true;
			Vector2 vector = _003C_003E4__this.SetVelocityFromRotation(angleRad, velocity);
			object obj = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rdi_v2 (System.Object)+100]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rdi_v2 (System.Object)+100]");
				((Timer)0).Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v3 (Il2CppClass<System.Object>)+370]");
			Action onComplete = new Action(obj, (IntPtr)0);
			nint num = (nint)obj;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	protected TrailRenderer _Trail;

	private ParticleSystem _TrailHeadFX;

	private const float Radius = 18f;

	private const float DelayDuration = 50f;

	private readonly List<EME_GreatswordProjectile_Absetzen> _targets;

	private int _targetIndex;

	private MultiTargetTween _moveTween;

	private Timer _delayTimer;

	private Timer _despawnTimer;

	private float _finalAngle;

	public List<EME_GreatswordProjectile_Absetzen> Targets => _targets;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_010e: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_01a3: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_Trail.emitting = false;
			float num = _weapon.PArea();
			float num3 = default(float);
			float num2 = num3 * 0.1f;
			_Trail.startWidth = num2;
			float num4 = _weapon.PArea();
			float endWidth = num2 * 0.08f;
			_Trail.endWidth = endWidth;
		}
		_isCullable = false;
		SetScaleToArea();
		BaseBody baseBody = body;
		baseBody._enable = true;
		BaseBody baseBody2 = body.setCircle(18f, (float?)(object)1, (float?)(object)1);
		nint num5 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v16 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num6 = 0;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody3 = sprite.body;
		baseBody3._velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		PlaySfx();
	}

	private void SetupTrail()
	{
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_Trail.emitting = false;
			float num = _weapon.PArea();
			object obj = default(object);
			float num2 = (float)obj * 0.1f;
			_Trail.startWidth = num2;
			float num3 = _weapon.PArea();
			float endWidth = num2 * 0.08f;
			_Trail.endWidth = endWidth;
		}
	}

	public void AddTarget(EME_GreatswordProjectile_Absetzen target)
	{
		if (_targets != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC060");
		}
	}

	public void PrepareToFire()
	{
		//IL_000d: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(EME_Greatsword2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v6+FFFFFFF8+v48 @ rax_v5*8]");
			if (0 == (nint)typeof(EME_Greatsword2Weapon))
			{
				if (_delayTimer != null)
				{
					_delayTimer.Cancel();
				}
				Action onComplete = SetInitialTarget;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer delayTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_delayTimer = delayTimer;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetInitialTarget()
	{
		if (_targets != null)
		{
			List<EME_GreatswordProjectile_Absetzen> targets = _targets;
			_targetIndex = 0;
			if (targets._size > 0)
			{
				EME_GreatswordProjectile_Absetzen[] items = targets._items;
				items[0].StartDespawn();
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 103 Invalid \"Jump target not found in method: 0x1871DEC20\"");
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private void SetNextTarget()
	{
		//IL_004b: Expected O, but got I4
		List<EME_GreatswordProjectile_Absetzen> targets = _targets;
		if (++_targetIndex < targets._size)
		{
			EME_GreatswordProjectile_Absetzen[] items = targets._items;
			object obj = _targetIndex + 1;
			float2 float5 = items[obj].position;
			Vector2 vector = default(Vector2);
			MoveTo(vector);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void MoveTo(Vector2 position)
	{
		//IL_0098: Expected I, but got O
		//IL_00ee: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		_Trail.emitting = true;
		PlaySfx();
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.x = (float?)(object)1;
		tweenConfig.delay = 50f;
		tweenConfig.duration = 100f;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_00a9: Expected O, but got I4
			_Trail.emitting = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			List<EME_GreatswordProjectile_Absetzen> targets = _targets;
			int targetIndex = _targetIndex;
			if (_targetIndex < targets._size)
			{
				EME_GreatswordProjectile_Absetzen[] items = targets._items;
				items[targetIndex].StartDespawn();
				List<EME_GreatswordProjectile_Absetzen> targets2 = _targets;
				object obj2 = targets2._size - 1;
				if (_targetIndex < (nint)obj2)
				{
					SetNextTarget();
				}
				else
				{
					MoveAtFinalAngle();
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween moveTween = Tweens.Add(tweenConfig);
		_moveTween = moveTween;
	}

	private void MoveAtFinalAngle()
	{
		//IL_01e8->IL0182: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass19_0();
		if (CS_0024_003C_003E8__locals9 != null)
		{
			CS_0024_003C_003E8__locals9._003C_003E4__this = this;
			PlaySfx();
			float angleRad = _finalAngle * ((float)Math.PI / 180f);
			CS_0024_003C_003E8__locals9.velocity = 20f;
			CS_0024_003C_003E8__locals9.angleRad = angleRad;
			ParticleSystem trailHeadFX = _TrailHeadFX;
			if ((object)_TrailHeadFX != null && ((UnityEngine.Object)trailHeadFX).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_TrailHeadFX == null)
				{
					goto IL_0131;
				}
				Transform transform = _TrailHeadFX.transform;
				Vector3 euler = default(Vector3);
				Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			}
			if (_delayTimer != null)
			{
				_delayTimer.Cancel();
			}
			Action onComplete = delegate
			{
				//IL_008d: Expected I, but got O
				//IL_0067: Expected O, but got I
				EME_GreatswordProjectile_AbsetzenBeam eME_GreatswordProjectile_AbsetzenBeam = CS_0024_003C_003E8__locals9._003C_003E4__this;
				eME_GreatswordProjectile_AbsetzenBeam._Trail.emitting = true;
				Vector2 vector = CS_0024_003C_003E8__locals9._003C_003E4__this.SetVelocityFromRotation(CS_0024_003C_003E8__locals9.angleRad, CS_0024_003C_003E8__locals9.velocity);
				object obj = CS_0024_003C_003E8__locals9._003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rdi_v2 (System.Object)+100]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rdi_v2 (System.Object)+100]");
					((Timer)0).Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v3 (Il2CppClass<System.Object>)+370]");
				Action onComplete2 = new Action(obj, (IntPtr)0);
				nint num = (nint)obj;
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				Timer timer = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer delayTimer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_delayTimer = delayTimer;
			return;
		}
		goto IL_0131;
		IL_0131:
		throw new NullReferenceException();
	}

	public unsafe float GetFinalAngle()
	{
		//IL_0025: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_057b: Expected I, but got O
		//IL_04be: Expected O, but got I
		//IL_075a: Expected F4, but got I4
		//IL_00ee: Expected I, but got O
		//IL_051b: Expected I, but got I8
		//IL_0145: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		//IL_01ed: Expected I, but got O
		//IL_021c: Expected I, but got O
		//IL_0266: Expected O, but got I4
		//IL_02c8: Expected O, but got I4
		//IL_035b: Expected O, but got I4
		//IL_03bd: Expected O, but got I4
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_006f->IL0520: Incompatible stack heights: 1 vs 0
		//IL_0520->IL073c: Incompatible stack heights: 3 vs 2
		//IL_0120->IL0520: Incompatible stack heights: 2 vs 0
		//IL_018f->IL0520: Incompatible stack heights: 3 vs 0
		//IL_05af->IL04ae: Incompatible stack heights: 4 vs 2
		//IL_0225->IL04ae: Incompatible stack heights: 4 vs 2
		//IL_024e->IL0520: Incompatible stack heights: 4 vs 0
		//IL_02b0->IL0520: Incompatible stack heights: 5 vs 0
		//IL_0306->IL0520: Incompatible stack heights: 6 vs 0
		//IL_0339->IL0520: Incompatible stack heights: 6 vs 0
		//IL_060e->IL0520: Incompatible stack heights: 7 vs 0
		//IL_03a5->IL0520: Incompatible stack heights: 8 vs 0
		//IL_03fb->IL0520: Incompatible stack heights: 9 vs 0
		//IL_042e->IL0520: Incompatible stack heights: 9 vs 0
		//IL_06db->IL075f: Incompatible stack heights: 10 vs 2
		//IL_048b->IL0520: Incompatible stack heights: 10 vs 0
		//IL_073c->IL06cc: Incompatible stack heights: 12 vs 10
		List<EME_GreatswordProjectile_Absetzen> targets = _targets;
		if (_targets != null)
		{
			int num = targets._size;
			object obj = targets._size - 2;
			bool flag = (nint)obj >= targets._size;
			EME_GreatswordProjectile_Absetzen[] items = targets._items;
			if (targets._items != null)
			{
				object obj2 = targets._size - 2;
				bool flag2 = (nint)obj2 >= items.Length;
				object obj3 = items[obj2];
				bool flag3 = (object)items[obj2] == null;
				nint num2 = (nint)typeof(UnityEngine.Object);
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v13 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					num2 = (nint)typeof(UnityEngine.Object);
					if (!flag4)
					{
						List<EME_GreatswordProjectile_Absetzen> targets2 = _targets;
						if (_targets != null)
						{
							num = targets2._size;
							object obj4 = targets2._size - 1;
							bool flag5 = (nint)obj4 >= targets2._size;
							items = targets2._items;
							if (targets2._items != null)
							{
								object obj5 = targets2._size - 1;
								bool flag6 = (nint)obj5 >= items.Length;
								object obj6 = items[obj5];
								num2 = (nint)typeof(UnityEngine.Object);
								if ((object)items[obj5] != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v17 (System.Object)+10]");
									bool flag7 = (nint)0 == 0;
									num2 = (nint)typeof(UnityEngine.Object);
									if (!flag7)
									{
										List<EME_GreatswordProjectile_Absetzen> targets3 = _targets;
										if (_targets != null)
										{
											object obj7 = targets3._size - 2;
											bool flag8 = (nint)obj7 >= targets3._size;
											EME_GreatswordProjectile_Absetzen[] items2 = targets3._items;
											if (targets3._items != null)
											{
												object obj8 = targets3._size - 2;
												bool flag9 = (nint)obj8 >= items2.Length;
												if ((object)items2[obj8] != null)
												{
													Transform transform = items2[obj8].transform;
													if ((object)transform != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v53 (UnityEngine.Transform)+10]");
														bool flag10 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v53 (UnityEngine.Transform)+10]");
														Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
														List<EME_GreatswordProjectile_Absetzen> targets4 = _targets;
														if (_targets != null)
														{
															object obj9 = targets4._size - 1;
															bool flag11 = (nint)obj9 >= targets4._size;
															EME_GreatswordProjectile_Absetzen[] items3 = targets4._items;
															if (targets4._items != null)
															{
																object obj10 = targets4._size - 1;
																bool flag12 = (nint)obj10 >= items3.Length;
																if ((object)items3[obj10] != null)
																{
																	Transform transform2 = items3[obj10].transform;
																	if ((object)transform2 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v61 (UnityEngine.Transform)+10]");
																		bool flag13 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v61 (UnityEngine.Transform)+10]");
																		float ret2;
																		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
																		object obj11 = default(object);
																		object obj12 = default(object);
																		float num3 = (float)obj11 - (float)obj12;
																		object obj13 = ret2 - ret;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
																		object trailHeadFX = _TrailHeadFX;
																		float num4 = num3 * 57.29578f;
																		float finalAngle = num4 + 90f;
																		_finalAngle = finalAngle;
																		if ((object)_TrailHeadFX != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v20 (System.Object)+10]");
																			if ((nint)0 != 0)
																			{
																				if ((object)_TrailHeadFX == null)
																				{
																					goto IL_0520;
																				}
																				Transform transform3 = _TrailHeadFX.transform;
																				Quaternion.Internal_FromEulerRad_Injected(ref ret, out *(Quaternion*)(&ret2));
																				bool flag14 = (object)transform3 == null;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1357 @ rax_v74 (UnityEngine.Transform)+10]");
																				bool flag15 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1357 @ rax_v74 (UnityEngine.Transform)+10]");
																				float value = default(float);
																				Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
																			}
																		}
																		return _finalAngle;
																	}
																}
															}
														}
													}
												}
											}
										}
										goto IL_0520;
									}
								}
								goto IL_04ae;
							}
						}
						goto IL_0520;
					}
				}
				goto IL_04ae;
			}
		}
		goto IL_0520;
		IL_0520:
		throw new NullReferenceException();
		IL_04ae:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag16 = obj14 == null;
			nint num2 = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v797 @ rax_v40 (should have been resolved before IL gen)");
		_finalAngle = 0f;
		return 0f;
	}

	public float GetRandomAngle()
	{
		//IL_0010: Expected O, but got I
		//IL_00ae: Expected F4, but got I4
		//IL_0076: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		EME_GreatswordProjectile_AbsetzenBeam eME_GreatswordProjectile_AbsetzenBeam = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			eME_GreatswordProjectile_AbsetzenBeam = (EME_GreatswordProjectile_AbsetzenBeam)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46 @ rax_v2 (should have been resolved before IL gen)");
		_finalAngle = 0f;
		return 0f;
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0079: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 2f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_absetzen, soundConfig, 200f, 10, time);
	}

	private void StartDespawn()
	{
		//IL_0030: Expected I, but got O
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_AbsetzenBeam>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		_Trail.emitting = false;
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		List<EME_GreatswordProjectile_Absetzen> targets = _targets;
		int version = targets._version + 1;
		targets._version = version;
		targets._size = 0;
		if (targets._size > 0)
		{
			Array.Clear(targets._items, 0, targets._size);
		}
		if (_delayTimer != null)
		{
			_delayTimer.Cancel();
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		base.Despawn();
	}

	public EME_GreatswordProjectile_AbsetzenBeam()
	{
		List<EME_GreatswordProjectile_Absetzen> targets = new List<EME_GreatswordProjectile_Absetzen>();
		_targets = targets;
		base._002Ector();
	}

	private void _003CMoveTo_003Eb__18_0()
	{
		//IL_00a9: Expected O, but got I4
		_Trail.emitting = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		List<EME_GreatswordProjectile_Absetzen> targets = _targets;
		int targetIndex = _targetIndex;
		if (_targetIndex < targets._size)
		{
			EME_GreatswordProjectile_Absetzen[] items = targets._items;
			items[targetIndex].StartDespawn();
			List<EME_GreatswordProjectile_Absetzen> targets2 = _targets;
			object obj = targets2._size - 1;
			if (_targetIndex < (nint)obj)
			{
				SetNextTarget();
			}
			else
			{
				MoveAtFinalAngle();
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}
}
