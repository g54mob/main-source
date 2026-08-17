using System;
using Assets.Scripts.UI.InGame.Levelup;
using Cpp2ILInjected;
using UnityEngine;

public class InventoryOverlay : MonoBehaviour
{
	public GameObject[] windows;

	public UpgradeInventoryUI inventoryUi;

	private bool active;

	private void Awake()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0230: Expected O, but got I4
		//IL_0246: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_027a: Expected O, but got I4
		Action b = OnWindowOpened;
		Delegate obj = Delegate.Combine(EncounterWindows.A_WindowOpened, b);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			EncounterWindows.A_WindowOpened = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02d3;
			}
			EncounterWindows.A_WindowOpened = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b8;
			}
		}
		Action b2 = OnWindowClosed;
		Delegate obj6 = Delegate.Combine(EncounterWindows.A_WindowClosed, b2);
		if ((object)obj6 == null)
		{
			EncounterWindows.A_WindowClosed = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02c3;
		}
		EncounterWindows.A_WindowClosed = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02d3;
		IL_02b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b8;
		IL_02d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02c3;
	}

	private void OnDestroy()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0230: Expected O, but got I4
		//IL_0246: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_027a: Expected O, but got I4
		Action value = OnWindowOpened;
		Delegate obj = Delegate.Remove(EncounterWindows.A_WindowOpened, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			EncounterWindows.A_WindowOpened = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02d3;
			}
			EncounterWindows.A_WindowOpened = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b8;
			}
		}
		Action value2 = OnWindowClosed;
		Delegate obj6 = Delegate.Remove(EncounterWindows.A_WindowClosed, value2);
		if ((object)obj6 == null)
		{
			EncounterWindows.A_WindowClosed = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02c3;
		}
		EncounterWindows.A_WindowClosed = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02d3;
		IL_02b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b8;
		IL_02d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02c3;
	}

	private void OnWindowOpened()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		GameObject[] array = windows;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			array[obj2].SetActive(value: true);
			obj2++;
			active = true;
			obj = obj2;
		}
		inventoryUi.Refresh();
	}

	private void OnWindowClosed()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		GameObject[] array = windows;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			array[obj2].SetActive(value: false);
			obj2++;
			active = false;
			obj = obj2;
		}
	}

	private void Update()
	{
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		if (!(UiManager.Instance != null) || !active)
		{
			return;
		}
		UiManager instance = UiManager.Instance;
		if (!instance.encounterWindows.HasEncounter())
		{
			GameObject[] array = windows;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				array[obj].SetActive(value: false);
				obj++;
				active = false;
				obj2 = obj;
			}
		}
	}
}
