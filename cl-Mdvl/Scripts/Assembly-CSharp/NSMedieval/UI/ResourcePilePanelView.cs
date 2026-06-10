using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ResourcePilePanelView : OverviewPanelView
	{
		[SerializeField]
		private OptimizedScrollView optimizedScrollView;

		[SerializeField]
		private string[] allowedSortingGroups;

		[SerializeField]
		private CustomToggle forbidAllToggle;

		[SerializeField]
		private CustomToggle urgentHaulAllToggle;

		[NonSerialized]
		private readonly HashSet<ResourcePileOverviewGroup> pileOverviewGroups = new HashSet<ResourcePileOverviewGroup>();

		private string currentSortingGroup;

		[NonSerialized]
		private readonly List<ResourcePileInstance> pileInstances = new List<ResourcePileInstance>();

		public string[] AllowedSortingGroups => allowedSortingGroups;

		protected override void Start()
		{
			base.Start();
			forbidAllToggle.onValueChanged.AddListener(OnForbidAll);
			urgentHaulAllToggle.onValueChanged.AddListener(OnUrgentHaulAll);
		}

		private void OnEnable()
		{
			OptimizedScrollView obj = optimizedScrollView;
			obj.UpdateScrollItemAction = (OptimizedScrollView.UpdateScrollDelegate)Delegate.Combine(obj.UpdateScrollItemAction, new OptimizedScrollView.UpdateScrollDelegate(OnUpdateScrollAction));
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent += OnPileSpawnedAction;
		}

		private void OnDisable()
		{
			OptimizedScrollView obj = optimizedScrollView;
			obj.UpdateScrollItemAction = (OptimizedScrollView.UpdateScrollDelegate)Delegate.Remove(obj.UpdateScrollItemAction, new OptimizedScrollView.UpdateScrollDelegate(OnUpdateScrollAction));
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= OnPileSpawnedAction;
			}
		}

		public void SetGroupAndShow(string sortingGroup)
		{
			currentSortingGroup = sortingGroup;
			UpdatePileInstances();
			Show();
		}

		public override void Show()
		{
			base.Show();
			SortEntries();
		}

		public override void Hide()
		{
			foreach (ResourcePileOverviewGroup pileOverviewGroup in pileOverviewGroups)
			{
				pileOverviewGroup.Unsubscribe();
			}
			base.Hide();
		}

		private void OnUpdateScrollAction(RectTransform rectTransform, int index)
		{
			if (pileInstances.Count <= index)
			{
				return;
			}
			ResourcePileInstance resourcePileInstance = pileInstances[index];
			if (resourcePileInstance.HasDisposed || resourcePileInstance.HasDied || resourcePileInstance.Stats == null)
			{
				OnPileCountChanged();
				return;
			}
			ResourcePileOverviewGroup component = rectTransform.GetComponent<ResourcePileOverviewGroup>();
			component.SetInstance(resourcePileInstance, index);
			if (!pileOverviewGroups.Contains(component))
			{
				pileOverviewGroups.Add(component);
				component.ItemDisposedAction += OnPileCountChanged;
			}
		}

		private void UpdatePileInstances()
		{
			pileInstances.Clear();
			foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
			{
				ResourcePileInstance key = allPile.Key;
				if (!key.HasDisposed && !key.HasDied && key.Stats != null && Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.CheckGroup(key.Blueprint.SortingGroup, currentSortingGroup))
				{
					pileInstances.Add(key);
				}
			}
		}

		private void OnPileSpawnedAction(ResourcePileInstance obj)
		{
			OnPileCountChanged();
		}

		private void OnPileCountChanged()
		{
			if (base.gameObject.activeInHierarchy)
			{
				UpdatePileInstances();
				SortEntries();
			}
		}

		private void OnForbidAll(bool isForbidden)
		{
			foreach (ResourcePileInstance pileInstance in pileInstances)
			{
				pileInstance.IsForbidden = isForbidden;
			}
		}

		private void OnUrgentHaulAll(bool isUrgentHaul)
		{
			foreach (ResourcePileInstance pileInstance in pileInstances)
			{
				pileInstance.IsUrgentHaul = isUrgentHaul;
			}
		}

		protected override void SortEntries()
		{
			pileInstances.Sort(OverviewEntrySortComparison);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				optimizedScrollView.RefreshVisibleEntries(pileInstances.Count);
			});
		}

		protected virtual int OverviewEntrySortComparison(ResourcePileInstance a, ResourcePileInstance b)
		{
			int num = 0;
			switch (base.CurrentSortMode)
			{
			case SortMode.Group:
				num = 1000 * SortByGroup();
				num += 10 * SortByName();
				break;
			case SortMode.Name:
				num = SortByName();
				break;
			case SortMode.Count:
				num = 1000 * (a.GetStorage().GetTotalStoredCount() - b.GetStorage().GetTotalStoredCount());
				num += 10 * SortByName();
				break;
			case SortMode.Health:
				num = SortByStat(StatType.Health);
				num += 10 * SortByName();
				break;
			case SortMode.Value:
				num = (int)(1000f * (a.GetWealth() - b.GetWealth()));
				num += 10 * SortByName();
				break;
			case SortMode.Weight:
				num = (int)(1000f * a.Blueprint.Weight - 1000f * b.Blueprint.Weight);
				num += 10 * SortByName();
				break;
			case SortMode.Freshness:
				num = SortByStat(StatType.Freshness);
				num += 10 * SortByName();
				break;
			case SortMode.Nutrition:
				num = 1000 * (a.GetNutrition() - b.GetNutrition());
				num += 10 * SortByName();
				break;
			case SortMode.Fermentation:
				num = SortByStat(StatType.Fermentation);
				num += 10 * SortByName();
				break;
			case SortMode.Quality:
				num = 1000 * (a.GetQuality() - b.GetQuality());
				num += 10 * SortByName();
				break;
			case SortMode.DamagePerSecond:
				num = GetDps(a) - GetDps(b);
				num += 10 * SortByName();
				break;
			case SortMode.Range:
				num = GetRange(a) - GetRange(b);
				num += 10 * SortByName();
				break;
			case SortMode.Precision:
				num = GetPrecision(a) - GetPrecision(b);
				num += 10 * SortByName();
				break;
			case SortMode.ArmorRating:
				num = GetArmourRating(a) - GetArmourRating(b);
				num += 10 * SortByName();
				break;
			case SortMode.MeleeCoverAmount:
				num = GetMeleeCover(a) - GetMeleeCover(b);
				num += 10 * SortByName();
				break;
			case SortMode.RangedCoverAmount:
				num = GetRangedCover(a) - GetRangedCover(b);
				num += 10 * SortByName();
				break;
			case SortMode.TempMin:
				num = GetMinTemp(a) - GetMinTemp(b);
				num += 10 * SortByName();
				break;
			case SortMode.TempMax:
				num = GetMaxTemp(a) - GetMaxTemp(b);
				num += 10 * SortByName();
				break;
			case SortMode.Allow:
				num = 1000 * SortByForbidden();
				num += 10 * SortByName();
				break;
			case SortMode.UrgentHaul:
				num = 1000 * SortByUrgentHaul();
				num += 10 * SortByName();
				break;
			case SortMode.OnStockpile:
				num = 1000 * SortByStockpile();
				num += 10 * SortByName();
				break;
			case SortMode.OwnerName:
				num = 1000 * SortByOwnerName();
				num += 10 * SortByName();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (!SortDirection)
			{
				return -num;
			}
			return num;
			static int GetArmourRating(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				StatInstance stat = instance.GetStat(StatType.Health);
				float num2 = ((stat != null) ? Mathf.Clamp(byID.ArmorRating * (stat.Current / stat.Max), 0f, 1f) : byID.ArmorRating);
				return Mathf.RoundToInt(1000f * num2);
			}
			static int GetDps(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				return Mathf.RoundToInt(1000f * (byID.PrimaryDamage / byID.PrimaryAttackSpeed));
			}
			static int GetMaxTemp(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				float num2 = WorldDate.ConvertCelsiusTemperature(units: MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits, celsiusTemperature: byID.WarmthModifier.Max, baseValue: false);
				return Mathf.RoundToInt(1000f * num2);
			}
			static int GetMeleeCover(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				return Mathf.RoundToInt(1000f * byID.GetCoverChance(DamageType.Melee));
			}
			static int GetMinTemp(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				float num2 = WorldDate.ConvertCelsiusTemperature(units: MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits, celsiusTemperature: byID.WarmthModifier.Min, baseValue: false);
				return Mathf.RoundToInt(1000f * num2);
			}
			static int GetPrecision(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				return Mathf.RoundToInt(1000f * byID.PrimaryPrecision);
			}
			static int GetRange(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				return Mathf.RoundToInt(1000f * byID.PrimaryRange);
			}
			static int GetRangedCover(ResourcePileInstance instance)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(instance.BlueprintId);
				return Mathf.RoundToInt(1000f * byID.GetCoverChance(DamageType.Ranged));
			}
			int SortByForbidden()
			{
				return (a.IsForbidden ? 1 : 0) - (b.IsForbidden ? 1 : 0);
			}
			int SortByGroup()
			{
				return string.Compare(a.Info.LocalizedGroup, b.Info.LocalizedGroup, StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByName()
			{
				return string.Compare(a.Info.LocalizedId, b.Info.LocalizedId, StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByOwnerName()
			{
				return string.Compare(a.GetStoredResource()?.LocalizedInheritedName, b.GetStoredResource()?.LocalizedInheritedName, StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByStat(StatType statType)
			{
				return Mathf.RoundToInt(1000f * ResourcePileUtils.GetStatCurrentPercent(statType, a) - 1000f * ResourcePileUtils.GetStatCurrentPercent(statType, b));
			}
			int SortByStockpile()
			{
				return string.Compare(a.Info.StorageId, b.Info.StorageId, StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByUrgentHaul()
			{
				return (a.IsUrgentHaul ? 1 : 0) - (b.IsUrgentHaul ? 1 : 0);
			}
		}
	}
}
