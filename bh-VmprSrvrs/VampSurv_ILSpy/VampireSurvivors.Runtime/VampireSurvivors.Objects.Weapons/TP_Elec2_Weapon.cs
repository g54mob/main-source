using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Elec2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__13_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__13_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1463;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int __repeatInterval;

		public TP_Elec2_Weapon _003C_003E4__this;

		public Vector2 pos;

		public float __amount;

		public Action _003C_003E9__0;

		public Action _003C_003E9__2;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_010d: Invalid comparison between F4 and I4
			//IL_0133: Expected O, but got I4
			//IL_0079: Expected O, but got I4
			//IL_00ee: Invalid comparison between F4 and I4
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				object obj = (flag ? 1 : 0) * __repeatInterval;
				if ((nint)obj <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass17_1();
					CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = this;
					CS_0024_003C_003E8__locals7.localIndex = (flag ? 1 : 0);
					TP_Elec2_Weapon tP_Elec2_Weapon = _003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_0160: Expected O, but got I4
						//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
						{
							GameObject gameObject = obj3._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Elec2_Weapon tP_Elec2_Weapon2 = obj5._003C_003E4__this;
									if ((object)obj5._003C_003E4__this != null && (object)obj5._003C_003E4__this != null)
									{
										Vector2 vector = default(Vector2);
										Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals7.localIndex, tP_Elec2_Weapon2._targetTransform);
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					object obj2 = __repeatInterval * (flag ? 1 : 0);
					float duration = (float)obj2 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Elec2_Weapon._lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while (__amount > (float)(flag ? 1 : 0));
		}

		internal void _003CFireProjectiles_003Eb__2()
		{
			//IL_011c: Invalid comparison between F4 and I4
			//IL_0142: Expected O, but got I4
			//IL_0088: Expected O, but got I4
			//IL_00fd: Invalid comparison between F4 and I4
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				object obj = (flag ? 1 : 0) * __repeatInterval;
				if ((nint)obj <= 0)
				{
					TP_Elec2_Weapon tP_Elec2_Weapon = _003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					_003C_003Ec__DisplayClass17_2 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass17_2();
					CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2 = this;
					CS_0024_003C_003E8__locals8.localIndex = (flag ? 1 : 0);
					TP_Elec2_Weapon tP_Elec2_Weapon2 = _003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_017f: Expected O, but got I4
						//IL_00a8->IL0148: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL0148: Incompatible stack heights: 1 vs 0
						//IL_00f6->IL0148: Incompatible stack heights: 1 vs 0
						//IL_0118->IL0148: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2;
						if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2 != null && (object)obj3._003C_003E4__this != null)
						{
							GameObject gameObject = obj3._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2;
								if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2 != null)
								{
									TP_Elec2_Weapon tP_Elec2_Weapon3 = obj5._003C_003E4__this;
									if ((object)obj5._003C_003E4__this != null && CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2 != null && (object)obj5._003C_003E4__this != null)
									{
										Vector2 vector = default(Vector2);
										Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals8.localIndex, tP_Elec2_Weapon3._targetTransform);
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					object obj2 = __repeatInterval * (flag ? 1 : 0);
					float duration = (float)obj2 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Elec2_Weapon2._lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while (__amount > (float)(flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_0160: Expected O, but got I4
			//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Elec2_Weapon tP_Elec2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Elec2_Weapon._targetTransform);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_2
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals2;

		internal void _003CFireProjectiles_003Eb__3()
		{
			//IL_017f: Expected O, but got I4
			//IL_00a8->IL0148: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0148: Incompatible stack heights: 1 vs 0
			//IL_00f6->IL0148: Incompatible stack heights: 1 vs 0
			//IL_0118->IL0148: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals2;
			if (CS_0024_003C_003E8__locals2 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals2;
					if (CS_0024_003C_003E8__locals2 != null)
					{
						TP_Elec2_Weapon tP_Elec2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && CS_0024_003C_003E8__locals2 != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Elec2_Weapon._targetTransform);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private float _mul = 500f;

	private bool _cooldownAffectedByMovement;

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private bool _hasGemini;

	private Timer rainStopTimer;

	private TP_Elec1_Weapon _elec1Weapon;

	private Vector2 _mirrorPos;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	protected override void Awake()
	{
		base.Awake();
		_hasGemini = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Elec01");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0303: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_0082: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_0334: Expected I, but got O
		//IL_0112: Expected O, but got I4
		//IL_00ce: Expected O, but got I
		//IL_0104: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__13_0;
		bool flag = _003C_003Ec._003C_003E9__13_0 != null;
		nint num3 = unchecked((nint)null);
		if (!flag)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__13_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 1463;
				return obj6 == null;
			});
			num3 = unchecked((nint)null);
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag2 = (object)equipment == null;
		Equipment elec1Weapon = equipment;
		if (flag2)
		{
			goto IL_0341;
		}
		num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Elec1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Elec1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Elec1_Weapon>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v47+FFFFFFF8+v458 @ rax_v42*8]");
			if (0 == (nint)typeof(TP_Elec1_Weapon))
			{
				obj4 = 1;
				goto IL_0350;
			}
		}
		obj4 = 0;
		goto IL_0350;
		IL_0341:
		_elec1Weapon = (TP_Elec1_Weapon)elec1Weapon;
		TP_Elec1_Weapon elec1Weapon2 = _elec1Weapon;
		if ((object)_elec1Weapon != null && ((UnityEngine.Object)elec1Weapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_elec1Weapon);
			}
			_elec1Weapon.Cleanup();
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag4 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_elec1Weapon);
			TP_Elec1_Weapon elec1Weapon3 = _elec1Weapon;
			elec1Weapon3._003CCanFireNormally_003Ek__BackingField = false;
			GameObject gameObject = _elec1Weapon.gameObject;
			gameObject.SetActive(value: true);
		}
		return;
		IL_0350:
		bool flag5 = obj4 == null;
		elec1Weapon = null;
		if (!flag5)
		{
			elec1Weapon = equipment;
		}
		goto IL_0341;
	}

	public override void InternalUpdate()
	{
		//IL_01fa: Expected O, but got F4
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = base.PInterval();
		bool flag = !_cooldownAffectedByMovement;
		float num3 = deltaTime;
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num4 = deltaTime2 * 1000f;
			float num5 = frameWalk * 100f;
			float num6 = num4 / _mul;
			float num7 = num6 * num5;
			num3 = (base._003CTotalTime_003Ek__BackingField = num7 + base._003CTotalTime_003Ek__BackingField);
		}
		if (!((base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
				TP_Elec1_Weapon elec1Weapon = _elec1Weapon;
				if ((object)_elec1Weapon != null && ((UnityEngine.Object)elec1Weapon).m_CachedPtr != (IntPtr)0)
				{
					_elec1Weapon.Fire();
				}
			}
		}
		float num8 = base._003CTotalTime_003Ek__BackingField * 0.85f;
		float num9 = num8 / deltaTime;
		float alpha = num9 + 0.15f;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		float playerFacing = PlayerFacing;
		float num10 = num3 * 0f;
		PhaserSprite phaserSprite2 = _cursor.setVisible(visible: false);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = default(float2);
		PhaserSprite phaserSprite3 = _cursor.setPosition(position2);
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num11 = (float)position3 + num10;
		object obj = default(object);
		float num12 = (float)obj + 0.24f;
		_mirrorPos = (Vector2)num11;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Invalid comparison between O and F4
		//IL_0087: Expected F4, but got O
		float2 position = _cursor.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireProjectiles(Vector2 pos)
	{
		//IL_003d: Expected F4, but got O
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals29 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals29._003C_003E4__this = this;
		CS_0024_003C_003E8__locals29.pos = pos;
		float num = base.PAmount();
		CS_0024_003C_003E8__locals29.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float num3 = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		CS_0024_003C_003E8__locals29.__repeatInterval = 0;
		object obj = default(object);
		bool flag = (nint)obj <= 0;
		bool flag2 = false;
		float num5 = default(float);
		bool flag3 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!flag)
		{
			bool flag4;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				float num4 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num5);
				Action onComplete = CS_0024_003C_003E8__locals29._003C_003E9__0;
				if (CS_0024_003C_003E8__locals29._003C_003E9__0 == null)
				{
					onComplete = (CS_0024_003C_003E8__locals29._003C_003E9__0 = delegate
					{
						//IL_010d: Invalid comparison between F4 and I4
						//IL_0133: Expected O, but got I4
						//IL_0079: Expected O, but got I4
						//IL_00ee: Invalid comparison between F4 and I4
						if (CS_0024_003C_003E8__locals29.__amount > 0f)
						{
							bool flag7 = false;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							do
							{
								object obj2 = (flag7 ? 1 : 0) * CS_0024_003C_003E8__locals29.__repeatInterval;
								if ((nint)obj2 <= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
								}
								else
								{
									_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals34 = new _003C_003Ec__DisplayClass17_1();
									CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals29;
									CS_0024_003C_003E8__locals34.localIndex = (flag7 ? 1 : 0);
									TP_Elec2_Weapon tP_Elec2_Weapon = CS_0024_003C_003E8__locals29._003C_003E4__this;
									Action onComplete3 = delegate
									{
										//IL_0160: Expected O, but got I4
										//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
										//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
										//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
										_003C_003Ec__DisplayClass17_0 obj4 = CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
										{
											GameObject gameObject = obj4._003C_003E4__this.gameObject;
											if ((object)gameObject != null)
											{
												bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
												object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
												if (obj5 == null)
												{
													return;
												}
												_003C_003Ec__DisplayClass17_0 obj6 = CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals1;
												if (CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals1 != null)
												{
													TP_Elec2_Weapon tP_Elec2_Weapon2 = obj6._003C_003E4__this;
													if ((object)obj6._003C_003E4__this != null && (object)obj6._003C_003E4__this != null)
													{
														Vector2 pos2 = default(Vector2);
														Projectile projectile = obj6._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals34.localIndex, tP_Elec2_Weapon2._targetTransform);
														return;
													}
												}
											}
										}
										throw new NullReferenceException();
									};
									object obj3 = CS_0024_003C_003E8__locals29.__repeatInterval * (flag7 ? 1 : 0);
									float duration3 = (float)obj3 * 0.001f;
									Timer lastShotTimer = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
									tP_Elec2_Weapon._lastShotTimer = lastShotTimer;
								}
								flag7 = (byte)((flag7 ? 1u : 0u) + 1u) != 0;
							}
							while (CS_0024_003C_003E8__locals29.__amount > (float)(flag7 ? 1 : 0));
						}
					});
				}
				float num6 = (float)(flag2 ? 1 : 0) * num4;
				float duration = num6 * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				flag4 = (flag2 ? 1 : 0) < (nint)obj;
				flag3 = flag3;
			}
			while (flag4);
		}
		if (!_hasGemini)
		{
			return;
		}
		bool flag5 = (nint)obj <= 0;
		bool flag6 = false;
		if (flag5)
		{
			return;
		}
		do
		{
			WeaponData currentWeaponData2 = _currentWeaponData;
			float num7 = (((object)currentWeaponData2._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num5);
			Action onComplete2 = CS_0024_003C_003E8__locals29._003C_003E9__2;
			if (CS_0024_003C_003E8__locals29._003C_003E9__2 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals29._003C_003E9__2 = delegate
				{
					//IL_011c: Invalid comparison between F4 and I4
					//IL_0142: Expected O, but got I4
					//IL_0088: Expected O, but got I4
					//IL_00fd: Invalid comparison between F4 and I4
					if (CS_0024_003C_003E8__locals29.__amount > 0f)
					{
						bool flag7 = false;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						do
						{
							object obj2 = (flag7 ? 1 : 0) * CS_0024_003C_003E8__locals29.__repeatInterval;
							if ((nint)obj2 <= 0)
							{
								TP_Elec2_Weapon tP_Elec2_Weapon = CS_0024_003C_003E8__locals29._003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							}
							else
							{
								_003C_003Ec__DisplayClass17_2 CS_0024_003C_003E8__locals40 = new _003C_003Ec__DisplayClass17_2();
								CS_0024_003C_003E8__locals40.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals29;
								CS_0024_003C_003E8__locals40.localIndex = (flag7 ? 1 : 0);
								TP_Elec2_Weapon tP_Elec2_Weapon2 = CS_0024_003C_003E8__locals29._003C_003E4__this;
								Action onComplete3 = delegate
								{
									//IL_017f: Expected O, but got I4
									//IL_00a8->IL0148: Incompatible stack heights: 1 vs 0
									//IL_00d7->IL0148: Incompatible stack heights: 1 vs 0
									//IL_00f6->IL0148: Incompatible stack heights: 1 vs 0
									//IL_0118->IL0148: Incompatible stack heights: 1 vs 0
									_003C_003Ec__DisplayClass17_0 obj4 = CS_0024_003C_003E8__locals40.CS_0024_003C_003E8__locals2;
									if (CS_0024_003C_003E8__locals40.CS_0024_003C_003E8__locals2 != null && (object)obj4._003C_003E4__this != null)
									{
										GameObject gameObject = obj4._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj5 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass17_0 obj6 = CS_0024_003C_003E8__locals40.CS_0024_003C_003E8__locals2;
											if (CS_0024_003C_003E8__locals40.CS_0024_003C_003E8__locals2 != null)
											{
												TP_Elec2_Weapon tP_Elec2_Weapon3 = obj6._003C_003E4__this;
												if ((object)obj6._003C_003E4__this != null && CS_0024_003C_003E8__locals40.CS_0024_003C_003E8__locals2 != null && (object)obj6._003C_003E4__this != null)
												{
													Vector2 pos2 = default(Vector2);
													Projectile projectile = obj6._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals40.localIndex, tP_Elec2_Weapon3._targetTransform);
													return;
												}
											}
										}
									}
									throw new NullReferenceException();
								};
								object obj3 = CS_0024_003C_003E8__locals29.__repeatInterval * (flag7 ? 1 : 0);
								float duration3 = (float)obj3 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								tP_Elec2_Weapon2._lastShotTimer = lastShotTimer;
							}
							flag7 = (byte)((flag7 ? 1u : 0u) + 1u) != 0;
						}
						while (CS_0024_003C_003E8__locals29.__amount > (float)(flag7 ? 1 : 0));
					}
				});
			}
			float num8 = (float)(flag6 ? 1 : 0) * num7;
			float duration2 = num8 * 0.001f;
			Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag6 ? 1 : 0) < (nint)obj);
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			_hasGemini = true;
		}
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0112: Expected O, but got Ref
		//IL_0169->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0113: Incompatible stack heights: 1 vs 0
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
			if ((object)pool != null)
			{
				SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
				if ((object)_cursor != null)
				{
					Transform transform = _cursor.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)_cursor != null)
						{
							Transform transform2 = _cursor.transform;
							if ((object)transform2 != null)
							{
								Vector3 localEulerAngles = transform2.localEulerAngles;
								if ((object)objectComponent != null)
								{
									object obj = default(object);
									float angle = default(float);
									string texture = default(string);
									string frame = default(string);
									bool flip = default(bool);
									objectComponent.Display(_times, _duration, (Vector3)(&obj), angle, texture, frame, flip);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
		TP_Elec1_Weapon elec1Weapon = _elec1Weapon;
		if ((object)_elec1Weapon != null && ((UnityEngine.Object)elec1Weapon).m_CachedPtr != (IntPtr)0)
		{
			_elec1Weapon.SetVisible(visible);
		}
	}
}
