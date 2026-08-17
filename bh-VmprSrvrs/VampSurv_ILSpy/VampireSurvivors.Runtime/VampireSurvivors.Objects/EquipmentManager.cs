using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects;

public abstract class EquipmentManager : GameMonoBehaviour
{
	private readonly List<Equipment> _003CActiveEquipment_003Ek__BackingField;

	private readonly List<Equipment> _003CHiddenEquipment_003Ek__BackingField;

	private readonly List<Equipment> _003CRemovedHiddenEquipment_003Ek__BackingField;

	private readonly List<Equipment> _003CRemovedEquipment_003Ek__BackingField;

	public static int MaxCapacity => 6;

	public List<Equipment> ActiveEquipment => _003CActiveEquipment_003Ek__BackingField;

	public List<Equipment> HiddenEquipment => _003CHiddenEquipment_003Ek__BackingField;

	public List<Equipment> RemovedHiddenEquipment => _003CRemovedHiddenEquipment_003Ek__BackingField;

	public List<Equipment> RemovedEquipment => _003CRemovedEquipment_003Ek__BackingField;

	public unsafe Equipment GetEquipmentByType(WeaponType equipmentType, bool searchHidden = false)
	{
		//IL_0023: Expected O, but got Ref
		if (searchHidden)
		{
		}
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			Equipment equipment = null;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Equipment GetRemovedHiddenEquipment(WeaponType equipmentType)
	{
		//IL_0017: Expected O, but got Ref
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			Equipment equipment = null;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Equipment GetRemovedEquipment(WeaponType equipmentType)
	{
		//IL_0017: Expected O, but got Ref
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			Equipment equipment = null;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public void LevelUpAllActiveEquipment()
	{
		//IL_0013: Expected O, but got I4
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public unsafe void MaxLevelUpAllEquipment()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0024: Expected O, but got I4
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		object obj;
		do
		{
			if (enumerator.MoveNext())
			{
				List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)0;
				List<Equipment>.Enumerator enumerator3 = (List<Equipment>.Enumerator)(&enumerator);
				obj = 0;
				continue;
			}
			return;
		}
		while ((nint)obj >= 10);
		throw new NullReferenceException();
	}

	public void AddEquipment(Equipment item)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
	}

	public void AddHiddenEquipment(Equipment item)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
	}

	public void RemoveEquipment(Equipment item)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
		object obj = default(object);
		if (obj != null)
		{
			GameObject gameObject = item.gameObject;
			gameObject.SetActive(value: false);
			bool flag = ((List<object>)(object)_003CActiveEquipment_003Ek__BackingField).Remove((object)item);
			bool flag2 = _003CRemovedEquipment_003Ek__BackingField.Remove(item);
		}
	}

	public void RemoveHiddenEquipment(Equipment item)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
		object obj = default(object);
		if (obj != null)
		{
			GameObject gameObject = item.gameObject;
			gameObject.SetActive(value: false);
			bool flag = ((List<object>)(object)_003CHiddenEquipment_003Ek__BackingField).Remove((object)item);
			bool flag2 = _003CRemovedHiddenEquipment_003Ek__BackingField.Remove(item);
		}
	}

	protected EquipmentManager()
	{
		List<Equipment> list = new List<Equipment>();
		_003CActiveEquipment_003Ek__BackingField = list;
		List<Equipment> list2 = new List<Equipment>();
		_003CHiddenEquipment_003Ek__BackingField = list2;
		List<Equipment> list3 = new List<Equipment>();
		_003CRemovedHiddenEquipment_003Ek__BackingField = list3;
		List<Equipment> list4 = new List<Equipment>();
		_003CRemovedEquipment_003Ek__BackingField = list4;
		base._onResumeSent = true;
	}
}
