using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Weapons;

public class TrainHazardWeapon : Weapon
{
	private Vector2 location;

	private float trainPixelSize;

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			float num3 = base.PDuration();
			float num4 = base.PSpeed();
			float num5 = base.PArea();
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num = num2;
			if (!flag2)
			{
				num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num6 = num2 * 0.001f;
					float num7 = num6 + currentWeaponData._003Cpower_003Ek__BackingField;
					float num8 = num7 + num2;
					float num9 = num8 + num2;
					float num10 = num9 * num;
					return num + num10;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void FireFrom(Vector2 from, bool skipTriggers = false)
	{
		location = from;
		Fire(skipTriggers);
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_02b4: Expected O, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0212: Invalid comparison between O and F4
		//IL_0015: Expected O, but got I
		//IL_023d: Expected F4, but got O
		//IL_0155: Expected O, but got F4
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_00d6: Expected O, but got F4
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		Vector2 vector = location;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018755662Bh\"");
		if ((object)location == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TrainHazardWeapon)+15C]");
			vector = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018755662Bh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TrainHazardWeapon)+15C]");
			if ((nint)0 == 0)
			{
				GameManager core = GM.Core;
				GameSessionData gameSessionData = core._gameSessionData;
				float2 position = gameSessionData._activeCharacter.position;
				GameManager core2 = GM.Core;
				GameSessionData gameSessionData2 = core2._gameSessionData;
				float2 position2 = gameSessionData2._activeCharacter.position;
				float num = trainPixelSize * 3f;
				float num2 = (float)position - num;
				location = (Vector2)num2;
				Vector2 vector2 = default(Vector2);
				vector = vector2;
			}
		}
		float num3 = base.PAmount();
		bool flag = (nint)vector <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				GameManager core3 = GM.Core;
				PlayerOptionsData config = core3._playerOptions.Config;
				if (!config._003CSelectedInverse_003Ek__BackingField)
				{
					float num4 = trainPixelSize;
					float num5 = (float)obj * trainPixelSize;
					vector = (Vector2)num5;
				}
				else
				{
					PlayerOptionsData config2 = core3._playerOptions.Config;
					float num4 = trainPixelSize;
					if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
					{
						vector = (Vector2)(obj * trainPixelSize);
					}
					else
					{
						float num6 = (float)obj * trainPixelSize;
						vector = num6 + location;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				obj++;
				float num7 = base.PAmount();
			}
			while (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
		}
		float num8 = base.PInterval();
		float num9 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num9 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num10 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void DealDamage(IDamageable other, float damage)
	{
		if (other == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			if (_currentWeaponData != null)
			{
			}
			float knockback = base.Knockback;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD810");
			float num = damage + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			float num2 = damage + config._003CTrainHazardEnemiesHit_003Ek__BackingField;
			config._003CTrainHazardEnemiesHit_003Ek__BackingField = num2;
		}
	}

	public TrainHazardWeapon()
	{
		//IL_001f: Expected I, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		location = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		trainPixelSize = 3.1f;
		base._002Ector();
	}
}
