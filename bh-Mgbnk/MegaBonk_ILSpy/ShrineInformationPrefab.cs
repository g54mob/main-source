using System;
using Assets.Scripts.Inventory__Items__Pickups.Chests;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class ShrineInformationPrefab : MonoBehaviour
{
	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_values;

	private string debugName;

	private InteractablesStatus.InteractableStatusContainer container;

	public void Set(InteractablesStatus.InteractableStatusContainer container, string name)
	{
		debugName = name;
		this.container = container;
		t_name.text = name;
		Refresh();
	}

	public void Refresh()
	{
		bool flag;
		if (!(GameManager.Instance != null))
		{
			flag = false;
		}
		else
		{
			GameManager instance = GameManager.Instance;
			flag = instance._003CisCrypt_003Ek__BackingField;
		}
		bool flag2 = debugName == InteractableChest.debugNameCrypt || debugName == InteractablePot.debugNameCrypt;
		bool flag3 = !flag;
		bool flag4 = false;
		if (!flag3)
		{
			flag4 = flag2;
		}
		if (!flag4 && (flag || flag2))
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			return;
		}
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EFE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg} / {arg2}";
		t_values.text = text;
	}

	public void SetValue(int current, int max)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EFE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg} / {arg2}";
		t_values.text = text;
	}

	public bool CanShow()
	{
		//IL_00ec: Expected I4, but got O
		bool flag;
		if (!(GameManager.Instance != null))
		{
			flag = false;
		}
		else
		{
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			flag = instance._003CisCrypt_003Ek__BackingField;
		}
		bool flag2 = debugName == InteractableChest.debugNameCrypt || debugName == InteractablePot.debugNameCrypt;
		bool flag3 = !flag;
		bool flag4 = false;
		if (!flag3)
		{
			flag4 = flag2;
		}
		if (!flag4 && (flag || flag2))
		{
			return false;
		}
		return true;
	}
}
