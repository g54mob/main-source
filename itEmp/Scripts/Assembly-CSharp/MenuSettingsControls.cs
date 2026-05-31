using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingsControls : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimToSubmenu_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuSettingsControls _003C_003E4__this;

		public Button button;

		public bool anim;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAnimToSubmenu_003Ed__22(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Buttons Menu")]
	public MenuSettingsSubMenu[] SubMenuCanvas;

	[Header("Keys")]
	public SettingsBaseButtonsControl[] keyBase;

	public SettingsButtonsControlSet[] keyControls;

	public string nowSetButton;

	[Header("Invert Mouse X")]
	public List<string> InvertMouseX;

	public TMP_Text viewInvertMouseX;

	private int nowindexInvertMouseX;

	private string selectedInvertMouseX;

	[Header("Invert Mouse Y")]
	public List<string> InvertMouseY;

	public TMP_Text viewInvertMouseY;

	private int nowindexInvertMouseY;

	private string selectedInvertMouseY;

	[Header("Mouse Sensitivity")]
	public TMP_Text viewMouseSensitivity;

	public Scrollbar viewScrollbarMouseSensitivity;

	[Header("Mouse Sensitivity")]
	public Image viewImageMouseType;

	public MouseType[] mouseType;

	private int nowindexMouseType;

	private MouseType selectedMouseType;

	public Coroutine AnimSubMenu;

	public void Awake()
	{
	}

	private void Start()
	{
	}

	public void ButtonToSubMenu(Button button)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimToSubmenu_003Ed__22))]
	public IEnumerator AnimToSubmenu(Button button, bool anim)
	{
		return null;
	}

	public void StartSetButton(string name)
	{
	}

	private void Update()
	{
	}

	public SettingsButtonsControlSet FindButton(string name)
	{
		return null;
	}

	public void SetNextInvertMouseXButton(int value)
	{
	}

	private void SetInvertMouseXAction(int value, bool increment = true)
	{
	}

	public void SetNextInvertMouseYButton(int value)
	{
	}

	private void SetInvertMouseYAction(int value, bool increment = true)
	{
	}

	public void SetNextMouseSensitivity(float value)
	{
	}

	public void SetNextMouseSensitivityAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarMouseSensitivity(float value)
	{
	}

	public void SetNextMouseTypeButton(int value)
	{
	}

	private void SetMouseTypeAction(int value, bool increment = true)
	{
	}

	public void SetDeflautOption()
	{
	}

	public void SetDeflautKeys()
	{
	}

	public void SaveButtons()
	{
	}

	public void LoadButtons()
	{
	}

	public void LoadSettings()
	{
	}

	public void UpdateTranslateText()
	{
	}

	public static int AddValue(int now, int value, bool increment)
	{
		return 0;
	}

	public static float AddValue(float now, float value, bool increment)
	{
		return 0f;
	}
}
