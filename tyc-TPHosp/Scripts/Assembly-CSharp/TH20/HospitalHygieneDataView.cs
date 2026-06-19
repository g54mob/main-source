using System;
using UnityEngine;

namespace TH20
{
	public class HospitalHygieneDataView : HospitalDataView
	{
		private CharacterAttributes.Type _currentCharAttribute;

		private readonly Level _level;

		public HospitalHygieneDataView(DataViewManager.Config config, Level level, HospitalMapAttributesVisualisation mapAttributesVisualisation, WorldState worldState, BuildEvents buildEvents)
			: base(config, mapAttributesVisualisation, worldState, buildEvents)
		{
			_level = level;
		}

		public override void Enable(DataViewManager.Mode mode)
		{
			base.Enable(mode);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffSpawned = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			_currentCharAttribute = DataViewManager.ModeToCharAttribute(mode);
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				allCharacter.Visual.ValueModeEnabled = true;
			}
		}

		public override void Update()
		{
			base.Update();
			if (!_config.CharAttributeVisualisations.TryGetValue(_currentCharAttribute, out var value))
			{
				return;
			}
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				SetCharacterValueColor(allCharacter, _currentCharAttribute, value);
			}
		}

		public override void Disable()
		{
			base.Disable();
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				allCharacter.Visual.ValueModeEnabled = false;
			}
		}

		private static void SetCharacterValueColor(Character character, CharacterAttributes.Type attributeType, DataViewManager.Config.CharAttributeVisualisation charAttributeVisualisation)
		{
			AttributeFloat attribute = character.GetCharacterAttributes().GetAttribute(attributeType);
			if (attribute != null)
			{
				float time = attribute.Value() / charAttributeVisualisation.MaxValue;
				Color valueMaterial = charAttributeVisualisation.Gradient.Evaluate(time);
				character.Visual.SetValueMaterial(valueMaterial);
			}
			else
			{
				character.Visual.SetValueMaterial(Color.white);
			}
		}

		private static void OnPatientSpawned(Patient patient)
		{
			patient.Visual.ValueModeEnabled = true;
		}

		private static void OnStaffSpawned(Staff staff)
		{
			staff.Visual.ValueModeEnabled = true;
		}

		protected override Color PositiveColor()
		{
			return _config.HygienicItemColor;
		}

		protected override Color NegativeColor()
		{
			return _config.UnhygienicItemColor;
		}

		protected override HospitalAttributeMap.Attribute AttributeToShow()
		{
			return HospitalAttributeMap.Attribute.Hygiene;
		}
	}
}
