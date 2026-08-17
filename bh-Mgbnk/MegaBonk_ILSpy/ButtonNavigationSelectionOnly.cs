using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonNavigationSelectionOnly : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int index;

		public ButtonNavigationSelectionOnly _003C_003E4__this;

		internal void _003CInit_003Eb__0()
		{
			_003C_003E4__this.ButtonPressed(index);
		}
	}

	private MyButtonTabs[] buttons;

	public int current;

	public float cooldown;

	private float lastPressedTime;

	public Action<int> A_ButtonSelected;

	public int startButton;

	private void Start()
	{
		if (buttons == null)
		{
			Init();
			ButtonPressed(startButton);
		}
	}

	private void Init()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected F4, but got Unknown
		if (buttons != null)
		{
			return;
		}
		float num = cooldown;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		float num2 = num ^ 0;
		lastPressedTime = num2;
		MyButtonTabs[] componentsInChildren = GetComponentsInChildren<MyButtonTabs>();
		buttons = componentsInChildren;
		MyButtonTabs[] array = buttons;
		int num3 = 0;
		for (int num4 = 0; num4 < array.Length; num4 = num3)
		{
			_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass7_0();
			CS_0024_003C_003E8__locals4._003C_003E4__this = this;
			CS_0024_003C_003E8__locals4.index = num3;
			MyButtonTabs[] array2 = buttons;
			Button button = array2[num3].GetButton();
			UnityAction call = delegate
			{
				CS_0024_003C_003E8__locals4._003C_003E4__this.ButtonPressed(CS_0024_003C_003E8__locals4.index);
			};
			button.m_OnClick.AddListener(call);
			array = buttons;
			num3++;
		}
	}

	private void ReInit()
	{
	}

	public void ButtonPressed(int index, bool force = false)
	{
		//IL_00ba: Expected I, but got O
		//IL_00eb: Expected O, but got I
		//IL_00eb: Expected O, but got I
		if (buttons == null)
		{
			Init();
		}
		if (!force)
		{
			float time = Time.time;
			float num = time - lastPressedTime;
			if (num < cooldown || current == index)
			{
				return;
			}
		}
		if (current != -1)
		{
			nint num2 = (nint)buttons;
			int num3 = current;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v10 (Il2CppMethodInfo)+20+v194 @ rax_v12 (System.Int32)*8]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v10 (Il2CppMethodInfo)+20+index @ rdx (System.Int32)*8]");
			((MyButtonTabs)num4).Deselect((MyButtonTabs)0);
		}
		MyButtonTabs[] array = buttons;
		current = index;
		array[index].Select();
		float time2 = Time.time;
		Action<int> a_ButtonSelected = A_ButtonSelected;
		lastPressedTime = time2;
		if (A_ButtonSelected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v165 @ rax_v10 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	private bool CanPress()
	{
		float time = Time.time;
		float num = time - lastPressedTime;
		bool flag = num < cooldown;
		return !flag;
	}

	public Button GetSelectedButton()
	{
		MyButtonTabs[] array = buttons;
		int num = current;
		if (current < array.Length)
		{
			return array[num].GetButton();
		}
		return (Button)(object)new IndexOutOfRangeException();
	}

	public int GetNumButtons()
	{
		//IL_003e: Expected I4, but got O
		MyButtonTabs[] array = buttons;
		if (buttons != null)
		{
			return array.Length;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public ButtonNavigationSelectionOnly()
	{
		//IL_000f: Expected I4, but got I8
		current = -1;
		base._002Ector();
	}
}
