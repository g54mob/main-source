using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menu.Windows;

public class TabsExplicitNavigation : MonoBehaviour
{
	private enum NavDirection
	{
		Up,
		Down,
		Left,
		Right
	}

	public Selectable topButton;

	public Selectable[] bottomButtons;

	public Transform content;

	public bool manualRefresh;

	private void Start()
	{
		if (!manualRefresh)
		{
			Refresh();
		}
	}

	public unsafe void Refresh()
	{
		//IL_0008: Expected O, but got Ref
		//IL_053f: Expected O, but got I4
		//IL_0183: Expected O, but got Ref
		//IL_01aa: Expected O, but got Ref
		//IL_031e: Expected O, but got Ref
		//IL_0228: Expected O, but got Ref
		//IL_0236: Expected O, but got Ref
		//IL_0448: Expected O, but got Ref
		//IL_04a1: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		List<Selectable> list = new List<Selectable>();
		Transform transform = content;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int childCount = transform.childCount;
			if (num >= childCount)
			{
				break;
			}
			Transform child = content.GetChild(num2);
			GameObject gameObject = child.gameObject;
			if (gameObject.activeSelf)
			{
				Transform child2 = content.GetChild(num2);
				Selectable component = child2.GetComponent<Selectable>();
				if (component != null)
				{
					list.Add(component);
				}
			}
			transform = content;
			num2++;
			num = num2;
		}
		if (list._size <= 0)
		{
			return;
		}
		Navigation navigation = default(Navigation);
		if (topButton != null)
		{
			Selectable selectable = topButton;
			Selectable selectable2 = list.get_Item(0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rdi_v16 (UnityEngine.UI.Selectable)+48]");
			_ = 0;
			selectable.navigation = (Navigation)(&navigation);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v48 (UnityEngine.UI.Selectable)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v48 (UnityEngine.UI.Selectable)+38]");
			_ = 0;
			selectable2.navigation = (Navigation)(&navigation);
			navigation = selectable2.m_Navigation;
		}
		int num3 = 0;
		int num4 = 0;
		while (true)
		{
			object obj3 = list._size - 1;
			if (num4 >= (nint)obj3)
			{
				break;
			}
			Selectable selectable3 = list.get_Item(num3);
			int index = num3 + 1;
			Selectable selectable4 = list.get_Item(index);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rax_v41 (UnityEngine.UI.Selectable)+48]");
			_ = 0;
			selectable3.navigation = (Navigation)(&navigation);
			Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			_ = selectable4.m_Navigation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rax_v42 (UnityEngine.UI.Selectable)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rax_v42 (UnityEngine.UI.Selectable)+38]");
			_ = 0;
			selectable4.navigation = navigation2;
			num3++;
			navigation = selectable3.m_Navigation;
			num4 = num3;
		}
		int index2 = list._size - 1;
		Selectable selectable5 = list.get_Item(index2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v23 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		_ = 0;
		_ = selectable5.m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v23 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		int index3 = list._size - 1;
		Selectable selectable6 = list.get_Item(index3);
		Navigation navigation3 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-20]");
		_ = 0;
		selectable6.navigation = navigation3;
		if (bottomButtons == null)
		{
			return;
		}
		Selectable[] array = bottomButtons;
		if (array.Length == 0)
		{
			return;
		}
		int num5 = 0;
		for (int num6 = 0; num6 < array.Length; num6 = num5)
		{
			Component component2 = array[num5];
			GameObject gameObject2 = array[num5].gameObject;
			if (gameObject2.activeInHierarchy)
			{
				int index4 = list._size - 1;
				Selectable selectable7 = list.get_Item(index4);
				Navigation navigation4 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				_ = selectable7.m_Navigation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rax_v35 (UnityEngine.UI.Selectable)+48]");
				_ = 0;
				selectable7.navigation = navigation4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rsi_v9 (UnityEngine.Component)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rsi_v9 (UnityEngine.Component)+38]");
				_ = 0;
				array[num5].navigation = (Navigation)(&navigation);
			}
			num5++;
		}
	}

	private unsafe void SetNavigation(Selectable parent, Selectable toButton, NavDirection direction)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0133: Expected O, but got Ref
		//IL_0175: Expected O, but got Ref
		//IL_00a9: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = parent.m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parent @ rdx (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parent @ rdx (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		_ = toButton.m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toButton @ r8 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toButton @ r8 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		bool flag = direction == NavDirection.Up;
		if (!flag)
		{
			object obj3 = direction - 1;
			if (!flag)
			{
				object obj4 = obj3 - 1;
				if (!flag && (nint)obj4 != 1)
				{
				}
			}
		}
		Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 31));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
		_ = 0;
		parent.navigation = navigation;
		Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 31));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		_ = 0;
		toButton.navigation = navigation2;
	}
}
