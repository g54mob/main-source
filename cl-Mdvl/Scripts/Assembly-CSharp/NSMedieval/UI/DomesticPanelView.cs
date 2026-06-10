using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.View.UI;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	public class DomesticPanelView : AnimalsPanelView
	{
		[SerializeField]
		private CustomToggle haulAllToggle;

		[SerializeField]
		private CustomToggle battleAllToggle;

		[SerializeField]
		private CustomToggle trainAllToggle;

		[SerializeField]
		private CustomToggle slaughterAllToggle;

		[SerializeField]
		private CustomToggle releaseAllToggle;

		[SerializeField]
		private CustomToggle pestControlAllToggle;

		private readonly List<DomesticAnimalGroup> animalPanelGroups = new List<DomesticAnimalGroup>();

		protected override void Start()
		{
			base.Start();
			haulAllToggle.onValueChanged.AddListener(OnHaulAllToggle);
			battleAllToggle.onValueChanged.AddListener(OnBattleAllToggle);
			trainAllToggle.onValueChanged.AddListener(OnTrainAllToggle);
			slaughterAllToggle.onValueChanged.AddListener(OnSlaughterAllToggle);
			releaseAllToggle.onValueChanged.AddListener(OnReleaseAllToggle);
			pestControlAllToggle.onValueChanged.AddListener(OnPestControlAllToggle);
		}

		private void OnPestControlAllToggle(bool isOn)
		{
			foreach (DomesticAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnPestControlChanged(isOn);
			}
		}

		private void OnReleaseAllToggle(bool isOn)
		{
			foreach (DomesticAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnReleaseChanged(isOn);
			}
		}

		private void OnSlaughterAllToggle(bool isOn)
		{
			foreach (DomesticAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnSlaughterChanged(isOn);
			}
		}

		private void OnTrainAllToggle(bool isOn)
		{
			foreach (DomesticAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnTrainChanged(isOn);
			}
		}

		private void OnBattleAllToggle(bool isOn)
		{
			foreach (DomesticAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnBattleChanged(isOn);
			}
		}

		private void OnHaulAllToggle(bool isOn)
		{
			foreach (DomesticAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnHaulChanged(isOn);
			}
		}

		public override void Show()
		{
			base.Show();
			List<AnimalInstance> list = new List<AnimalInstance>(GlobalSaveController.CurrentVillageData.Animals);
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				if (caravan.Creatures == null)
				{
					continue;
				}
				foreach (CreatureBase creature in caravan.Creatures)
				{
					if (creature is AnimalInstance item)
					{
						list.Add(item);
					}
				}
			}
			IEnumerable<AnimalInstance> enumerable = list.Where((AnimalInstance animal) => animal.AnimalType == AnimalType.Domestic || (animal.AnimalType == AnimalType.Pet && (animal.PetOwner is HumanoidInstance || animal.PetOwner == null)));
			int num = 0;
			foreach (AnimalInstance item2 in enumerable)
			{
				DomesticAnimalGroup at = animalPanelGroups.GetAt(base.ContentGroup, num);
				at.SetAnimal(item2);
				at.Show();
				num++;
			}
			animalPanelGroups.SetActiveFromIndex(num, active: false);
		}

		protected override void SortEntries()
		{
			animalPanelGroups.Sort(AnimalEntrySortComparison);
			int num = 0;
			foreach (DomesticAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.transform.SetSiblingIndex(num++);
			}
		}

		private int AnimalEntrySortComparison(DomesticAnimalGroup a, DomesticAnimalGroup b)
		{
			int num = 0;
			switch (base.CurrentSortMode)
			{
			case SortMode.Animal:
				num = 100 * SortByAnimal() + 10 * SortByName();
				break;
			case SortMode.Name:
				num = SortByName();
				break;
			case SortMode.Age:
				num = a.AnimalAge - b.AnimalAge;
				break;
			case SortMode.Assigned:
				num = 1000 * SortByType();
				num += 100 * SortByAssigned();
				num += SortByName();
				break;
			case SortMode.Haul:
				num = 1000 * ((a.Animal.Blueprint.CanHaulAsPet ? 1 : 0) - (b.Animal.Blueprint.CanHaulAsPet ? 1 : 0));
				num += 100 * ((a.Animal.PetHaulEnabled ? 1 : 0) - (b.Animal.PetHaulEnabled ? 1 : 0));
				num += 10 * SortByType();
				break;
			case SortMode.Battle:
				num = 1000 * ((a.Animal.Blueprint.CanAttackAsPet ? 1 : 0) - (b.Animal.Blueprint.CanAttackAsPet ? 1 : 0));
				num += 100 * ((a.Animal.PetBattleEnabled ? 1 : 0) - (b.Animal.PetBattleEnabled ? 1 : 0));
				num += 10 * SortByType();
				break;
			case SortMode.PestControl:
				num = 10000 * ((a.Animal.Blueprint.CanPestControlAsPet ? 1 : 0) - (b.Animal.Blueprint.CanPestControlAsPet ? 1 : 0));
				num += 1000 * ((a.Animal.PetPestControlEnabled ? 1 : 0) - (b.Animal.PetPestControlEnabled ? 1 : 0));
				num += 100 * SortByType();
				num += 10 * (((a.Animal.PestGroup != null) ? 1 : 0) - ((b.Animal.PestGroup != null) ? 1 : 0));
				break;
			case SortMode.Train:
				num = 1000 * ((a.Animal.Blueprint.CanBeTrained ? 1 : 0) - (b.Animal.Blueprint.CanBeTrained ? 1 : 0));
				num += 100 * ((a.Animal.CanTryTraining ? 1 : 0) - (b.Animal.CanTryTraining ? 1 : 0));
				num += 10 * SortByType();
				break;
			case SortMode.Slaughter:
				num = 100 * SortByOrderType(AnimalOrderType.Slaughter);
				num += 10 * SortByType();
				break;
			case SortMode.Release:
				num = 100 * SortByOrderType(AnimalOrderType.Release);
				num += 10 * SortByType();
				break;
			case SortMode.InPen:
				num = string.Compare(b.GetPenName(), a.GetPenName(), StringComparison.CurrentCultureIgnoreCase);
				num += 10 * SortByType();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (!SortDirection)
			{
				return -num;
			}
			return num;
			int SortByAnimal()
			{
				return string.Compare(GetAnimalLocalized(a.Animal), GetAnimalLocalized(b.Animal), StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByAssigned()
			{
				if (a.Animal.PetOwner == null && b.Animal.PetOwner == null)
				{
					return 0;
				}
				if (a.Animal.PetOwner != null && b.Animal.PetOwner == null)
				{
					return -1;
				}
				if (a.Animal.PetOwner == null && b.Animal.PetOwner != null)
				{
					return 1;
				}
				return string.Compare(a.Animal.PetOwner.GetFullName(), b.Animal.PetOwner.GetFullName(), StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByName()
			{
				return string.Compare(a.Animal.GetFullName(), b.Animal.GetFullName(), StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByOrderType(AnimalOrderType orderType)
			{
				return (a.Animal.OrderType.Equals(orderType) ? 1 : 0) - (b.Animal.OrderType.Equals(orderType) ? 1 : 0);
			}
			int SortByType(AnimalType type = AnimalType.Pet)
			{
				return (a.Animal.AnimalType.Equals(type) ? 1 : 0) - (b.Animal.AnimalType.Equals(type) ? 1 : 0);
			}
		}
	}
}
