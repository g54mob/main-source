using System;
using UnityEngine;

namespace TH20
{
	public class StaffHappinessDataView : IDataViewMode
	{
		private readonly VisualManager _visualManager;

		private readonly Level _level;

		private readonly DataViewManager.Config _config;

		public StaffHappinessDataView(DataViewManager.Config config, VisualManager visualManager, Level level)
		{
			_visualManager = visualManager;
			_level = level;
			_config = config;
		}

		public void Enable(DataViewManager.Mode mode)
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			_visualManager.RoomLightingManager.EnableDesaturatedHospital();
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				staffMember.Visual.ValueModeEnabled = true;
			}
			foreach (Patient patient in _level.CharacterManager.Patients)
			{
				patient.Visual.ValueModeEnabled = true;
				patient.Visual.SetValueMaterial(Color.white);
			}
		}

		public void Disable()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				staffMember.Visual.ValueModeEnabled = false;
			}
			foreach (Patient patient in _level.CharacterManager.Patients)
			{
				patient.Visual.ValueModeEnabled = false;
			}
		}

		public void OnStaffSpawned(Staff staff)
		{
			staff.Visual.ValueModeEnabled = true;
		}

		public void OnPatientSpawned(Patient patient)
		{
			patient.Visual.ValueModeEnabled = true;
			patient.Visual.SetValueMaterial(Color.white);
		}

		public void Update()
		{
			if (!_config.CharAttributeVisualisations.TryGetValue(CharacterAttributes.Type.Happiness, out var value))
			{
				return;
			}
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				AttributeFloat attribute = staffMember.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Happiness);
				if (attribute != null)
				{
					Color valueMaterial = value.Gradient.Evaluate(attribute.Value() / 100f);
					staffMember.Visual.SetValueMaterial(valueMaterial);
				}
				else
				{
					staffMember.Visual.SetValueMaterial(Color.white);
				}
			}
		}
	}
}
