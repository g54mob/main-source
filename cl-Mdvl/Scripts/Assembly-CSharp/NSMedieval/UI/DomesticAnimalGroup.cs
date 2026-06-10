using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UI.Enums;
using UnityEngine;

namespace NSMedieval.UI
{
	public class DomesticAnimalGroup : AnimalPanelGroup
	{
		[SerializeField]
		private TMP_Dropdown assignDropdown;

		[SerializeField]
		private CustomToggle haulToggle;

		[SerializeField]
		private CustomToggle pestControlToggle;

		[SerializeField]
		private CustomToggle battleToggle;

		[SerializeField]
		private CustomToggle trainToggle;

		[SerializeField]
		private CustomToggle slaughterToggle;

		[SerializeField]
		private CustomToggle releaseToggle;

		[SerializeField]
		private TMP_Text penLabel;

		[NonSerialized]
		private List<HumanoidInstance> workers = new List<HumanoidInstance>();

		protected override void Start()
		{
			base.Start();
			assignDropdown.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet);
			assignDropdown.onValueChanged.AddListener(OnAssignChanged);
			haulToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanHaulAsPet);
			haulToggle.onValueChanged.AddListener(OnHaulChanged);
			pestControlToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.PestGroup != null && base.Animal.Blueprint.CanPestControlAsPet);
			pestControlToggle.onValueChanged.AddListener(OnPestControlChanged);
			battleToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanAttackAsPet);
			battleToggle.onValueChanged.AddListener(OnBattleChanged);
			trainToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Domestic);
			trainToggle.onValueChanged.AddListener(OnTrainChanged);
			slaughterToggle.gameObject.SetActive(value: true);
			slaughterToggle.onValueChanged.AddListener(OnSlaughterChanged);
			releaseToggle.gameObject.SetActive(value: true);
			releaseToggle.onValueChanged.AddListener(OnReleaseChanged);
		}

		protected override void OnPetOwnerChanged(AnimalInstance pet, CreatureBase owner)
		{
			AddAssignPetOwnerOptions();
		}

		protected override void OnOrderGivenFromAnimalUI(AnimalInstance animalInstance)
		{
			if (base.Animal == animalInstance)
			{
				switch (animalInstance.OrderType)
				{
				case AnimalOrderType.None:
					trainToggle.SetIsOnWithoutNotify(value: false);
					slaughterToggle.SetIsOnWithoutNotify(value: false);
					releaseToggle.SetIsOnWithoutNotify(value: false);
					break;
				case AnimalOrderType.Slaughter:
					trainToggle.SetIsOnWithoutNotify(value: false);
					releaseToggle.SetIsOnWithoutNotify(value: false);
					slaughterToggle.SetIsOnWithoutNotify(value: true);
					break;
				case AnimalOrderType.Release:
					trainToggle.SetIsOnWithoutNotify(value: false);
					slaughterToggle.SetIsOnWithoutNotify(value: false);
					releaseToggle.SetIsOnWithoutNotify(value: true);
					break;
				case AnimalOrderType.Train:
					slaughterToggle.SetIsOnWithoutNotify(value: false);
					releaseToggle.SetIsOnWithoutNotify(value: false);
					trainToggle.SetIsOnWithoutNotify(value: true);
					break;
				case AnimalOrderType.Hunt:
				case AnimalOrderType.Tame:
				case AnimalOrderType.Harvest:
					break;
				}
			}
		}

		protected override void UpdateData()
		{
			base.UpdateData();
			RefreshViews();
			AddAssignPetOwnerOptions();
			haulToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanHaulAsPet);
			pestControlToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanPestControlAsPet);
			battleToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanAttackAsPet);
			trainToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Domestic);
			trainToggle.SetIsOnWithoutNotify(base.Animal.OrderType.Equals(AnimalOrderType.Train));
			slaughterToggle.SetIsOnWithoutNotify(base.Animal.OrderType.Equals(AnimalOrderType.Slaughter));
			releaseToggle.SetIsOnWithoutNotify(base.Animal.OrderType.Equals(AnimalOrderType.Release));
			battleToggle.SetIsOnWithoutNotify(base.Animal.PetBattleEnabled);
			haulToggle.SetIsOnWithoutNotify(base.Animal.PetHaulEnabled);
			pestControlToggle.SetIsOnWithoutNotify(base.Animal.PetPestControlEnabled);
			UpdateEnabledButtons();
			if (!MonoSingleton<PenViewManager>.IsInstantiated() || MonoSingleton<PenViewManager>.Instance.PenInstances.Count == 0)
			{
				penLabel.SetText(string.Empty);
			}
			else
			{
				penLabel.SetText(GetPenName());
			}
		}

		public string GetPenName()
		{
			string result = string.Empty;
			for (int i = 0; i < MonoSingleton<PenViewManager>.Instance.PenInstances.Count; i++)
			{
				if (MonoSingleton<PenViewManager>.Instance.PenInstances[i].IsInPen(base.Animal, out var penInstance))
				{
					string text = penInstance.GetPenName().Replace(" Pen ", string.Empty);
					result = string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_pen", i, LinkType.LinkPen, text);
				}
			}
			return result;
		}

		private void OnAssignChanged(int value)
		{
			if (value == 0)
			{
				base.Animal.AssignPetOwner(null);
				return;
			}
			HumanoidInstance humanoidInstance = workers[value - 1];
			foreach (AnimalInstance item in humanoidInstance.Pets.ToList())
			{
				item.AssignPetOwner(null);
			}
			base.Animal.AssignPetOwner(humanoidInstance);
			RefreshViews();
		}

		private void RefreshViews()
		{
			assignDropdown.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Domestic || base.Animal.AnimalType == AnimalType.Pet);
			haulToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanHaulAsPet);
			pestControlToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanPestControlAsPet);
			battleToggle.gameObject.SetActive(base.Animal.AnimalType == AnimalType.Pet && base.Animal.Blueprint.CanAttackAsPet);
		}

		public void OnReleaseChanged(bool isOn)
		{
			AnimalOrderType orderType = (isOn ? AnimalOrderType.Release : AnimalOrderType.None);
			MonoSingleton<AnimalController>.Instance.MarkForOrder(orderType, base.Animal);
			trainToggle.SetIsOnWithoutNotify(value: false);
			slaughterToggle.SetIsOnWithoutNotify(value: false);
			if (base.Animal.OrderType == AnimalOrderType.None && base.Animal.HasHarvestableProduction())
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, base.Animal);
			}
			UpdateData();
		}

		public void OnSlaughterChanged(bool isOn)
		{
			AnimalOrderType orderType = (isOn ? AnimalOrderType.Slaughter : AnimalOrderType.None);
			MonoSingleton<AnimalController>.Instance.MarkForOrder(orderType, base.Animal);
			releaseToggle.SetIsOnWithoutNotify(value: false);
			trainToggle.SetIsOnWithoutNotify(value: false);
			if (base.Animal.OrderType == AnimalOrderType.None && base.Animal.HasHarvestableProduction())
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, base.Animal);
			}
			UpdateData();
		}

		public void OnTrainChanged(bool isOn)
		{
			if (!(base.Animal.AnimalType == AnimalType.Pet && isOn))
			{
				AnimalOrderType orderType = (isOn ? AnimalOrderType.Train : AnimalOrderType.None);
				MonoSingleton<AnimalController>.Instance.MarkForOrder(orderType, base.Animal);
				releaseToggle.SetIsOnWithoutNotify(value: false);
				slaughterToggle.SetIsOnWithoutNotify(value: false);
				if (base.Animal.OrderType == AnimalOrderType.None && base.Animal.HasHarvestableProduction())
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, base.Animal);
				}
				UpdateData();
			}
		}

		public void OnBattleChanged(bool battleEnabled)
		{
			base.Animal.PetBattleEnabled = battleEnabled;
			UpdateData();
		}

		public void OnHaulChanged(bool haulEnabled)
		{
			base.Animal.PetHaulEnabled = haulEnabled;
			UpdateData();
		}

		public void OnPestControlChanged(bool pestControlEnabled)
		{
			base.Animal.PetPestControlEnabled = pestControlEnabled;
			if (base.Animal.GetGoapAgent()?.GetCurrentGoal()?.Id == "AttackGoal")
			{
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.Animal, null);
			}
			UpdateData();
		}

		private void UpdateEnabledButtons()
		{
			bool flag = !base.Animal.IsInIncognitoMode() && base.Animal.GetGoapAgent() != null && !base.Animal.IsFormingCaravan();
			trainToggle.interactable = flag;
			slaughterToggle.interactable = flag;
			releaseToggle.interactable = flag;
			battleToggle.interactable = flag;
			haulToggle.interactable = flag;
			pestControlToggle.interactable = flag;
			assignDropdown.interactable = flag;
			TooltipViewNew component = base.gameObject.GetComponent<TooltipViewNew>();
			if (component != null)
			{
				if (!flag)
				{
					component.SetSingleLineTooltip(MonoSingleton<LocalizationController>.Instance.GetText("caravan_status_travelling"));
				}
				component.SetEnabled(!flag);
			}
		}

		private void AddAssignPetOwnerOptions()
		{
			bool flag = base.Animal.AnimalType == AnimalType.Pet;
			assignDropdown.gameObject.SetActive(flag);
			if (!flag)
			{
				return;
			}
			assignDropdown.ClearOptions();
			List<string> list = new List<string> { MonoSingleton<LocalizationController>.Instance.GetText("general_none") };
			workers.Clear();
			workers.AddRange(GlobalSaveController.CurrentVillageData.Workers);
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				if (caravan != null && caravan.Workers.Any())
				{
					workers.AddRange(caravan.Workers);
				}
			}
			workers.Sort((HumanoidInstance a, HumanoidInstance b) => string.CompareOrdinal(a.Info.GetFullName(), b.Info.GetFullName()));
			foreach (HumanoidInstance worker in workers)
			{
				if (MonoSingleton<CaravanManager>.Instance.IsWorkerInCaravan(worker))
				{
					string item = ColorUtils.ColorText(worker.Info.GetFullName() + " (" + MonoSingleton<LocalizationController>.Instance.GetText("caravan_status_travelling") + ")", ColorUtils.GetColor("pet_owner_in_caravan"));
					list.Add(item);
				}
				else
				{
					list.Add(worker.Info.GetFullName());
				}
			}
			assignDropdown.AddOptions(list);
			if (base.Animal.PetOwner != null)
			{
				assignDropdown.SetValueWithoutNotify(workers.IndexOf((HumanoidInstance)base.Animal.PetOwner) + 1);
			}
		}
	}
}
