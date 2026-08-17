using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Mech_BallisticMissile_Weapon : Weapon
{
	protected readonly Dictionary<WeaponType, string> _glimmerNames;

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	protected unsafe override void OnStart()
	{
		//IL_0063: Expected O, but got Ref
		base.OnStart();
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)2376, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
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
		//IL_0144: Expected F4, but got I4
		//IL_0172: Expected I, but got O
		//IL_01b9: Expected O, but got I4
		//IL_0207: Expected O, but got I4
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0245: Invalid comparison between O and F4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)2376, out object value))
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
		_ = 2376;
		stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		float num = base.PSpeed();
		float num2 = 0f + 0f;
		if (!(num2 > 1f))
		{
			num2 = 1f;
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Sfx_eme_ballisticmissile, 500f, 1, 0f, volume, rate, detune, loop, 1f);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num3 = 1.06199776E+09f + 0.32f;
		nint num4 = (nint)this;
		float num5 = base.PAmount();
		float num6 = num3 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech_BallisticMissile_Weapon>)+410]");
		bool flag = ((Dictionary<WeaponType, string>)(object)this).TryGetValue(WeaponType.VOID, out *(string*)1);
		object obj4 = (flag ? 1 : 0) + (flag ? 1 : 0);
		if ((nint)obj4 < 14)
		{
			if ((nint)obj4 <= 0)
			{
				goto IL_020c;
			}
		}
		else
		{
			obj4 = 14;
		}
		int num7 = 0;
		int num8 = default(int);
		num7 = num8;
		do
		{
			Projectile projectile = base.FireOneProjectile(position, num7, _targetTransform);
			num7++;
		}
		while (num7 < (nint)obj4);
		goto IL_020c;
		IL_020c:
		float num9 = base.PInterval();
		float num10 = _lastFiringInterval - num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj5 = num10 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num11 = base.PInterval();
			_lastFiringInterval = num6;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public EME_Mech_BallisticMissile_Weapon()
	{
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		_glimmerNames = glimmerNames;
		base._002Ector();
	}
}
