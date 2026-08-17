using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Vent2Projectile : Projectile
{
	private sealed class _003CAnimateKillCounter_003Ed__41(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Vent2Projectile _003C_003E4__this;

		public int objectsSucked;

		private float _003CanimateT_003E5__2;

		private string _003CfullString_003E5__3;

		private int _003CfullStringLength_003E5__4;

		private int _003CcurrentStringLength_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0210: Expected I4, but got I8
			//IL_043f: Expected I4, but got O
			//IL_025b: Expected I4, but got O
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected I4, but got Unknown
			//IL_036d: Expected F4, but got I4
			//IL_036d: Expected F4, but got O
			//IL_036d: Expected F4, but got O
			//IL_036d: Expected O, but got I4
			Vent2Projectile vent2Projectile = _003C_003E4__this;
			string translation = default(string);
			bool flag = default(bool);
			GameObject gameObject = default(GameObject);
			string text = default(string);
			bool flag2 = default(bool);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Vent2Weapon trueWeapon = vent2Projectile._trueWeapon;
					if ((object)vent2Projectile._trueWeapon != null && (object)trueWeapon._ejectionText != null)
					{
						trueWeapon._ejectionText.enabled = true;
						Vent2Weapon trueWeapon2 = vent2Projectile._trueWeapon;
						if ((object)vent2Projectile._trueWeapon != null && (object)trueWeapon2._ejectionText != null)
						{
							trueWeapon2._ejectionText.text = "";
							_003CanimateT_003E5__2 = 0f;
							translation = LocalizationManager.GetTranslation("weaponLang/{C1_VENT2}enemiesEjected", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, gameObject, text, flag2);
							int num = this + 40;
							string newValue = ((int*)num)->ToString();
							if (translation != null)
							{
								string text2 = translation.Replace("%0", newValue);
								_003CfullString_003E5__3 = text2;
								string text3 = _003CfullString_003E5__3;
								if (_003CfullString_003E5__3 != null)
								{
									_003CfullStringLength_003E5__4 = text3._stringLength;
									_003CcurrentStringLength_003E5__5 = 0;
									goto IL_046b;
								}
							}
						}
					}
				}
				goto IL_0431;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0423;
			}
			_003C_003E1__state = -1;
			goto IL_046b;
			IL_046b:
			if (2f > _003CanimateT_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num2 = deltaTime + _003CanimateT_003E5__2;
				_003CanimateT_003E5__2 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm1\"");
				bool flag3 = (nint)translation < _003CfullStringLength_003E5__4;
				int num3 = (int)translation;
				if (!flag3)
				{
					num3 = _003CfullStringLength_003E5__4;
				}
				if ((object)_003C_003E4__this != null)
				{
					Vent2Weapon trueWeapon3 = vent2Projectile._trueWeapon;
					if ((object)vent2Projectile._trueWeapon != null && _003CfullString_003E5__3 != null)
					{
						string text4 = _003CfullString_003E5__3.Substring(0, num3);
						if ((object)trueWeapon3._ejectionText != null)
						{
							trueWeapon3._ejectionText.text = text4;
							if (num3 != _003CcurrentStringLength_003E5__5)
							{
								_003CcurrentStringLength_003E5__5 = num3;
								PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_EjectText, 10f, 10, 0f, (float?)(object)flag, (float)gameObject, (float)text, flag2, 1f);
							}
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				Vent2Weapon trueWeapon4 = vent2Projectile._trueWeapon;
				if ((object)vent2Projectile._trueWeapon != null && (object)trueWeapon4._ejectionText != null)
				{
					trueWeapon4._ejectionText.enabled = false;
					goto IL_0423;
				}
			}
			goto IL_0431;
			IL_0423:
			return false;
			IL_0431:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CSpawnParticles_003Ed__37(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Vent2Projectile _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			//IL_00f6: Expected I4, but got O
			Vent2Projectile vent2Projectile = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null || (object)vent2Projectile._suckParticles == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				vent2Projectile._suckParticles.Emit(1000);
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private Vent2Weapon _trueWeapon;

	private bool _hasInitialisedGraphics;

	private TileSprite _stars;

	private float _starsWidthPixels = 500f;

	private float _doorThickness = 32f;

	private float _extendingTime = 500f;

	private float _openingTime = 500f;

	private float _closingTime = 500f;

	private float _retractingTime = 500f;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	private MultiTargetTween _tween5;

	private MultiTargetTween _tween6;

	private MultiTargetTween _tween7;

	private MultiTargetTween _tween8;

	private PhaserSprite _topDoor;

	private PhaserSprite _topDoorCap;

	private PhaserSprite _bottomDoor;

	private PhaserSprite _bottomDoorCap;

	private ParticleEmitterManager _suckParticleManager;

	private ParticleSystem _suckParticles;

	private GravityWell _suckParticleWell;

	public float _currentSuckLevel;

	private bool _xFlip;

	private bool _shouldStopASAP;

	private VampireSurvivors.Framework.TimerSystem.Timer _hitboxDelayTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _mainSuckingTimer;

	private bool _firstFiring = true;

	private HashSet<IDamageable> _objectsSucked;

	private float ExtraneousAnimationTimeMultiplier()
	{
		float num = _weapon.PInterval();
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		object obj = default(object);
		return (float)obj / currentWeaponData._003Cinterval_003Ek__BackingField;
	}

	private float BaseDoorHeight()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.height * 0.5f;
		float height = _topDoorCap.Height;
		return num - height;
	}

	private float CapHeight()
	{
		return _topDoorCap.Height;
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0066: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_0095: Expected F4, but got I4
		//IL_00ac: Expected I, but got O
		//IL_00b4: Expected I, but got O
		//IL_00c4: Expected O, but got I
		//IL_0144: Expected O, but got I4
		//IL_0100: Expected O, but got I
		//IL_0136: Expected O, but got I4
		//IL_021c: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		//IL_0473: Expected I, but got O
		//IL_04cb: Expected I, but got O
		//IL_0523: Expected I, but got O
		//IL_05c8: Expected I4, but got I8
		//IL_0770: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		_shouldStopASAP = false;
		_hitboxDelayTimer = null;
		_mainSuckingTimer = null;
		bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		bool xFlip = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		_xFlip = xFlip;
		ArcadeSprite arcadeSprite = setScale(_starsWidthPixels, (float?)(object)1);
		bool flag2 = !_xFlip;
		bool flag3 = !flag2;
		ArcadeSprite arcadeSprite2 = setOrigin(flag3 ? 1 : 0, (float?)(object)1);
		nint num = (nint)typeof(Vent2Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Vent2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Vent2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1084 @ rax_v129+FFFFFFF8+v1003 @ rax_v27*8]");
			if (0 == (nint)typeof(Vent2Weapon))
			{
				obj3 = 1;
				goto IL_06ca;
			}
		}
		obj3 = 0;
		goto IL_06ca;
		IL_06ca:
		bool flag4 = obj3 == null;
		Weapon trueWeapon = null;
		if (!flag4)
		{
			trueWeapon = weapon;
		}
		_trueWeapon = (Vent2Weapon)trueWeapon;
		if (!_hasInitialisedGraphics)
		{
			_hasInitialisedGraphics = true;
			InitialiseGraphics();
		}
		_stars.SetVisible(visible: true);
		PhaserSprite phaserSprite = _topDoor.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _bottomDoor.setVisible(visible: true);
		PhaserSprite phaserSprite3 = _topDoorCap.setVisible(visible: true);
		PhaserSprite phaserSprite4 = _bottomDoorCap.setVisible(visible: true);
		PhaserSprite phaserSprite5 = _topDoorCap.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite6 = _bottomDoorCap.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite7 = _bottomDoorCap.setFlipY(flipY: true);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = default(PhaserScene);
			if (_xFlip)
			{
				float2 float5 = default(float2);
				base.position = float5;
				s_scene = ArcadePhysics.s_scene;
			}
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num4 = renderer.height * 0.5f;
			float2 float6 = base.position;
			float height = _topDoorCap.Height;
			float num5 = num4 * 0.5f;
			float num6 = height + num5;
			float num7 = 1.0653532E+09f + num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 float7 = _topDoor.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 float8 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj4 = num4 ^ 0;
			float num8 = (float)obj4 * 0.5f;
			float height2 = _topDoorCap.Height;
			float num9 = num8 - height2;
			float num10 = 1.0653532E+09f + num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 float9 = _bottomDoor.position;
			float num11 = 1.0653532E+09f + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			_currentSuckLevel = 0f;
			UpdateParticleSuck();
			if (_firstFiring)
			{
				_suckParticles.Clear(withChildren: true);
				_firstFiring = false;
			}
			_003CSpawnParticles_003Ed__37 obj5 = null;
			obj5._003C_003E1__state = 0;
			obj5._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj5);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[3];
			nint num12 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if ((object)_topDoor != null)
				{
					nint num13 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj7 = default(object);
					if (obj7 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if ((object)_bottomDoor != null)
				{
					nint num14 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					if (obj8 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = array;
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float num15 = renderer2.width * 0.5f;
				float num16 = num15 - 0.5f;
				bool flag5 = _xFlip;
				bool flag6 = true;
				if (!flag5)
				{
					flag6 = true;
				}
				float num17 = (float)(flag6 ? 1 : 0) * num16;
				tweenConfig.localX = (float?)(object)1;
				float num18 = _weapon.PInterval();
				Weapon weapon2 = _weapon;
				WeaponData currentWeaponData = weapon2._currentWeaponData;
				float num19 = num17 / currentWeaponData._003Cinterval_003Ek__BackingField;
				float duration = num19 * _extendingTime;
				tweenConfig.duration = duration;
				TweenCallback onComplete = delegate
				{
					//IL_0033: Expected F4, but got I4
					//IL_007b: Expected I, but got O
					//IL_01db: Expected I, but got O
					//IL_025d: Expected O, but got I4
					//IL_0329: Expected I, but got O
					//IL_039d: Unknown result type (might be due to invalid IL or missing references)
					//IL_03a2: Expected O, but got Unknown
					//IL_03c0: Expected O, but got I4
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_DoorOpen, 0f, 10, 0f, volume, rate, detune, loop, 1f);
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					if ((object)this != null)
					{
						nint num20 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj9 = default(object);
						if (obj9 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig2.targets = array2;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object value = default(object);
					bool flag7 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_currentSuckLevel", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig2.custom = dictionary;
					float num21 = _weapon.PInterval();
					Weapon weapon3 = _weapon;
					WeaponData currentWeaponData2 = weapon3._currentWeaponData;
					float num22 = 1f / currentWeaponData2._003Cinterval_003Ek__BackingField;
					float duration2 = num22 * _openingTime;
					tweenConfig2.duration = duration2;
					MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
					_tween2 = tween2;
					TweenConfig tweenConfig3 = new TweenConfig();
					object[] array3 = new object[1];
					if ((object)_topDoor != null)
					{
						nint num23 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj10 = default(object);
						if (obj10 == null)
						{
							ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
							throw ex5;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array3;
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					float num24 = renderer3.height * 0.65f;
					tweenConfig3.localY = (float?)(object)1;
					float num25 = _weapon.PInterval();
					Weapon weapon4 = _weapon;
					WeaponData currentWeaponData3 = weapon4._currentWeaponData;
					float num26 = num24 / currentWeaponData3._003Cinterval_003Ek__BackingField;
					float duration3 = num26 * _openingTime;
					tweenConfig3.duration = duration3;
					MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
					_tween3 = tween3;
					TweenConfig tweenConfig4 = new TweenConfig();
					object[] array4 = new object[1];
					if ((object)_bottomDoor != null)
					{
						nint num27 = (nint)array4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj11 = default(object);
						if (obj11 == null)
						{
							ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
							throw ex6;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig4.targets = array4;
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer4 = s_scene4._renderer;
					float height3 = renderer4.height;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					object obj12 = height3 ^ 0;
					float num28 = (float)obj12 * 0.65f;
					tweenConfig4.localY = (float?)(object)1;
					float num29 = _weapon.PInterval();
					Weapon weapon5 = _weapon;
					WeaponData currentWeaponData4 = weapon5._currentWeaponData;
					float num30 = num28 / currentWeaponData4._003Cinterval_003Ek__BackingField;
					float duration4 = num30 * _openingTime;
					tweenConfig4.duration = duration4;
					TweenCallback onComplete2 = StartSucking;
					tweenConfig4.onComplete = onComplete2;
					MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
					_tween4 = tween4;
				};
				tweenConfig.onComplete = onComplete;
				MultiTargetTween tween = Tweens.Add(tweenConfig);
				_tween1 = tween;
				return;
			}
			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
			throw ex3;
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		if (!((HashSet<object>)(object)_objectsSucked).Contains((object)other))
		{
			bool flag = ((HashSet<object>)(object)_objectsSucked).AddIfNotPresent((object)other);
		}
	}

	private IEnumerator SpawnParticles()
	{
		_003CSpawnParticles_003Ed__37 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void StartSucking()
	{
		_currentSuckLevel = 1f;
		float num = _weapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
		object obj = default(object);
		float num5 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if ((nint)obj > 1)
		{
			float num2 = _weapon.PDuration();
			float num4 = default(float);
			float num3 = num4 / (float)obj;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			num5 = num3 * 0.001f;
			VampireSurvivors.Framework.TimerSystem.Timer hitboxDelayTimer = Timers.Register(num5, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxDelayTimer = hitboxDelayTimer;
		}
		float num6 = _weapon.PDuration();
		Action onComplete2 = ReturnToNormal;
		float duration = num5 * 0.001f;
		VampireSurvivors.Framework.TimerSystem.Timer mainSuckingTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_mainSuckingTimer = mainSuckingTimer;
	}

	private void ReturnToNormal()
	{
		//IL_0038: Expected F4, but got I4
		//IL_0066: Expected I, but got O
		//IL_01c6: Expected I, but got O
		//IL_0266: Expected O, but got I4
		//IL_0332: Expected I, but got O
		//IL_039c: Expected O, but got I4
		_hitboxDelayTimer = null;
		_mainSuckingTimer = null;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_DoorClose, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_currentSuckLevel", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			float num2 = _weapon.PInterval();
			Weapon weapon = _weapon;
			WeaponData currentWeaponData = weapon._currentWeaponData;
			float num3 = 1f / currentWeaponData._003Cinterval_003Ek__BackingField;
			float duration = num3 * _closingTime;
			tweenConfig.duration = duration;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween5 = tween;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_topDoor != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float height = _topDoorCap.Height;
			float num5 = renderer.height * 0.25f;
			float num6 = height + num5;
			tweenConfig2.localY = (float?)(object)1;
			float num7 = _weapon.PInterval();
			Weapon weapon2 = _weapon;
			WeaponData currentWeaponData2 = weapon2._currentWeaponData;
			float num8 = num6 / currentWeaponData2._003Cinterval_003Ek__BackingField;
			float duration2 = num8 * _closingTime;
			tweenConfig2.duration = duration2;
			MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
			_tween6 = tween2;
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_bottomDoor != null)
			{
				nint num9 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			float height2 = _topDoorCap.Height;
			tweenConfig3.localY = (float?)(object)1;
			float num10 = _weapon.PInterval();
			Weapon weapon3 = _weapon;
			WeaponData currentWeaponData3 = weapon3._currentWeaponData;
			float num11 = height2 / currentWeaponData3._003Cinterval_003Ek__BackingField;
			float duration3 = num11 * _closingTime;
			tweenConfig3.duration = duration3;
			TweenCallback onComplete = delegate
			{
				//IL_0027: Expected I, but got O
				//IL_007f: Expected I, but got O
				//IL_00d7: Expected I, but got O
				//IL_017c: Expected O, but got I8
				//IL_02c3: Expected O, but got I4
				//IL_0193: Expected O, but got I4
				TweenConfig tweenConfig4 = new TweenConfig();
				object[] array4 = new object[3];
				if ((object)this != null)
				{
					nint num12 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if ((object)_topDoor != null)
				{
					nint num13 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if ((object)_bottomDoor != null)
				{
					nint num14 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
						throw ex6;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig4.targets = array4;
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float num15 = renderer2.width * 0.5f;
				float num16 = num15 + 1f;
				bool flag2 = _xFlip;
				float? num17 = (float?)(object)4294967295L;
				if (!flag2)
				{
					num17 = (float?)(object)1;
				}
				float num18 = (float)num17 * num16;
				tweenConfig4.localX = (float?)(object)1;
				float num19 = _weapon.PInterval();
				Weapon weapon4 = _weapon;
				WeaponData currentWeaponData4 = weapon4._currentWeaponData;
				float num20 = num18 / currentWeaponData4._003Cinterval_003Ek__BackingField;
				float duration4 = num20 * _retractingTime;
				tweenConfig4.duration = duration4;
				TweenCallback onComplete2 = DisplayKillCount;
				tweenConfig4.onComplete = onComplete2;
				MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
				_tween8 = tween4;
			};
			tweenConfig3.onComplete = onComplete;
			MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
			_tween7 = tween3;
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	private void DisplayKillCount()
	{
		//IL_00eb: Expected O, but got I4
		//IL_0033->IL008d: Incompatible stack heights: 1 vs 0
		//IL_0069->IL008d: Incompatible stack heights: 1 vs 0
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				goto IL_0086;
			}
			HashSet<IDamageable> objectsSucked = _objectsSucked;
			if (_objectsSucked != null)
			{
				_003CAnimateKillCounter_003Ed__41 obj2 = null;
				obj2._003C_003E1__state = 0;
				obj2._003C_003E4__this = this;
				obj2.objectsSucked = objectsSucked._count;
				if ((object)_trueWeapon != null)
				{
					Coroutine coroutine = _trueWeapon.StartCoroutine(obj2);
					goto IL_0086;
				}
			}
		}
		throw new NullReferenceException();
		IL_0086:
		Despawn();
	}

	private IEnumerator AnimateKillCounter(int objectsSucked)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CAnimateKillCounter_003Ed__41 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.objectsSucked = objectsSucked;
			return obj;
		}
		obj.objectsSucked = objectsSucked;
		return obj;
	}

	private unsafe void InitialiseGraphics()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b8: Expected I4, but got I8
		//IL_0251: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_0582: Expected O, but got I
		//IL_0678: Expected O, but got F4
		//IL_06aa: Expected O, but got I
		//IL_079f: Expected O, but got I
		//IL_09fe: Expected O, but got I
		//IL_0c6d: Expected O, but got F4
		//IL_0d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9a: Expected O, but got Unknown
		//IL_0df0: Expected O, but got Ref
		//IL_0e0a: Expected native int or pointer, but got O
		//IL_0e24: Expected O, but got I
		//IL_0e44: Expected O, but got Ref
		//IL_0e5e: Expected native int or pointer, but got O
		//IL_17df: Expected O, but got I
		//IL_0e96: Expected O, but got Ref
		//IL_0eb0: Expected native int or pointer, but got O
		//IL_0eca: Expected O, but got I
		//IL_0ef0: Expected O, but got Ref
		//IL_0f11: Expected O, but got I
		//IL_0f2b: Expected native int or pointer, but got O
		//IL_1819: Expected O, but got I
		//IL_0f63: Expected O, but got Ref
		//IL_0f7d: Expected native int or pointer, but got O
		//IL_1853: Expected O, but got I
		//IL_102a: Expected O, but got I
		//IL_1051: Expected O, but got I
		//IL_106c: Expected O, but got I
		//IL_1087: Expected O, but got I
		//IL_10a2: Expected O, but got I
		//IL_10bd: Expected O, but got I
		//IL_118c: Expected O, but got I4
		//IL_11a3: Expected O, but got I4
		//IL_12de: Expected I4, but got I8
		//IL_197f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1984: Expected O, but got Unknown
		//IL_1336: Expected O, but got I
		//IL_1358: Expected O, but got I4
		//IL_19db: Expected O, but got I
		//IL_1a13: Expected O, but got I
		//IL_15ee->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_0456->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_1615->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_048c->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_04eb->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_0515->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_053f->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_05a3->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_05cd->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_163c->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_060f->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_1663->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_06d4->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_06fe->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_0728->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_0780->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_07bb->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_07e5->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_168a->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_0827->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_0883->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_08b2->IL14a3: Incompatible stack heights: 1 vs 0
		//IL_16e4->IL14a3: Incompatible stack heights: 2 vs 0
		//IL_08de->IL14a3: Incompatible stack heights: 2 vs 0
		//IL_170b->IL14a3: Incompatible stack heights: 2 vs 0
		//IL_0914->IL14a3: Incompatible stack heights: 2 vs 0
		//IL_146a->IL1a3b: Incompatible stack heights: 46 vs 45
		//IL_14a3->IL1a60: Incompatible stack heights: 47 vs 46
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Vent2Projectile vent2Projectile = RenderingExtensions.SetScrollFactor(this, 0f);
		if ((object)vent2Projectile != null)
		{
			ArcadeSprite arcadeSprite = vent2Projectile.setTint(0u);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)arcadeSprite != null)
				{
					int num = (int)(4294967294L - renderer.pixelHeight);
					ArcadeSprite arcadeSprite2 = arcadeSprite.setDepth(num);
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
					{
						float width = _starsWidthPixels * 0.01f;
						float height = default(float);
						string textureName = default(string);
						string spriteName = default(string);
						TileSprite component = RenderingExtensions.AddTileSprite(this, 0f, 0f, width, height, textureName, spriteName);
						TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene3._renderer;
							if (s_scene3._renderer != null && (object)tileSprite != null)
							{
								int num2 = ~renderer2.pixelHeight;
								TileSprite stars = tileSprite.SetDepth(num2);
								_stars = stars;
								PhaserScene s_scene4 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer3 = s_scene4._renderer;
									if (s_scene4._renderer != null)
									{
										float num3 = (float)renderer3.pixelHeight * 0.5f;
										ArcadeSprite s_scene5 = (ArcadeSprite)(object)ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											float2 float5 = base.position;
											float2 float6 = base.displaySize;
											Vector2 vector = default(Vector2);
											PhaserSprite phaserSprite = RenderingExtensions.sprite((Factory)(nint)((UnityEngine.Object)s_scene5).m_CachedPtr, vector, "EjectionDoor_Top", "EjectionDoor_Top_0");
											Camera main = Camera.main;
											if ((object)main != null)
											{
												Transform parent = main.transform;
												if ((object)phaserSprite != null)
												{
													Transform transform = phaserSprite.transform;
													if ((object)transform != null)
													{
														transform.SetParent(parent, worldPositionStays: true);
														_ = 0;
														_ = 1065353216;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
														PhaserSprite phaserSprite2 = phaserSprite.setScale(1f, (float?)(object)0);
														if ((object)phaserSprite2 != null)
														{
															GameObject gameObject = phaserSprite2.gameObject;
															if ((object)gameObject != null)
															{
																((UnityEngine.Object)gameObject).SetName("TopDoor");
																PhaserScene s_scene6 = ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null)
																{
																	PhaserScene.Renderer renderer4 = s_scene6._renderer;
																	if (s_scene6._renderer != null)
																	{
																		int num4 = renderer4.pixelHeight + 1;
																		PhaserSprite topDoor = phaserSprite2.setDepth(num4);
																		_topDoor = topDoor;
																		ArcadeSprite topDoor2 = (ArcadeSprite)(object)_topDoor;
																		if ((object)_topDoor != null)
																		{
																			ArcadeSprite arcadeSprite3 = (ArcadeSprite)(object)topDoor2.body;
																			if (topDoor2.body != null)
																			{
																				bool flag = ((UnityEngine.Object)arcadeSprite3).m_CachedPtr == (IntPtr)0;
																				SpriteRenderer.set_drawMode_Injected(((UnityEngine.Object)arcadeSprite3).m_CachedPtr, SpriteDrawMode.Tiled);
																				PhaserSprite topDoor3 = _topDoor;
																				if ((object)_topDoor != null && (object)topDoor3._spriteRenderer != null)
																				{
																					topDoor3._spriteRenderer.size = vector;
																					PhaserScene s_scene7 = ArcadePhysics.s_scene;
																					if (ArcadePhysics.s_scene != null && (object)_topDoor != null)
																					{
																						float2 float7 = _topDoor.position;
																						PhaserSprite phaserSprite3 = RenderingExtensions.sprite(s_scene7.add, vector, "EjectionDoor_Top", "EjectionDoor_Top_1");
																						Camera main2 = Camera.main;
																						if ((object)main2 != null)
																						{
																							Transform parent2 = main2.transform;
																							if ((object)phaserSprite3 != null)
																							{
																								Transform transform2 = phaserSprite3.transform;
																								if ((object)transform2 != null)
																								{
																									transform2.SetParent(parent2, worldPositionStays: true);
																									_ = 0;
																									_ = 1065353216;
																									_ = 1;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																									PhaserSprite phaserSprite4 = phaserSprite3.setScale(1f, (float?)(object)0);
																									if ((object)phaserSprite4 != null)
																									{
																										GameObject gameObject2 = phaserSprite4.gameObject;
																										if ((object)gameObject2 != null)
																										{
																											((UnityEngine.Object)gameObject2).SetName("TopDoorCap");
																											PhaserScene s_scene8 = ArcadePhysics.s_scene;
																											if (ArcadePhysics.s_scene != null)
																											{
																												PhaserScene.Renderer renderer5 = s_scene8._renderer;
																												if (s_scene8._renderer != null)
																												{
																													int num5 = renderer5.pixelHeight + 2;
																													PhaserSprite topDoorCap = phaserSprite4.setDepth(num5);
																													_topDoorCap = topDoorCap;
																													ArcadeSprite s_scene9 = (ArcadeSprite)(object)ArcadePhysics.s_scene;
																													if (ArcadePhysics.s_scene != null)
																													{
																														float2 float8 = base.position;
																														float2 float9 = base.displaySize;
																														object obj3 = num3 ^ -0f;
																														float num6 = (float)obj3 * 0.5f;
																														PhaserSprite phaserSprite5 = RenderingExtensions.sprite((Factory)(nint)((UnityEngine.Object)s_scene9).m_CachedPtr, vector, "EjectionDoor_Top", "EjectionDoor_Top_0");
																														Camera main3 = Camera.main;
																														if ((object)main3 != null)
																														{
																															Transform parent3 = main3.transform;
																															if ((object)phaserSprite5 != null)
																															{
																																Transform transform3 = phaserSprite5.transform;
																																if ((object)transform3 != null)
																																{
																																	transform3.SetParent(parent3, worldPositionStays: true);
																																	PhaserSprite phaserSprite6 = phaserSprite5.setFlipY(flipY: true);
																																	_ = 0;
																																	_ = 1065353216;
																																	_ = 1;
																																	if ((object)phaserSprite6 != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																		PhaserSprite phaserSprite7 = phaserSprite6.setScale(1f, (float?)(object)0);
																																		if ((object)phaserSprite7 != null)
																																		{
																																			GameObject gameObject3 = phaserSprite7.gameObject;
																																			if ((object)gameObject3 != null)
																																			{
																																				((UnityEngine.Object)gameObject3).SetName("BottomDoor");
																																				PhaserScene s_scene10 = ArcadePhysics.s_scene;
																																				if (ArcadePhysics.s_scene != null)
																																				{
																																					PhaserScene.Renderer renderer6 = s_scene10._renderer;
																																					if (s_scene10._renderer != null)
																																					{
																																						int num7 = renderer6.pixelHeight + 1;
																																						PhaserSprite bottomDoor = phaserSprite7.setDepth(num7);
																																						_bottomDoor = bottomDoor;
																																						ArcadeSprite bottomDoor2 = (ArcadeSprite)(object)_bottomDoor;
																																						if ((object)_bottomDoor != null)
																																						{
																																							ArcadeSprite arcadeSprite4 = (ArcadeSprite)(object)bottomDoor2.body;
																																							if (bottomDoor2.body != null)
																																							{
																																								bool flag2 = ((UnityEngine.Object)arcadeSprite4).m_CachedPtr == (IntPtr)0;
																																								SpriteRenderer.set_drawMode_Injected(((UnityEngine.Object)arcadeSprite4).m_CachedPtr, SpriteDrawMode.Tiled);
																																								PhaserSprite bottomDoor3 = _bottomDoor;
																																								if ((object)_bottomDoor != null && (object)bottomDoor3._spriteRenderer != null)
																																								{
																																									bottomDoor3._spriteRenderer.size = vector;
																																									PhaserScene s_scene11 = ArcadePhysics.s_scene;
																																									if (ArcadePhysics.s_scene != null && (object)_topDoor != null)
																																									{
																																										float2 float10 = _topDoor.position;
																																										PhaserSprite phaserSprite8 = RenderingExtensions.sprite(s_scene11.add, vector, "EjectionDoor_Top", "EjectionDoor_Top_1");
																																										Camera main4 = Camera.main;
																																										bool flag3 = (object)main4 == null;
																																										Transform parent4 = main4.transform;
																																										bool flag4 = (object)phaserSprite8 == null;
																																										Transform transform4 = phaserSprite8.transform;
																																										bool flag5 = (object)transform4 == null;
																																										transform4.SetParent(parent4, worldPositionStays: true);
																																										_ = 0;
																																										_ = 1065353216;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										PhaserSprite phaserSprite9 = phaserSprite8.setScale(1f, (float?)(object)0);
																																										bool flag6 = (object)phaserSprite9 == null;
																																										GameObject gameObject4 = phaserSprite9.gameObject;
																																										bool flag7 = (object)gameObject4 == null;
																																										((UnityEngine.Object)gameObject4).SetName("BottomDoorCap");
																																										PhaserScene s_scene12 = ArcadePhysics.s_scene;
																																										bool flag8 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer7 = s_scene12._renderer;
																																										bool flag9 = s_scene12._renderer == null;
																																										int num8 = renderer7.pixelHeight + 2;
																																										PhaserSprite bottomDoorCap = phaserSprite9.setDepth(num8);
																																										_bottomDoorCap = bottomDoorCap;
																																										GameObject gameObject5 = new GameObject();
																																										GameObject.Internal_CreateGameObject(gameObject5, "Vent2ParticleSuckManager");
																																										bool flag10 = (object)gameObject5 == null;
																																										ParticleEmitterManager suckParticleManager = gameObject5.AddComponent<ParticleEmitterManager>();
																																										_suckParticleManager = suckParticleManager;
																																										bool flag11 = (object)_suckParticleManager == null;
																																										Transform transform5 = _suckParticleManager.transform;
																																										Camera main5 = Camera.main;
																																										bool flag12 = (object)main5 == null;
																																										Transform parent5 = main5.transform;
																																										bool flag13 = (object)transform5 == null;
																																										transform5.SetParent(parent5, worldPositionStays: true);
																																										PhaserScene s_scene13 = ArcadePhysics.s_scene;
																																										bool flag14 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer8 = s_scene13._renderer;
																																										bool flag15 = s_scene13._renderer == null;
																																										PhaserScene s_scene14 = ArcadePhysics.s_scene;
																																										bool flag16 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer9 = s_scene14._renderer;
																																										bool flag17 = s_scene14._renderer == null;
																																										PhaserScene s_scene15 = ArcadePhysics.s_scene;
																																										bool flag18 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer10 = s_scene15._renderer;
																																										bool flag19 = s_scene15._renderer == null;
																																										PhaserScene s_scene16 = ArcadePhysics.s_scene;
																																										bool flag20 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer11 = s_scene16._renderer;
																																										bool flag21 = s_scene16._renderer == null;
																																										Rectangle rectangle = new Rectangle();
																																										object obj4 = renderer8.width ^ -0f;
																																										float y = renderer9.height * 0.5f;
																																										float x = (float)obj4 * 0.5f;
																																										rectangle._y = y;
																																										rectangle._width = renderer10.width;
																																										rectangle._x = x;
																																										rectangle._height = renderer11.height;
																																										ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
																																										List<string> list = new List<string>();
																																										bool flag22 = list == null;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3183 @ rax_v153 (System.Collections.Generic.List`1<System.String>)+1C]");
																																										_ = (nint)0 + (nint)1;
																																										IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
																																										bool flag23 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
																																										CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1851 @ rcx_v136 (System.IntPtr)+18]");
																																										if ((nint)cancellationTokenSource >= 0)
																																										{
																																											((List<object>)(object)list).AddWithResize((object)"_blur3");
																																										}
																																										else
																																										{
																																											CancellationTokenSource cancellationTokenSource2 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
																																											((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource2;
																																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																										}
																																										bool flag24 = particleSystemConfig == null;
																																										particleSystemConfig._frame = list;
																																										ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
																																										_ = 0;
																																										_ = 0;
																																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(2000f, 5000f));
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
																																										particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
																																										_ = 0;
																																										ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
																																										_ = 0;
																																										_ = 0;
																																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 100f));
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
																																										_ = 0;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
																																										particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
																																										_ = 0;
																																										ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
																																										_ = 0;
																																										_ = 0;
																																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-100f, 100f));
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
																																										particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
																																										_ = 0;
																																										_ = 0;
																																										ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
																																										_ = 100;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										particleSystemConfig._quantity = (int?)(object)0;
																																										_ = 0;
																																										_ = 0;
																																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 1f));
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
																																										_ = 0;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
																																										particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
																																										_ = 0;
																																										ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
																																										_ = 0;
																																										_ = 0;
																																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 1f));
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+88]");
																																										_ = 0;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
																																										particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
																																										_ = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
																																										_ = 0;
																																										particleSystemConfig._emitZone = new EmitZone
																																										{
																																											_type = EmitZoneType.Random,
																																											_source = rectangle
																																										};
																																										particleSystemConfig._tintRandom = new uint[4] { 16777215u, 16755370u, 11206570u, 11184895u };
																																										_ = 0;
																																										_ = 1120403456;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										particleSystemConfig._frequency = (float?)(object)0;
																																										_ = 0;
																																										_ = 1;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										particleSystemConfig._blendMode = (BlendMode?)(object)0;
																																										_ = 257;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										particleSystemConfig._collideTop = (bool?)(object)0;
																																										_ = 257;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										particleSystemConfig._collideBottom = (bool?)(object)0;
																																										_ = 257;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										particleSystemConfig._collideLeft = (bool?)(object)0;
																																										_ = 257;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										particleSystemConfig._collideRight = (bool?)(object)0;
																																										particleSystemConfig._on = false;
																																										PhaserScene s_scene17 = ArcadePhysics.s_scene;
																																										bool flag25 = ArcadePhysics.s_scene == null;
																																										bool flag26 = s_scene17._renderer == null;
																																										PhaserScene s_scene18 = ArcadePhysics.s_scene;
																																										bool flag27 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer12 = s_scene18._renderer;
																																										bool flag28 = s_scene18._renderer == null;
																																										PhaserScene s_scene19 = ArcadePhysics.s_scene;
																																										bool flag29 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer13 = s_scene19._renderer;
																																										bool flag30 = s_scene19._renderer == null;
																																										PhaserScene s_scene20 = ArcadePhysics.s_scene;
																																										bool flag31 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer14 = s_scene20._renderer;
																																										bool flag32 = s_scene20._renderer == null;
																																										object obj5 = -renderer12.pixelHeight;
																																										object obj6 = renderer13.pixelWidth + renderer13.pixelWidth;
																																										float num9 = (float)obj5 * 0.5f;
																																										particleSystemConfig._bounds = (Rect?)vector;
																																										_ = renderer14.pixelHeight;
																																										Camera main6 = Camera.main;
																																										bool flag33 = (object)main6 == null;
																																										Transform parent6 = main6.transform;
																																										bool flag34 = (object)_suckParticleManager == null;
																																										ParticleSystem suckParticles = _suckParticleManager.CreateEmitter(particleSystemConfig, parent6, "vfx");
																																										_suckParticles = suckParticles;
																																										bool flag35 = (object)_suckParticles == null;
																																										Transform transform6 = _suckParticles.transform;
																																										bool flag36 = (object)transform6 == null;
																																										bool flag37 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
																																										Vector2 value = default(Vector2);
																																										Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)(&value));
																																										GravityWellConfig gravityWellConfig = new GravityWellConfig();
																																										PhaserScene s_scene21 = ArcadePhysics.s_scene;
																																										bool flag38 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer15 = s_scene21._renderer;
																																										bool flag39 = s_scene21._renderer == null;
																																										_ = 0;
																																										bool flag40 = _xFlip;
																																										EmitZoneType emitZoneType = (EmitZoneType)(-1);
																																										if (!flag40)
																																										{
																																											emitZoneType = EmitZoneType.Random;
																																										}
																																										object obj7 = emitZoneType * renderer15.width;
																																										_ = 1;
																																										bool flag41 = gravityWellConfig == null;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										((UnityEngine.Object)(object)gravityWellConfig).m_CachedPtr = (IntPtr)0;
																																										_ = 0;
																																										_ = 0;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
																																										((MonoBehaviour)(object)gravityWellConfig).m_CancellationTokenSource = (CancellationTokenSource)0;
																																										((GameMonoBehaviour)(object)gravityWellConfig)._onPauseSent = false;
																																										_ = 1140457472;
																																										((PhaserGameObject)(object)gravityWellConfig).body = (BaseBody)1120403456;
																																										Camera main7 = Camera.main;
																																										bool flag42 = (object)main7 == null;
																																										Transform parent7 = main7.transform;
																																										bool flag43 = (object)_suckParticleManager == null;
																																										GravityWell suckParticleWell = _suckParticleManager.CreateGravityWell(gravityWellConfig, parent7, "Vent2SuckWell");
																																										_suckParticleWell = suckParticleWell;
																																										PhaserScene s_scene22 = ArcadePhysics.s_scene;
																																										bool flag44 = ArcadePhysics.s_scene == null;
																																										PhaserScene.Renderer renderer16 = s_scene22._renderer;
																																										bool flag45 = s_scene22._renderer == null;
																																										RenderingExtensions.SetDepth(_suckParticles, renderer16.pixelHeight);
																																										bool flag46 = (object)_suckParticles == null;
																																										_ = _suckParticles;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																																										object obj8 = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																																										if ((nint)0 == 0)
																																										{
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																																											bool flag47 = obj8 == null;
																																										}
																																										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v4444 @ rax_v230 (should have been resolved before IL gen)");
																																										bool flag48 = (object)_suckParticles == null;
																																										_ = _suckParticles;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC0]");
																																										object obj9 = 0;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC0]");
																																										if ((nint)0 == 0)
																																										{
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																																											bool flag49 = obj9 == null;
																																										}
																																										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v4531 @ rax_v235 (should have been resolved before IL gen)");
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
		_stars.SetVisible(visible: false);
		PhaserSprite phaserSprite = _topDoor.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _bottomDoor.setVisible(visible: false);
		PhaserSprite phaserSprite3 = _topDoorCap.setVisible(visible: false);
		PhaserSprite phaserSprite4 = _bottomDoorCap.setVisible(visible: false);
		CleanupTweens();
		base.Despawn();
	}

	private void CleanupTweens()
	{
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		if (_tween5 != null)
		{
			_tween5.Kill();
		}
		if (_tween6 != null)
		{
			_tween6.Kill();
		}
		if (_tween7 != null)
		{
			_tween7.Kill();
		}
		if (_tween8 != null)
		{
			_tween8.Kill();
		}
	}

	protected override void OnDestroy()
	{
		Cleanup();
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
	}

	private void Cleanup()
	{
		CleanupTweens();
		TileSprite stars = _stars;
		if ((object)_stars != null && ((UnityEngine.Object)stars).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.Destroy(_stars, 0f);
			_stars = null;
		}
		PhaserSprite topDoor = _topDoor;
		if ((object)_topDoor != null && ((UnityEngine.Object)topDoor).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.Destroy(_topDoor, 0f);
			_topDoor = null;
		}
		PhaserSprite bottomDoor = _bottomDoor;
		if ((object)_bottomDoor != null && ((UnityEngine.Object)bottomDoor).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.Destroy(_bottomDoor, 0f);
			_bottomDoor = null;
		}
		PhaserSprite topDoorCap = _topDoorCap;
		if ((object)_topDoorCap != null && ((UnityEngine.Object)topDoorCap).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.Destroy(_topDoorCap, 0f);
			_topDoorCap = null;
		}
		PhaserSprite bottomDoorCap = _bottomDoorCap;
		if ((object)_bottomDoorCap != null && ((UnityEngine.Object)bottomDoorCap).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.Destroy(_bottomDoorCap, 0f);
			_bottomDoorCap = null;
		}
		GravityWell suckParticleWell = _suckParticleWell;
		if ((object)_suckParticleWell != null && ((UnityEngine.Object)suckParticleWell).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _suckParticleWell.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
			_suckParticleWell = null;
		}
		ParticleSystem suckParticles = _suckParticles;
		if ((object)_suckParticles != null && ((UnityEngine.Object)suckParticles).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj2 = _suckParticles.gameObject;
			UnityEngine.Object.Destroy(obj2, 0f);
			_suckParticles = null;
		}
		ParticleEmitterManager suckParticleManager = _suckParticleManager;
		if ((object)_suckParticleManager != null && ((UnityEngine.Object)suckParticleManager).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj3 = _suckParticleManager.gameObject;
			UnityEngine.Object.Destroy(obj3, 0f);
			_suckParticleManager = null;
		}
	}

	private void UpdateParticleSuck()
	{
		if ((object)_suckParticleWell != null)
		{
			Transform transform = _suckParticleWell.transform;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
			{
				if (!_xFlip)
				{
				}
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				GravityWell suckParticleWell = _suckParticleWell;
				float num = _weapon.PArea();
				float num2 = _currentSuckLevel * 100f;
				object obj = default(object);
				float num3 = num2 * (float)obj;
				float power = num3 * suckParticleWell._gravity;
				suckParticleWell._power = power;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void LateUpdate()
	{
		//IL_0186: Invalid comparison between F4 and I4
		//IL_0632: Expected O, but got I8
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_01bf: Expected O, but got I4
		//IL_0204: Expected O, but got I
		//IL_0237: Expected I, but got O
		//IL_023f: Expected I, but got O
		//IL_024f: Expected O, but got I
		//IL_0287: Expected O, but got I
		//IL_0495: Expected I, but got O
		//IL_049e: Expected I, but got O
		//IL_04ae: Expected O, but got I
		//IL_04e6: Expected O, but got I
		//IL_0198->IL0532: Incompatible stack heights: 3 vs 0
		//IL_0532->IL0532: Incompatible stack heights: 4 vs 0
		//IL_02d1->IL0640: Incompatible stack heights: 6 vs 4
		//IL_02f6->IL0640: Incompatible stack heights: 6 vs 4
		//IL_031b->IL0640: Incompatible stack heights: 6 vs 4
		//IL_0340->IL0640: Incompatible stack heights: 6 vs 4
		//IL_0365->IL0640: Incompatible stack heights: 6 vs 4
		//IL_038a->IL0640: Incompatible stack heights: 6 vs 4
		//IL_03af->IL0640: Incompatible stack heights: 6 vs 4
		//IL_044f->IL0640: Incompatible stack heights: 7 vs 4
		//IL_052d->IL0640: Incompatible stack heights: 10 vs 4
		if (PauseSystem._paused)
		{
			return;
		}
		Transform transform = _stars.transform;
		float2 center = getCenter();
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		TileSprite stars = _stars;
		Transform transform2 = base.transform;
		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
		stars._spriteScroller.SetScrollOffsetX(ret);
		TileSprite stars2 = _stars;
		Transform transform3 = base.transform;
		bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)(&ret));
		float num = default(float);
		stars2._spriteScroller.SetScrollOffsetY(num);
		float2 float5 = _topDoor.position;
		float height = _topDoor.Height;
		float num2 = height * 0.5f;
		object obj = default(object);
		float num3 = (float)obj - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float6 = _bottomDoor.position;
		float height2 = _topDoor.Height;
		float num4 = height2 * 0.5f;
		float num5 = (float)obj + num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		UpdateParticleSuck();
		if (!(_currentSuckLevel > 0f))
		{
			return;
		}
		Transform transform4 = base.transform;
		bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)(&ret));
		bool flag5 = _xFlip;
		object obj2 = 4294967295L;
		if (!flag5)
		{
			obj2 = 1;
		}
		object obj3 = obj2 + ret;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		float2 float7 = default(float2);
		while (enumerator.MoveNext())
		{
			Transform transform5 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+28]");
			if ((nint)0 == 0)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+28]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1797 @ rax_v74+40]");
			if ((nint)0 == 0)
			{
				continue;
			}
			nint num6 = (nint)typeof(EnemyController);
			nint num7 = (nint)transform5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1405 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1335 @ r8_v16 (Il2CppClass<UnityEngine.Transform>)+130]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1405 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
			bool flag6 = num8 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1335 @ r8_v16 (Il2CppClass<UnityEngine.Transform>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1453 @ rax_v76+FFFFFFF8+v1452 @ rax_v75*8]");
			bool flag7 = 0 != (nint)typeof(EnemyController);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+19C]");
			if ((nint)0 == 806)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+19C]");
			if ((nint)0 == 252)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+19C]");
			if ((nint)0 == 211)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+19C]");
			if ((nint)0 == 62)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+19C]");
			if ((nint)0 == 1054)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+19C]");
			if ((nint)0 == 1080)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rbx_v21 (UnityEngine.Transform)+19C]");
			if ((nint)0 != 1055)
			{
				Transform transform6 = ((Component)null).transform;
				bool flag8 = (object)transform6 == null;
				Vector3 vector = transform6.position;
				float num9 = num - (float)float7;
				float num10 = (float)obj3 - vector.x;
				float num11 = num9 * num9;
				float num12 = num10 * num10;
				float num13 = num12 + num11;
				if (0.1f < num13)
				{
					float deltaTime = PauseSystem.DeltaTime;
					bool flag9 = (object)_weapon == null;
					float num14 = _weapon.PArea();
					nint num15 = (nint)typeof(EnemyController);
					nint num16 = (nint)transform5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ r8_v18 (Il2CppClass<UnityEngine.Transform>)+130]");
					nint num17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
					bool flag10 = num17 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ r8_v18 (Il2CppClass<UnityEngine.Transform>)+C8]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ rax_v82+FFFFFFF8+v1241 @ rax_v81*8]");
					bool flag11 = 0 != (nint)typeof(EnemyController);
					float2 float8 = ((ArcadeSprite)null).position;
					((ArcadeSprite)null).position = float7;
				}
			}
		}
	}

	public void TryStoppingEarly()
	{
		//IL_0129: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		if (_shouldStopASAP || _mainSuckingTimer == null)
		{
			return;
		}
		bool flag = _hitboxDelayTimer == null;
		_shouldStopASAP = true;
		if (!flag)
		{
			_hitboxDelayTimer.Cancel();
			_hitboxDelayTimer = null;
		}
		VampireSurvivors.Framework.TimerSystem.Timer mainSuckingTimer = _mainSuckingTimer;
		if (!_mainSuckingTimer.IsDone)
		{
			if (mainSuckingTimer._onComplete != null)
			{
				Action onComplete = mainSuckingTimer._onComplete;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v203.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			mainSuckingTimer._003CIsCompleted_003Ek__BackingField = true;
			float timeElapsed = _mainSuckingTimer.GetTimeElapsed();
			mainSuckingTimer._timeElapsedBeforeCancel = (float?)(object)1;
			mainSuckingTimer._timeElapsedBeforePause = (float?)(object)0;
		}
		_mainSuckingTimer = null;
	}

	public Vent2Projectile()
	{
		HashSet<IDamageable> objectsSucked = (HashSet<IDamageable>)(object)new HashSet<object>();
		_objectsSucked = objectsSucked;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__35_0()
	{
		//IL_0033: Expected F4, but got I4
		//IL_007b: Expected I, but got O
		//IL_01db: Expected I, but got O
		//IL_025d: Expected O, but got I4
		//IL_0329: Expected I, but got O
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03c0: Expected O, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_DoorOpen, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)this != null)
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_currentSuckLevel", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		float num2 = _weapon.PInterval();
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float num3 = 1f / currentWeaponData._003Cinterval_003Ek__BackingField;
		float duration = num3 * _openingTime;
		tweenConfig.duration = duration;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween2 = tween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_topDoor != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num5 = renderer.height * 0.65f;
		tweenConfig2.localY = (float?)(object)1;
		float num6 = _weapon.PInterval();
		Weapon weapon2 = _weapon;
		WeaponData currentWeaponData2 = weapon2._currentWeaponData;
		float num7 = num5 / currentWeaponData2._003Cinterval_003Ek__BackingField;
		float duration2 = num7 * _openingTime;
		tweenConfig2.duration = duration2;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
		_tween3 = tween2;
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_bottomDoor != null)
		{
			nint num8 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float height = renderer2.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = height ^ 0;
		float num9 = (float)obj4 * 0.65f;
		tweenConfig3.localY = (float?)(object)1;
		float num10 = _weapon.PInterval();
		Weapon weapon3 = _weapon;
		WeaponData currentWeaponData3 = weapon3._currentWeaponData;
		float num11 = num9 / currentWeaponData3._003Cinterval_003Ek__BackingField;
		float duration3 = num11 * _openingTime;
		tweenConfig3.duration = duration3;
		TweenCallback onComplete = StartSucking;
		tweenConfig3.onComplete = onComplete;
		MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
		_tween4 = tween3;
	}

	private void _003CStartSucking_003Eb__38_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CReturnToNormal_003Eb__39_0()
	{
		//IL_0027: Expected I, but got O
		//IL_007f: Expected I, but got O
		//IL_00d7: Expected I, but got O
		//IL_017c: Expected O, but got I8
		//IL_02c3: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)this != null)
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
		if ((object)_topDoor != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_bottomDoor != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num4 = renderer.width * 0.5f;
		float num5 = num4 + 1f;
		bool flag = _xFlip;
		float? num6 = (float?)(object)4294967295L;
		if (!flag)
		{
			num6 = (float?)(object)1;
		}
		float num7 = (float)num6 * num5;
		tweenConfig.localX = (float?)(object)1;
		float num8 = _weapon.PInterval();
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float num9 = num7 / currentWeaponData._003Cinterval_003Ek__BackingField;
		float duration = num9 * _retractingTime;
		tweenConfig.duration = duration;
		TweenCallback onComplete = DisplayKillCount;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween8 = tween;
	}
}
