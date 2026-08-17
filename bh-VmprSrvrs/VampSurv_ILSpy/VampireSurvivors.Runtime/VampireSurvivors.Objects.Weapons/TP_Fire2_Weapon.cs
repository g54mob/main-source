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
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Fire2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__20_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__20_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1455;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private string _cursorTexture;

	private string _cursorSprite;

	private bool _lockCursor;

	private EnemyController _lockOnTarget;

	private BulletPool _tailPool;

	private bool _hasGemini;

	private TP_Fire1_Weapon _fire1Weapon;

	private float2 RotationDurationRange;

	private float2 ForwardDurationRange;

	private int _003CTailAmount_003Ek__BackingField;

	public virtual bool IsPrimaryWeapon => true;

	public int TailAmount
	{
		get
		{
			return _003CTailAmount_003Ek__BackingField;
		}
		set
		{
			_003CTailAmount_003Ek__BackingField = value;
		}
	}

	public PhaserSprite Cursor => _cursor;

	protected override void Awake()
	{
		base.Awake();
		_hasGemini = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, _cursorTexture, _cursorSprite);
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_030e: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_0082: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_033f: Expected I, but got O
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
		_explosionType = WeaponType.FIREEXPLOSION;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__20_0;
		bool flag = _003C_003Ec._003C_003E9__20_0 != null;
		nint num3 = unchecked((nint)null);
		if (!flag)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__20_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 1455;
				return obj6 == null;
			});
			num3 = unchecked((nint)null);
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag2 = (object)equipment == null;
		Equipment fire1Weapon = equipment;
		if (flag2)
		{
			goto IL_034c;
		}
		num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Fire1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Fire1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Fire1_Weapon>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v47+FFFFFFF8+v458 @ rax_v42*8]");
			if (0 == (nint)typeof(TP_Fire1_Weapon))
			{
				obj4 = 1;
				goto IL_035b;
			}
		}
		obj4 = 0;
		goto IL_035b;
		IL_034c:
		_fire1Weapon = (TP_Fire1_Weapon)fire1Weapon;
		TP_Fire1_Weapon fire1Weapon2 = _fire1Weapon;
		if ((object)_fire1Weapon != null && ((UnityEngine.Object)fire1Weapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_fire1Weapon);
			}
			_fire1Weapon.Cleanup();
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag4 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_fire1Weapon);
			TP_Fire1_Weapon fire1Weapon3 = _fire1Weapon;
			fire1Weapon3._003CCanFireNormally_003Ek__BackingField = false;
			GameObject gameObject = _fire1Weapon.gameObject;
			gameObject.SetActive(value: true);
		}
		return;
		IL_035b:
		bool flag5 = obj4 == null;
		fire1Weapon = null;
		if (!flag5)
		{
			fire1Weapon = equipment;
		}
		goto IL_034c;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_01b2: Expected O, but got Ref
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
				TP_Fire1_Weapon fire1Weapon = _fire1Weapon;
				if ((object)_fire1Weapon != null && ((UnityEngine.Object)fire1Weapon).m_CachedPtr != (IntPtr)0)
				{
					_fire1Weapon.Fire();
				}
			}
		}
		float num3 = base._003CTotalTime_003Ek__BackingField * 0.75f;
		float num4 = num3 / deltaTime;
		float alpha = num4 + 0.25f;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		if (!IsPrimaryWeapon)
		{
			return;
		}
		PhaserSprite cursor;
		float2 position2;
		if (_lockCursor)
		{
			ArcadeSprite lockOnTarget = _lockOnTarget;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v43 (ArcadeSprite)+260]");
			if ((nint)0 == 0)
			{
				cursor = _cursor;
				float2 position = lockOnTarget.position;
				position2 = position;
				goto IL_0361;
			}
			_lockCursor = false;
		}
		GameManager core = GM.Core;
		float2 position3 = _cursor.position;
		object obj = default(object);
		EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true, 0.1618f);
		if (!enemyController)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			cursor = _cursor;
			float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if ((object)GM.Core != null)
			{
				float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				if ((object)GM.Core != null)
				{
					float2 float5 = default(float2);
					position2 = float5;
					goto IL_0361;
				}
			}
			throw new NullReferenceException();
		}
		float2 position6 = enemyController.position;
		PhaserSprite phaserSprite2 = _cursor.setPosition(position6);
		_lockCursor = true;
		_lockOnTarget = enemyController;
		return;
		IL_0361:
		PhaserSprite phaserSprite3 = cursor.setPosition(position2);
	}

	public override void OnMirrorData(Vector2 position)
	{
		//IL_00ba->IL0069: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_cursor != null)
				{
					float2 position2 = default(float2);
					PhaserSprite phaserSprite = _cursor.setPosition(position2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected float CalcRadAngle(float x1, float y1, float x2, float y2)
	{
		float num = x2 - x1;
		object obj = default(object);
		float result = (float)obj - y1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		return result;
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
		_lockCursor = false;
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
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Expected I4, but got Unknown
		//IL_065b: Expected I4, but got F4
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0168: Expected O, but got I4
		//IL_0171: Expected O, but got I4
		//IL_0094: Expected O, but got I
		//IL_02e6: Expected I, but got O
		//IL_02f4: Expected I, but got O
		//IL_0304: Expected O, but got I
		//IL_0384: Expected O, but got I4
		//IL_0340: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0376: Expected O, but got I4
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_04f8: Expected I, but got O
		//IL_0506: Expected I, but got O
		//IL_0516: Expected O, but got I
		//IL_0596: Expected O, but got I4
		//IL_0552: Expected O, but got I
		//IL_0588: Expected O, but got I4
		//IL_0766->IL05f5: Incompatible stack heights: 1 vs 0
		//IL_07b5->IL05f5: Incompatible stack heights: 2 vs 0
		//IL_0498->IL05f5: Incompatible stack heights: 2 vs 0
		//IL_07fe->IL05f4: Incompatible stack heights: 2 vs 0
		//IL_05d4->IL05f4: Incompatible stack heights: 2 vs 0
		//IL_05f4->IL05f4: Incompatible stack heights: 2 vs 0
		float num = base.PSpeedRepeatInterval();
		float num2 = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
		float num3 = base.PAmount();
		object obj = default(object);
		int times = obj + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num4 = num3 + 1f;
		_003CTailAmount_003Ek__BackingField = (int)num4;
		float num5 = default(float);
		DisplayCursorVFX(times, num5);
		List<float> list = Weapon.MakeChanceArray();
		List<float> list2 = Weapon.MakeChanceArray();
		bool flag = list == null;
		float num6 = num5;
		object obj2 = 0;
		object obj3 = 0;
		if (!flag)
		{
			Vector2 pos2 = default(Vector2);
			Vector2 pos3 = default(Vector2);
			while (true)
			{
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)obj4 < 0)
				{
					object obj5 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)obj5 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						object obj7 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v25+18]");
						if ((nint)obj7 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Fire2_Weapon)+1A4]");
							object obj8 = 0 - RotationDurationRange;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v25+20+v154 @ rdx_v19*4]");
							object obj9 = obj8 * 0;
							num6 = (float)obj9 + (float)RotationDurationRange;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+1C]");
							_ = (nint)0 + (nint)1;
							obj2++;
							obj3 = obj2;
							continue;
						}
						goto IL_0674;
					}
				}
				else
				{
					bool flag2 = list2 == null;
					object obj10 = 0;
					object obj11 = 0;
					if (flag2)
					{
						break;
					}
					while (true)
					{
						object obj12 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v12 (System.Collections.Generic.List`1<System.Single>)+18]");
						if ((nint)obj12 < 0)
						{
							object obj13 = obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v12 (System.Collections.Generic.List`1<System.Single>)+18]");
							if ((nint)obj13 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v12 (System.Collections.Generic.List`1<System.Single>)+10]");
							object obj14 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v12 (System.Collections.Generic.List`1<System.Single>)+10]");
							if ((nint)0 == 0)
							{
								goto end_IL_0680;
							}
							object obj15 = obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v24+18]");
							if ((nint)obj15 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Fire2_Weapon)+1AC]");
								object obj16 = 0 - ForwardDurationRange;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v24+20+v156 @ rdx_v21*4]");
								object obj17 = obj16 * 0;
								num6 = (float)obj17 + (float)ForwardDurationRange;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v12 (System.Collections.Generic.List`1<System.Single>)+1C]");
								_ = (nint)0 + (nint)1;
								obj10++;
								obj11 = obj10;
								continue;
							}
							goto IL_0674;
						}
						Projectile projectile = base.FireOneProjectile(pos2, 0, _targetTransform);
						object obj18;
						if ((object)projectile == null)
						{
							obj18 = null;
							goto IL_06e2;
						}
						nint num7 = (nint)projectile;
						nint num8 = (nint)typeof(TP_Fire2_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2_Projectile>)+130]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2_Projectile>)+130]");
						object obj21;
						if (num9 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj20 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v97+FFFFFFF8+v493 @ rax_v93*8]");
							if (0 == (nint)typeof(TP_Fire2_Projectile))
							{
								obj21 = 1;
								goto IL_06ac;
							}
						}
						obj21 = 0;
						goto IL_06ac;
						IL_07bf:
						object obj22;
						bool flag3 = obj22 == null;
						TP_Fire2_Projectile tP_Fire2_Projectile = null;
						Projectile projectile2;
						if (!flag3)
						{
							tP_Fire2_Projectile = (TP_Fire2_Projectile)projectile2;
						}
						goto IL_07e6;
						IL_06ac:
						bool flag4 = obj21 == null;
						obj18 = null;
						pos2 = (Vector2)typeof(TP_Fire2_Projectile);
						if (!flag4)
						{
							obj18 = projectile;
							pos2 = (Vector2)typeof(TP_Fire2_Projectile);
						}
						goto IL_06e2;
						IL_06e2:
						if (obj18 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbp_v5 (System.Object)+10]");
							if ((nint)0 == 0)
							{
							}
						}
						if (!_hasGemini)
						{
							return;
						}
						if ((object)_cursor == null)
						{
							goto end_IL_0680;
						}
						float2 position = _cursor.position;
						object obj23 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							goto end_IL_0680;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbp_v8 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbp_v8 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform == null)
						{
							goto end_IL_0680;
						}
						bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)_cursor == null)
						{
							goto end_IL_0680;
						}
						float2 position2 = _cursor.position;
						if ((object)_cursor == null)
						{
							goto end_IL_0680;
						}
						float2 position3 = _cursor.position;
						projectile2 = base.FireOneProjectile(pos3, 1, _targetTransform);
						if ((object)projectile2 == null)
						{
							tP_Fire2_Projectile = null;
							goto IL_07e6;
						}
						nint num10 = (nint)projectile2;
						nint num11 = (nint)typeof(TP_Fire2_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1184 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2_Projectile>)+130]");
						object obj24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1184 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2_Projectile>)+130]");
						if (num12 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rax_v69+FFFFFFF8+v1185 @ rax_v65*8]");
							if (0 == (nint)typeof(TP_Fire2_Projectile))
							{
								obj22 = 1;
								goto IL_07bf;
							}
						}
						obj22 = 0;
						goto IL_07bf;
						IL_07e6:
						if ((object)tP_Fire2_Projectile != null && ((UnityEngine.Object)tP_Fire2_Projectile).m_CachedPtr != (IntPtr)0)
						{
							tP_Fire2_Projectile.SetMovementPath(list, list2, isMirrored: true);
						}
						return;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				goto IL_0674;
				IL_0674:
				throw new IndexOutOfRangeException();
				continue;
				end_IL_0680:
				break;
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
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

	public Projectile SpawnTailProjectile(float2 pos, int index)
	{
		//IL_012a: Expected I, but got O
		//IL_0242: Expected I, but got O
		if (_tailPool != null)
		{
			goto IL_029c;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_FIRE2_TAIL);
			BulletPool tailPool = new BulletPool(projectilePrefab);
			_tailPool = tailPool;
			BulletPool tailPool2 = _tailPool;
			if (_tailPool != null)
			{
				tailPool2.UpperLimit = 1000;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						ArcadePhysics physics = s_scene.physics;
						if ((object)s_scene.physics != null)
						{
							GameManager core = GM.Core;
							if ((object)GM.Core != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Fire2_Weapon>)+370]");
								ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
								nint num = (nint)this;
								if (physics.add != null)
								{
									ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
									CallbackContext callbackContext = default(CallbackContext);
									Collider collider = physics.add.overlap(_tailPool, core.Enemies, collideCallback, processCallback, callbackContext);
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene2 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											ArcadePhysics physics2 = s_scene2.physics;
											if ((object)s_scene2.physics != null)
											{
												GameManager core2 = GM.Core;
												if ((object)GM.Core != null)
												{
													PhysicsManager physicsManager = core2._physicsManager;
													if (core2._physicsManager != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Fire2_Weapon>)+3A0]");
														ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
														nint num2 = (nint)this;
														if (physics2.add != null)
														{
															Collider collider2 = physics2.add.overlap(_tailPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
															goto IL_029c;
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
		goto IL_02d8;
		IL_029c:
		if (_tailPool != null)
		{
			return _tailPool.SpawnAt(pos, this, index);
		}
		goto IL_02d8;
		IL_02d8:
		return (Projectile)(object)new NullReferenceException();
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
		TP_Fire1_Weapon fire1Weapon = _fire1Weapon;
		if ((object)_fire1Weapon != null && ((UnityEngine.Object)fire1Weapon).m_CachedPtr != (IntPtr)0)
		{
			_fire1Weapon.SetVisible(visible);
		}
	}

	public override void Cleanup()
	{
		if (_tailPool != null)
		{
			_tailPool.Cleanup();
		}
		base.Cleanup();
	}

	public TP_Fire2_Weapon()
	{
		//IL_0010: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		_cursorTexture = "ThosePeople";
		_cursorSprite = "TP_VFX_Fire18";
		RotationDurationRange = (float2)1150681088;
		_ = 1155596288;
		ForwardDurationRange = (float2)1145569280;
		_ = 1150681088;
		base._002Ector();
	}
}
