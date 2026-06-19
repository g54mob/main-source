using System;
using UnityEngine;

namespace TH20
{
	public class PatientHappinessDataView : IDataViewMode
	{
		private readonly VisualManager _visualManager;

		private readonly Level _level;

		private readonly DataViewManager.Config _config;

		public PatientHappinessDataView(DataViewManager.Config config, VisualManager visualManager, Level level)
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
			_visualManager.RoomLightingManager.EnableDesaturatedHospital();
			foreach (Patient patient in _level.CharacterManager.Patients)
			{
				patient.Visual.ValueModeEnabled = true;
			}
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				staffMember.Visual.ValueModeEnabled = true;
				staffMember.Visual.SetValueMaterial(Color.white);
			}
		}

		public void Disable()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			foreach (Patient patient in _level.CharacterManager.Patients)
			{
				patient.Visual.ValueModeEnabled = false;
			}
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				staffMember.Visual.ValueModeEnabled = false;
			}
		}

		public void OnPatientSpawned(Patient patient)
		{
			patient.Visual.ValueModeEnabled = true;
		}

		public void OnStaffSpawned(Staff staff)
		{
			staff.Visual.ValueModeEnabled = true;
			staff.Visual.SetValueMaterial(Color.white);
		}

		public void Update()
		{
			if (!_config.CharAttributeVisualisations.TryGetValue(CharacterAttributes.Type.Happiness, out var value))
			{
				return;
			}
			foreach (Patient patient in _level.CharacterManager.Patients)
			{
				AttributeFloat attribute = patient.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Happiness);
				if (attribute != null)
				{
					float time = attribute.Value() / 100f;
					Color valueMaterial = value.Gradient.Evaluate(time);
					patient.Visual.SetValueMaterial(valueMaterial);
				}
				else
				{
					patient.Visual.SetValueMaterial(Color.white);
				}
			}
		}
	}
}
