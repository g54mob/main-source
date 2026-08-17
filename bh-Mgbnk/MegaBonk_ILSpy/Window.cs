using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Cpp2ILInjected;
using UnityEngine;

public class Window : MonoBehaviour
{
	protected MyButton savedBtn;

	public MyButton startBtn;

	public bool alwaysUseStartBtn;

	public float openDelay;

	public List<MyButton> allButtons;

	public HashSet<GameObject> allButtonsHashed;

	private bool isFocused;

	public static Action A_WindowOpenedFirstTime;

	private float lastHadButtonTime;

	protected void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyButton> b = OnButtonHover;
		Delegate obj = Delegate.Combine(ButtonManager.A_ButtonHover, b);
		if ((object)obj == null)
		{
			ButtonManager.A_ButtonHover = (Action<MyButton>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyButton> action = default(Action<MyButton>);
		if (action != null)
		{
			ButtonManager.A_ButtonHover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyButton>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyButton>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	protected void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyButton> value = OnButtonHover;
		Delegate obj = Delegate.Remove(ButtonManager.A_ButtonHover, value);
		if ((object)obj == null)
		{
			ButtonManager.A_ButtonHover = (Action<MyButton>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyButton> action = default(Action<MyButton>);
		if (action != null)
		{
			ButtonManager.A_ButtonHover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyButton>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyButton>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe void FindAllButtonsInWindow()
	{
		MyButton[] componentsInChildren = GetComponentsInChildren<MyButton>(includeInactive: true);
		List<object> list = Enumerable.ToList((IEnumerable<object>)componentsInChildren);
		allButtons = (List<MyButton>)(object)list;
		HashSet<GameObject> hashSet = (HashSet<GameObject>)(object)new HashSet<object>();
		allButtonsHashed = hashSet;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Component component = default(Component);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component == null)
				{
					break;
				}
				GameObject item = component.gameObject;
				bool flag = allButtonsHashed.Add(item);
				continue;
			}
			((List<MyButton>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	protected void Start()
	{
		FindAllButtonsInWindow();
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
		Action a_WindowOpenedFirstTime = A_WindowOpenedFirstTime;
		if (A_WindowOpenedFirstTime != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v36.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	protected void OnEnable()
	{
		WindowManager.WindowOpened(this);
	}

	protected void OnDisable()
	{
		WindowManager.WindowClosed(this);
		CancelInvoke("DelayedButtonFocus");
	}

	public void Close()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject != null)
		{
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
		}
	}

	private void OnButtonHover(MyButton btn)
	{
		GameObject item = btn.gameObject;
		if (((HashSet<object>)(object)allButtonsHashed).Contains((object)item))
		{
			savedBtn = btn;
		}
	}

	public unsafe void FocusWindow()
	{
		//IL_0101: Invalid comparison between F4 and I4
		isFocused = true;
		if (allButtons == null)
		{
			FindAllButtonsInWindow();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		MyButton myButton = default(MyButton);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)myButton == null)
				{
					break;
				}
				myButton.SetFocus(focus: true);
				continue;
			}
			((List<MyButton>.Enumerator*)(&enumerator))->Dispose();
			if (!(openDelay > 0f))
			{
				Invoke("DelayedButtonFocus", 0f);
				return;
			}
			CancelInvoke("DelayedButtonFocus");
			Invoke("DelayedButtonFocus", openDelay);
			return;
		}
		throw new NullReferenceException();
	}

	private void DelayedButtonFocus()
	{
		if (savedBtn != null && !alwaysUseStartBtn)
		{
			ButtonManager.SetFirstButton(savedBtn);
			ButtonManager.ForceHoverButton(savedBtn);
		}
		else
		{
			ButtonManager.SetFirstButton(startBtn);
			ButtonManager.ForceHoverButton(startBtn);
		}
	}

	public unsafe void UnfocusWindow()
	{
		isFocused = false;
		if (allButtons == null)
		{
			FindAllButtonsInWindow();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		MyButton myButton = default(MyButton);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)myButton == null)
				{
					break;
				}
				myButton.SetFocus(focus: false);
				continue;
			}
			((List<MyButton>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	protected void Update()
	{
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_02fe: Invalid comparison between O and F4
		//IL_030d: Expected O, but got I4
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_0347: Invalid comparison between O and F4
		//IL_0356: Expected O, but got I4
		//IL_037b: Expected O, but got I4
		//IL_03ab: Expected O, but got I4
		bool flag = ButtonManager.selectedButton2 != null;
		if (!flag)
		{
			if (isFocused == flag)
			{
				return;
			}
			float time = Time.time;
			float num = time - lastHadButtonTime;
			if (0.5f > num)
			{
				return;
			}
			float axis = MyInputManager.GetAxis(MyInputManager.UIHorizontal);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj = axis & 0;
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f);
			object obj2 = 0;
			if (!flag2)
			{
				float axis2 = MyInputManager.GetAxis(MyInputManager.UIVertical);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				obj = axis2 & 0;
				bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f);
				obj2 = 0;
				if (!flag3)
				{
					bool buttonDown = MyInputManager.GetButtonDown(MyInputManager.UISubmit);
					obj2 = 0;
					if (!buttonDown)
					{
						bool buttonDown2 = MyInputManager.GetButtonDown(MyInputManager.UICancel);
						bool flag4 = !buttonDown2;
						obj2 = 0;
						if (flag4)
						{
							return;
						}
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803635B0");
			UnityEngine.Object obj3 = default(UnityEngine.Object);
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803635B0");
				Component component = default(Component);
				GameObject item = component.gameObject;
				if (((HashSet<object>)(object)allButtonsHashed).Contains((object)item))
				{
					return;
				}
			}
			if (startBtn != null)
			{
				GameObject gameObject = startBtn.gameObject;
				if (gameObject.activeInHierarchy)
				{
					ButtonManager.ForceHoverButton(startBtn);
					return;
				}
			}
			List<MyButton> list = allButtons;
			if (list._size <= 0)
			{
				return;
			}
			int num2 = 0;
			for (int num3 = 0; num3 < list._size; num3 = num2)
			{
				MyButton myButton = allButtons.get_Item(num2);
				if (myButton != null)
				{
					MyButton myButton2 = allButtons.get_Item(num2);
					GameObject gameObject2 = myButton2.gameObject;
					if (gameObject2.activeInHierarchy)
					{
						MyButton btn = allButtons.get_Item(num2);
						ButtonManager.ForceHoverButton(btn);
					}
				}
				list = allButtons;
				num2++;
			}
		}
		else
		{
			float time2 = Time.time;
			lastHadButtonTime = time2;
		}
	}

	public Window()
	{
		HashSet<GameObject> hashSet = (HashSet<GameObject>)(object)new HashSet<object>();
		allButtonsHashed = hashSet;
		base._002Ector();
	}
}
