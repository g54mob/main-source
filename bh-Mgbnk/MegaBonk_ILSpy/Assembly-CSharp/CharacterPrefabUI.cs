using System;
using Cpp2ILInjected;
using UnityEngine;

public class CharacterPrefabUI : SelectionButton
{
	public static Action<CharacterData> A_CharacterSelected;

	public static Action<CharacterPrefabUI> A_CharacterClicked;

	public CharacterData characterData;

	public void SetCharacter(CharacterData data)
	{
		characterData = data;
		string text = characterData.GetName();
		t_name.text = text;
		Texture icon = characterData.GetIcon();
		i_icon.texture = icon;
	}

	protected void OnCharacterSelected(CharacterData data)
	{
		if (data != characterData)
		{
			clicked = false;
			selectionOverlay.SetActive(value: false);
		}
	}

	protected override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<CharacterData> b = OnCharacterSelected;
		Delegate obj = Delegate.Combine(A_CharacterSelected, b);
		if ((object)obj == null)
		{
			A_CharacterSelected = (Action<CharacterData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<CharacterData> action = default(Action<CharacterData>);
		if (action != null)
		{
			A_CharacterSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<CharacterData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<CharacterData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	protected override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<CharacterData> value = OnCharacterSelected;
		Delegate obj = Delegate.Remove(A_CharacterSelected, value);
		if ((object)obj == null)
		{
			A_CharacterSelected = (Action<CharacterData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<CharacterData> action = default(Action<CharacterData>);
		if (action != null)
		{
			A_CharacterSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<CharacterData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<CharacterData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	protected override void OnClicked()
	{
		Action<CharacterPrefabUI> a_CharacterClicked = A_CharacterClicked;
		if (A_CharacterClicked != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<CharacterPrefabUI>)+18] (should have been resolved before IL gen)");
		}
	}

	protected override void OnSelectedCharacter()
	{
		Action<CharacterData> a_CharacterSelected = A_CharacterSelected;
		if (A_CharacterSelected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<CharacterData>)+18] (should have been resolved before IL gen)");
		}
	}
}
