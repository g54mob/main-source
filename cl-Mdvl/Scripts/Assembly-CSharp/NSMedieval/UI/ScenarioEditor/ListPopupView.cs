using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ListPopupView : CharacterEditPopupView
	{
		[SerializeField]
		private LayoutGroupView genericListGroup;

		[SerializeField]
		private LayoutGroupView apparanceEditListGroup;

		[SerializeField]
		private LayoutGroupView perksListGroup;

		[SerializeField]
		private GameObject scrollViewPerks;

		private readonly List<ButtonLayoutItemView> perksListButtons = new List<ButtonLayoutItemView>();

		private readonly List<ButtonLayoutItemView> appearanceEditListButtons = new List<ButtonLayoutItemView>();

		private readonly List<ButtonLayoutItemView> genericListButtons = new List<ButtonLayoutItemView>();

		private int paddingTop;

		private int paddingBottom;

		private int paddingLeft;

		private Vector2 cellSize = Vector2.zero;

		private Vector2 spacing = Vector2.zero;

		private GridLayoutGroup genericGrid;

		protected override void Start()
		{
			base.Start();
			genericGrid = genericListGroup.GetComponent<GridLayoutGroup>();
			paddingTop = genericGrid.padding.top;
			paddingBottom = genericGrid.padding.bottom;
			paddingLeft = genericGrid.padding.left;
			cellSize = genericGrid.cellSize;
			spacing = genericGrid.spacing;
			CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
			instance.ShowPopupListAction = (Action<ListPopupData>)Delegate.Combine(instance.ShowPopupListAction, new Action<ListPopupData>(OnShowPopupList));
			CharacterEditController instance2 = MonoSingleton<CharacterEditController>.Instance;
			instance2.ShowAppearancePopupListAction = (Action<ListPopupData>)Delegate.Combine(instance2.ShowAppearancePopupListAction, new Action<ListPopupData>(OnShowAppearanceEditList));
			CharacterEditController instance3 = MonoSingleton<CharacterEditController>.Instance;
			instance3.ShowPerksPopupListAction = (Action<ListPopupData>)Delegate.Combine(instance3.ShowPerksPopupListAction, new Action<ListPopupData>(OnShowPerksPopupList));
			CharacterEditController instance4 = MonoSingleton<CharacterEditController>.Instance;
			instance4.HidePopupListAction = (Action)Delegate.Combine(instance4.HidePopupListAction, new Action(Hide));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<CharacterEditController>.IsInstantiated())
			{
				CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
				instance.ShowPopupListAction = (Action<ListPopupData>)Delegate.Remove(instance.ShowPopupListAction, new Action<ListPopupData>(OnShowPopupList));
				CharacterEditController instance2 = MonoSingleton<CharacterEditController>.Instance;
				instance2.ShowAppearancePopupListAction = (Action<ListPopupData>)Delegate.Remove(instance2.ShowAppearancePopupListAction, new Action<ListPopupData>(OnShowAppearanceEditList));
				CharacterEditController instance3 = MonoSingleton<CharacterEditController>.Instance;
				instance3.ShowPerksPopupListAction = (Action<ListPopupData>)Delegate.Remove(instance3.ShowPerksPopupListAction, new Action<ListPopupData>(OnShowPerksPopupList));
				CharacterEditController instance4 = MonoSingleton<CharacterEditController>.Instance;
				instance4.HidePopupListAction = (Action)Delegate.Remove(instance4.HidePopupListAction, new Action(Hide));
			}
		}

		private void OnShowPopupList(ListPopupData data)
		{
			Show();
			SetTitle(data.Title);
			scrollViewPerks.SetActive(value: false);
			genericListGroup.gameObject.SetActive(value: true);
			genericListButtons.SetAllActive(active: false);
			foreach (ListPopupItemData item in data.ListItems)
			{
				ButtonLayoutItemView next = genericListButtons.GetNext(genericListGroup);
				next.SetButtonData(item.ID, item.LocalizedName);
				if (!string.IsNullOrEmpty(item.ImagePath))
				{
					next.SetImage(item.ImagePath);
					Rect rect = next.ImageObject.rectTransform.rect;
					genericGrid.padding.top = paddingTop + (int)(rect.height / 2f);
					genericGrid.padding.bottom = paddingBottom + (int)(rect.height / 2f);
					genericGrid.padding.left = paddingLeft + (int)(rect.width * 0.8125f) + 1;
					genericGrid.cellSize = new Vector2(cellSize.x - (float)genericGrid.padding.left, cellSize.y);
					genericGrid.spacing = new Vector2(spacing.x, (int)(rect.height * 0.456f));
				}
				else
				{
					genericGrid.padding.top = paddingTop;
					genericGrid.padding.left = paddingLeft;
					genericGrid.cellSize = cellSize;
					genericGrid.spacing = spacing;
				}
				next.ImageObject.enabled = !string.IsNullOrEmpty(item.ImagePath);
				next.TooltipNew.ClearLines();
				if (item.TooltipLines != null)
				{
					next.TooltipNew.AppendLines(item.TooltipLines);
				}
				else
				{
					next.TooltipNew.SetSingleLineTooltip(item.LocalizedName, TooltipStyles.TooltipTitle);
				}
				next.Button.AddCleanListener(item.Callback.Invoke);
				next.Button.onClick.AddListener(delegate
				{
					SetSelectedGeneric(new List<string> { item.ID });
				});
			}
			SetSelectedGeneric(data.SelectedID);
		}

		private void SetSelectedGeneric(ICollection<string> selectedId)
		{
			foreach (ButtonLayoutItemView genericListButton in genericListButtons)
			{
				genericListButton.Button.interactable = !selectedId.Contains(genericListButton.GetId);
				if (genericListButton.ImageObject.enabled)
				{
					genericListButton.ImageObject.color = (selectedId.Contains(genericListButton.GetId) ? Color.gray : Color.white);
				}
			}
		}

		private void SetSelectedPerks(ICollection<string> selectedId)
		{
			foreach (ButtonLayoutItemView perksListButton in perksListButtons)
			{
				perksListButton.Button.interactable = !selectedId.Contains(perksListButton.GetId);
				if (perksListButton.ImageObject.enabled)
				{
					perksListButton.ImageObject.color = (selectedId.Contains(perksListButton.GetId) ? Color.gray : Color.white);
				}
			}
		}

		private void OnShowAppearanceEditList(ListPopupData data)
		{
			Show();
			SetTitle(data.Title);
			scrollViewPerks.SetActive(value: false);
			appearanceEditListButtons.SetAllActive(active: false);
			apparanceEditListGroup.gameObject.SetActive(value: true);
			WorkerPhysicalLook physicalLook = data.HumanoidInstance.GetCharacterInfo().PhysicalLook;
			string hairType = physicalLook.GetHairType();
			string moustacheType = physicalLook.GetMoustacheType();
			string beardType = physicalLook.GetBeardType();
			string headType = physicalLook.GetHeadType();
			string hairColor = physicalLook.GetHairColor();
			string skinColor = physicalLook.GetSkinColor();
			foreach (ListPopupItemData item in data.ListItems)
			{
				physicalLook.SetSkinColor(skinColor);
				physicalLook.SetHairType(hairType);
				physicalLook.SetHeadType(headType);
				physicalLook.SetBeardType(beardType);
				physicalLook.SetMoustacheType(moustacheType);
				physicalLook.SetHairColor(hairColor);
				ButtonLayoutItemView next = appearanceEditListButtons.GetNext(apparanceEditListGroup);
				next.SetButtonData(item.ID, item.LocalizedName);
				next.Button.AddCleanListener(item.Callback.Invoke);
				next.Button.onClick.AddListener(delegate
				{
					SetSelectedAppearanceEdit(new List<string> { item.ID });
				});
				switch (data.ListType)
				{
				case ListPopupItemType.HairType:
					physicalLook.SetHairType(item.ID);
					break;
				case ListPopupItemType.FacialHairType:
					physicalLook.SetMoustacheType(item.ID);
					physicalLook.SetBeardType(item.ID);
					break;
				case ListPopupItemType.HeadType:
					physicalLook.SetHeadType(item.ID);
					break;
				case ListPopupItemType.HairColor:
					physicalLook.SetHairColor(item.ID);
					break;
				case ListPopupItemType.SkinColor:
					physicalLook.SetSkinColor(item.ID);
					break;
				}
				next.ImageObject.sprite = MonoSingleton<HumanoidIconManager>.Instance.GenerateIcon(data.HumanoidInstance);
			}
			physicalLook.SetSkinColor(skinColor);
			physicalLook.SetHairType(hairType);
			physicalLook.SetHeadType(headType);
			physicalLook.SetBeardType(beardType);
			physicalLook.SetMoustacheType(moustacheType);
			physicalLook.SetHairColor(hairColor);
			MonoSingleton<HumanoidIconManager>.Instance.GenerateAndCacheIcon(data.HumanoidInstance);
			SetSelectedAppearanceEdit(data.SelectedID);
		}

		private void SetSelectedAppearanceEdit(ICollection<string> selectedId)
		{
			foreach (ButtonLayoutItemView appearanceEditListButton in appearanceEditListButtons)
			{
				appearanceEditListButton.Button.interactable = !selectedId.Contains(appearanceEditListButton.GetId);
				appearanceEditListButton.Select(selectedId.Contains(appearanceEditListButton.GetId));
			}
		}

		private void OnShowPerksPopupList(ListPopupData data)
		{
			Show();
			SetTitle(data.Title);
			scrollViewPerks.SetActive(value: true);
			perksListGroup.gameObject.SetActive(value: true);
			perksListButtons.SetAllActive(active: false);
			foreach (ListPopupItemData item in data.ListItems)
			{
				ButtonLayoutItemView next = perksListButtons.GetNext(perksListGroup);
				next.SetButtonData(item.ID, item.LocalizedName);
				if (!string.IsNullOrEmpty(item.ImagePath))
				{
					next.SetImage(item.ImagePath);
				}
				next.ImageObject.enabled = !string.IsNullOrEmpty(item.ImagePath);
				next.TooltipNew.ClearLines();
				if (item.TooltipLines != null)
				{
					next.TooltipNew.AppendLines(item.TooltipLines);
				}
				else
				{
					next.TooltipNew.SetSingleLineTooltip(item.LocalizedName, TooltipStyles.TooltipTitle);
				}
				next.Button.AddCleanListener(item.Callback.Invoke);
				next.Button.onClick.AddListener(delegate
				{
					SetSelectedPerks(new List<string> { item.ID });
				});
			}
			SetSelectedPerks(data.SelectedID);
		}

		public override void Hide()
		{
			apparanceEditListGroup.gameObject.SetActive(value: true);
			appearanceEditListButtons.SetAllActive(active: false);
			genericListGroup.gameObject.SetActive(value: true);
			genericListButtons.SetAllActive(active: false);
			scrollViewPerks.SetActive(value: true);
			perksListGroup.gameObject.SetActive(value: true);
			perksListButtons.SetAllActive(active: false);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				apparanceEditListGroup.gameObject.SetActive(value: false);
				genericListGroup.gameObject.SetActive(value: false);
				perksListGroup.gameObject.SetActive(value: false);
				scrollViewPerks.SetActive(value: false);
				base.Hide();
				MonoSingleton<CharacterEditController>.Instance.NotifyCharacterUpdated();
			});
		}
	}
}
