using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Axe_HellsFury_Weapon : Weapon
{
	protected readonly Dictionary<WeaponType, string> _glimmerNames;

	public override float PAmount()
	{
		return 1f;
	}

	protected override void Awake()
	{
		base.Awake();
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	protected unsafe override void OnStart()
	{
		//IL_0087: Expected O, but got Ref
		base.OnStart();
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)2389, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		float num = base.PInterval();
		object obj2 = default(object);
		float num2 = (float)obj2 * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	private void UpdateFiringTimer()
	{
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
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
		if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)2389, out object value))
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
		_ = 2389;
		stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
	}

	public EME_Axe_HellsFury_Weapon()
	{
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		_glimmerNames = glimmerNames;
		base._002Ector();
	}
}
