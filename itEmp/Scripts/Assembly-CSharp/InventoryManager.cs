using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimEnterInventory_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InventoryManager _003C_003E4__this;

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

		public InventoryManager _003C_003E4__this;

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

		public InventoryManager _003C_003E4__this;

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

	public static InventoryManager instance;

	[Header("Item Base")]
	public List<InventoryItem> ItemsBase;

	[Header("Components")]
	public PlayerInventory playerInventory;

	[Header("Animation")]
	public CanvasGroup mainCanvasGroup;

	public CanvasGroup additionalCanvasGroup;

	public UIBlur blur;

	public float timeAnimation;

	public bool isInventory;

	public bool isAnimate;

	private Coroutine animationCoroutine;

	[Header("Inventory Data")]
	public Transform parentMainSlot;

	public Transform parentAdditionalSlot;

	private OpenInventory OpenInventorys;

	[Header("Selector")]
	public float moveSpeed;

	public InventorySlot selectSlot;

	public RectTransform SelectItemView;

	public Vector3 selectItemPosition;

	public Vector3 selectTargetPosition;

	[Header("UI")]
	public TMP_Text NameAdditionalInventory;

	[Header("Steam")]
	public List<string> SteamPatchcordCounter;

	private DefaultInterfaceSettings lastBlockPlayerData;

	public OpenInventory GetOpenInventorys()
	{
		return null;
	}

	private void Awake()
	{
	}

	public void SteamPatchcordCounterAdd(string uniqueItemID)
	{
	}

	public static void LoadItemCollector()
	{
	}

	public static void SaveItemCollector()
	{
	}

	public bool IsOpen()
	{
		return false;
	}

	private void Start()
	{
	}

	public void Update()
	{
	}

	private void MovingItem()
	{
	}

	public void RenderSlots()
	{
	}

	public void SelectSlot(InventorySlot slot)
	{
	}

	private void SetPosition(RectTransform targetRectTransform, RectTransform referenceRectTransform)
	{
	}

	public void DropSlot(InventorySlot slot)
	{
	}

	private InventorySlot GetSlotByMousePosition(InventorySlot slot)
	{
		return null;
	}

	public InventoryItem FindEmptySlotInMainInventory()
	{
		return null;
	}

	public InventoryItem FindItemInMainInventory(string name)
	{
		return null;
	}

	public InventoryItem FindItemByName(string name)
	{
		return null;
	}

	public void OpenInventory(List<InventoryItem> mainInventory, List<InventoryItem> additionalInventory, string nameAdditionalInventory)
	{
	}

	public void CloseInventory()
	{
	}

	public void StepAwayDevice()
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

	public static void SetItemToEmptySlot(InventoryItem emptySlot, InventoryItem item)
	{
	}

	public static void AddNewItemTemplateToEmptySlot(InventoryItem emptySlot, InventoryItem itemTemplate)
	{
	}
}
