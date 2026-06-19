using System;
using UnityEngine;

namespace TH20
{
	public class StaffTypeDataView : IDataViewMode
	{
		private readonly VisualManager _visualManager;

		private readonly Level _level;

		private readonly DataViewManager.Config _config;

		private Gradient _doctorGradient;

		private Gradient _nurseGradient;

		private Gradient _assistantGradient;

		private Gradient _janitorGradient;

		public StaffTypeDataView(DataViewManager.Config config, VisualManager visualManager, Level level)
		{
			_visualManager = visualManager;
			_level = level;
			_config = config;
		}

		public void Enable(DataViewManager.Mode mode)
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			_visualManager.RoomLightingManager.EnableDesaturatedHospital();
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				staffMember.Visual.ValueModeEnabled = true;
			}
			_doctorGradient = _config.DoctorTypeGradient;
			_nurseGradient = _config.NurseTypeGradient;
			_assistantGradient = _config.AssistantTypeGradient;
			_janitorGradient = _config.JanitorTypeGradient;
		}

		public void Disable()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffSpawned, new Action<Staff>(OnStaffSpawned));
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				staffMember.Visual.ValueModeEnabled = false;
			}
		}

		public void Update()
		{
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				float time = (float)staffMember.Rank / 4f;
				switch (staffMember.Definition._type)
				{
				case StaffDefinition.Type.Doctor:
					staffMember.Visual.SetValueMaterial(_doctorGradient.Evaluate(time));
					break;
				case StaffDefinition.Type.Nurse:
					staffMember.Visual.SetValueMaterial(_nurseGradient.Evaluate(time));
					break;
				case StaffDefinition.Type.Assistant:
					staffMember.Visual.SetValueMaterial(_assistantGradient.Evaluate(time));
					break;
				case StaffDefinition.Type.Janitor:
					staffMember.Visual.SetValueMaterial(_janitorGradient.Evaluate(time));
					break;
				}
			}
		}

		public void OnStaffSpawned(Staff staff)
		{
			staff.Visual.ValueModeEnabled = true;
		}
	}
}
