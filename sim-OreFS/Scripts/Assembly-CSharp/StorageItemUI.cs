using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class StorageItemUI : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	[Header("References")]
	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private TextMeshProUGUI descriptionText;

	[SerializeField]
	private TextMeshProUGUI countText;

	[SerializeField]
	private TextMeshProUGUI weightText;

	[SerializeField]
	private Image iconImage;

	[Header("Selectable")]
	[SerializeField]
	private Selectable selectable;

	[Header("Input Actions")]
	[Tooltip("Left action - Banta gönder (A / Enter / sol tık vb.)")]
	[SerializeField]
	private InputActionReference leftAction;

	[Tooltip("Right action - Sack olarak al (B / Escape / sağ tık vb.)")]
	[SerializeField]
	private InputActionReference rightAction;

	[Header("State")]
	[SerializeField]
	private T_ItemSO itemSO;

	[SerializeField]
	private int availableCount;

	private bool isSubscribed;

	public Action<T_ItemSO> OnSendToBeltRequested;

	public Action<T_ItemSO> OnTakeAsSackRequested;

	public T_ItemSO GetItemSO()
	{
		return itemSO;
	}

	public void Initialize(T_ItemSO item, int initialCount)
	{
		itemSO = item;
		availableCount = Mathf.Max(0, initialCount);
		Refresh();
	}

	public void SetCount(int newCount)
	{
		availableCount = Mathf.Max(0, newCount);
		UpdateCountText();
		UpdateWeightText();
	}

	public void SetItem(T_ItemSO item)
	{
		itemSO = item;
		UpdateTextsAndIcon();
		UpdateWeightText();
	}

	private void Refresh()
	{
		UpdateTextsAndIcon();
		UpdateCountText();
		UpdateWeightText();
	}

	private void UpdateTextsAndIcon()
	{
		if (itemSO != null)
		{
			if (nameText != null)
			{
				string translation = LocalizationManager.GetTranslation(itemSO.Name);
				nameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : itemSO.Name);
			}
			if (descriptionText != null)
			{
				string translation2 = LocalizationManager.GetTranslation(itemSO.Description);
				descriptionText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : itemSO.Description);
			}
		}
		if (iconImage != null)
		{
			Sprite sprite = ((itemSO != null) ? itemSO.Icon : null);
			iconImage.sprite = sprite;
			iconImage.enabled = sprite != null;
		}
	}

	private void UpdateCountText()
	{
		if (countText != null)
		{
			countText.text = $"x{availableCount}";
		}
	}

	private void UpdateWeightText()
	{
		if (!(weightText == null))
		{
			if (itemSO != null && availableCount > 0)
			{
				weightText.text = $"{availableCount}";
			}
			else
			{
				weightText.text = "0";
			}
		}
	}

	private void OnEnable()
	{
		ResolveInputActionReferences();
	}

	private void OnDisable()
	{
		UnsubscribeInputActions();
	}

	public void OnSelect(BaseEventData eventData)
	{
		SubscribeInputActions();
	}

	public void OnDeselect(BaseEventData eventData)
	{
		UnsubscribeInputActions();
	}

	private void ResolveInputActionReferences()
	{
		InputSystemUIInputModule inputSystemUIInputModule = EventSystem.current?.currentInputModule as InputSystemUIInputModule;
		if ((leftAction == null || leftAction.action == null) && inputSystemUIInputModule != null)
		{
			if (inputSystemUIInputModule.submit != null)
			{
				leftAction = inputSystemUIInputModule.submit;
			}
			else if (inputSystemUIInputModule.leftClick != null)
			{
				leftAction = inputSystemUIInputModule.leftClick;
			}
		}
		if ((rightAction == null || rightAction.action == null) && inputSystemUIInputModule != null)
		{
			if (inputSystemUIInputModule.cancel != null)
			{
				rightAction = inputSystemUIInputModule.cancel;
			}
			else if (inputSystemUIInputModule.rightClick != null)
			{
				rightAction = inputSystemUIInputModule.rightClick;
			}
		}
	}

	private void SubscribeInputActions()
	{
		if (!isSubscribed)
		{
			isSubscribed = true;
			if (leftAction != null && leftAction.action != null)
			{
				leftAction.action.performed += OnLeftActionPerformed;
			}
			if (rightAction != null && rightAction.action != null)
			{
				rightAction.action.performed += OnRightActionPerformed;
			}
		}
	}

	private void UnsubscribeInputActions()
	{
		if (isSubscribed)
		{
			isSubscribed = false;
			if (leftAction != null && leftAction.action != null)
			{
				leftAction.action.performed -= OnLeftActionPerformed;
			}
			if (rightAction != null && rightAction.action != null)
			{
				rightAction.action.performed -= OnRightActionPerformed;
			}
		}
	}

	private void OnLeftActionPerformed(InputAction.CallbackContext ctx)
	{
		if (!(itemSO == null) && availableCount > 0)
		{
			OnTakeAsSackRequested?.Invoke(itemSO);
		}
	}

	private void OnRightActionPerformed(InputAction.CallbackContext ctx)
	{
		if (!(itemSO == null) && availableCount > 0)
		{
			OnSendToBeltRequested?.Invoke(itemSO);
		}
	}
}
