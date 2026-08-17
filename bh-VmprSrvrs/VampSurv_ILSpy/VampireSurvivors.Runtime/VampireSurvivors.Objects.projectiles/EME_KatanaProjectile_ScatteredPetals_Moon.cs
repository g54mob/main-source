using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KatanaProjectile_ScatteredPetals_Moon : Projectile
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public float gravity;

		public EME_KatanaProjectile_ScatteredPetals_Moon _003C_003E4__this;

		internal void _003CLaunch_003Eb__0()
		{
			float num = gravity - 0.2f;
			gravity = num;
			float2 position = _003C_003E4__this.position;
			float2 position2 = _003C_003E4__this.position;
			float deltaTime = PauseSystem.DeltaTime;
			float2 position3 = default(float2);
			_003C_003E4__this.position = position3;
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public SpriteRenderer[] faces;

		internal void _003CPlayShatterVfx_003Eb__0()
		{
			//IL_015f->IL00f6: Incompatible stack heights: 1 vs 0
			SpriteRenderer[] array = faces;
			if (array.Length == 0)
			{
				return;
			}
			SpriteRenderer spriteRenderer = array[0];
			if ((object)array[0] != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				SpriteRenderer[] array2 = faces;
				if (array2.Length <= 0)
				{
					throw new IndexOutOfRangeException();
				}
				Transform transform = array2[0].transform;
				Transform parent = transform.parent;
				Transform transform2 = parent.transform;
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
			}
		}
	}

	private SpriteRenderer _MoonVFX;

	private ParticleSystem ShatterFX;

	private GameObject TearGO;

	private const float GlobalScale = 1f;

	private const float MoonVFXScale = 0.75f;

	private const float Radius = 100f;

	private ShatterVFX _shatterVfx;

	private MultiTargetTween[] _tweens;

	private Timer _expireTimer;

	private MultiTargetTween _moveTween;

	private MultiTargetTween _fadeTween;

	private MultiTargetTween _scaleTween;

	private EME_Katana2Weapon _trueWeapon;

	private Action m_OnDespawn;

	public event Action OnDespawn
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 288;
			Delegate obj2 = this.m_OnDespawn;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 288;
			Delegate obj2 = this.m_OnDespawn;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0068: Expected I, but got O
		//IL_0070: Expected I, but got O
		//IL_0080: Expected O, but got I
		//IL_0100: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_00bc: Expected O, but got I
		//IL_00f2: Expected O, but got I4
		//IL_0190: Expected O, but got I4
		//IL_0190: Expected O, but got I4
		//IL_0338: Expected O, but got I4
		//IL_0226: Expected O, but got Ref
		//IL_03b1->IL02ec: Incompatible stack heights: 1 vs 0
		//IL_024a->IL02ec: Incompatible stack heights: 1 vs 0
		//IL_026c->IL02ec: Incompatible stack heights: 1 vs 0
		//IL_029d->IL02ec: Incompatible stack heights: 1 vs 0
		//IL_02bb->IL02ec: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		if ((object)TearGO == null)
		{
			goto IL_02ec;
		}
		TearGO.SetActive(value: true);
		InitShatterVfx();
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_02f3;
		}
		nint num = (nint)typeof(EME_Katana2Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rax_v49+FFFFFFF8+v365 @ rax_v44*8]");
			if (0 == (nint)typeof(EME_Katana2Weapon))
			{
				obj3 = 1;
				goto IL_0302;
			}
		}
		obj3 = 0;
		goto IL_0302;
		IL_02ec:
		throw new NullReferenceException();
		IL_0302:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_02f3;
		IL_02f3:
		_trueWeapon = (EME_Katana2Weapon)trueWeapon;
		BaseBody baseBody = body;
		_isCullable = false;
		if (body != null)
		{
			baseBody._enable = true;
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(100f, (float?)(object)1, (float?)(object)1);
				if ((object)_weapon != null)
				{
					float num4 = _weapon.PArea();
					if ((object)_trueWeapon != null)
					{
						float num5 = default(float);
						if (2.5f > num5)
						{
							ArcadeSprite arcadeSprite = setScale(2.5f, (float?)(object)0);
							if ((object)_MoonVFX == null)
							{
								goto IL_02ec;
							}
						}
						Transform transform = _MoonVFX.transform;
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						float2 value = default(float2);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
						if ((object)_cachedTransform != null)
						{
							Vector3 vector = default(Vector3);
							_cachedTransform.eulerAngles = (Vector3)(&vector);
							Weapon weapon3 = _weapon;
							if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
							{
								float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
								if ((object)_trueWeapon != null)
								{
									float2 float6 = default(float2);
									base.position = float6;
									Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 476 Invalid \"Jump target not found in method: 0x1871E9700\"");
								}
							}
						}
					}
				}
			}
		}
		goto IL_02ec;
	}

	private void Launch()
	{
		//IL_00bc: Expected I, but got O
		//IL_0138: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.gravity = 5f;
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		if (!characterController._isFlipped || _moveTween != null)
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
		float2 float5 = base.position;
		tweenConfig.rotateMode = RotateMode.FastBeyond360;
		tweenConfig.duration = 500f;
		tweenConfig.x = (float?)(object)1;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onUpdate = delegate
		{
			float gravity = CS_0024_003C_003E8__locals7.gravity - 0.2f;
			CS_0024_003C_003E8__locals7.gravity = gravity;
			float2 float6 = CS_0024_003C_003E8__locals7._003C_003E4__this.position;
			float2 float7 = CS_0024_003C_003E8__locals7._003C_003E4__this.position;
			float deltaTime = PauseSystem.DeltaTime;
			float2 float8 = default(float2);
			CS_0024_003C_003E8__locals7._003C_003E4__this.position = float8;
		};
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onComplete = Explode;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween moveTween = Tweens.Add(tweenConfig);
		_moveTween = moveTween;
	}

	private void Explode()
	{
		//IL_0054: Expected O, but got I4
		TearGO.SetActive(value: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		PlayShatterVfx();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Window, soundConfig, 200f, 3, time);
	}

	private void InitShatterVfx()
	{
		//IL_0096: Expected O, but got I4
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx == null || ((UnityEngine.Object)shatterVfx).m_CachedPtr == (IntPtr)0)
		{
			ShatterVFX.ShatterDetails shatterDetails = new ShatterVFX.ShatterDetails();
			shatterDetails.horizontalCuts = 8;
			shatterDetails.verticalCuts = 8;
			shatterDetails.shatterType = ShatterVFX.ShatterType.Radial;
			shatterDetails.radialSectors = 13;
			shatterDetails.radials = 3;
			shatterDetails.radialCentre = (Vector2)1056964608;
			_ = 1056964608;
			shatterDetails.randomSeed = 61;
			shatterDetails.randomizeAtRunTime = false;
			shatterDetails.randomness = 1f;
			GameObject gameObject = _MoonVFX.gameObject;
			ShatterVFX shatterVfx2 = gameObject.AddComponent<ShatterVFX>();
			_shatterVfx = shatterVfx2;
			ShatterVFX shatterVfx3 = _shatterVfx;
			shatterVfx3.shatterDetails = shatterDetails;
		}
	}

	private unsafe void PlayShatterVfx()
	{
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_025f: Expected O, but got I4
		//IL_0270: Expected O, but got I4
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_05c7: Expected I, but got O
		//IL_05dd: Expected O, but got I
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected O, but got Unknown
		//IL_0654: Expected I, but got O
		//IL_096e: Expected O, but got I4
		//IL_0985: Expected I, but got I8
		//IL_09a6: Expected I, but got O
		//IL_0673: Expected I, but got O
		//IL_0689: Expected O, but got I
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Expected O, but got Unknown
		//IL_0705: Expected I, but got O
		//IL_063d: Expected I, but got I8
		//IL_09fe: Expected I, but got I8
		//IL_06d8: Expected I, but got I8
		//IL_03ae: Expected O, but got I
		//IL_0352: Expected I, but got O
		//IL_0443: Expected I, but got O
		//IL_04b6: Expected O, but got I4
		//IL_08a0: Expected O, but got F4
		//IL_08ce: Expected O, but got I4
		//IL_0a3d: Expected O, but got F4
		//IL_0a7a: Expected O, but got I4
		//IL_08dc: Expected O, but got F4
		//IL_0935: Expected O, but got I4
		//IL_0508: Expected I, but got O
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		//IL_07fc->IL0778: Incompatible stack heights: 1 vs 0
		//IL_0196->IL0778: Incompatible stack heights: 1 vs 0
		//IL_0233->IL0778: Incompatible stack heights: 1 vs 0
		//IL_0376->IL0376: Incompatible stack heights: 6 vs 5
		//IL_0461->IL0461: Incompatible stack heights: 11 vs 10
		//IL_052b->IL052b: Incompatible stack heights: 14 vs 13
		//IL_0579->IL093a: Incompatible stack heights: 14 vs 1
		_003C_003Ec__DisplayClass20_0 obj = new _003C_003Ec__DisplayClass20_0();
		TweenCallback tweenCallback;
		if ((object)ShatterFX != null)
		{
			ShatterFX.Play(withChildren: true);
			if ((object)_shatterVfx != null)
			{
				SpriteRenderer[] faces = _shatterVfx.Shatter();
				if (obj != null)
				{
					obj.faces = faces;
					SpriteRenderer[] faces2 = obj.faces;
					if (obj.faces != null && (object)faces2[0] != null)
					{
						Transform transform = faces2[0].transform;
						if ((object)transform != null)
						{
							Transform parent = transform.parent;
							if ((object)parent != null)
							{
								Transform transform2 = parent.transform;
								if ((object)transform2 != null)
								{
									bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									float value = default(float);
									Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
									GameObject gameObject = parent.gameObject;
									if ((object)gameObject != null)
									{
										gameObject.SetActive(value: true);
										MultiTargetTween[] tweens = _tweens;
										bool flag2 = _tweens == null;
										Transform transform3 = null;
										Transform transform4 = null;
										if (!flag2)
										{
											while ((nint)transform4 < tweens.Length)
											{
												if (tweens[(object)transform3] != null)
												{
													tweens[(object)transform3].Kill();
													transform3 = (Transform)(transform3 + 1);
													transform4 = transform3;
												}
												else
												{
													transform3 = (Transform)(transform3 + 1);
													transform4 = transform3;
												}
											}
											SpriteRenderer[] faces3 = obj.faces;
											if (obj.faces != null)
											{
												MultiTargetTween[] tweens2 = new MultiTargetTween[faces3.Length];
												_tweens = tweens2;
												object obj2 = 0;
												float num2 = default(float);
												float num = num2;
												object obj3 = 0;
												object obj5 = default(object);
												object obj9 = default(object);
												while (true)
												{
													SpriteRenderer[] faces4 = obj.faces;
													bool flag3 = obj.faces == null;
													if ((nint)obj3 >= faces4.Length)
													{
														break;
													}
													MultiTargetTween[] tweens3 = _tweens;
													TweenConfig tweenConfig = new TweenConfig();
													object[] array = new object[2];
													object faces5 = obj.faces;
													bool flag4 = obj.faces == null;
													object obj4 = obj2;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1432 @ rbx_v21 (System.Object)+18]");
													bool flag5 = (nint)obj4 >= 0;
													bool flag6 = array == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1432 @ rbx_v21 (System.Object)+20+v375 @ r14_v14*8]");
													if ((nint)0 != 0)
													{
														nint num3 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag7 = obj5 == null;
													}
													bool flag8 = array.Length <= 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1432 @ rbx_v21 (System.Object)+20+v375 @ r14_v14*8]");
													array[0] = 0;
													SpriteRenderer[] faces6 = obj.faces;
													bool flag9 = obj.faces == null;
													bool flag10 = (nint)obj2 >= faces6.Length;
													Transform transform5 = (Transform)(object)faces6[obj2];
													bool flag11 = (object)faces6[obj2] == null;
													bool flag12 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
													IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)transform5).m_CachedPtr);
													Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
													if ((object)transform6 != null)
													{
														Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform6);
														bool flag13 = (object)transform7 == null;
													}
													bool flag14 = array.Length <= 1;
													array[1] = transform6;
													bool flag15 = tweenConfig == null;
													tweenConfig.targets = array;
													tweenConfig.alpha = (float?)(object)1;
													object obj6 = UnityEngine.Random.value;
													float num4 = num * 360f;
													float num5 = num4 - 90f;
													tweenConfig.angle = (float?)(object)1;
													object obj7 = UnityEngine.Random.value;
													float num6 = num5 - 0.5f;
													float num7 = num6 * 1.5f;
													float num8 = num7 + num7;
													tweenConfig.localX = (float?)(object)1;
													object obj8 = UnityEngine.Random.value;
													float num9 = num8 - 0.5f;
													tweenConfig.ease = Ease.InOutSine;
													tweenConfig.duration = 1000f;
													float num10 = num9 * 1.2f;
													num = num10 + num10;
													tweenConfig.localY = (float?)(object)1;
													MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
													bool flag16 = _tweens == null;
													if (multiTargetTween != null)
													{
														nint num11 = (nint)tweens3;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag17 = obj9 == null;
													}
													bool flag18 = (nint)obj2 >= tweens3.Length;
													tweens3[obj2] = multiTargetTween;
													obj2++;
													obj3 = obj2;
												}
												tweenCallback = null;
												nint num12 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1629 @ r10_v4 (Il2CppMethodInfo)+8]");
												((Delegate)tweenCallback).method_ptr = (IntPtr)0;
												((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass20_0._003CPlayShatterVfx_003Eb__0);
												((Delegate)tweenCallback).m_target = obj;
												((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1629 @ r10_v4 (Il2CppMethodInfo)+4C]");
												object obj10 = (nint)0 >> 4;
												object obj11 = obj10 & 1;
												nint num13;
												if (obj11 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1629 @ r10_v4 (Il2CppMethodInfo)+52]");
													if ((nint)0 == 0)
													{
														num13 = unchecked((nint)6447293664L);
														goto IL_0965;
													}
												}
												((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
												num13 = ((Delegate)tweenCallback).method_ptr;
												goto IL_0965;
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
		IL_09e7:
		TweenCallback tweenCallback2;
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		Tween tween;
		if (tween != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1738 @ rax_v65 (DG.Tweening.Tween)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag19 = tween == null;
		return;
		IL_0965:
		object obj12 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		tween = DOVirtual.DelayedCall(1.1500001f, tweenCallback, ignoreTimeScale: false);
		tweenCallback2 = null;
		nint num14 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1761 @ rcx_v53 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_ScatteredPetals_Moon>)+370]");
		nint method = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r10_v5 (System.IntPtr)+8]");
		((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback2).method = method;
		((Delegate)tweenCallback2).m_target = this;
		((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r10_v5 (System.IntPtr)+4C]");
		object obj13 = (nint)0 >> 4;
		object obj14 = obj13 & 1;
		nint num15;
		if (obj14 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r10_v5 (System.IntPtr)+52]");
			bool flag20 = (nint)0 == 0;
			num15 = unchecked((nint)6447293664L);
			if (flag20)
			{
				goto IL_09e7;
			}
		}
		num15 = ((Delegate)tweenCallback2).method_ptr;
		((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
		goto IL_09e7;
	}

	private void KillTweens()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		MultiTargetTween[] tweens = _tweens;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				tweens[obj2].Kill();
			}
			obj2++;
			obj = obj2;
		}
	}

	private static void KillTween(MultiTargetTween[] tweens)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				tweens[obj2].Kill();
			}
			obj2++;
			obj = obj2;
		}
	}

	public override void Despawn()
	{
		//IL_00b9: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_moveTween != null)
		{
			_moveTween.Kill();
		}
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		MultiTargetTween[] tweens = _tweens;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < tweens.Length)
		{
			if (tweens[obj] != null)
			{
				tweens[obj].Kill();
			}
			obj++;
			obj2 = obj;
		}
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx != null && ((UnityEngine.Object)shatterVfx).m_CachedPtr != (IntPtr)0)
		{
			_shatterVfx.Destroy();
		}
		Action onDespawn = this.m_OnDespawn;
		if (this.m_OnDespawn != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v356.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		this.m_OnDespawn = null;
		base.Despawn();
	}

	public EME_KatanaProjectile_ScatteredPetals_Moon()
	{
		MultiTargetTween[] tweens = new MultiTargetTween[0];
		_tweens = tweens;
		base._002Ector();
	}
}
