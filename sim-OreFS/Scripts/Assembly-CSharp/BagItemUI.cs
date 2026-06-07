using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class BagItemUI : MonoBehaviour
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
	[Tooltip("Left action - Sack'e koyma (A / Enter / sol tık vb.)")]
	[SerializeField]
	private InputActionReference leftAction;

	[Tooltip("Right action - Alternatif işlem (B / Escape / sağ tık vb.)")]
	[SerializeField]
	private InputActionReference rightAction;

	[Header("State")]
	[SerializeField]
	private T_ItemSO itemSO;

	[SerializeField]
	private int count;

	[Header("References")]
	private T_Bag localBag;

	public T_ItemSO GetItemSO()
	{
		return itemSO;
	}

	public void Initialize(T_ItemSO item, int initialCount)
	{
		itemSO = item;
		count = Mathf.Max(0, initialCount);
		Refresh();
	}

	public void SetCount(int newCount)
	{
		count = Mathf.Max(0, newCount);
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
			countText.text = $"x{count}";
		}
	}

	private void UpdateWeightText()
	{
		if (!(weightText == null))
		{
			if (itemSO != null && count > 0)
			{
				weightText.text = $"{count}";
			}
			else
			{
				weightText.text = "0";
			}
		}
	}

	private void Awake()
	{
		if (GameManager.Instance != null)
		{
			localBag = GameManager.Instance.localBag;
		}
	}

	private void OnEnable()
	{
		SetupInputActions();
	}

	private void OnDisable()
	{
		if (leftAction != null && leftAction.action != null)
		{
			leftAction.action.performed -= OnLeftActionPerformed;
		}
		if (rightAction != null && rightAction.action != null)
		{
			rightAction.action.performed -= OnRightActionPerformed;
		}
	}

	private void SetupInputActions()
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
		if (leftAction != null && leftAction.action != null)
		{
			leftAction.action.performed -= OnLeftActionPerformed;
			leftAction.action.performed += OnLeftActionPerformed;
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
		if (rightAction != null && rightAction.action != null)
		{
			rightAction.action.performed -= OnRightActionPerformed;
			rightAction.action.performed += OnRightActionPerformed;
		}
	}

	private void OnLeftActionPerformed(InputAction.CallbackContext ctx)
	{
		if (IsInputActive())
		{
			HandleLeftAction();
		}
	}

	private void OnRightActionPerformed(InputAction.CallbackContext ctx)
	{
		if (IsInputActive())
		{
			HandleRightAction();
		}
	}

	private bool IsInputActive()
	{
		if (EventSystem.current == null || selectable == null)
		{
			return false;
		}
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject == null)
		{
			return false;
		}
		if (!(currentSelectedGameObject == selectable.gameObject))
		{
			return currentSelectedGameObject.transform.IsChildOf(selectable.transform);
		}
		return true;
	}

	private void HandleLeftAction()
	{
		if (itemSO == null || count <= 0)
		{
			return;
		}
		if (localBag == null)
		{
			if (GameManager.Instance != null)
			{
				localBag = GameManager.Instance.localBag;
			}
			if (localBag == null)
			{
				return;
			}
		}
		localBag.ConvertItemTypeToSack(itemSO);
	}

	private void HandleRightAction()
	{
	}
}
