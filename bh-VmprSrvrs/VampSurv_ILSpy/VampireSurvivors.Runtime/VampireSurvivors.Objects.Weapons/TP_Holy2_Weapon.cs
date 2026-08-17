using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Holy2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__8_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__8_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1469;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private TP_Holy2_WeaponSupport support;

	private bool _initialisedParticles;

	private bool _hasGemini;

	private TP_Holy1_Weapon _holy1Weapon;

	public virtual bool IsPrimaryWeapon => true;

	protected override void Awake()
	{
		base.Awake();
		_hasGemini = false;
		support.Initialize();
	}

	public override float PInterval()
	{
		float num = base.PInterval();
		bool flag = !_hasGemini;
		float num2 = 15000f;
		if (!flag)
		{
			num *= 0.5f;
			num2 = 7500f;
		}
		if (num < num2)
		{
			num = num2;
		}
		return num;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_02db: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_0082: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_030c: Expected I, but got O
		//IL_0112: Expected O, but got I4
		//IL_00ce: Expected O, but got I
		//IL_0104: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		float num = PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.99f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__8_0;
		bool flag = _003C_003Ec._003C_003E9__8_0 != null;
		nint num3 = unchecked((nint)null);
		if (!flag)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__8_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 1469;
				return obj6 == null;
			});
			num3 = unchecked((nint)null);
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag2 = (object)equipment == null;
		Equipment holy1Weapon = equipment;
		if (flag2)
		{
			goto IL_0319;
		}
		num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Holy1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Holy1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Holy1_Weapon>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v45+FFFFFFF8+v435 @ rax_v40*8]");
			if (0 == (nint)typeof(TP_Holy1_Weapon))
			{
				obj4 = 1;
				goto IL_0328;
			}
		}
		obj4 = 0;
		goto IL_0328;
		IL_0319:
		_holy1Weapon = (TP_Holy1_Weapon)holy1Weapon;
		TP_Holy1_Weapon holy1Weapon2 = _holy1Weapon;
		if ((object)_holy1Weapon != null && ((UnityEngine.Object)holy1Weapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_holy1Weapon);
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag4 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_holy1Weapon);
			GameObject gameObject = _holy1Weapon.gameObject;
			gameObject.SetActive(value: true);
		}
		return;
		IL_0328:
		bool flag5 = obj4 == null;
		holy1Weapon = null;
		if (!flag5)
		{
			holy1Weapon = equipment;
		}
		goto IL_0319;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
		TP_Holy1_Weapon holy1Weapon = _holy1Weapon;
		if ((object)_holy1Weapon != null && ((UnityEngine.Object)holy1Weapon).m_CachedPtr != (IntPtr)0)
		{
			_holy1Weapon.InternalUpdate();
		}
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
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Invalid comparison between O and F4
		support.Trigger();
		float num = PInterval();
		float num3 = default(float);
		float num2 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num4 = PInterval();
			_lastFiringInterval = num3;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void SetVisible(bool visible)
	{
		TP_Holy1_Weapon holy1Weapon = _holy1Weapon;
		_isVisible = visible;
		if ((object)_holy1Weapon != null && ((UnityEngine.Object)holy1Weapon).m_CachedPtr != (IntPtr)0)
		{
			_holy1Weapon.SetVisible(visible);
		}
		TP_Holy2_WeaponSupport tP_Holy2_WeaponSupport = support;
		tP_Holy2_WeaponSupport._mesh.enabled = visible;
	}
}
