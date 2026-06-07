using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class QuickInventoryTabBase : MonoBehaviour, IRecyclableObject
{
	[SerializeField]
	private GameObject objectWhenOn;

	[SerializeField]
	private GameObject objectWhenOff;

	[SerializeField]
	private Color hotkeyNumberIsOnColor;

	[SerializeField]
	private Color hotkeyNumberIsOffColor;

	private Toggle tabToggle;

	private TextMeshProUGUI hotkeyNumber;

	private Button deleteButton;

	private QIElementDragHandlerBase tabDragHandler;

	private TextMeshProUGUI dragDropIcon;

	public string ObjectTypeId { get; set; }

	public event Action<bool> OnTabSelectedEvent;

	public event Action OnDeleteButtonEvent;

	public event Action OnBeginDragEvent;

	public event Action OnEndDragEvent;

	protected void Awake()
	{
		tabToggle = GetComponent<Toggle>();
		hotkeyNumber = base.transform.FindComponent<TextMeshProUGUI>("Text", isRecursively: true);
		deleteButton = base.transform.FindComponent<Button>("DeleteButton", isRecursively: true);
		tabDragHandler = GetComponent<QIElementDragHandlerBase>();
		dragDropIcon = base.transform.FindComponent<TextMeshProUGUI>("DragDropIcon", isRecursively: true);
		tabToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetToggleStyles(isOn);
			this.OnTabSelectedEvent?.Invoke(isOn);
		});
		deleteButton.onClick.AddListener(delegate
		{
			this.OnDeleteButtonEvent?.Invoke();
		});
		tabDragHandler.OnBeginDragEvent += delegate
		{
			this.OnBeginDragEvent?.Invoke();
		};
		tabDragHandler.OnEndDragEvent += delegate
		{
			this.OnEndDragEvent?.Invoke();
		};
	}

	public virtual void SetEditable(bool isEditable)
	{
		if (isEditable)
		{
			deleteButton.gameObject.SetActive(value: true);
			tabDragHandler.enabled = true;
			dragDropIcon.gameObject.SetActive(value: true);
		}
		else
		{
			deleteButton.gameObject.SetActive(value: false);
			tabDragHandler.enabled = false;
			dragDropIcon.gameObject.SetActive(value: false);
		}
	}

	public void SetHotkeyNumber(string number)
	{
		hotkeyNumber.SetText(number);
	}

	public void SetToggleGroup(ToggleGroup toggleGroup)
	{
		tabToggle.group = toggleGroup;
	}

	public void SetToggleValue(bool isSelected)
	{
		if (tabToggle.isOn != isSelected)
		{
			tabToggle.SetValue(isSelected);
			SetToggleStyles(isSelected);
		}
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

	public void OnInstantiation()
	{
	}

	public void OnUnistantiation()
	{
		this.OnTabSelectedEvent = null;
		this.OnDeleteButtonEvent = null;
		this.OnBeginDragEvent = null;
		this.OnEndDragEvent = null;
	}
}
