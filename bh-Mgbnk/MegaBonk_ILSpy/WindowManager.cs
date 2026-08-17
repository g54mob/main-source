using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

public static class WindowManager
{
	public static List<Window> openWindows;

	public static Window activeWindow;

	public static Action<Window> A_WindowOpened;

	public static void Update()
	{
		//IL_016c: Expected I, but got O
		//IL_00fd: Expected F8, but got I4
		if (activeWindow != null && !Cursor.visible)
		{
			Vector3 mousePositionDelta = Input.mousePositionDelta;
			nint num = (nint)typeof(Math);
			float num2 = mousePositionDelta.y * mousePositionDelta.y;
			float num3 = mousePositionDelta.x * mousePositionDelta.x;
			float num4 = mousePositionDelta.z * mousePositionDelta.z;
			float num5 = num2 + num3;
			float num6 = num5 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v9 (Il2CppClass<System.Math>)+E4]");
			double num7;
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
				num7 = 0.0;
			}
			else
			{
				num7 = Math.Sqrt(num6);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			if (num7 > 0.10000000149011612)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
		}
	}

	public unsafe static void CloseAll()
	{
		//IL_0108: Expected O, but got I
		IEnumerable<object> enumerable = openWindows;
		List<object> list = Enumerable.ToList((IEnumerable<object>)openWindows);
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			UnityEngine.Object obj = default(UnityEngine.Object);
			while (enumerator.MoveNext())
			{
				if (obj != null)
				{
					if ((object)obj == null)
					{
						throw new NullReferenceException();
					}
					GameObject gameObject = ((Component)obj).gameObject;
					if (gameObject != null)
					{
						((Window)obj).Close();
					}
				}
			}
			((List<Window>.Enumerator*)(&enumerator))->Dispose();
			enumerable = openWindows;
			if (openWindows != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+10]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+18]");
					Array.Clear((Array)num, 0, 0);
				}
				RefreshCursor();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public static void WindowOpened(Window newWindow)
	{
		if (activeWindow != null)
		{
			activeWindow.UnfocusWindow();
		}
		newWindow.FocusWindow();
		activeWindow = newWindow;
		List<object> list = (List<object>)(object)openWindows;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)newWindow);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			int num = default(int);
			items[num] = newWindow;
		}
		RefreshCursor();
		Action<Window> a_WindowOpened = A_WindowOpened;
		if (A_WindowOpened != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v306 @ rax_v22 (System.Action`1<Window>)+18] (should have been resolved before IL gen)");
		}
	}

	public static void WindowClosed(Window closedWindow)
	{
		bool flag = ((List<object>)(object)openWindows).Remove((object)closedWindow);
		List<Window> list = openWindows;
		if (list._size <= 0)
		{
			activeWindow = null;
			AlwaysUi instance = AlwaysUi.Instance;
			if ((object)AlwaysUi.Instance != null && (object)instance.selectionArrow != null)
			{
				instance.selectionArrow.Hide();
			}
			EventSystem.current?.SetSelectedGameObject(null);
			ButtonManager.SetNull();
		}
		else
		{
			List<Window> list2 = openWindows;
			int index = list2._size - 1;
			Window window = list2.get_Item(index);
			activeWindow = window;
			activeWindow.FocusWindow();
		}
		RefreshCursor();
	}

	public static void RefreshCursor()
	{
		CursorLockMode lockState;
		bool visible;
		if (activeWindow != null && !MyInputManager.IsUsingController())
		{
			lockState = CursorLockMode.None;
			visible = true;
		}
		else
		{
			lockState = CursorLockMode.Locked;
			visible = false;
		}
		Cursor.visible = visible;
		Cursor.lockState = lockState;
	}

	public static bool HasOpenWindow()
	{
		//IL_009e: Expected I4, but got O
		List<Window> list = openWindows;
		if (openWindows != null)
		{
			int num = list._size ^ list._size;
			int num2 = list._size & num;
			bool flag = num2 < 0;
			bool flag2 = list._size < 0;
			bool flag3 = list._size == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static int GetNumOpenWindows()
	{
		//IL_001d: Expected I4, but got O
		List<Window> list = openWindows;
		if (openWindows != null)
		{
			return list._size;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public unsafe static void OnGUI()
	{
		//IL_00d9: Expected O, but got Ref
		//IL_007a: Expected O, but got I
		//IL_00f1: Expected O, but got Ref
		//IL_0094: Expected O, but got I
		//IL_00b8: Expected O, but got Ref
		int num = 0;
		object obj = default(object);
		object obj2 = default(object);
		while (true)
		{
			List<Window> list = openWindows;
			if (num < list._size)
			{
				Window window = openWindows.get_Item(num);
				if (window != activeWindow)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED70]");
					obj = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED50]");
					obj = 0;
				}
				GUI.color = (Color)(&obj);
				string name = window.name;
				GUI.Box((Rect)(&obj2), name);
				num++;
				continue;
			}
			break;
		}
		GUI.color = (Color)(&obj);
	}

	static WindowManager()
	{
		List<Window> list = new List<Window>();
		openWindows = list;
	}
}
