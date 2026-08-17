using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.UI;

public class BasePopup : MonoBehaviour
{
	protected List<GameObject> _spawned;

	protected string _ID;

	protected GameObject _previouslySelected;

	private bool _refreshLayouts;

	private Action _onClose;

	public virtual void Show()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
	}

	public virtual void Hide()
	{
		//IL_0052: Expected F4, but got I4
		//IL_0075: Expected F4, but got I4
		//IL_00ef: Expected O, but got I
		//IL_018c: Expected I4, but got O
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		Component component = this;
		if (!flag)
		{
			gameObject.SetActive(value: false);
			List<GameObject> spawned = _spawned;
			bool flag2 = _spawned == null;
			component = (Component)(object)gameObject;
			if (!flag2)
			{
				float num = 0f;
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				while (enumerator.MoveNext())
				{
					UnityEngine.Object.Destroy(null, 0f);
					num = 0f;
				}
				component = (Component)(object)_spawned;
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v3 (UnityEngine.Component)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v3 (UnityEngine.Component)+18]");
					int num2 = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v3 (UnityEngine.Component)+18]");
					if ((nint)0 > (nint)0)
					{
						IntPtr cachedPtr = ((UnityEngine.Object)component).m_CachedPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v3 (UnityEngine.Component)+18]");
						Array.Clear((Array)(nint)cachedPtr, 0, 0);
						spawned = null;
					}
					GameObject previouslySelected = _previouslySelected;
					if ((object)_previouslySelected == null || ((UnityEngine.Object)previouslySelected).m_CachedPtr == (IntPtr)0)
					{
						goto IL_026a;
					}
					if ((object)_previouslySelected != null)
					{
						Selectable component2 = _previouslySelected.GetComponent<Selectable>();
						if ((object)component2 != null)
						{
							num2 = (int)component2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v291 @ r8_v6 (System.Int32)+398] (should have been resolved before IL gen)");
							goto IL_026a;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_026a:
		if (_onClose != null)
		{
			Action onClose = _onClose;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v494.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void BaseInit(string id)
	{
		_ID = id;
		EventSystem current = EventSystem.current;
		_previouslySelected = current.m_CurrentSelected;
	}

	public void AddOnCloseCallback(Action cb)
	{
		_onClose = cb;
	}

	protected unsafe void SetNavigationUp(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	protected unsafe void SetNavigationDown(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void SetNavigationLeft(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void SetNavigationRight(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	protected unsafe void SetNavigationMode(Selectable origin, Navigation.Mode mode)
	{
		//IL_000d: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationUp(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationDown(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationLeft(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationRight(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	private void LateUpdate()
	{
		if (_refreshLayouts)
		{
			RectTransform component = GetComponent<RectTransform>();
			Extensions.RefreshLayoutGroupsImmediateAndRecursive(component);
			Canvas.ForceUpdateCanvases();
		}
	}

	protected void RefreshFormatting()
	{
		_refreshLayouts = true;
	}

	public BasePopup()
	{
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
		_ID = "";
	}
}
