using System;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
	public RectTransform rectTransform;

	private RectTransform selectedRect;

	public Image renderer;

	public RectTransform mask;

	private Transform defaultParent;

	public static SelectionArrow Instance;

	public float sizeOffset = 30f;

	private Vector2 newSize;

	private float fps = 5f;

	private float nextUpdateTime;

	private void Awake()
	{
		//IL_00ad: Expected I, but got O
		//IL_00be: Expected O, but got I4
		//IL_0101: Expected I, but got O
		//IL_0112: Expected O, but got I4
		//IL_017f: Expected I, but got O
		//IL_0190: Expected O, but got I4
		//IL_01d3: Expected I, but got O
		//IL_01e4: Expected O, but got I4
		//IL_03b3: Expected I, but got O
		//IL_03f2: Expected I, but got O
		//IL_0403: Expected O, but got I4
		if (Instance == null)
		{
			Instance = this;
			Transform transform = base.transform;
			Transform parent = transform.parent;
			defaultParent = parent;
			Action<MyButton> b = OnButtonHover;
			Delegate obj = Delegate.Combine(ButtonManager.A_ButtonHover, b);
			nint num;
			Delegate obj2;
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				ButtonManager.A_ButtonHover = (Action<MyButton>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<MyButton> action = default(Action<MyButton>);
				bool flag = action == null;
				num = (nint)typeof(Action<MyButton>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				if (flag)
				{
					goto IL_032e;
				}
				ButtonManager.A_ButtonHover = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<MyButton>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				if (flag2)
				{
					goto IL_033e;
				}
			}
			Action<int> b2 = OnResolutionChanged;
			Delegate obj6 = Delegate.Combine(CurrentSettings.A_ResolutionChanged, b2);
			if ((object)obj6 == null)
			{
				CurrentSettings.A_ResolutionChanged = (Action<int>)obj6;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<int> action2 = default(Action<int>);
				bool flag3 = action2 == null;
				num = (nint)typeof(Action<int>);
				obj2 = obj6;
				obj3 = 0;
				obj4 = null;
				if (flag3)
				{
					goto IL_0376;
				}
				CurrentSettings.A_ResolutionChanged = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj7 = default(object);
				bool flag4 = obj7 == null;
				num = (nint)typeof(Action<int>);
				obj2 = obj6;
				obj3 = 0;
				obj4 = null;
				if (flag4)
				{
					goto IL_0386;
				}
			}
			Action action3 = Refresh;
			Delegate obj8 = Delegate.Combine(Window.A_WindowOpenedFirstTime, action3);
			if ((object)obj8 == null)
			{
				Window.A_WindowOpenedFirstTime = null;
				return;
			}
			bool flag5 = (object)obj8.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag5)
			{
				obj9 = obj8;
			}
			bool flag6 = (object)obj9 == null;
			nint num2 = (nint)typeof(Action);
			if (!flag6)
			{
				Window.A_WindowOpenedFirstTime = (Action)obj9;
				bool flag7 = (object)obj8.GetType() != typeof(Action);
				Delegate obj10 = null;
				if (!flag7)
				{
					obj10 = obj8;
				}
				if ((object)obj10 != null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			num = (nint)Window.A_WindowOpenedFirstTime;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			goto IL_0386;
		}
		GameObject obj11 = base.gameObject;
		UnityEngine.Object.Destroy(obj11);
		return;
		IL_033e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_032e;
		IL_0386:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0376;
		IL_032e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		throw new NullReferenceException();
		IL_0376:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_033e;
	}

	private void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317313B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("FirstSelection", 0.02f);
	}

	private void FirstSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 70 Invalid \"Jump target not found in method: 0x180578550\"");
	}

	private void OnDestroy()
	{
		//IL_027c: Expected I, but got O
		//IL_028d: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0108: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_015c: Expected I, but got O
		//IL_016d: Expected O, but got I4
		//IL_0189: Expected I, but got O
		//IL_0317: Expected O, but got I4
		//IL_032d: Expected I, but got O
		//IL_035b: Expected O, but got I4
		//IL_0371: Expected I, but got O
		Action<MyButton> value = OnButtonHover;
		Delegate obj = Delegate.Remove(ButtonManager.A_ButtonHover, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			ButtonManager.A_ButtonHover = (Action<MyButton>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButton> action = default(Action<MyButton>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<MyButton>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_03b7;
			}
			ButtonManager.A_ButtonHover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<MyButton>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_029c;
			}
		}
		Action<int> value2 = OnResolutionChanged;
		Delegate obj6 = Delegate.Remove(CurrentSettings.A_ResolutionChanged, value2);
		if ((object)obj6 == null)
		{
			CurrentSettings.A_ResolutionChanged = (Action<int>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_02cf;
			}
			CurrentSettings.A_ResolutionChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_02df;
			}
		}
		num = (nint)Window.A_WindowOpenedFirstTime;
		Action action3 = Refresh;
		Delegate obj8 = Delegate.Remove(Window.A_WindowOpenedFirstTime, action3);
		if ((object)obj8 == null)
		{
			Window.A_WindowOpenedFirstTime = null;
			return;
		}
		bool flag4 = (object)obj8.GetType() != typeof(Action);
		Delegate obj9 = null;
		if (!flag4)
		{
			obj9 = obj8;
		}
		bool flag5 = (object)obj9 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_03a7;
		}
		Window.A_WindowOpenedFirstTime = (Action)obj9;
		bool flag6 = (object)obj8.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj8;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num4 = (nint)typeof(Action);
		if (!flag7)
		{
			return;
		}
		goto IL_03b7;
		IL_03a7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02df;
		IL_03b7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a7;
		IL_02df:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02cf;
		IL_029c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_029c;
	}

	private unsafe void OnButtonHover(MyButton btn)
	{
		//IL_003e: Expected O, but got I4
		//IL_0194: Expected O, but got I4
		//IL_0408: Expected O, but got I4
		//IL_00b4: Expected F4, but got O
		//IL_00c3: Expected O, but got Ref
		//IL_00e6: Expected O, but got Ref
		//IL_00ef: Expected O, but got I4
		//IL_0297: Expected O, but got I4
		//IL_02d4: Expected O, but got I4
		//IL_02dc: Expected O, but got Ref
		//IL_0493: Expected O, but got I4
		//IL_043c: Expected O, but got I4
		//IL_0306: Expected O, but got Ref
		//IL_033a: Expected O, but got I4
		//IL_0342: Expected O, but got Ref
		//IL_03ad: Expected O, but got I4
		//IL_03b5: Expected O, but got Ref
		//IL_036c: Expected O, but got Ref
		if (!(btn != null))
		{
			return;
		}
		bool flag = (object)btn == null;
		UnityEngine.Object obj = null;
		object obj2 = 0;
		UnityEngine.Object obj3 = btn;
		Transform transform;
		float x = default(float);
		if (!flag)
		{
			RectTransform component = btn.GetComponent<RectTransform>();
			OnButtonHover(component);
			ScrollRect componentInParent = btn.GetComponentInParent<ScrollRect>();
			object obj4 = default(object);
			if (!(componentInParent != null))
			{
				obj3 = componentInParent;
				bool flag2 = (object)mask == null;
				obj = null;
				obj2 = 0;
				if (!flag2)
				{
					float num = (float)Vector3.zeroVector;
					mask.localPosition = (Vector3)(&obj4);
					obj3 = defaultParent;
					bool flag3 = (object)defaultParent == null;
					obj = (UnityEngine.Object)(&obj4);
					obj2 = 0;
					if (!flag3)
					{
						bool flag4 = (object)obj3.GetType() != typeof(RectTransform);
						UnityEngine.Object obj5 = null;
						if (!flag4)
						{
							obj5 = defaultParent;
						}
						bool flag5 = (object)obj5 == null;
						obj = (UnityEngine.Object)(object)typeof(RectTransform);
						obj2 = 0;
						if (!flag5)
						{
							bool flag6 = (object)obj3.GetType() != typeof(RectTransform);
							UnityEngine.Object obj6 = null;
							if (!flag6)
							{
								obj6 = obj3;
							}
							transform = (Transform)obj6;
							goto IL_037e;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						goto IL_04b1;
					}
				}
			}
			else
			{
				bool flag7 = (object)componentInParent == null;
				obj = null;
				obj2 = 0;
				obj3 = componentInParent;
				if (!flag7)
				{
					UnityEngine.Object obj7;
					if (componentInParent.m_Viewport != null)
					{
						obj7 = null;
						obj3 = componentInParent.m_Viewport;
						transform = componentInParent.m_Viewport;
					}
					else
					{
						Transform transform2 = componentInParent.transform;
						bool flag8 = (object)transform2 == null;
						obj7 = null;
						obj3 = componentInParent;
						transform = null;
						if (!flag8)
						{
							bool flag9 = (object)transform2.GetType() != typeof(RectTransform);
							transform = null;
							if (!flag9)
							{
								transform = transform2;
							}
							bool flag10 = (object)transform == null;
							obj7 = (UnityEngine.Object)(object)typeof(RectTransform);
							obj3 = componentInParent;
							obj = (UnityEngine.Object)(object)typeof(RectTransform);
							obj2 = 0;
							if (flag10)
							{
								goto IL_04b1;
							}
						}
					}
					bool flag11 = (object)transform == null;
					obj = obj7;
					obj2 = 0;
					if (!flag11)
					{
						Vector3 position = transform.position;
						bool flag12 = (object)mask == null;
						obj = transform;
						obj2 = 0;
						obj3 = (UnityEngine.Object)(&x);
						if (!flag12)
						{
							float num = position.x;
							mask.position = (Vector3)(&obj4);
							Quaternion rotation = transform.rotation;
							bool flag13 = (object)mask == null;
							obj = transform;
							obj2 = 0;
							obj3 = (UnityEngine.Object)(&x);
							if (!flag13)
							{
								num = rotation.x;
								mask.rotation = (Quaternion)(&x);
								x = rotation.x;
								goto IL_037e;
							}
						}
					}
				}
			}
		}
		goto IL_03d7;
		IL_04b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03d7:
		throw new NullReferenceException();
		IL_037e:
		Rect rect = ((RectTransform)transform).rect;
		bool flag14 = (object)mask == null;
		obj = transform;
		obj2 = 0;
		obj3 = (UnityEngine.Object)(&x);
		if (!flag14)
		{
			Vector2 sizeDelta = default(Vector2);
			mask.sizeDelta = sizeDelta;
			return;
		}
		goto IL_03d7;
	}

	private void OnButtonHover(RectTransform button)
	{
		if (button != null)
		{
			selectedRect = button;
			UpdatePosition();
			rectTransform.sizeDelta = newSize;
		}
	}

	private unsafe void UpdatePosition()
	{
		//IL_009f: Expected O, but got F4
		//IL_00c4: Expected O, but got Ref
		//IL_00dc: Expected O, but got Ref
		if (selectedRect != null)
		{
			Vector2 sizeDelta = selectedRect.sizeDelta;
			Vector3 localScale = selectedRect.localScale;
			object obj = default(object);
			float num = localScale.x * (float)obj;
			float num2 = localScale.x * (float)sizeDelta;
			float num3 = num + sizeOffset;
			float num4 = num2 + sizeOffset;
			newSize = (Vector2)num4;
			Rect rect = selectedRect.rect;
			float num5 = default(float);
			Vector3 vector = selectedRect.TransformPoint((Vector3)(&num5));
			rectTransform.position = (Vector3)(&num5);
		}
	}

	private void Update()
	{
		CheckVisibility();
		if (renderer.enabled)
		{
			UpdatePosition();
			float time = Time.time;
			if (!(nextUpdateTime > time))
			{
				float time2 = Time.time;
				float num = 1f / fps;
				float num2 = num + time2;
				nextUpdateTime = num2;
				float time3 = Time.time;
				float num3 = time3 * 6f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
				Vector2 sizeDelta = default(Vector2);
				rectTransform.sizeDelta = sizeDelta;
			}
		}
	}

	private void CheckVisibility()
	{
		if (renderer != null)
		{
			if (selectedRect == null && renderer.enabled)
			{
				renderer.enabled = false;
			}
			else if (selectedRect != null && !renderer.enabled)
			{
				renderer.enabled = true;
			}
		}
	}

	public void Refresh()
	{
		OnButtonHover(selectedRect);
	}

	public void Hide()
	{
		selectedRect = null;
		CheckVisibility();
	}

	private void OnResolutionChanged(int i)
	{
		OnButtonHover(selectedRect);
	}

	private void OnWindowOpened(Window window)
	{
		OnButtonHover(selectedRect);
	}
}
