using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.View.UI;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WildlifePanelView : AnimalsPanelView
	{
		[SerializeField]
		private CustomToggle huntAllToggle;

		[SerializeField]
		private CustomToggle tameAllToggle;

		private readonly List<WildlifeAnimalGroup> animalPanelGroups = new List<WildlifeAnimalGroup>();

		public override void Show()
		{
			base.Show();
			IEnumerable<AnimalInstance> enumerable = GlobalSaveController.CurrentVillageData.Animals.Where((AnimalInstance animal) => animal.AnimalType == AnimalType.Wild || animal.AnimalType == AnimalType.WildAggressive);
			int num = 0;
			foreach (AnimalInstance item in enumerable)
			{
				WildlifeAnimalGroup at = animalPanelGroups.GetAt(base.ContentGroup, num);
				at.SetAnimal(item);
				at.Show();
				num++;
			}
			animalPanelGroups.SetActiveFromIndex(num, active: false);
		}

		protected override void Start()
		{
			base.Start();
			huntAllToggle.onValueChanged.AddListener(OnHuntAllToggle);
			tameAllToggle.onValueChanged.AddListener(OnTameAllToggle);
		}

		private void OnHuntAllToggle(bool isOn)
		{
			foreach (WildlifeAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnHuntChanged(isOn);
			}
		}

		private void OnTameAllToggle(bool isOn)
		{
			foreach (WildlifeAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.OnTameChanged(isOn);
			}
		}

		protected override void SortEntries()
		{
			animalPanelGroups.Sort(AnimalEntrySortComparison);
			int num = 0;
			foreach (WildlifeAnimalGroup animalPanelGroup in animalPanelGroups)
			{
				animalPanelGroup.transform.SetSiblingIndex(num++);
			}
		}

		private int AnimalEntrySortComparison(WildlifeAnimalGroup a, WildlifeAnimalGroup b)
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
			case SortMode.Hunt:
				num = 100 * SortByOrderType(AnimalOrderType.Hunt);
				num += 10 * SortByAnimal();
				break;
			case SortMode.HuntRet:
				num += (int)(1000f * (a.Animal.GetAttributeValue(AttributeType.HuntingRetaliateChance) - b.Animal.GetAttributeValue(AttributeType.HuntingRetaliateChance)));
				break;
			case SortMode.Tame:
				num = 100 * SortByOrderType(AnimalOrderType.Tame);
				num += 10 * SortByAnimal();
				break;
			case SortMode.Tameable:
				num += (int)(1000f * (a.Animal.GetAttributeValue(AttributeType.AnimalTameChance) - b.Animal.GetAttributeValue(AttributeType.AnimalTameChance)));
				break;
			case SortMode.TameRet:
				num += (int)(1000f * (a.Animal.GetAttributeValue(AttributeType.TameRetaliateChance) - b.Animal.GetAttributeValue(AttributeType.TameRetaliateChance)));
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
			int SortByName()
			{
				return string.Compare(a.Animal.GetFullName(), b.Animal.GetFullName(), StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByOrderType(AnimalOrderType orderType)
			{
				return (a.Animal.OrderType.Equals(orderType) ? 1 : 0) - (b.Animal.OrderType.Equals(orderType) ? 1 : 0);
			}
		}
	}
}
