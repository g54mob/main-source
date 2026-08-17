using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Ring_Chaos_Weapon : EME_Ring_Generic_Magic_Weapon
{
	public override WeaponType GlimmerName => WeaponType.EME_MAGIC_TECH_06;

	protected unsafe override void OnStart()
	{
		//IL_0116: Expected O, but got Ref
		//IL_00ee: Expected I4, but got O
		((Weapon)this).OnStart();
		WeaponType glimmerName = GlimmerName;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool flag = default(bool);
		GameObject gameObject = default(GameObject);
		string text2 = default(string);
		bool flag2 = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag, gameObject, text2, flag2);
		bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)glimmerName, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		if (list._size == 0)
		{
			Action onComplete = delegate
			{
				base.Fire();
			};
			Timer timer = Timers.Register(10f, onComplete, null, isLooped: false, flag, (MonoBehaviour)(object)gameObject, (int)text2, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		}
	}

	private void _003COnStart_003Eb__2_0()
	{
		base.Fire();
	}
}
