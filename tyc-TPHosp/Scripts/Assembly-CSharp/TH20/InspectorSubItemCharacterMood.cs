using System.Collections.Generic;
using System.Text;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class InspectorSubItemCharacterMood : InspectorSubItem
	{
		[SerializeField]
		private ProgressBarMaskable _happinessBar;

		[SerializeField]
		private TooltipSpawner _happinessTooltip;

		[SerializeField]
		private ProgressBarMaskable _energyBar;

		[SerializeField]
		private ProgressBarMaskable _healthBar;

		[SerializeField]
		private TooltipSpawner _energyHealthTooltip;

		[SerializeField]
		private ProgressBarMaskable _thirstBar;

		[SerializeField]
		private TooltipSpawner _thirstTooltip;

		[SerializeField]
		private ProgressBarMaskable _hungerBar;

		[SerializeField]
		private TooltipSpawner _hungerTooltip;

		[SerializeField]
		private ProgressBarMaskable _toiletBar;

		[SerializeField]
		private TooltipSpawner _toiletTooltip;

		[SerializeField]
		private GameObject _boredomGameObject;

		[SerializeField]
		private ProgressBarMaskable _boredomBar;

		[SerializeField]
		private TooltipSpawner _boredomTooltip;

		[SerializeField]
		private ProgressBarMaskable _hygieneBar;

		[SerializeField]
		private TooltipSpawner _hygieneTooltip;

		[SerializeField]
		private ProgressBarMaskable _attractivenessBar;

		[SerializeField]
		private TooltipSpawner _attractivenessTooltip;

		[SerializeField]
		private ProgressBarMaskable _temperatureBar;

		[SerializeField]
		private TooltipSpawner _temperatureTooltip;

		[SerializeField]
		private TooltipSpawner _topModifiersTooltip;

		[SerializeField]
		private GameObject _topComplaintsPanel;

		[SerializeField]
		private TMP_Text _topComplaints;

		[SerializeField]
		private TMP_Text _topPositives;

		private Character _character;

		private Staff _staff;

		private Patient _patient;

		protected void Start()
		{
			_happinessTooltip.SetDataProvider(SetHappinessTooltip);
			_energyHealthTooltip.SetDataProvider(SetEnergyHealthTooltip);
			_thirstTooltip.SetDataProvider(SetThirstTooltip);
			_hungerTooltip.SetDataProvider(SetHungerTooltip);
			_toiletTooltip.SetDataProvider(SetToiletTooltip);
			_boredomTooltip.SetDataProvider(SetBoredomTooltip);
			_hygieneTooltip.SetDataProvider(SetHygieneTooltip);
			_attractivenessTooltip.SetDataProvider(SetAttractivenessTooltip);
			_temperatureTooltip.SetDataProvider(SetTemperatureTooltip);
			_topModifiersTooltip.SetDataProvider(TopModifiersTooltip);
		}

		public void Setup(Character character)
		{
			_character = character;
			_staff = character as Staff;
			_patient = character as Patient;
		}

		private void Update()
		{
			if (_patient != null || _staff != null)
			{
				CharacterAttributes characterAttributes = _character.GetCharacterAttributes();
				if (_staff != null)
				{
					bool flag = _staff.GetComponent<RoboJanitorComponent>() != null;
					GameObjectUtils.SetActive(_healthBar.gameObject, isActive: false);
					GameObjectUtils.SetActive(_boredomGameObject, isActive: false);
					GameObjectUtils.SetActive(_energyBar.gameObject, isActive: true);
					GameObjectUtils.SetActive(_hygieneBar.gameObject, !flag);
					GameObjectUtils.SetActive(_attractivenessBar.gameObject, !flag);
					GameObjectUtils.SetActive(_topComplaintsPanel, !flag);
					_energyBar.Progress = _staff.Energy.Value() / 100f;
				}
				if (_patient != null)
				{
					GameObjectUtils.SetActive(_energyBar.gameObject, isActive: false);
					GameObjectUtils.SetActive(_healthBar.gameObject, isActive: true);
					GameObjectUtils.SetActive(_boredomGameObject, isActive: true);
					_healthBar.Progress = _patient.Health.Value() / 100f;
					_boredomBar.Progress = 1f - characterAttributes.GetAttribute(CharacterAttributes.Type.Boredom).Value() / 100f;
				}
				if (_happinessBar != null)
				{
					_happinessBar.Progress = ((_character.Happiness != null) ? (_character.Happiness.Value() / 100f) : 0f);
				}
				UpdateAttributeProgressBar(characterAttributes, CharacterAttributes.Type.Hunger, _hungerBar);
				UpdateAttributeProgressBar(characterAttributes, CharacterAttributes.Type.Thirst, _thirstBar);
				UpdateAttributeProgressBar(characterAttributes, CharacterAttributes.Type.Toilet, _toiletBar);
				_temperatureBar.Progress = Mathf.Clamp01(MathUtils.ProportionThroughRange(_character.TemperatureValue, -1f, 1f));
				_attractivenessBar.Progress = Mathf.Clamp01(MathUtils.ProportionThroughRange(_character.AttractivenessValue, -1f, 1f));
				AttributeFloat attribute = characterAttributes.GetAttribute(CharacterAttributes.Type.Hygiene);
				if (attribute != null)
				{
					_hygieneBar.Progress = Mathf.Clamp01(attribute.Value() / 100f);
				}
				CharacterHappinessComponent component = _character.GetComponent<CharacterHappinessComponent>();
				if (component != null)
				{
					List<string> topComplaints = component.GetTopComplaints(3, showHidden: false);
					List<string> topPositives = component.GetTopPositives(3, showHidden: false);
					_topComplaints.text = GameStringUtils.MakeStringFromList(topComplaints);
					_topPositives.text = GameStringUtils.MakeStringFromList(topPositives);
				}
			}
		}

		private static void UpdateAttributeProgressBar(CharacterAttributes attributes, CharacterAttributes.Type type, ProgressBarMaskable bar)
		{
			AttributeFloat attribute = attributes.GetAttribute(type);
			if (attribute != null)
			{
				bar.Progress = 1f - attribute.Value() / 100f;
			}
			GameObjectUtils.SetActive(bar.gameObject, attribute != null);
		}

		private void SetHappinessTooltip(Tooltip tooltip)
		{
			if (_character != null && _character.Happiness != null)
			{
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Happiness_CS, StringUtils.FormatPercentageValue(_character.Happiness.Value() / 100f));
			}
		}

		private void SetEnergyHealthTooltip(Tooltip tooltip)
		{
			if (_staff != null)
			{
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Energy_CS, StringUtils.FormatPercentageValue(_staff.Energy.Value() / 100f));
			}
			else if (_patient != null)
			{
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Health_CS, StringUtils.FormatPercentageValue(_patient.Health.Value() / 100f));
			}
		}

		private void SetAttributeTooltip(Tooltip tooltip, string stringFormat, CharacterAttributes.Type type)
		{
			if (_character == null)
			{
				return;
			}
			CharacterAttributes characterAttributes = _character.GetCharacterAttributes();
			if (characterAttributes != null)
			{
				AttributeFloat attribute = characterAttributes.GetAttribute(type);
				if (attribute != null)
				{
					tooltip.Text = string.Format(stringFormat, StringUtils.FormatPercentageValue(attribute.Value() / 100f));
				}
			}
		}

		private void SetThirstTooltip(Tooltip tooltip)
		{
			SetAttributeTooltip(tooltip, ScriptLocalization.Inspector.Stat_Thirst_CS, CharacterAttributes.Type.Thirst);
		}

		private void SetHungerTooltip(Tooltip tooltip)
		{
			SetAttributeTooltip(tooltip, ScriptLocalization.Inspector.Stat_Hunger_CS, CharacterAttributes.Type.Hunger);
		}

		private void SetToiletTooltip(Tooltip tooltip)
		{
			SetAttributeTooltip(tooltip, ScriptLocalization.Inspector.Stat_Toilet_CS, CharacterAttributes.Type.Toilet);
		}

		private void SetBoredomTooltip(Tooltip tooltip)
		{
			SetAttributeTooltip(tooltip, ScriptLocalization.Inspector.Stat_Boredom_CS, CharacterAttributes.Type.Boredom);
		}

		private void SetHygieneTooltip(Tooltip tooltip)
		{
			SetAttributeTooltip(tooltip, ScriptLocalization.Inspector.Stat_Hygiene_CS, CharacterAttributes.Type.Hygiene);
		}

		private void SetAttractivenessTooltip(Tooltip tooltip)
		{
			if (_character != null)
			{
				float value = MathUtils.ProportionThroughRange(_character.AttractivenessValue, -1f, 1f);
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Attractiveness_CS, StringUtils.FormatPercentageValue(value));
			}
		}

		private void SetTemperatureTooltip(Tooltip tooltip)
		{
			if (_character != null)
			{
				tooltip.Text = GameStringUtils.GetTemperatureDescription(_character.TemperatureValue);
			}
		}

		private void TopModifiersTooltip(Tooltip tooltip)
		{
			if (_character == null)
			{
				return;
			}
			CharacterHappinessComponent component = _character.GetComponent<CharacterHappinessComponent>();
			if (component == null)
			{
				return;
			}
			List<CharacterHappinessComponent.StatModifier> topPositivesStatModifiers = component.GetTopPositivesStatModifiers(6);
			topPositivesStatModifiers.AddRange(component.GetTopComplaintsStatModifiers(6));
			if (topPositivesStatModifiers.Count <= 0)
			{
				return;
			}
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder(topPositivesStatModifiers.Count * 50);
			for (int i = 0; i < topPositivesStatModifiers.Count; i++)
			{
				float num = topPositivesStatModifiers[i].Value;
				if (_character is Patient)
				{
					num *= _character.GetAttributeMultiplier(CharacterAttributes.Type.Happiness) * GameAlgorithms.Config.SecondsPerDay * 30f;
				}
				if (Mathf.Abs(num) >= 0.01f)
				{
					builder.AppendFormat("<color={0}>{1}</color>{4}{2} {3}", (topPositivesStatModifiers[i].Value > 0f) ? "#8080ff" : "#ff2020", component.GetTranslatedStatName(topPositivesStatModifiers[i].Term), StringUtils.FormatPercentageValue(num / 100f, prefixPlus: true), (_character is Patient) ? ScriptLocalization.Inspector.HappinessPerMonth_CS : ScriptLocalization.Inspector.Happiness_CS, ScriptLocalization.Misc.ColonSeparator_CS);
					if (i < topPositivesStatModifiers.Count - 1)
					{
						builder.AppendLine();
					}
				}
			}
			tooltip.Text = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
		}
	}
}
