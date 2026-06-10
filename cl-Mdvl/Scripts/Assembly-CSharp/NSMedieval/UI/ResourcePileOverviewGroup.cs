using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResourcePileOverviewGroup : LayoutGroupItemView
	{
		[SerializeField]
		private SoundButton selectTargetButton;

		[SerializeField]
		private TMP_Text resourceName;

		[SerializeField]
		private TMP_Text sortingGroup;

		[SerializeField]
		private TMP_Text resourceHitpoints;

		[SerializeField]
		private TMP_Text resourceValue;

		[SerializeField]
		private TMP_Text resourceWeight;

		[SerializeField]
		private CustomToggle forbidToggle;

		[SerializeField]
		private CustomToggle urgentHaulToggle;

		[SerializeField]
		private TMP_Text storageName;

		[NonSerialized]
		private Image background;

		[NonSerialized]
		protected ResourcePileInstance pileInstance;

		protected ResourcePileInstance PileInstance => pileInstance;

		protected Image Background => background ?? (background = GetComponent<Image>());

		public event Action ItemDisposedAction;

		public virtual void SetInstance(ResourcePileInstance instance, int index)
		{
			if (instance == null || instance.HasDisposed)
			{
				return;
			}
			SetBackgroundAlpha(index);
			if (instance != PileInstance)
			{
				if (pileInstance != null)
				{
					Unsubscribe();
				}
				pileInstance = instance;
				Subscribe();
				selectTargetButton.AddCleanListener(OnSelectTargetClick);
				base.TooltipNew.SetLines(GetTooltipLines());
				resourceName.SetText(GetName());
				sortingGroup.SetText(GetSortingGroup());
				OnWeightChanged();
				OnValueChanged();
				UpdateHealth();
				OnStorageChanged();
				forbidToggle.SetIsOnWithoutNotify(PileInstance.IsForbidden);
				urgentHaulToggle.SetIsOnWithoutNotify(PileInstance.IsUrgentHaul);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			pileInstance = null;
			this.ItemDisposedAction = null;
		}

		private void SetBackgroundAlpha(int index)
		{
			index += 10;
			Color color = Background.color;
			float num = ((index % 2 == 0) ? 2 : 0);
			Background.color = new Color(color.r, color.g, color.b, num / 255f);
		}

		private void OnSelectTargetClick()
		{
			ResourcePileView view = MonoSingleton<ResourcePileManager>.Instance.GetView(PileInstance);
			if (view != null)
			{
				SelectTarget(view);
				return;
			}
			int storageUniqueId = ResourcePileUtils.GetStorageUniqueId(PileInstance);
			if (!storageUniqueId.Equals(0))
			{
				SelectableObject byId = MonoSingleton<SelectableObjectManager>.Instance.GetById(storageUniqueId);
				if (!(byId == null))
				{
					SelectTarget(byId);
				}
			}
		}

		private void SelectTarget(SelectableObject selectableObject)
		{
			MonoSingleton<UIController>.Instance.OverviewPanelManager.Close();
			MonoSingleton<UIPanelManager>.Instance.CloseAllOpened();
			MonoSingleton<World>.Instance.JumpToLayer(selectableObject.GetAsWorldObject().GetGridPosition());
			MonoSingleton<RtsCamera>.Instance.JumpTo(selectableObject.transform.position);
			MonoSingleton<TaskController>.Instance.WaitFor(0.3f).Then(delegate
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(selectableObject);
			});
		}

		protected virtual List<string> GetTooltipLines()
		{
			return ResourcePileUtils.GetTooltipLines(PileInstance);
		}

		public virtual bool Unsubscribe()
		{
			forbidToggle.onValueChanged.RemoveListener(OnForbid);
			urgentHaulToggle.onValueChanged.RemoveListener(OnUrgentHaul);
			if (PileInstance == null)
			{
				return false;
			}
			PileInstance.ResourceStoredOnStockpileEvent -= OnStoredOnStockpile;
			PileInstance.ResourceStoredOnStorageEvent -= OnStoredOnStorage;
			PileInstance.ForbidChangeEvent -= OnForbidChanged;
			PileInstance.UrgentHaulChangeEvent -= OnUrgentHaulChanged;
			PileInstance.Stats?.Controller.RemoveListener(OnHealthChanged);
			return true;
		}

		protected virtual void Subscribe()
		{
			forbidToggle.onValueChanged.AddListener(OnForbid);
			urgentHaulToggle.onValueChanged.AddListener(OnUrgentHaul);
			PileInstance.Stats?.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Health, OnHealthChanged);
			PileInstance.ResourceStoredOnStockpileEvent += OnStoredOnStockpile;
			PileInstance.ResourceStoredOnStorageEvent += OnStoredOnStorage;
			PileInstance.ForbidChangeEvent += OnForbidChanged;
			PileInstance.UrgentHaulChangeEvent += OnUrgentHaulChanged;
			PileInstance.OnDisposedEvent += OnItemDisposed;
		}

		private void OnItemDisposed(IGameDisposable obj)
		{
			Unsubscribe();
			this.ItemDisposedAction?.Invoke();
		}

		protected void OnWeightChanged()
		{
			resourceWeight.SetText($"{PileInstance.Blueprint.Weight:F1}");
		}

		protected int GetCount()
		{
			if (pileInstance?.GetStorage() == null)
			{
				return 0;
			}
			return PileInstance.GetStorage().GetTotalStoredCount();
		}

		private string GetSortingGroup()
		{
			string text = "resource_group_" + PileInstance.Blueprint.SortingGroup;
			string localizedAlmanacLink = UiUtils.GetLocalizedAlmanacLink(text);
			if (!localizedAlmanacLink.Equals(string.Empty))
			{
				return localizedAlmanacLink;
			}
			return base.Localize.GetText(text);
		}

		private string GetName()
		{
			return ResourceUtils.GetLocalizedNameWithSprite(PileInstance.Blueprint);
		}

		protected string GetStatValue(StatType statType)
		{
			float statCurrentPercent = ResourcePileUtils.GetStatCurrentPercent(statType, PileInstance);
			if (statCurrentPercent != 0f)
			{
				return $"{statCurrentPercent:P0}";
			}
			return string.Empty;
		}

		private float GetBaseValue()
		{
			return PileInstance.GetWealth();
		}

		private bool IsMyPileInstance(IForbidable obj)
		{
			IForbidable forbidable = PileInstance;
			if (forbidable != null)
			{
				return forbidable == obj;
			}
			return false;
		}

		private void OnForbidChanged(IForbidable obj)
		{
			if (IsMyPileInstance(obj))
			{
				forbidToggle.SetIsOnWithoutNotify(PileInstance.IsForbidden);
			}
		}

		private void OnForbidDrag()
		{
			forbidToggle.isOn = !forbidToggle.isOn;
		}

		private void OnForbid(bool isForbidden)
		{
			if (PileInstance.InstanceStorage == null)
			{
				PileInstance.IsForbidden = isForbidden;
			}
			int storageUniqueId = ResourcePileUtils.GetStorageUniqueId(PileInstance);
			if (!storageUniqueId.Equals(0))
			{
				SelectableObject byId = MonoSingleton<SelectableObjectManager>.Instance.GetById(storageUniqueId);
				if (!(byId == null))
				{
					VillageManager.ActiveVillage.Map.ShelfComponentManager.GetComponentInstance(byId.GetAsWorldObject())?.SetForbidden(isForbidden);
				}
			}
		}

		private void OnUrgentHaul(bool isUrgentHaul)
		{
			PileInstance.IsUrgentHaul = isUrgentHaul;
		}

		private void OnUrgentHaulChanged(ResourcePileInstance pileInstance)
		{
			if (IsMyPileInstance(pileInstance))
			{
				urgentHaulToggle.SetIsOnWithoutNotify(PileInstance.IsUrgentHaul);
				UpdateUrgentHaulToggleVisibility();
			}
		}

		private void OnHealthChanged(object stat)
		{
			UpdateHealth();
		}

		private void UpdateHealth()
		{
			resourceHitpoints.SetText(GetStatValue(StatType.Health));
		}

		protected void OnValueChanged()
		{
			resourceValue.SetText(string.Format("{0}{1:F1}", AssetUtils.GetSpriteAsset("value"), GetBaseValue()));
		}

		private void OnStoredOnStorage(bool arg1, UniversalStorage arg2)
		{
			OnStorageChanged();
		}

		private void OnStoredOnStockpile(bool arg1, StockpileInstance arg2)
		{
			OnStorageChanged();
		}

		private void OnStorageChanged()
		{
			storageName.SetText(ResourcePileUtils.GetStorage(PileInstance));
			UpdateUrgentHaulToggleVisibility();
		}

		private void UpdateUrgentHaulToggleVisibility()
		{
			if (PileInstance != null && !PileInstance.HasDisposed)
			{
				bool active = !PileInstance.IsStoredOnStockpile() && !PileInstance.IsPlacedOnStorageBuilding;
				urgentHaulToggle.gameObject.SetActive(active);
			}
		}
	}
}
