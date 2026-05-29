using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletDevice : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCloseTablet_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletDevice _003C_003E4__this;

		public bool stepAwayDevice;

		private Quaternion _003CstartRotationCamera_003E5__2;

		private Quaternion _003CtargetRotationCamera_003E5__3;

		private Quaternion _003CstartRotationParent_003E5__4;

		private Quaternion _003CtargetRotationParent_003E5__5;

		private Quaternion _003CstartRotationPlayerCamera_003E5__6;

		private Quaternion _003CtargetRotationPlayerCamera_003E5__7;

		private float _003Cduration_003E5__8;

		private float _003CelapsedTime_003E5__9;

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
		public _003CCloseTablet_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003COpenTablet_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletDevice _003C_003E4__this;

		private Quaternion _003CstartRotationCamera_003E5__2;

		private Quaternion _003CtargetRotationCamera_003E5__3;

		private Quaternion _003CstartRotationParent_003E5__4;

		private Quaternion _003CtargetRotationParent_003E5__5;

		private Quaternion _003CstartRotationPlayerCamera_003E5__6;

		private Quaternion _003CtargetRotationPlayerCamera_003E5__7;

		private float _003Cduration_003E5__8;

		private float _003CelapsedTime_003E5__9;

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
		public _003COpenTablet_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CUpdateTime_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletDevice _003C_003E4__this;

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
		public _003CUpdateTime_003Ed__26(int _003C_003E1__state)
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

	[Header("Unique Device ID")]
	public string deviceID;

	public string deviceName;

	[Header("Components")]
	public PlayerManager playerManager;

	public NetworkManager networkManager;

	public ButtonInformationByDevice buttonInformationByDevice;

	public TabletDetectionInputField tabletDetectionInputField;

	[Header("Next Tablet Script")]
	public TabletAppSettings settings;

	[Header("GameObjects")]
	public Transform CameraObject;

	public Transform ParentTabletObject;

	public Transform TabletObject;

	[Header("Wallapaper")]
	public Image wallpaper;

	public Transform[] viewerObject;

	public Canvas[] viewerCanvas;

	public MeshRenderer[] viewerMeshRenderer;

	[Header("Device Settings")]
	public DeviceDataTime deviceDataTime;

	[Header("UI")]
	public TMP_Text UI_Time;

	[Header("Animation")]
	public bool isTabletOpen;

	public bool isAnimate;

	private DefaultInterfaceSettings lastBlockPlayerData;

	private void OnValidate()
	{
	}

	private void Start()
	{
	}

	public bool IsOpen()
	{
		return false;
	}

	public void OpenClose()
	{
	}

	[IteratorStateMachine(typeof(_003COpenTablet_003Ed__23))]
	private IEnumerator OpenTablet()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseTablet_003Ed__24))]
	private IEnumerator CloseTablet(bool stepAwayDevice = false)
	{
		return null;
	}

	public void StepAwayDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateTime_003Ed__26))]
	private IEnumerator UpdateTime()
	{
		return null;
	}
}
