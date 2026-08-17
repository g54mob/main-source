using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class TickBoxUI : MonoBehaviour, ISelectableUI, IUIObject
{
	private GameObject _On;

	private GameObject _Off;

	private UnityEvent<bool> OnToggle;

	private bool isOn;

	public bool IsOn => isOn;

	private void Start()
	{
		//IL_0030: Expected I4, but got O
		InitialSet(isOn);
		UnityAction<bool> unityAction = null;
		((TickBoxUI)(object)unityAction).PlaySound((byte)(int)this != 0);
		OnToggle.AddListener(unityAction);
	}

	public void Toggle()
	{
		bool flag = !isOn;
		isOn = flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = "False";
		if (!isOn)
		{
			text = "True";
		}
		string message = "Is On : " + text;
		Debug.Log(message);
		if (!isOn)
		{
			SetOff();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 130 Invalid \"Jump target not found in method: 0x186DDE8D0\"");
		}
	}

	public void SetOn()
	{
		Debug.Log("Setting on");
		_On.SetActive(value: true);
		GameObject off = _Off;
		if ((object)_Off != null && ((UnityEngine.Object)off).m_CachedPtr != (IntPtr)0)
		{
			_Off.SetActive(value: false);
		}
		isOn = true;
		OnToggle.Invoke(arg0: true);
	}

	public void SetOff()
	{
		Debug.Log("Setting off");
		_On.SetActive(value: false);
		GameObject off = _Off;
		if ((object)_Off != null && ((UnityEngine.Object)off).m_CachedPtr != (IntPtr)0)
		{
			_Off.SetActive(value: true);
		}
		isOn = false;
		OnToggle.Invoke(arg0: false);
	}

	public void PlaySound(bool b)
	{
		SfxType sfxType = (b ? SfxType.ClickIn : SfxType.ClickOut);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, null, 0f, 10, time);
	}

	public void InitialSet(bool b)
	{
		if (!b)
		{
			_On.SetActive(value: false);
			GameObject off = _Off;
			if ((object)_Off != null && ((UnityEngine.Object)off).m_CachedPtr != (IntPtr)0)
			{
				_Off.SetActive(value: true);
			}
			isOn = false;
		}
		else
		{
			_On.SetActive(value: true);
			GameObject off2 = _Off;
			if ((object)_Off != null && ((UnityEngine.Object)off2).m_CachedPtr != (IntPtr)0)
			{
				_Off.SetActive(value: false);
			}
			isOn = true;
		}
	}

	public void Initialize(bool _isOn)
	{
		GameObject off2;
		bool active;
		if (!_isOn)
		{
			_On.SetActive(value: false);
			GameObject off = _Off;
			if ((object)_Off == null || ((UnityEngine.Object)off).m_CachedPtr == (IntPtr)0)
			{
				goto IL_00df;
			}
			off2 = _Off;
			active = true;
		}
		else
		{
			_On.SetActive(value: true);
			GameObject off3 = _Off;
			if ((object)_Off == null || ((UnityEngine.Object)off3).m_CachedPtr == (IntPtr)0)
			{
				goto IL_00df;
			}
			off2 = _Off;
			active = false;
		}
		off2.SetActive(active);
		goto IL_00df;
		IL_00df:
		isOn = _isOn;
	}

	public void AddOnToggle(Action<bool> cb)
	{
		//IL_0027: Expected I4, but got O
		UnityAction<bool> unityAction = null;
		unityAction((byte)(int)cb != 0);
		OnToggle.AddListener(unityAction);
	}

	public void SetInteractive(bool isInteractive)
	{
		Button component = GetComponent<Button>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			component.interactable = isInteractive;
		}
	}

	public Selectable GetSelectable()
	{
		return GetComponentInChildren<Button>();
	}

	public GameObject GetGameObject()
	{
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Transform parent = transform.parent;
			if ((object)parent != null)
			{
				return parent.gameObject;
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
	}

	public unsafe void MakeVisuallyDisabled()
	{
		//IL_0027: Expected O, but got Ref
		//IL_0072: Expected O, but got Ref
		//IL_008e: Expected O, but got Ref
		Image component = _On.GetComponent<Image>();
		object obj = default(object);
		component.color = (Color)(&obj);
		Transform transform = _On.transform;
		Transform parent = transform.parent;
		Image component2 = parent.GetComponent<Image>();
		component2.color = (Color)(&obj);
		TextMeshProUGUI componentInChildren = GetComponentInChildren<TextMeshProUGUI>();
		componentInChildren.color = (Color)(&obj);
	}

	public unsafe void MakeVisuallyEnabled()
	{
		//IL_0027: Expected O, but got Ref
		//IL_0072: Expected O, but got Ref
		//IL_008e: Expected O, but got Ref
		Image component = _On.GetComponent<Image>();
		object obj = default(object);
		component.color = (Color)(&obj);
		Transform transform = _On.transform;
		Transform parent = transform.parent;
		Image component2 = parent.GetComponent<Image>();
		component2.color = (Color)(&obj);
		TextMeshProUGUI componentInChildren = GetComponentInChildren<TextMeshProUGUI>();
		componentInChildren.color = (Color)(&obj);
	}

	public TickBoxUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
