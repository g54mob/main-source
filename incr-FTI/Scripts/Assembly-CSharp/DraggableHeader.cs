using System;
using System.Diagnostics;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableHeader : MenuElement, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	private RectTransform headerTransform;

	private RectTransform targetPanel;

	[NonSerialized]
	public MenuPanel parentPanel;

	private Vector3 dragStart;

	private Vector3 initialWorldPosition;

	private Vector3 initialScreenPosition;

	public TextMeshProUGUI headerText;

	public MenuElement pinButton;

	public MenuButton closeButton;

	private bool isMinimized;

	public GridLayoutGroup buttonGrid;

	public Image headerIcon;

	public bool isFixed;

	private bool isInitialized;

	public EntityId displayedEntity;

	public void Initialize(MenuPanel p)
	{
		headerTransform = GetComponent<RectTransform>();
		if (null == headerTransform)
		{
			UnityEngine.Debug.LogError("Missing header transform", this);
		}
		else
		{
			if (null == headerTransform.parent)
			{
				return;
			}
			parentPanel = p;
			if (null == parentPanel)
			{
				UnityEngine.Debug.LogError("Missing parent panel", this);
				return;
			}
			parentPanel.header = this;
			targetPanel = parentPanel.GetComponent<RectTransform>();
			isInitialized = true;
			closeButton.gameObject.SetActive(!isFixed);
			if (null != headerIcon && null != parentPanel.headerSprite)
			{
				headerIcon.sprite = parentPanel.headerSprite;
			}
		}
	}

	public void SetFixed(bool nextState)
	{
		isFixed = nextState;
		closeButton.gameObject.SetActive(!isFixed);
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		UpdateDisplay();
	}

	public void ReloadLabels()
	{
		if (!(null != parentPanel))
		{
			return;
		}
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		if (!string.IsNullOrEmpty(parentPanel.headerLocalizationKey))
		{
			if (displayedEntity.type != EntityType.None)
			{
				pooledStringBuilder.Append(TextDisplay.FormattedKeyValue(parentPanel.headerLocalizationKey, TextDisplay.LabelForEntity(displayedEntity)));
			}
			else
			{
				pooledStringBuilder.Append(parentPanel.headerLocalizationKey.Localized());
			}
		}
		else if (displayedEntity.type != EntityType.None)
		{
			pooledStringBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForMenuPanel(parentPanel.panelType), TextDisplay.LabelForEntity(displayedEntity));
		}
		else
		{
			pooledStringBuilder.Append(TextDisplay.LabelForMenuPanel(parentPanel.panelType));
		}
		if (parentPanel.panelType != MenuPanelType.Inventory && parentPanel.panelType != MenuPanelType.Quests && parentPanel.displayedTown != null)
		{
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.Append('[');
			pooledStringBuilder.Append(parentPanel.displayedTown.townName);
			pooledStringBuilder.Append(']');
		}
		headerText.SetText(pooledStringBuilder);
		GameUtility.ReturnToPool(pooledStringBuilder);
	}

	public void UpdateDisplay()
	{
		ReloadLabels();
	}

	public void OnClosePressed()
	{
		if (null != parentPanel)
		{
			parentPanel.ManuallyClose();
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!isFixed)
		{
			parentPanel.TrySendToFront();
			dragStart = UserInput.ScreenMousePos();
			initialWorldPosition = targetPanel.position;
			initialScreenPosition = StartupManager.Instance.mainCamera.WorldToScreenPoint(initialWorldPosition);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!isFixed)
		{
			_ = targetPanel.sizeDelta;
			_ = Screen.width;
			Vector3 vector = UserInput.ScreenMousePos();
			float x = Mathf.Clamp(vector.x, 10f, (float)Screen.width - 10f);
			float y = Mathf.Clamp(vector.y, 10f, (float)Screen.height - 10f);
			Vector3 vector2 = new Vector3(x, y, 0f) - dragStart;
			float x2 = initialScreenPosition.x + vector2.x;
			float y2 = initialScreenPosition.y + vector2.y;
			Vector3 position = new Vector3(x2, y2, 0f);
			Vector3 vector3 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position);
			targetPanel.position = new Vector3(vector3.x, vector3.y, initialWorldPosition.z);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!isFixed)
		{
			Vector3 position = targetPanel.position;
			Vector3 position2 = targetPanel.position;
			Vector2 sizeDelta = targetPanel.sizeDelta;
			float x = (float)Mathf.RoundToInt(position2.x / (float)Screen.width * 4f) / 4f;
			float y = (float)Mathf.RoundToInt(position2.y / (float)Screen.height * 4f) / 4f;
			float num = 100f;
			if (position2.x - sizeDelta.x * 0.5f < num)
			{
				x = 0f;
			}
			else if (position2.x + sizeDelta.x * 0.5f > (float)Screen.width - num)
			{
				x = 1f;
			}
			if (position2.y - sizeDelta.y * 0.5f < num)
			{
				y = 0f;
			}
			else if (position2.y + sizeDelta.y * 0.5f > (float)Screen.height - 100f)
			{
				y = 1f;
			}
			targetPanel.anchorMin = new Vector2(x, y);
			targetPanel.anchorMax = new Vector2(x, y);
			targetPanel.position = position;
			parentPanel.SaveLayout();
		}
	}

	public void SetMinimized(bool nextState)
	{
		isMinimized = nextState;
		UpdateDisplay();
	}

	[Conditional("UNITY_EDITORx")]
	private void LogEditor(string s)
	{
	}
}
