using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HotbarActionUI : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
	[Header("Config")]
	[SerializeField]
	private int hotbarActionIdx;

	[SerializeField]
	private InputActionReference inputActionRef;

	[SerializeField]
	private int inputActionBindingIndex;

	[Header("References")]
	[SerializeField]
	private TextMeshProUGUI bindingActionName;

	[SerializeField]
	private Image actionIcon;

	private bool pointerDown;

	private RectTransform draggedElementTransform;

	private GameplayObjectData draggedElementGod;

	public int HotbarActionIdx => hotbarActionIdx;

	private void Start()
	{
		LTFunctionLibrary.GetLTPlayerController().onHotbarBankChanged += OnHotbarBankChanged;
		LTFunctionLibrary.GetLTPlayerController().onHotbarActionChanged += OnHotbarActionChanged;
	}

	private void OnEnable()
	{
		UpdateInfo();
	}

	private void OnDisable()
	{
		if ((bool)draggedElementTransform)
		{
			LTFunctionLibrary.GetLTPlayerController().AddHotbarAction(draggedElementGod, hotbarActionIdx);
			draggedElementGod = null;
			Object.Destroy(draggedElementTransform.gameObject);
		}
	}

	private void OnDestroy()
	{
		LTFunctionLibrary.GetLTPlayerController().onHotbarBankChanged -= OnHotbarBankChanged;
		LTFunctionLibrary.GetLTPlayerController().onHotbarActionChanged -= OnHotbarActionChanged;
	}

	public void UpdateInfo()
	{
		UpdateActionIcon();
		UpdateBindingActionName();
	}

	private void UpdateActionIcon()
	{
		actionIcon.sprite = LTFunctionLibrary.GetLTPlayerController().GetHotbarAction(HotbarActionIdx)?.HotbarImage ?? null;
		if ((bool)actionIcon.sprite)
		{
			actionIcon.enabled = true;
		}
		else
		{
			actionIcon.enabled = false;
		}
	}

	private void UpdateBindingActionName()
	{
		bindingActionName.text = inputActionRef.action.GetBindingDisplayString(inputActionBindingIndex);
	}

	public void OnHotbarActionPressed()
	{
		LTFunctionLibrary.GetLTPlayerController().DoHotbarAction(HotbarActionIdx);
	}

	private void OnHotbarBankChanged(int bankIdx)
	{
		UpdateInfo();
	}

	private void OnHotbarActionChanged(int actionIdx)
	{
		if (HotbarActionIdx == actionIdx)
		{
			UpdateInfo();
		}
	}

	private void CreateDragElement(Vector2 position)
	{
		draggedElementTransform = new GameObject("DraggedIcon", typeof(RectTransform)).GetComponent<RectTransform>();
		draggedElementTransform.sizeDelta = Vector2.one * 58f * GameManager.instance.PlayerController.CurrentHUD.GetComponent<Canvas>().scaleFactor;
		draggedElementTransform.position = position;
		draggedElementTransform.SetParent(GetComponentInParent<HUDMenu>().transform);
		draggedElementTransform.SetAsLastSibling();
		Image image = draggedElementTransform.AddComponent<Image>();
		image.sprite = actionIcon.sprite;
		image.raycastTarget = false;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!LTFunctionLibrary.GetLTPlayerController().LTHUD.IsHotbarDragLocked && LTFunctionLibrary.GetLTPlayerController().GetHotbarAction(hotbarActionIdx) != null)
		{
			CreateDragElement(eventData.position);
			actionIcon.enabled = false;
			draggedElementGod = LTFunctionLibrary.GetLTPlayerController().GetHotbarAction(hotbarActionIdx);
			LTFunctionLibrary.GetLTPlayerController().RemoveHotbarAction(hotbarActionIdx);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if ((bool)draggedElementTransform)
		{
			draggedElementTransform.transform.position = eventData.position;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!draggedElementTransform)
		{
			return;
		}
		HotbarActionUI hotbarActionUI = FunctionLibrary.TryToGetObjectUnderCursor<HotbarActionUI>(EventSystem.current);
		if ((bool)hotbarActionUI)
		{
			GameplayObjectData hotbarAction = LTFunctionLibrary.GetLTPlayerController().GetHotbarAction(hotbarActionUI.HotbarActionIdx);
			if ((bool)hotbarAction)
			{
				LTFunctionLibrary.GetLTPlayerController().AddHotbarAction(hotbarAction, hotbarActionIdx);
			}
			LTFunctionLibrary.GetLTPlayerController().AddHotbarAction(draggedElementGod, hotbarActionUI.HotbarActionIdx);
		}
		draggedElementGod = null;
		Object.Destroy(draggedElementTransform.gameObject);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!draggedElementGod)
		{
			OnHotbarActionPressed();
		}
		pointerDown = false;
	}
}
