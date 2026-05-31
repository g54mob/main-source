using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerPortsInterface : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimEnterInventory_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerPortsInterface _003C_003E4__this;

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
		public _003CAnimEnterInventory_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003CAnimExitInventory_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerPortsInterface _003C_003E4__this;

		public bool stepAwayDevice;

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
		public _003CAnimExitInventory_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003CChangeBlurIntensity_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerPortsInterface _003C_003E4__this;

		public bool stepAwayDevice;

		public float target;

		public float time;

		private float _003CstartValue_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CChangeBlurIntensity_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CChangeCanvasAlpha_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CanvasGroup cg;

		public bool stepAwayDevice;

		public float target;

		public float time;

		private float _003CstartValue_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CChangeCanvasAlpha_003Ed__45(int _003C_003E1__state)
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
	private sealed class _003CFadeAlert_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerPortsInterface _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private Color _003CstartColor_003E5__3;

		private Color _003CendColor_003E5__4;

		private float _003Celapsed_003E5__5;

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
		public _003CFadeAlert_003Ed__34(int _003C_003E1__state)
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
	public InventoryManager inventoryManager;

	[Header("Animation")]
	public CanvasGroup mainCanvasGroup;

	public CanvasGroup infoDeviceCanvasGroup;

	public CanvasGroup portsDeviceCanvasGroup;

	public UIBlur blur;

	public float timeAnimation;

	public bool isInventory;

	public bool isAnimate;

	private Coroutine animationCoroutine;

	private CursorLockMode lastCursorLockMode;

	[Header("Inventory Data")]
	public Transform parentMainSlot;

	public OpenInventory OpenInventorys;

	[Header("UI")]
	public TMP_Text UiItemName;

	public TMP_Text UiItemDes;

	[Header("Open Device")]
	public ComputerFrontPort device;

	public Button[] portsButton;

	public Button ConnectButton;

	public Button DisconnectButton;

	public RectTransform InventorySelector;

	public TMP_Text infoDeviceAlert;

	public TMP_Text alertUI;

	private Coroutine currentCoroutineAlert;

	public InventoryItem ItemInPort;

	public InventoryItem ItemInInventory;

	public int selectPort;

	public int selectIdSlotInventory;

	private DefaultInterfaceSettings lastBlockPlayerData;

	private void Start()
	{
	}

	public void UnselectPortAndSlot()
	{
	}

	public void RenderSlots()
	{
	}

	public void RenderPorts()
	{
	}

	public void SelectItem(InventorySlot slot, InventoryItem item, int idInventoryItem)
	{
	}

	public void SelectPortDevice(int port)
	{
	}

	public void SetAlert(string des)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeAlert_003Ed__34))]
	private IEnumerator FadeAlert()
	{
		return null;
	}

	public void ButtonDisconnectDevice()
	{
	}

	public void ButtonConnectDevice()
	{
	}

	public string GetNextLetter(string current)
	{
		return null;
	}

	public void OpenInventory(List<InventoryItem> mainInventory, ComputerFrontPort computerFrontPort)
	{
	}

	public void CloseInventory()
	{
	}

	public void CloseInventoryByStepAwayDevice()
	{
	}

	public void ToggleInventory(bool stepAwayDevice = false)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimEnterInventory_003Ed__42))]
	public IEnumerator AnimEnterInventory()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimExitInventory_003Ed__43))]
	public IEnumerator AnimExitInventory(bool stepAwayDevice = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CChangeBlurIntensity_003Ed__44))]
	public IEnumerator ChangeBlurIntensity(float target, float time, bool stepAwayDevice = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CChangeCanvasAlpha_003Ed__45))]
	public IEnumerator ChangeCanvasAlpha(CanvasGroup cg, float target, float time, bool stepAwayDevice = false)
	{
		return null;
	}
}
