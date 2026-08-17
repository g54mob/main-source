using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Acid2_Weapon : FB_QuantisedAngleWeapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__18_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__18_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1465;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public float __area;

		public Vector2 pos;

		public float __repeatInterval;

		public TP_Acid2_Weapon _003C_003E4__this;

		public float __amount;

		public Action _003C_003E9__0;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_01ae: Invalid comparison between F4 and I4
			//IL_0030: Expected O, but got I
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_008c: Expected O, but got I8
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Expected O, but got Unknown
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_018f: Invalid comparison between F4 and I4
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
				_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass23_1();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj = num ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj2 = 0 & obj;
				bool flag2 = (nint)obj2 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag3 = (nint)0 < (nint)0;
				CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = this;
				object obj3 = (flag ? 1 : 0) & 0x80000007L;
				if (flag3 != flag2)
				{
					object obj4 = obj3 - 1;
					object obj5 = obj4 | -8;
					obj3 = obj5 + 1;
				}
				object obj6 = obj3 * __area;
				Vector2 _pos = (Vector2)(obj6 + (object)pos);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Acid2_Weapon+<>c__DisplayClass23_0)+18]");
				_ = 0;
				CS_0024_003C_003E8__locals8.localIndex = (flag ? 1 : 0);
				CS_0024_003C_003E8__locals8.__pos = _pos;
				object obj7 = flag * __repeatInterval;
				if ((nint)obj7 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					TP_Acid2_Weapon tP_Acid2_Weapon = _003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_0160: Expected O, but got I4
						//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass23_0 obj8 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj8._003C_003E4__this != null)
						{
							GameObject gameObject = obj8._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj9 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj9 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass23_0 obj10 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Acid2_Weapon tP_Acid2_Weapon2 = obj10._003C_003E4__this;
									if ((object)obj10._003C_003E4__this != null && (object)obj10._003C_003E4__this != null)
									{
										Vector2 vector = default(Vector2);
										Projectile projectile = obj10._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals8.localIndex, tP_Acid2_Weapon2._targetTransform);
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num2 = (float)(flag ? 1 : 0) * __repeatInterval;
					float duration = num2 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Acid2_Weapon._lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while (__amount > (float)(flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_1
	{
		public Vector2 __pos;

		public int localIndex;

		public _003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_0160: Expected O, but got I4
			//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass23_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass23_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Acid2_Weapon tP_Acid2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Acid2_Weapon._targetTransform);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private IDamageable _targetDamagable;

	private bool _hasGemini;

	private TP_Acid1_Weapon _acid1Weapon;

	private PhaserSprite _cursor;

	private float _cursorAngle;

	private float _angleUnit = 0.0174533f;

	private float _targetAngle = (float)Math.PI / 2f;

	private float _mul = 333.33334f;

	private bool _cooldownAffectedByMovement;

	private bool _isStandalone;

	public virtual bool IsPrimaryWeapon => true;

	public virtual float PlayerFacing => 1f;

	private PhaserSprite CursorToUse1
	{
		get
		{
			if (_isStandalone)
			{
				return _cursor;
			}
			TP_Acid1_Weapon acid1Weapon = _acid1Weapon;
			if ((object)_acid1Weapon != null)
			{
				return acid1Weapon._cursor;
			}
			return (PhaserSprite)(object)new NullReferenceException();
		}
	}

	private PhaserSprite CursorToUse2
	{
		get
		{
			if (_isStandalone)
			{
				return _cursor;
			}
			TP_Acid1_Weapon acid1Weapon = _acid1Weapon;
			if ((object)_acid1Weapon != null)
			{
				return acid1Weapon.GeminiCursor;
			}
			return (PhaserSprite)(object)new NullReferenceException();
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00cc: Expected I, but got O
		//IL_00da: Expected I, but got O
		//IL_00ea: Expected O, but got I
		//IL_016a: Expected O, but got I4
		//IL_03ce: Expected O, but got I
		//IL_0126: Expected O, but got I
		//IL_0177: Expected O, but got I
		//IL_015c: Expected O, but got I4
		_hasGemini = false;
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		((Weapon)this)._003CTotalTime_003Ek__BackingField = num2;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Acid15");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(2);
		PhaserSprite phaserSprite2 = _cursor.setVisible(visible: false);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__18_0;
		bool flag = _003C_003Ec._003C_003E9__18_0 != null;
		string text = "TP_VFX_Acid15";
		if (!flag)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__18_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 1465;
				return obj6 == null;
			});
			text = null;
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag2 = (object)equipment == null;
		Equipment acid1Weapon = null;
		if (flag2)
		{
			goto IL_03a8;
		}
		nint num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Acid1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Acid1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Acid1_Weapon>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ rax_v58+FFFFFFF8+v657 @ rax_v54*8]");
			if (0 == (nint)typeof(TP_Acid1_Weapon))
			{
				obj4 = 1;
				goto IL_03b7;
			}
		}
		obj4 = 0;
		goto IL_03b7;
		IL_03b7:
		bool flag3 = obj4 == null;
		text = (string)num3;
		acid1Weapon = null;
		if (!flag3)
		{
			text = (string)num3;
			acid1Weapon = equipment;
		}
		goto IL_03a8;
		IL_03a8:
		_acid1Weapon = (TP_Acid1_Weapon)acid1Weapon;
		TP_Acid1_Weapon acid1Weapon2 = _acid1Weapon;
		if ((object)_acid1Weapon != null && ((UnityEngine.Object)acid1Weapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag4 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_acid1Weapon);
			}
			_acid1Weapon.Cleanup();
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag5 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_acid1Weapon);
			TP_Acid1_Weapon acid1Weapon3 = _acid1Weapon;
			acid1Weapon3._003CCanFireNormally_003Ek__BackingField = false;
			GameObject gameObject2 = _acid1Weapon.gameObject;
			gameObject2.SetActive(value: true);
		}
		else
		{
			_isStandalone = true;
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0d75: Expected O, but got F4
		//IL_0567: Expected F4, but got I4
		//IL_0e0b: Expected O, but got F4
		//IL_05ad: Expected F4, but got I4
		//IL_010f: Expected O, but got I4
		//IL_079b: Expected I, but got O
		//IL_02ad: Expected O, but got I
		//IL_0833: Expected I, but got O
		//IL_08a3: Expected F4, but got I4
		//IL_095c: Expected O, but got F4
		//IL_0969: Expected O, but got F4
		//IL_098e: Invalid comparison between F4 and I4
		//IL_099d: Invalid comparison between F4 and I4
		//IL_0872: Expected F4, but got I4
		//IL_0f21: Expected O, but got I4
		//IL_0f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2e: Expected O, but got Unknown
		//IL_08e3: Expected O, but got F4
		//IL_08f0: Expected O, but got F4
		//IL_0915: Invalid comparison between F4 and I4
		//IL_0924: Invalid comparison between F4 and I4
		//IL_02d1: Expected F8, but got O
		//IL_02d1: Expected F8, but got I
		//IL_0c0e: Expected O, but got I4
		//IL_0c38: Expected O, but got F4
		//IL_0c69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6e: Expected O, but got Unknown
		//IL_0c76: Invalid comparison between F4 and O
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected F4, but got Unknown
		//IL_031b: Invalid comparison between F8 and I4
		//IL_0344: Expected O, but got I4
		//IL_03ce: Invalid comparison between F4 and I4
		//IL_0450: Expected O, but got Ref
		//IL_0a8d: Expected O, but got Ref
		//IL_045d: Expected I, but got O
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Expected O, but got Unknown
		//IL_0b66->IL0a92: Incompatible stack heights: 1 vs 0
		//IL_0118->IL0af6: Incompatible stack heights: 1 vs 0
		//IL_0d2e->IL0a92: Incompatible stack heights: 1 vs 0
		//IL_016d->IL0a92: Incompatible stack heights: 2 vs 0
		//IL_01c1->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_025c->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_0219->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_028b->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_0bcf->IL0a92: Incompatible stack heights: 4 vs 0
		//IL_0fd5->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_0c25->IL0f5c: Incompatible stack heights: 5 vs 3
		//IL_0cbb->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_043e->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_0d05->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_0492->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_04b4->IL0a92: Incompatible stack heights: 3 vs 0
		//IL_0546->IL0d0a: Incompatible stack heights: 3 vs 1
		//IL_055e->IL0af6: Incompatible stack heights: 3 vs 0
		base.InternalUpdate();
		Transform targetTransform = _targetTransform;
		if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
		{
			if (_targetDamagable == null)
			{
				goto IL_0a92;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj == null)
			{
				goto IL_0089;
			}
		}
		UpdateTargeting();
		goto IL_0089;
		IL_08a8:
		float num = (float)Math.PI;
		goto IL_0eac;
		IL_0a92:
		throw new NullReferenceException();
		IL_0f3c:
		float num2;
		float num3 = default(float);
		if (PauseSystem._paused)
		{
			num2 = 0f;
		}
		else
		{
			object obj2 = Time.deltaTime;
			num2 = num3;
		}
		float num4 = num2 * 1000f;
		float num5 = base.PInterval();
		if (_cooldownAffectedByMovement)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
			{
				goto IL_0a92;
			}
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float num6;
			if (PauseSystem._paused)
			{
				num6 = 0f;
			}
			else
			{
				object obj3 = Time.deltaTime;
				num6 = frameWalk;
			}
			float num7 = frameWalk * 100f;
			float num8 = num6 * 1000f;
			float num9 = num8 / _mul;
			float num10 = num9 * num7;
			float num11 = num10 + ((Weapon)this)._003CTotalTime_003Ek__BackingField;
			((Weapon)this)._003CTotalTime_003Ek__BackingField = num11;
		}
		if (!((((Weapon)this)._003CTotalTime_003Ek__BackingField = num4 + ((Weapon)this)._003CTotalTime_003Ek__BackingField) < num3))
		{
			((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
				Transform acid1Weapon = (Transform)(object)_acid1Weapon;
				if ((object)_acid1Weapon != null && ((UnityEngine.Object)acid1Weapon).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_acid1Weapon == null)
					{
						goto IL_0a92;
					}
					_acid1Weapon.Fire();
				}
			}
		}
		if (!_isStandalone)
		{
			if ((object)_cursor != null)
			{
				PhaserSprite phaserSprite = _cursor.setVisible(visible: false);
			}
			return;
		}
		if ((object)_cursor != null)
		{
			PhaserSprite phaserSprite2 = _cursor.setVisible(_isVisible);
			if ((object)_cursor != null)
			{
				float num12 = ((Weapon)this)._003CTotalTime_003Ek__BackingField * 0.85f;
				float num13 = num12 / num3;
				float alpha = num13 + 0.15f;
				PhaserSprite phaserSprite3 = _cursor.setAlpha(alpha);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
					{
						nint num14 = (nint)typeof(ArcadePhysics);
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
						{
							ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rax_v60 (ArcadeSprite)+230]");
								if ((nint)0 <= (nint)0)
								{
									num = _cursorAngle;
								}
								else
								{
									bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
									nint num15 = (nint)this;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2382 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Acid2_Weapon>)+5E0]");
									num14 = 0;
									if (!flipX)
									{
										if (IsPrimaryWeapon)
										{
											goto IL_08a8;
										}
										num = 0f;
									}
									else
									{
										if (!IsPrimaryWeapon)
										{
											goto IL_08a8;
										}
										num = 0f;
									}
								}
								goto IL_0eac;
							}
						}
					}
				}
			}
		}
		goto IL_0a92;
		IL_054b:
		Vector3 localEulerAngles;
		float x = localEulerAngles.x;
		goto IL_0f3c;
		IL_0089:
		Transform targetTransform2 = _targetTransform;
		float2 float6 = default(float2);
		if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform2).m_CachedPtr != (IntPtr)0)
		{
			object targetTransform3 = _targetTransform;
			if ((object)_targetTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rdi_v22 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rdi_v22 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				List<Projectile> spawnedProjectiles = _spawnedProjectiles;
				bool flag2 = (nint)_spawnedProjectiles < 0;
				if (_spawnedProjectiles != null)
				{
					object obj4 = spawnedProjectiles._size - 1;
					if (flag2)
					{
						goto IL_0f3c;
					}
					object obj5 = default(object);
					while (true)
					{
						List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
						if (_spawnedProjectiles == null)
						{
							break;
						}
						bool flag3 = (nint)obj4 >= spawnedProjectiles2._size;
						Projectile[] items = spawnedProjectiles2._items;
						if (spawnedProjectiles2._items == null)
						{
							break;
						}
						bool flag4 = (nint)obj4 >= items.Length;
						ArcadeSprite arcadeSprite2 = items[obj4];
						if ((object)items[obj4] == null)
						{
							break;
						}
						float2 float5;
						float2 float7;
						if (arcadeSprite2.body == null)
						{
							Transform cachedTrans = ((ArcadeSprite)items[obj4]).CachedTrans;
							if ((object)cachedTrans == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v152 (UnityEngine.Transform)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v152 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
							Transform cachedTrans2 = ((ArcadeSprite)items[obj4]).CachedTrans;
							if ((object)cachedTrans2 == null)
							{
								break;
							}
							bool flag6 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out Vector3 ret3);
							ret3 = (Vector3)0;
							float5 = float6;
							float7 = float6;
						}
						else
						{
							BaseBody body = arcadeSprite2.body;
							if (arcadeSprite2.body == null)
							{
								break;
							}
							ArcadeTransform arcadeTransform = body._transform;
							if (body._transform == null)
							{
								break;
							}
							float7 = arcadeTransform.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rax_v151 (ArcadeTransform)+4C]");
							float5 = (float2)0;
						}
						double x2 = (double)ret - (double)float7;
						double y = (double)obj5 - (double)float5;
						double num16 = Math.Atan2(y, x2);
						BaseBody body2 = arcadeSprite2.body;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
						float num17 = 0f * 57.29578f;
						if (arcadeSprite2.body == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rax_v122 (BaseBody)+74]");
						double num18 = Math.Atan2(0.0, (double)body2._velocity);
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
						float num19 = 0f * 57.29578f;
						object obj6 = Time.deltaTime;
						double num20 = num18 * 300.0;
						float num21 = Mathf.DeltaAngle(num19, num17);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj7 = num20 ^ 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num21) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
						{
							bool flag7 = num20 < (double)num21;
							double num22 = num20 - (double)num21;
							bool flag8 = num22 == 0.0;
							bool flag9 = !flag7;
							bool flag10 = !flag8;
							object obj8 = flag10 & flag9;
							if (obj8 != null)
							{
								goto IL_0c8d;
							}
						}
						num17 = num21 + num19;
						float num23 = num17 - num19;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						num21 = num23 & 0;
						if (num20 < (double)num21)
						{
							float num24 = num17 - num19;
							float num25 = ((num24 < 0f) ? (-1f) : 1f);
							float num26 = num25 * (float)num20;
							num17 = num26 + num19;
						}
						goto IL_0c8d;
						IL_0c8d:
						Transform cachedTrans3 = ((ArcadeSprite)items[obj4]).CachedTrans;
						if ((object)cachedTrans3 == null)
						{
							break;
						}
						localEulerAngles = cachedTrans3.localEulerAngles;
						Transform cachedTrans4 = ((ArcadeSprite)items[obj4]).CachedTrans;
						if ((object)cachedTrans4 == null)
						{
							break;
						}
						cachedTrans4.localEulerAngles = (Vector3)(&x);
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene == null)
						{
							break;
						}
						nint num27 = (nint)arcadeSprite2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2692 @ rdx_v55 (Il2CppClass<ArcadeSprite>)+2D8] (should have been resolved before IL gen)");
						object body3 = arcadeSprite2.body;
						if (arcadeSprite2.body == null || (object)s_scene3.physics == null)
						{
							break;
						}
						float num28 = num17 * ((float)Math.PI / 180f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
						float num29 = num28 * num21;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
						obj4--;
						num3 = num28 * num21;
						bool flag11 = (nint)s_scene3.physics >= 0;
						x = localEulerAngles.x;
						if (flag11)
						{
							continue;
						}
						goto IL_054b;
					}
				}
			}
			goto IL_0a92;
		}
		goto IL_0f3c;
		IL_0eac:
		_targetAngle = num;
		_angleUnit = 0.000872665f;
		float deltaTime = PauseSystem.DeltaTime;
		float num30 = deltaTime * 1000f;
		float num31 = num30 * 0.000872665f;
		float num32;
		bool flag12;
		bool flag13;
		bool flag14;
		if (!(num > _cursorAngle))
		{
			num32 = _cursorAngle - num31;
			float num33 = num32 - num;
			object obj9 = num32 ^ num;
			object obj10 = num32 ^ num33;
			object obj11 = obj9 & obj10;
			flag12 = (nint)obj11 < 0;
			flag13 = num33 < 0f;
			flag14 = num33 == 0f;
		}
		else
		{
			float num34 = num31 + _cursorAngle;
			float num35 = num - num34;
			object obj12 = num ^ num34;
			object obj13 = num ^ num35;
			object obj14 = obj12 & obj13;
			flag12 = (nint)obj14 < 0;
			flag13 = num35 < 0f;
			flag14 = num35 == 0f;
			num32 = num34;
		}
		bool flag15 = flag13 == flag12;
		object obj15 = !flag14;
		object obj16 = flag15 & obj15;
		if (obj16 == null)
		{
			num32 = num;
		}
		_cursorAngle = num32;
		float num36 = num32 + (float)Math.PI;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			if ((object)_cursor != null)
			{
				PhaserSprite phaserSprite4 = _cursor.setPosition(position);
				if ((object)_cursor != null)
				{
					PhaserSprite phaserSprite5 = _cursor.setLocalPosition(float6);
					if ((object)_cursor != null)
					{
						Transform transform = _cursor.transform;
						if ((object)transform != null)
						{
							transform.localEulerAngles = (Vector3)(&x);
							return;
						}
					}
				}
			}
		}
		goto IL_0a92;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0079: Expected I, but got O
		//IL_012b: Expected O, but got F4
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			float num = UnityEngine.Random.Range(-15f, 15f);
			float num2 = (projectile.angle = num + _firingAngleDegrees);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				nint num4 = (nint)projectile;
				float projectileSpeed = projectile.ProjectileSpeed;
				BaseBody body = projectile.body;
				if (projectile.body != null && (object)s_scene.physics != null)
				{
					float num5 = num2 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num6 = num5 * num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num7 = num5 * num;
					body._velocity = (float2)num6;
					goto IL_01b5;
				}
			}
			return (Projectile)(object)new NullReferenceException();
		}
		projectile = null;
		goto IL_01b5;
		IL_01b5:
		return projectile;
	}

	private void UpdateTargeting()
	{
		//IL_0367: Expected O, but got I
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected O, but got Unknown
		//IL_0498->IL0396: Incompatible stack heights: 1 vs 0
		GameManager gameMan = _gameMan;
		if ((object)_gameMan != null)
		{
			Stage stage = gameMan._stage;
			if ((object)gameMan._stage != null)
			{
				List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
				float2 firingVector = GetFiringVector();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 cachedPosition = ((Equipment)this)._003COwner_003Ek__BackingField.cachedPosition;
					if (stage._spawnedEnemies != null)
					{
						object obj = null;
						IDamageable damageable = null;
						float num = -1f;
						object obj2 = null;
						object obj3 = default(object);
						ArcadeSprite arcadeSprite = default(ArcadeSprite);
						object obj6 = default(object);
						object obj7 = default(object);
						object obj10 = default(object);
						IDamageable damageable2 = default(IDamageable);
						while (true)
						{
							if ((nint)obj2 < spawnedEnemies._size)
							{
								if ((nint)obj < spawnedEnemies._size)
								{
									EnemyController[] items = spawnedEnemies._items;
									if (spawnedEnemies._items == null)
									{
										break;
									}
									if ((nint)obj < items.Length)
									{
										EnemyController enemyController = items[obj];
										if ((object)items[obj] != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
											if (obj3 == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v55+260]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
												if ((object)arcadeSprite == null)
												{
													break;
												}
												float2 cachedPosition2 = arcadeSprite.cachedPosition;
												object obj4 = cachedPosition2 - cachedPosition;
												object obj5 = obj6 - obj6;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873F6AC4h\"");
												if (obj4 == null)
												{
													bool flag = obj5 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873F6AC4h\"");
													if (flag)
													{
														goto IL_0409;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850046E0");
												obj4 /= obj7;
												obj5 /= obj7;
												object obj8 = (object)firingVector * obj4;
												object obj9 = obj10 * obj5;
												object obj11 = obj8 + obj9;
												float num2 = (float)obj11 / (float)obj7;
												bool flag2 = !(num2 > num);
												object obj12 = obj7;
												if (!flag2)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
													obj12 = obj7;
													damageable = damageable2;
													num = num2;
												}
											}
										}
										goto IL_0409;
									}
								}
								else
								{
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								}
								throw new IndexOutOfRangeException();
							}
							if (damageable == null)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rbp_v9 (VampireSurvivors.Interfaces.IDamageable)+10]");
							if ((nint)0 != 0)
							{
								_targetDamagable = damageable;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rbp_v9 (VampireSurvivors.Interfaces.IDamageable)+68]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rbp_v9 (VampireSurvivors.Interfaces.IDamageable)+68]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v10 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v10 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform targetTransform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								_targetTransform = targetTransform;
							}
							return;
							IL_0409:
							obj++;
							obj2 = obj;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0124: Invalid comparison between O and F4
		//IL_014f: Expected F4, but got O
		PhaserSprite cursor;
		if (_isStandalone)
		{
			cursor = _cursor;
		}
		else
		{
			TP_Acid1_Weapon acid1Weapon = _acid1Weapon;
			cursor = acid1Weapon._cursor;
		}
		float2 position = cursor.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		bool flag = !_hasGemini;
		Vector2 vector2 = vector;
		if (!flag)
		{
			PhaserSprite phaserSprite;
			if (_isStandalone)
			{
				phaserSprite = _cursor;
			}
			else
			{
				TP_Acid1_Weapon acid1Weapon2 = _acid1Weapon;
				phaserSprite = acid1Weapon2.GeminiCursor;
			}
			float2 position2 = phaserSprite.position;
			FireProjectiles(vector);
			vector2 = vector;
		}
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireProjectiles(Vector2 pos)
	{
		//IL_003d: Expected F4, but got O
		//IL_00a9: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals21.pos = pos;
		CS_0024_003C_003E8__locals21._003C_003E4__this = this;
		float num = base.PAmount();
		CS_0024_003C_003E8__locals21.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float num3 = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		CS_0024_003C_003E8__locals21.__area = 0.08f;
		float playerFacing = PlayerFacing;
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		object obj = (flipX ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		object obj3 = obj2 - 1;
		float num4 = (float)obj3 * num3;
		float _area = num4 * 0.08f;
		CS_0024_003C_003E8__locals21.__area = _area;
		float num5 = base.PSpeedRepeatInterval();
		CS_0024_003C_003E8__locals21.__repeatInterval = num3;
		float hitBoxDelay2 = base.HitBoxDelay;
		int num6 = default(int);
		DisplayCursorVFX(num6, hitBoxDelay2);
		if (num6 <= 0)
		{
			return;
		}
		bool flag = false;
		float num8 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num7 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num8);
			Action onComplete = CS_0024_003C_003E8__locals21._003C_003E9__0;
			if (CS_0024_003C_003E8__locals21._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals21._003C_003E9__0 = delegate
				{
					//IL_01ae: Invalid comparison between F4 and I4
					//IL_0030: Expected O, but got I
					//IL_0040: Unknown result type (might be due to invalid IL or missing references)
					//IL_0045: Expected O, but got Unknown
					//IL_008c: Expected O, but got I8
					//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
					//IL_01d4: Expected O, but got Unknown
					//IL_0214: Unknown result type (might be due to invalid IL or missing references)
					//IL_0219: Expected O, but got Unknown
					//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b6: Expected O, but got Unknown
					//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c4: Expected O, but got Unknown
					//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
					//IL_00d2: Expected O, but got Unknown
					//IL_018f: Invalid comparison between F4 and I4
					if (CS_0024_003C_003E8__locals21.__amount > 0f)
					{
						bool flag2 = false;
						bool useRealTime2 = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						do
						{
							_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass23_1();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							object obj4 = num11 ^ 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							object obj5 = 0 & obj4;
							bool flag3 = (nint)obj5 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag4 = (nint)0 < (nint)0;
							CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals21;
							object obj6 = (flag2 ? 1 : 0) & 0x80000007L;
							if (flag4 != flag3)
							{
								object obj7 = obj6 - 1;
								object obj8 = obj7 | -8;
								obj6 = obj8 + 1;
							}
							object obj9 = obj6 * CS_0024_003C_003E8__locals21.__area;
							Vector2 _pos = (Vector2)(obj9 + (object)CS_0024_003C_003E8__locals21.pos);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Acid2_Weapon+<>c__DisplayClass23_0)+18]");
							_ = 0;
							CS_0024_003C_003E8__locals26.localIndex = (flag2 ? 1 : 0);
							CS_0024_003C_003E8__locals26.__pos = _pos;
							object obj10 = flag2 * CS_0024_003C_003E8__locals21.__repeatInterval;
							if ((nint)obj10 <= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							}
							else
							{
								TP_Acid2_Weapon tP_Acid2_Weapon = CS_0024_003C_003E8__locals21._003C_003E4__this;
								Action onComplete2 = delegate
								{
									//IL_0160: Expected O, but got I4
									//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
									//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
									//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
									_003C_003Ec__DisplayClass23_0 obj11 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null && (object)obj11._003C_003E4__this != null)
									{
										GameObject gameObject = obj11._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj12 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj12 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass23_0 obj13 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Acid2_Weapon tP_Acid2_Weapon2 = obj13._003C_003E4__this;
												if ((object)obj13._003C_003E4__this != null && (object)obj13._003C_003E4__this != null)
												{
													Vector2 pos2 = default(Vector2);
													Projectile projectile = obj13._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals26.localIndex, tP_Acid2_Weapon2._targetTransform);
													return;
												}
											}
										}
									}
									throw new NullReferenceException();
								};
								float num12 = (float)(flag2 ? 1 : 0) * CS_0024_003C_003E8__locals21.__repeatInterval;
								float duration2 = num12 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								tP_Acid2_Weapon._lastShotTimer = lastShotTimer;
							}
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
						}
						while (CS_0024_003C_003E8__locals21.__amount > (float)(flag2 ? 1 : 0));
					}
				});
			}
			float num9 = (float)(flag ? 1 : 0) * num7;
			float num10 = num9 + 1f;
			float duration = num10 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < num6);
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			_hasGemini = true;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
	}

	private float Approach(float start, float end, float shift)
	{
		if (!(end > start))
		{
			float num = start - shift;
			if (num < end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start + shift;
		if (num2 > end)
		{
			num2 = end;
		}
		return num2;
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0113: Expected O, but got Ref
		//IL_016a->IL0114: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0114: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0114: Incompatible stack heights: 1 vs 0
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
		PhaserSprite cursor;
		if (_isStandalone)
		{
			cursor = _cursor;
		}
		else
		{
			TP_Acid1_Weapon acid1Weapon = _acid1Weapon;
			cursor = acid1Weapon._cursor;
		}
		PhaserSprite phaserSprite2 = cursor.setVisible(visible);
		PhaserSprite phaserSprite3;
		if (_isStandalone)
		{
			phaserSprite3 = _cursor;
		}
		else
		{
			TP_Acid1_Weapon acid1Weapon2 = _acid1Weapon;
			phaserSprite3 = acid1Weapon2.GeminiCursor;
		}
		PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible);
		TP_Acid1_Weapon acid1Weapon3 = _acid1Weapon;
		if ((object)_acid1Weapon != null && ((UnityEngine.Object)acid1Weapon3).m_CachedPtr != (IntPtr)0)
		{
			_acid1Weapon.SetVisible(visible);
		}
	}
}
