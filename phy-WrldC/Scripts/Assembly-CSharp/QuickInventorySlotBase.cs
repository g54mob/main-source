using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class QuickInventorySlotBase<TItemView, TItemModel> : MonoBehaviour, IRecyclableObject where TItemView : Component where TItemModel : class
{
	[SerializeField]
	private GameObject objectWhenOn;

	[SerializeField]
	private GameObject objectWhenOff;

	[SerializeField]
	private Color hotkeyNumberIsOnColor;

	[SerializeField]
	private Color hotkeyNumberIsOffColor;

	private Toggle slotToggle;

	private GameObject hotkeyPanel;

	private TextMeshProUGUI hotkeyNumber;

	private Button deleteButton;

	private QIElementDragHandlerBase slotDragHandler;

	private TextMeshProUGUI dragDropIcon;

	protected TextMeshProUGUI userIcon;

	protected GameObject referenceBlockObject;

	private TooltipTriggerBase tooltipTrigger;

	protected Transform itemScalableTransform;

	protected Vector3 itemOriginalScale;

	public TItemView ItemView { get; private set; }

	public GameObject ItemFolder { get; private set; }

	public string ObjectTypeId { get; set; }

	public event Action<bool> OnSlotSelectedEvent;

	public event Action OnDeleteButtonEvent;

	public event Action OnBeginDragEvent;

	public event Action OnEndDragEvent;

	protected virtual void Awake()
	{
		slotToggle = GetComponent<Toggle>();
		hotkeyPanel = base.transform.FindChildRecursively("HotkeyPanel").gameObject;
		hotkeyNumber = hotkeyPanel.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
		deleteButton = base.transform.FindComponent<Button>("DeleteButton", isRecursively: true);
		slotDragHandler = GetComponent<QIElementDragHandlerBase>();
		dragDropIcon = base.transform.FindComponent<TextMeshProUGUI>("DragDropIcon", isRecursively: true);
		userIcon = base.transform.FindComponent<TextMeshProUGUI>("UserIcon", isRecursively: true);
		ItemFolder = base.transform.FindChildRecursively("ItemFolder").gameObject;
		referenceBlockObject = base.transform.FindChildRecursively("ReferenceBlockObject").gameObject;
		tooltipTrigger = GetComponent<TooltipTriggerBase>();
		slotToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetToggleStyles(isOn);
			this.OnSlotSelectedEvent?.Invoke(isOn);
		});
		deleteButton.onClick.AddListener(delegate
		{
			this.OnDeleteButtonEvent?.Invoke();
		});
		slotDragHandler.OnBeginDragEvent += delegate
		{
			this.OnBeginDragEvent?.Invoke();
		};
		slotDragHandler.OnEndDragEvent += delegate
		{
			this.OnEndDragEvent?.Invoke();
		};
		Util.AddMouseOverUIEvents(base.gameObject, MouseOverHandler);
		itemOriginalScale = Vector3.one;
	}

	public void SetConfiguration(TItemModel itemModel, int tabIndex, int slotIndex, ToggleGroup toggleGroup)
	{
		if (ItemView != null)
		{
			ActionBeforeRemoveOldItemView();
			ItemFolder.transform.RemoveAllChildren();
			this.OnSlotSelectedEvent = null;
			this.OnDeleteButtonEvent = null;
			this.OnBeginDragEvent = null;
			this.OnEndDragEvent = null;
		}
		slotToggle.group = toggleGroup;
		if (slotIndex < 10)
		{
			hotkeyNumber.text = ((slotIndex == 9) ? "0" : (slotIndex + 1).ToString());
			hotkeyPanel.SetActive(value: true);
		}
		else
		{
			hotkeyPanel.SetActive(value: false);
		}
		ItemView = SetConfigurationHandler(itemModel);
		if (ItemView.transform.parent != ItemFolder.transform)
		{
			ItemView.transform.SetParent(ItemFolder.transform, worldPositionStays: true);
		}
	}

	protected abstract void ActionBeforeRemoveOldItemView();

	protected abstract TItemView SetConfigurationHandler(TItemModel itemModel);

	public void SetEditable(bool isEditable)
	{
		if (isEditable)
		{
			deleteButton.gameObject.SetActive(value: true);
			slotToggle.interactable = false;
			slotDragHandler.enabled = true;
			dragDropIcon.gameObject.SetActive(value: true);
			tooltipTrigger.enabled = false;
		}
		else
		{
			deleteButton.gameObject.SetActive(value: false);
			slotToggle.interactable = true;
			slotDragHandler.enabled = false;
			dragDropIcon.gameObject.SetActive(value: false);
			tooltipTrigger.enabled = true;
		}
	}

	public void SetToggleValue(bool isSelected)
	{
		if (slotToggle.isOn != isSelected)
		{
			slotToggle.SetValue(isSelected);
			SetToggleStyles(isSelected);
		}
	}

	public void SetHotkeyNumber(string number, bool isVisible = true)
	{
		hotkeyNumber.text = number;
		hotkeyPanel.SetActive(isVisible);
	}

	private void SetToggleStyles(bool isOn)
	{
		if (objectWhenOn != null)
		{
			objectWhenOn.SetActive(isOn);
		}
		if (objectWhenOff != null)
		{
			objectWhenOff.SetActive(!isOn);
		}
		hotkeyNumber.color = (isOn ? hotkeyNumberIsOnColor : hotkeyNumberIsOffColor);
	}

	private void MouseOverHandler(bool isMouseOver)
	{
		if (!(itemScalableTransform == null))
		{
			if (isMouseOver)
			{
				itemScalableTransform.DOScale(itemOriginalScale.x * 1.15f, 0.25f);
			}
			else
			{
				itemScalableTransform.transform.DOScale(itemOriginalScale.x, 0.25f);
			}
		}
	}

	private void OnDisable()
	{
		if (!(itemScalableTransform == null))
		{
			itemScalableTransform.localScale = itemOriginalScale;
		}
	}

	public void OnInstantiation()
	{
	}

	public void OnUnistantiation()
	{
		this.OnSlotSelectedEvent = null;
		this.OnDeleteButtonEvent = null;
		this.OnBeginDragEvent = null;
		this.OnEndDragEvent = null;
	}
}
