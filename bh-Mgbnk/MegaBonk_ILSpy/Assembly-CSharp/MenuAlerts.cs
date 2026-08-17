using System;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;

public class MenuAlerts : MonoBehaviour
{
	public GameObject alertUnlocks;

	public GameObject alertQuests;

	public GameObject alertShop;

	private void Awake()
	{
		//IL_0101: Expected I, but got O
		Action b = Refresh;
		Delegate obj = Delegate.Combine(SaveManager.A_SavesLoaded, b);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = Refresh;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, value);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnable()
	{
		Refresh();
	}

	private void Refresh()
	{
		if (!(SaveManager._003CInstance_003Ek__BackingField != null))
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		HashSet<string> newUnlockables = progression.newUnlockables;
		GameObject gameObject;
		bool active;
		if (newUnlockables._count <= 0)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression2 = saveManager2.progression;
			MenuMeta menuMeta = progression2.menuMeta;
			if (menuMeta.hasVisitedUnlocks)
			{
				gameObject = alertUnlocks;
				active = false;
				goto IL_02df;
			}
		}
		gameObject = alertUnlocks;
		active = true;
		goto IL_02df;
		IL_02fb:
		GameObject gameObject2;
		bool active2;
		gameObject2.SetActive(active2);
		SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression3 = saveManager3.progression;
		HashSet<string> newShopItems = progression3.newShopItems;
		if (newShopItems._count <= 0)
		{
			SaveManager saveManager4 = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression4 = saveManager4.progression;
			MenuMeta menuMeta2 = progression4.menuMeta;
			if (menuMeta2.hasVisitedShop)
			{
				alertShop.SetActive(value: false);
				return;
			}
		}
		alertShop.SetActive(value: true);
		return;
		IL_02df:
		gameObject.SetActive(active);
		SaveManager saveManager5 = SaveManager._003CInstance_003Ek__BackingField;
		if (!saveManager5.progression.HasUnclaimedQuests())
		{
			SaveManager saveManager6 = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression5 = saveManager6.progression;
			MenuMeta menuMeta3 = progression5.menuMeta;
			if (menuMeta3.hasVisitedQuests)
			{
				gameObject2 = alertQuests;
				active2 = false;
				goto IL_02fb;
			}
		}
		gameObject2 = alertQuests;
		active2 = true;
		goto IL_02fb;
	}
}
