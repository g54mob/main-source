using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Production;
using NSMedieval.RoomDetection;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.View;
using NSMedieval.Village;
using UnityEngine;
using UnityEngine.UI;

public class RoomTypesUI : MonoBehaviour
{
	[SerializeField]
	private LayoutGroupView roomButtonsGroup;

	[SerializeField]
	private List<RectTransform> refreshLayoutOnOverlayToggle;

	private readonly Dictionary<RoomType, ButtonLayoutItemView> buttonsPerRoomType = new Dictionary<RoomType, ButtonLayoutItemView>();

	private int roomIndexToSelect;

	private CanvasGroup canvasGroup;

	private void Start()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		RoomViewManager instance = MonoSingleton<RoomViewManager>.Instance;
		instance.RoomOverlayToggleEvent = (Action<bool>)Delegate.Combine(instance.RoomOverlayToggleEvent, new Action<bool>(OnRoomOverlayToggle));
		MonoSingleton<RoomDetectionController>.Instance.RoomTypeUnlockedEvent += OnRoomTypeUnlocked;
		OnRoomOverlayToggle(GlobalSaveController.CurrentVillageData.HeatmapVisible == 3);
	}

	private void OnDestroy()
	{
		foreach (ButtonLayoutItemView value in buttonsPerRoomType.Values)
		{
			UnityEngine.Object.DestroyImmediate(value.gameObject);
		}
		buttonsPerRoomType.Clear();
		refreshLayoutOnOverlayToggle.Clear();
		if (MonoSingleton<RoomDetectionController>.IsInstantiated())
		{
			MonoSingleton<RoomDetectionController>.Instance.RoomTypeUnlockedEvent -= OnRoomTypeUnlocked;
		}
		if (MonoSingleton<RoomViewManager>.IsInstantiated())
		{
			RoomViewManager instance = MonoSingleton<RoomViewManager>.Instance;
			instance.RoomOverlayToggleEvent = (Action<bool>)Delegate.Remove(instance.RoomOverlayToggleEvent, new Action<bool>(OnRoomOverlayToggle));
		}
	}

	private void OnRoomTypeUnlocked(RoomType roomType)
	{
		OnRoomOverlayToggle(isEnabled: true);
	}

	private void OnRoomOverlayToggle(bool isEnabled)
	{
		if (isEnabled)
		{
			InitRoomTypeButtons();
		}
		canvasGroup.alpha = (isEnabled ? 1 : 0);
		roomButtonsGroup.gameObject.SetActive(isEnabled);
		if (!isEnabled)
		{
			foreach (SelectableObject item in new List<SelectableObject>(MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects))
			{
				if (item is RoomView roomView)
				{
					roomView.Deselect();
				}
			}
		}
		if (refreshLayoutOnOverlayToggle == null)
		{
			return;
		}
		foreach (RectTransform item2 in refreshLayoutOnOverlayToggle)
		{
			if (item2 != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(item2);
			}
		}
	}

	private void SetRoomTypeButtonClick(ButtonLayoutItemView buttonItemView, RoomType roomType)
	{
		buttonItemView.gameObject.name = "button_" + roomType.GetID();
		(buttonItemView.TooltipNew as RoomTypeTooltipView)?.SetRoomType(roomType);
		buttonItemView.Button.onClick.RemoveAllListeners();
		buttonItemView.Button.onClick.AddListener(delegate
		{
			if (MonoSingleton<SelectableObjectManager>.IsInstantiated() && MonoSingleton<RoomViewManager>.IsInstantiated())
			{
				List<Room> list = ListPool<Room>.Get();
				foreach (Room item in VillageManager.ActiveVillage.Map.RoomDetection.IterateRoomsSafe())
				{
					if (item.RoomType == roomType)
					{
						list.Add(item);
					}
				}
				if (!list.Any())
				{
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("room_type_not_found_legend").Replace("{type}", roomType.NameLocalized);
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
				}
				else
				{
					foreach (SelectableObject selectableObject in MonoSingleton<SelectableObjectManager>.Instance.SelectableObjects)
					{
						selectableObject.Deselect();
					}
					Room room = list[roomIndexToSelect % list.Count];
					RoomView view = MonoSingleton<RoomViewManager>.Instance.GetView(room);
					if (view != null)
					{
						MonoSingleton<SelectableObjectManager>.Instance.SelectObject(view);
						MonoSingleton<RtsCamera>.Instance.JumpTo(view.transform.position);
					}
				}
				ListPool<Room>.Return(list);
				roomIndexToSelect++;
			}
		});
	}

	private void InitRoomTypeButtons()
	{
		int num = 0;
		foreach (RoomType allItem in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems())
		{
			if (RoomType.IsRoomTypeUnlocked(allItem))
			{
				if (buttonsPerRoomType.TryGetValue(allItem, out var value))
				{
					value.transform.SetSiblingIndex(num);
					num++;
					continue;
				}
				ButtonLayoutItemView component = UnityEngine.Object.Instantiate(roomButtonsGroup.Prefab, roomButtonsGroup.transform).GetComponent<ButtonLayoutItemView>();
				buttonsPerRoomType.Add(allItem, component);
				SetRoomTypeButtonClick(component, allItem);
				component.transform.SetSiblingIndex(num);
				num++;
			}
		}
		OnRoomOverlayToggle(isEnabled: false);
	}
}
