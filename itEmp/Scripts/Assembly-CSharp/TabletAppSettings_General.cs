using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppSettings_General : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAutomaticUpdatesCoroutine_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public TabletAppSettings_General _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003CAutomaticUpdatesCoroutine_003Ed__30(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CBetaUpdatesCoroutine_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public TabletAppSettings_General _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003CBetaUpdatesCoroutine_003Ed__31(int _003C_003E1__state)
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

	[Header("Components")]
	public TabletAppSettings settings;

	public RectTransform This_Settings;

	public GameObject This_Settings_View;

	[Header("About this device")]
	public RectTransform About_this_device;

	public GameObject About_this_device_View;

	[Header("Updates")]
	public RectTransform Updates;

	public GameObject Updates_View;

	public RectTransform dotAutomaticUpdates;

	public RectTransform dotBetaUpdates;

	public Image bgDotAutomaticUpdates;

	public Image bgdotBetaUpdates;

	public bool AutomaticUpdates;

	public bool BetaUpdates;

	[Header("Storage")]
	public RectTransform Storage;

	public GameObject Storage_View;

	[Header("Warranty")]
	public RectTransform Warranty;

	public GameObject Warranty_View;

	[Header("Language")]
	public RectTransform Language;

	public GameObject Language_View;

	public bool isCoroutineEnded;

	[HideInInspector]
	public Coroutine turnonofAutomaticUpdatesCoroutine;

	[HideInInspector]
	public Coroutine turnonofBetaUpdatesCoroutine;

	public void OpenThisView()
	{
	}

	public void CloseThisView()
	{
	}

	public void OpenAbout_this_device_View()
	{
	}

	public void CloseAbout_this_device_View()
	{
	}

	public void Open_Updates_View()
	{
	}

	public void Close_Updates_View()
	{
	}

	public void TurnOnOrOffAutomaticUpdates()
	{
	}

	public void TurnOnOrOffBetaUpdates()
	{
	}

	[IteratorStateMachine(typeof(_003CAutomaticUpdatesCoroutine_003Ed__30))]
	public IEnumerator AutomaticUpdatesCoroutine(RectTransform obj, float fromX, float toX, float time, bool closedNow = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CBetaUpdatesCoroutine_003Ed__31))]
	public IEnumerator BetaUpdatesCoroutine(RectTransform obj, float fromX, float toX, float time, bool closedNow = false)
	{
		return null;
	}

	public void Open_Storage_View()
	{
	}

	public void Close_Storage_View()
	{
	}

	public void Open_Warranty_View()
	{
	}

	public void Close_Warranty_View()
	{
	}

	public void Open_Language_View()
	{
	}

	public void Close_Language_View()
	{
	}
}
