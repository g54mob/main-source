using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class TapOnTileSlotInput : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<RaycastResult, bool> _003C_003E9__7_0;

		internal bool _003CClick_003Eb__7_0(RaycastResult x)
		{
			return x.gameObject.GetComponent<ICanvasRaycastFilter>() != null;
		}
	}

	[SerializeField]
	private TileSlotEvent onNewTileSlotClicked;

	[FormerlySerializedAs("onTileSlotClickConfirmed")]
	[SerializeField]
	private UnityEvent onSelectedTileSlotClicked;

	private TileSlot currentTileSlot;

	private TouchController touchController;

	private Camera mainCamera;

	private void Awake()
	{
		touchController = GetComponentInParent<TouchController>();
	}

	private void Start()
	{
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		touchController.Controls.Touch.PrimaryTouchContact.canceled += delegate
		{
			Click();
		};
	}

	private void Click()
	{
		TileSlot tileSlot = DetermineCurrentTileSlot();
		if (!touchController.TilePlacementAllowed)
		{
			return;
		}
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		if (Enumerable.Count(list, (RaycastResult x) => x.gameObject.GetComponent<ICanvasRaycastFilter>() != null) <= 0 && !(tileSlot == null))
		{
			if (tileSlot != currentTileSlot)
			{
				currentTileSlot = tileSlot;
				onNewTileSlotClicked.Invoke(currentTileSlot);
			}
			else if (tileSlot != null)
			{
				onSelectedTileSlotClicked.Invoke();
			}
		}
	}

	private TileSlot DetermineCurrentTileSlot()
	{
		Physics.Raycast(mainCamera.ScreenPointToRay(touchController.CurrentPrimaryTouchPos), out var hitInfo, 1000f, LayerMask.GetMask("TileSlot"));
		TileSlot tileSlot = (hitInfo.collider ? hitInfo.collider.GetComponent<TileSlot>() : null);
		if (tileSlot != null && !tileSlot.IsValid)
		{
			tileSlot = null;
		}
		return tileSlot;
	}

	private void _003CStart_003Eb__6_0(InputAction.CallbackContext _)
	{
		Click();
	}
}
