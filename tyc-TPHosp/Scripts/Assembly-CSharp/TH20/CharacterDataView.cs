using System;
using UnityEngine;

namespace TH20
{
	public class CharacterDataView : IDataViewMode
	{
		private CharacterAttributes.Type _currentCharAttribute;

		private readonly VisualManager _visualManager;

		private readonly Level _level;

		private readonly DataViewManager.Config _config;

		public CharacterDataView(DataViewManager.Config config, VisualManager visualManager, Level level)
		{
			_visualManager = visualManager;
			_level = level;
			_config = config;
		}

		public void Enable(DataViewManager.Mode mode)
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffSpawned = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			_currentCharAttribute = DataViewManager.ModeToCharAttribute(mode);
			_visualManager.RoomLightingManager.EnableDesaturatedHospital();
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				allCharacter.Visual.ValueModeEnabled = true;
			}
		}

		private void OnPatientSpawned(Patient patient)
		{
			patient.Visual.ValueModeEnabled = true;
		}

		private void OnStaffSpawned(Staff staff)
		{
			staff.Visual.ValueModeEnabled = true;
		}

		public void Update()
		{
			if (!_config.CharAttributeVisualisations.TryGetValue(_currentCharAttribute, out var value))
			{
				return;
			}
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				SetCharacterValueColor(allCharacter, _currentCharAttribute, value);
			}
		}

		public void Disable()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				allCharacter.Visual.ValueModeEnabled = false;
			}
		}

		public static void SetCharacterValueColor(Character character, CharacterAttributes.Type attributeType, DataViewManager.Config.CharAttributeVisualisation charAttributeVisualisation)
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
	}
}
