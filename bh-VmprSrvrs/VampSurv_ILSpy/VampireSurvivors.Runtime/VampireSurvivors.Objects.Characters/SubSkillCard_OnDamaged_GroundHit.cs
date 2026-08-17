using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnDamaged_GroundHit(ArcanaType type) : CharacterSkillCard_Base(type)
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__4_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitialActivate_003Eb__4_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 222;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private Weapon _groundHitWeapon;

	private bool _canRetaliate = true;

	private float retaliationDelay = 1000f;

	public override void InitialActivate()
	{
		base.InitialActivate();
		CharacterController linkedCharacter = LinkedCharacter;
		_canRetaliate = true;
		CharacterWeaponsManager weaponsManager = linkedCharacter._weaponsManager;
		Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__4_0;
		if (_003C_003Ec._003C_003E9__4_0 == null)
		{
			match = (Predicate<object>)(_003C_003Ec._003C_003E9__4_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 222;
				return obj == null;
			});
		}
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(match);
		if (list._size == 0)
		{
			GameManager core = GM.Core;
			bool allowDuplicates = default(bool);
			Weapon groundHitWeapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.EX_GROUNDHIT, LinkedCharacter, removeFromStore: true, allowDuplicates);
			_groundHitWeapon = groundHitWeapon;
			Weapon groundHitWeapon2 = _groundHitWeapon;
			WeaponData currentWeaponData = groundHitWeapon2._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = 1f;
			Weapon groundHitWeapon3 = _groundHitWeapon;
			((Equipment)groundHitWeapon3)._003CShowInRecap_003Ek__BackingField = false;
		}
	}

	public override void OnOwnerGetDamaged(float damageAmount)
	{
		if (_canRetaliate)
		{
			_groundHitWeapon.Fire();
			_canRetaliate = false;
			Action onComplete = delegate
			{
				_canRetaliate = true;
			};
			float duration = retaliationDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private void _003COnOwnerGetDamaged_003Eb__5_0()
	{
		_canRetaliate = true;
	}
}
