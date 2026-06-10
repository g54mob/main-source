using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class BioScreenController : MonoBehaviour
{
	public delegate void InventoryOpenChange();

	[CompilerGenerated]
	private sealed class _003CDisplayNewPerk_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delayTime;

		public SocialControls.SocialCreditBuff newPerk;

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
		public _003CDisplayNewPerk_003Ed__75(int _003C_003E1__state)
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
	public Canvas canvasParent;

	public RectTransform socialCreditDisplayParent;

	public RectTransform levelBarBlipParent;

	public RectTransform socialLevelBarRect;

	public RectTransform barFill;

	public JuiceController barJuice;

	public List<CanvasRenderer> socialCreditRenderers;

	[Space(7f)]
	public RectTransform inventoryParentRect;

	public RectTransform solidBG;

	public ButtonController closeButton;

	public RectTransform equipmentParentRect;

	public RectTransform itemsParentRect;

	public TextMeshProUGUI inventoryTitleText;

	public TextMeshProUGUI cashText;

	public RectTransform summaryTextRect;

	public TextMeshProUGUI summaryText;

	public RectTransform buttonAreaParent;

	public ButtonController dropButton;

	public ButtonController inspectButton;

	public ButtonController scanButton;

	public ButtonController moreOptionsButton;

	public ButtonController editDecorButton;

	public RectTransform scanProgressBar;

	public ButtonController selectNothingButton;

	public InventorySquareController nothingSquare;

	public List<CanvasRenderer> inventoryRenderers;

	[Header("Settings")]
	public GameObject levelBlipPrefab;

	public Color clearedLevel;

	public Color futureLevel;

	[Space(7f)]
	public GameObject inventorySquarePrefab;

	public Sprite equipmentBGIcon;

	public Sprite itemBGIcon;

	[Header("State")]
	public int maxLevels;

	public int maxPoints;

	public float desiredBarFillLevel;

	public float barHeight;

	public int currentLevel;

	private List<ButtonController> levelBlips;

	public float socialCreditBarDisplayTimer;

	public float socialCreditDisplayProgress;

	private ButtonController currentLevelBlip;

	public bool openedFromPause;

	[Space(7f)]
	public bool isOpen;

	public float inventoryDisplayProgress;

	[NonSerialized]
	public FirstPersonItemController.InventorySlot hoveredSlot;

	[NonSerialized]
	public FirstPersonItemController.InventorySlot selectedSlot;

	public int hoverIndex;

	private string summaryTextToDisplay;

	private float summaryTextProgress;

	[NonSerialized]
	public Interactable scanningItem;

	public float scanProgress;

	private AudioController.LoopingSoundInfo scannerLoop;

	public Dictionary<Interactable, List<Interactable>> scannedObjectsPrintsCache;

	private static BioScreenController _instance;

	public static BioScreenController Instance => null;

	public event InventoryOpenChange OnInventoryOpenChange
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void SetMaxSocialCreditLevels(int newMax)
	{
	}

	public void SetInventoryOpen(bool val, bool forceUpdate, bool resumeGame = true)
	{
	}

	public void HoverSlot(FirstPersonItemController.InventorySlot newSlot)
	{
	}

	public void SelectSlot(FirstPersonItemController.InventorySlot newSlot, bool closeInventory = false, bool forceUpdate = false, bool cancelAutoUmbrella = true)
	{
	}

	public void UpdateButtons()
	{
	}

	public void UpdateDecorEditButton()
	{
	}

	public void UpdateSummary()
	{
	}

	public InventorySquareController SpawnSlotObject(FirstPersonItemController.InventorySlot slot)
	{
		return null;
	}

	public void OnChangePoints(bool allowLevelChangeDisplay)
	{
	}

	public void UpdateSocialCreditPerks()
	{
	}

	public void NewSocialCreditPerk(SocialControls.SocialCreditBuff newPerk, bool allowDisplay = true)
	{
	}

	public void UpdateLevelBlipsWithPerkTooltips()
	{
	}

	[IteratorStateMachine(typeof(_003CDisplayNewPerk_003Ed__75))]
	private IEnumerator DisplayNewPerk(SocialControls.SocialCreditBuff newPerk, float delayTime)
	{
		return null;
	}

	private void Update()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AddSocialCredit()
	{
	}

	public void DecorEditButton()
	{
	}

	public void DropButton()
	{
	}

	public void InspectButton()
	{
	}

	public void ScanButton()
	{
	}

	public void OnScanComplete(Interactable scanCompleteOn)
	{
	}

	public void EquipButton()
	{
	}

	public void MoreOptionsButton()
	{
	}

	public void CloseButton()
	{
	}
}
