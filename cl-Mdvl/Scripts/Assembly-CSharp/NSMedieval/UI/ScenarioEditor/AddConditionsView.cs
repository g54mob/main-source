using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Research;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	public class AddConditionsView : ClosableUIView
	{
		[SerializeField]
		private ScenarioEditView scenarioEditView;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private LayoutGroupView conditionsGroup;

		private readonly List<ButtonLayoutItemView> conditionButtons = new List<ButtonLayoutItemView>();

		public event Action<string> AddResource;

		public event Action<string> AddEquipment;

		public event Action<string> AddStructurePile;

		public event Action<VillagerConstraint> AddConstraint;

		public event Action<Perk> AddPerk;

		public event Action<StatType> AddStatOverride;

		public event Action<string> AddTechnology;

		public event Action<string> AddMapType;

		public event Action<string> AddClothes;

		public event Action<string> AddAnimal;

		private void Awake()
		{
			closeButton.onClick.AddListener(Hide);
		}

		public void ShowGroup(ScenarioConditionGroup group)
		{
			Show();
			conditionButtons.SetAllActive(active: false);
			foreach (KeyValuePair<string, Action> groupItem in GetGroupItems(group))
			{
				ButtonLayoutItemView next = conditionButtons.GetNext(conditionsGroup);
				next.SetText(1, groupItem.Key.ToString());
				next.Button.AddCleanListener(groupItem.Value.Invoke);
			}
		}

		private List<KeyValuePair<string, Action>> GetGroupItems(ScenarioConditionGroup group)
		{
			List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>();
			switch (group)
			{
			case ScenarioConditionGroup.Root:
				list.AddRange(from condition in (ScenarioConditionGroup[])Enum.GetValues(typeof(ScenarioConditionGroup))
					where condition != ScenarioConditionGroup.Root && condition != ScenarioConditionGroup.VillagerPerks && condition != ScenarioConditionGroup.VillagerStats && condition != ScenarioConditionGroup.VillagerClothes
					select new KeyValuePair<string, Action>(base.Localize.GetText($"scenario_condition_{condition}", BodyType.None), delegate
					{
						ShowGroup(condition);
					}));
				break;
			case ScenarioConditionGroup.Resources:
				list.AddRange(from res in scenarioEditView.Resources
					orderby ResourceUtils.GetLocalizedResourceName(res)
					select new KeyValuePair<string, Action>(ResourceUtils.GetLocalizedResourceName(res), delegate
					{
						OnResourceClick(res);
					}));
				break;
			case ScenarioConditionGroup.Equipment:
				list.AddRange(from res in scenarioEditView.ProtoEquipments
					orderby ResourceUtils.GetLocalizedResourceName(res, showQuality: false)
					select new KeyValuePair<string, Action>(ResourceUtils.GetLocalizedResourceName(res, showQuality: false), delegate
					{
						OnEquipmentClick(res);
					}));
				break;
			case ScenarioConditionGroup.StructurePiles:
				list.AddRange(from item in scenarioEditView.StructurePiles.OrderBy(BuildingUtils.GetLocalizedName)
					select new KeyValuePair<string, Action>(BuildingUtils.GetLocalizedName(item), delegate
					{
						OnStructurePileClick(item);
					}));
				break;
			case ScenarioConditionGroup.VillagerConstraints:
				list.AddRange(scenarioEditView.Constraints.Select((VillagerConstraint constraint) => new KeyValuePair<string, Action>(base.Localize.GetText($"villager_constraint_{constraint}"), delegate
				{
					OnConstraintClick(constraint);
				})));
				break;
			case ScenarioConditionGroup.VillagerPerks:
				list.AddRange(from perk in scenarioEditView.Perks.OrderBy((Perk perk) => base.Localize.GetText(LocKeyUtils.GetName(perk.LocKeys))).ToList()
					select new KeyValuePair<string, Action>(base.Localize.GetText(LocKeyUtils.GetName(perk.LocKeys), BodyType.Male), delegate
					{
						OnPerkClick(perk);
					}));
				break;
			case ScenarioConditionGroup.Technology:
				list.AddRange(from tech in scenarioEditView.Technology
					orderby base.Localize.GetText(LocKeyUtils.GetName(Repository<ResearchRepository, ResearchModel>.Instance.GetByID(tech).LocKeys))
					select new KeyValuePair<string, Action>(base.Localize.GetText(LocKeyUtils.GetName(Repository<ResearchRepository, ResearchModel>.Instance.GetByID(tech).LocKeys)), delegate
					{
						OnTechnologyClick(tech);
					}));
				break;
			case ScenarioConditionGroup.MapTypes:
				list.AddRange(from id in scenarioEditView.MapTypes
					orderby base.Localize.GetText(LocKeyUtils.GetName(Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(id).LocKeys))
					select new KeyValuePair<string, Action>(base.Localize.GetText(LocKeyUtils.GetName(Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(id).LocKeys)), delegate
					{
						OnMapTypeClick(id);
					}));
				break;
			case ScenarioConditionGroup.VillagerStats:
				list.AddRange(from stat in scenarioEditView.StatOverrides
					orderby base.Localize.GetText($"menu_{stat}")
					select new KeyValuePair<string, Action>(base.Localize.GetText($"menu_{stat}"), delegate
					{
						OnStatClick(stat);
					}));
				break;
			case ScenarioConditionGroup.VillagerClothes:
				list.AddRange(from res in scenarioEditView.ClothesDistinctIDs
					orderby ResourceUtils.GetLocalizedResourceName(res, showQuality: false)
					select new KeyValuePair<string, Action>(ResourceUtils.GetLocalizedResourceName(res, showQuality: false), delegate
					{
						OnClothesClick(res);
					}));
				break;
			case ScenarioConditionGroup.Animals:
				list.AddRange(from s in scenarioEditView.Animals.OrderBy(AnimalUtils.GetLocalizedName)
					select new KeyValuePair<string, Action>(AnimalUtils.GetLocalizedName(s), delegate
					{
						OnAnimalClick(s);
					}));
				break;
			}
			return list;
		}

		private void DevAddAll(List<KeyValuePair<string, Action>> list)
		{
			list.Add(new KeyValuePair<string, Action>("dev_all", delegate
			{
				foreach (KeyValuePair<string, Action> item in list)
				{
					if (!item.Key.Equals("dev_all"))
					{
						item.Value();
					}
				}
				Hide();
			}));
		}

		private void OnStatClick(StatType stat)
		{
			this.AddStatOverride?.Invoke(stat);
			Hide();
		}

		private void OnPerkClick(Perk perk)
		{
			this.AddPerk?.Invoke(perk);
			Hide();
		}

		private void OnClothesClick(string res)
		{
			this.AddClothes?.Invoke(res);
			Hide();
		}

		private void OnConstraintClick(VillagerConstraint constraint)
		{
			switch (constraint)
			{
			case VillagerConstraint.ForcedPerks:
				ShowGroup(ScenarioConditionGroup.VillagerPerks);
				break;
			case VillagerConstraint.OverrideStats:
				ShowGroup(ScenarioConditionGroup.VillagerStats);
				break;
			case VillagerConstraint.DefaultClothes:
				ShowGroup(ScenarioConditionGroup.VillagerClothes);
				break;
			default:
				this.AddConstraint?.Invoke(constraint);
				Hide();
				break;
			}
		}

		private void OnTechnologyClick(string tech)
		{
			this.AddTechnology?.Invoke(tech);
			Hide();
		}

		private void OnMapTypeClick(string tech)
		{
			this.AddMapType?.Invoke(tech);
			Hide();
		}

		private void OnEquipmentClick(string equipmentId)
		{
			this.AddEquipment?.Invoke(equipmentId);
			Hide();
		}

		private void OnStructurePileClick(string structurePileId)
		{
			this.AddStructurePile?.Invoke(structurePileId);
			Hide();
		}

		private void OnResourceClick(string resourceId)
		{
			this.AddResource?.Invoke(resourceId);
			Hide();
		}

		private void OnAnimalClick(string animalId)
		{
			this.AddAnimal?.Invoke(animalId);
			Hide();
		}
	}
}
