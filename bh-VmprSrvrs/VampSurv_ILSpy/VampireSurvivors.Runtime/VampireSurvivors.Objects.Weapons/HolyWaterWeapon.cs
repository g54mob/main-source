using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class HolyWaterWeapon : Weapon
{
	private readonly List<float> _targetAngles;

	private readonly List<float> _targetRadii;

	private int _lasAngleIndex;

	private int _lastRadiusIndex;

	private const int MaxAngles = 12;

	private float _mul;

	private bool _cooldownAffectedByMovement;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00bc: Expected O, but got I4
		//IL_00e4: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_023b: Expected O, but got I
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		base.InitWeapon(characterController, weaponType);
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj = default(object);
		float num = (float)obj * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v6 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		if (!(num2 > num))
		{
			num = num2;
		}
		List<float> targetAngles = _targetAngles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<float> targetRadii = _targetRadii;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		object obj2 = 0;
		do
		{
			List<float> targetAngles2 = _targetAngles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj3 = 0;
			float num3 = (float)obj2 * ((float)Math.PI * 2f);
			float item = num3 / 12f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v6+18]");
			if (num4 >= 0)
			{
				targetAngles2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			List<float> targetRadii2 = _targetRadii;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v12 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v12 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj5 = 0;
			float num5 = num * 0.1f;
			float num6 = num * 0.25f;
			float num7 = (float)obj2 / 12f;
			float num8 = num7 * num5;
			float item2 = num8 + num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v12 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v8+18]");
			if (num9 >= 0)
			{
				targetRadii2.AddWithResize(item2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v12 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj6 = (nint)0 + (nint)1;
			}
			obj2++;
		}
		while ((nint)obj2 < 12);
		Extensions.Shuffle(_targetRadii);
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_cooldownAffectedByMovement;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 1000f;
			float num4 = frameWalk * 100f;
			float num5 = num3 / _mul;
			float num6 = num5 * num4;
			num2 = (base._003CTotalTime_003Ek__BackingField = num6 + base._003CTotalTime_003Ek__BackingField);
		}
		float num7 = base.PInterval();
		if (!(base._003CTotalTime_003Ek__BackingField < num2))
		{
			float num8 = base.PInterval();
			float num9 = base._003CTotalTime_003Ek__BackingField - num2;
			base._003CTotalTime_003Ek__BackingField = num9;
			base.Fire();
		}
	}

	public override bool LevelUp()
	{
		//IL_0015: Expected I, but got O
		//IL_0025: Expected O, but got I
		//IL_0035: Expected O, but got I
		Extensions.Shuffle(_targetRadii);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.HolyWaterWeapon>)+208]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.HolyWaterWeapon>)+210]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v35 @ rax_v3 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public float GetAngle()
	{
		//IL_0068: Expected O, but got I4
		//IL_0080: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00d1: Expected I4, but got O
		//IL_003c: Expected O, but got I
		//IL_004e: Expected F4, but got I
		List<float> targetAngles = _targetAngles;
		object obj = _lasAngleIndex + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		nint num = default(nint);
		object obj2 = num >> 1;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 2;
		object obj6 = obj4 + obj5;
		object obj7 = obj6 << 2;
		int num2 = (_lasAngleIndex = obj - obj7);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v7+20+v41 @ r8_v3 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public float GetRadius()
	{
		//IL_0068: Expected O, but got I4
		//IL_0080: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00d1: Expected I4, but got O
		//IL_003c: Expected O, but got I
		//IL_004e: Expected F4, but got I
		List<float> targetRadii = _targetRadii;
		object obj = _lastRadiusIndex + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		nint num = default(nint);
		object obj2 = num >> 1;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 2;
		object obj6 = obj4 + obj5;
		object obj7 = obj6 << 2;
		int num2 = (_lastRadiusIndex = obj - obj7);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v7+20+v41 @ r8_v3 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public override float PPower()
	{
		float num = base.PPower();
		float bloodlineArmorValue = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineArmorValue;
		return num + num;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public HolyWaterWeapon()
	{
		List<float> targetAngles = new List<float>();
		_targetAngles = targetAngles;
		_targetRadii = new List<float>();
		_mul = 166f;
		base._002Ector();
	}
}
