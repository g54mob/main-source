using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class LarobbaWeapon : Weapon
{
	private readonly List<float> _targetAngles;

	private int _lastAngleIndex;

	private const int MaxAngles = 12;

	private const int MaxFrames = 20;

	private int _lastRobbaIndex;

	private List<Sprite> _robbaFrames;

	public override void CheckArcanas()
	{
		if (!_beginningArcana)
		{
			GameManager gameMan = _gameMan;
			List<WeaponType> list = gameMan._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager gameMan2 = _gameMan;
				List<WeaponType> list2 = gameMan2._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj = default(object);
				if (obj != null)
				{
					int beginningAmount = _beginningAmount + 3;
					_beginningAmount = beginningAmount;
					WeaponData currentWeaponData = _currentWeaponData;
					_beginningArcana = true;
					int num = currentWeaponData._003Camount_003Ek__BackingField + 3;
					currentWeaponData._003Camount_003Ek__BackingField = num;
				}
			}
			if (!_beginningArcana)
			{
				GameManager core = GM.Core;
				List<WeaponType> list3 = core._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 > (nint)0)
				{
					GameManager core2 = GM.Core;
					List<WeaponType> list4 = core2._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj2 = default(object);
					if ((nint)obj2 == -1)
					{
						int beginningAmount2 = _beginningAmount + 1;
						_beginningAmount = beginningAmount2;
						WeaponData currentWeaponData2 = _currentWeaponData;
						_beginningArcana = true;
						int num2 = currentWeaponData2._003Camount_003Ek__BackingField + 1;
						currentWeaponData2._003Camount_003Ek__BackingField = num2;
					}
				}
			}
		}
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager = core3._arcanaManager;
		List<ArcanaType> list5 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj3 = default(object);
		if ((nint)obj3 > -1)
		{
			_explodeOnExpire = true;
		}
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_004f: Expected O, but got I
		//IL_005f: Expected O, but got I
		//IL_00f6: Expected O, but got I
		//IL_01ed: Expected O, but got Ref
		base.InitWeapon(characterController, weaponType);
		List<float> targetAngles = _targetAngles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		int num = 0;
		do
		{
			List<float> targetAngles2 = _targetAngles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = 0;
			float num2 = (float)num * ((float)Math.PI / 2f);
			float num3 = num2 / 12f;
			float num4 = num3 + (float)Math.PI / 4f;
			float item = num4 ^ -0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r8_v5+18]");
			if (num5 >= 0)
			{
				targetAngles2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj3 = (nint)0 + (nint)1;
			}
			num++;
		}
		while (num < 12);
		Extensions.Shuffle(_targetAngles);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController2._characterType == CharacterType.TP_JUSTE)
		{
			List<Sprite> robbaFrames = _robbaFrames;
			int version = robbaFrames._version + 1;
			robbaFrames._version = version;
			robbaFrames._size = 0;
			if (robbaFrames._size > 0)
			{
				Array.Clear(robbaFrames._items, 0, robbaFrames._size);
			}
			int num6 = 1;
			object obj4 = default(object);
			do
			{
				string text = System.Number.FormatInt32(num6, (ReadOnlySpan<char>)(&obj4), null);
				string spriteName = "TP_VFX_Stuff" + text;
				Sprite sprite = SpriteManager.GetSprite(spriteName, "ThosePeople");
				if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
				}
				num6++;
			}
			while (num6 <= 25);
		}
		Extensions.Shuffle((IList<object>)_robbaFrames);
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
		object obj = _lastAngleIndex + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		nint num = default(nint);
		object obj2 = num >> 1;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 2;
		object obj6 = obj4 + obj5;
		object obj7 = obj6 << 2;
		int num2 = (_lastAngleIndex = obj - obj7);
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

	public Sprite GetRobbaFrame()
	{
		//IL_0063: Expected O, but got I4
		//IL_007b: Expected O, but got I
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00cc: Expected I4, but got O
		List<Sprite> robbaFrames = _robbaFrames;
		object obj = _lastRobbaIndex + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		nint num = default(nint);
		object obj2 = num >> 3;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 4;
		object obj6 = obj4 + obj5;
		object obj7 = obj6 << 2;
		int num2 = (_lastRobbaIndex = obj - obj7);
		if (num2 < robbaFrames._size)
		{
			Sprite[] items = robbaFrames._items;
			return items[num2];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sprite result = default(Sprite);
		return result;
	}

	public override bool LevelUp()
	{
		//IL_0020: Expected I, but got O
		//IL_0030: Expected O, but got I
		//IL_0040: Expected O, but got I
		Extensions.Shuffle(_targetAngles);
		Extensions.Shuffle((IList<object>)_robbaFrames);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.LarobbaWeapon>)+208]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.LarobbaWeapon>)+210]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v40 @ rax_v4 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public LarobbaWeapon()
	{
		List<float> targetAngles = new List<float>();
		_targetAngles = targetAngles;
		base._002Ector();
	}
}
