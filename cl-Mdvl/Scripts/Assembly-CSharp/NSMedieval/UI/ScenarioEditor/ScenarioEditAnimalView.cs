using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditAnimalView : ScenarioEditIntIconView
	{
		[SerializeField]
		private DropdownLayoutItemView genderDropdown;

		[SerializeField]
		private DropdownLayoutItemView lifePhaseDropdown;

		[SerializeField]
		private DropdownLayoutItemView animalTypeDropdown;

		private Animal animal;

		private BodyType gender = BodyType.Female;

		private int lifePhase;

		private List<AnimalType> allowedTypes;

		private AnimalType animalType;

		private List<AnimalType> AllowedTypes => allowedTypes ?? (allowedTypes = ((AnimalType[])Enum.GetValues(typeof(AnimalType))).ToList().FindAll((AnimalType type) => type != AnimalType.DomesticNpc));

		public new event Action<ScenarioAnimalData, ScenarioEditEntryView> ValueChanged;

		public void SetData(ScenarioAnimalData data)
		{
			gender = data.BodyType;
			animalType = data.AnimalType;
			lifePhase = data.LifePhaseIndex;
			SetDefaults(data.ID, new IntRange(1, 10), data.Count);
		}

		public void SetDefaults(string animalId, IntRange minMaxRange, int currentValue)
		{
			if (minMaxRange.Min == minMaxRange.Max)
			{
				base.IntInput.gameObject.SetActive(value: false);
			}
			animal = Repository<AnimalBaseRepository, Animal>.Instance.GetByID(animalId);
			if (animal == null)
			{
				Debug.LogWarning("ScenarioEditAnimalView: Animal with ID '" + animalId + "' not found. Skipping (modded or stale data).");
				return;
			}
			SetDefaults(AnimalUtils.GetLocalizedName(animalId), minMaxRange, currentValue, "");
			IEnumerable<string> optionValues = from type in EnumValues.BodyTypes
				where type != BodyType.None
				select base.Localize.GetText("general_" + type.ToString().ToLower() + "_animal");
			genderDropdown.SetData(optionValues, OnGenderValueChange);
			genderDropdown.SetValueWithoutNotify((int)(gender - 1));
			List<string> optionValues2 = AllowedTypes.Select((AnimalType type) => base.Localize.GetText($"animal_type_{type}")).ToList();
			animalTypeDropdown.SetData(optionValues2, OnTypeChange);
			animalTypeDropdown.SetValueWithoutNotify(AllowedTypes.IndexOf(animalType));
			List<string> optionValues3 = animal.LifePhases.Select((AnimalLifePhase phase) => base.Localize.GetText(LocKeyUtils.GetName(phase.LocKeys))).ToList();
			lifePhaseDropdown.SetData(optionValues3, OnLifePhaseChange);
			lifePhaseDropdown.SetValueWithoutNotify(lifePhase);
			OnInputValueChanged(base.IntInput.text);
		}

		protected override void OnInputValueChanged(string value)
		{
			if (!(animal == null))
			{
				int count = ScenarioEditEntryView.Clamp(value, base.MinMaxRange);
				base.IntInput.SetTextWithoutNotify(count.ToString());
				ScenarioAnimalData arg = new ScenarioAnimalData
				{
					ID = animal.GetID(),
					Count = count,
					BodyType = gender,
					LifePhaseIndex = lifePhase,
					AnimalType = animalType
				};
				this.ValueChanged?.Invoke(arg, this);
			}
		}

		private void Init()
		{
		}

		private void OnGenderValueChange(int index)
		{
			gender = (BodyType)(index + 1);
			OnInputValueChanged(base.IntInput.text);
		}

		private void OnTypeChange(int index)
		{
			animalType = AllowedTypes[index];
			OnInputValueChanged(base.IntInput.text);
		}

		private void OnLifePhaseChange(int index)
		{
			lifePhase = index;
			OnInputValueChanged(base.IntInput.text);
		}
	}
}
