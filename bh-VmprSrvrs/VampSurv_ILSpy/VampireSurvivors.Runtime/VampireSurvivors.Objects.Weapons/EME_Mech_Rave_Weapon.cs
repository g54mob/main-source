using System;
using System.Collections.Generic;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Mech_Rave_Weapon : Weapon, EME_iCosmicRaveVFX
{
	private BulletPool _cosmicRaveVFXpool;

	private Projectile _CosmicRaveVFXPrefab;

	protected readonly Dictionary<WeaponType, string> _glimmerNames;

	protected override void Awake()
	{
		base.Awake();
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	protected unsafe override void OnStart()
	{
		//IL_00b3: Expected O, but got Ref
		base.OnStart();
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)2378, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		if (_cosmicRaveVFXpool == null)
		{
			BulletPool cosmicRaveVFXpool = new BulletPool(_CosmicRaveVFXPrefab, 20);
			_cosmicRaveVFXpool = cosmicRaveVFXpool;
		}
	}

	public void DisplayCosmicRaveVFX(float2 position)
	{
		Projectile projectile = _cosmicRaveVFXpool.SpawnAt(position, this);
	}

	private unsafe void AddGlimmerName(WeaponType glimmerWeaponType)
	{
		//IL_005c: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)glimmerWeaponType, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	private unsafe string GetGlimmerName(WeaponType weaponType)
	{
		//IL_0033: Expected I4, but got O
		//IL_0058: Expected O, but got Ref
		if (_glimmerNames != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)weaponType, out object value))
			{
				object obj = default(object);
				object arg = (WeaponType)obj;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Glimmer weapon types not configured correctly for weapon {0}", (System.ParamsArray)(&obj2));
				GameObject context = base.gameObject;
				Debug.LogWarning(message, context);
				return "Glimmer WeaponType not set";
			}
			return (string)value;
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_004b: Expected I4, but got O
		//IL_0070: Expected O, but got Ref
		base.Fire(skipTriggers);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)2378, out object value))
		{
			object obj = default(object);
			object arg = (WeaponType)obj;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Glimmer weapon types not configured correctly for weapon {0}", (System.ParamsArray)(&obj2));
			GameObject context = base.gameObject;
			Debug.LogWarning(message, context);
			object obj3 = "Glimmer WeaponType not set";
		}
		else
		{
			object obj3 = value;
		}
		Tuple<string, WeaponType> glimmerNameAndType = null;
		_ = 2378;
		stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
	}

	public EME_Mech_Rave_Weapon()
	{
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		_glimmerNames = glimmerNames;
		base._002Ector();
	}
}
