using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class RescueLandmarkVariable : QuestLandmarkVariableBase
	{
		public enum Mode
		{
			AgentProfile = 0,
			QuestGiver = 1,
			QuestVariable = 2,
			Any = 3
		}

		[SerializeField]
		private Mode _mode;

		[SerializeField]
		[ConditionalEnumHide("_mode", 0, true)]
		private AgentProfile _actorProfile;

		[SerializeField]
		[ConditionalEnumHide("_mode", 2, true)]
		[QuestVariable(QuestVariableType.Actor)]
		private QuestVariableReference _questVariable;

		[Header("Spawning")]
		[SerializeReference]
		[SubclassSelector]
		private ILandmarkPickerSettings _spawnSettings = new LandmarkPicker.Settings();

		public RescueLandmarkVariable()
		{
		}

		public RescueLandmarkVariable(RescueLandmarkVariable other)
			: base(other)
		{
			_mode = other._mode;
			_actorProfile = other._actorProfile;
			_questVariable = other._questVariable;
			_spawnSettings = other._spawnSettings;
		}

		public override void SetOwningQuest(Quest owningQuest)
		{
			base.SetOwningQuest(owningQuest);
			_spawnSettings.SetOwningQuest(owningQuest);
		}

		protected override LandmarkSpawner GetLandmarkSpawner()
		{
			LandmarkSpawner landmarkSpawner = null;
			AgentDescriptor actorDescriptor;
			if (TryGetActorProfile(out var actorProfile))
			{
				actorProfile.Spawn(_spawnSettings, out landmarkSpawner);
			}
			else if (TryGetActorDescriptor(out actorDescriptor))
			{
				_spawnSettings.SpawnDrifter(out landmarkSpawner, actorDescriptor);
			}
			if (landmarkSpawner == null)
			{
				Debug.LogException(new Exception("RescueLandmarkVariable was unable to spawn rescue landmark."));
			}
			return landmarkSpawner;
		}

		protected override T Get<T>()
		{
			if (TryGetActorProfile(out var actorProfile) && actorProfile is T)
			{
				return (T)(object)((actorProfile is T) ? actorProfile : null);
			}
			if (TryGetActorDescriptor(out var actorDescriptor) && actorDescriptor is T)
			{
				return (T)(object)((actorDescriptor is T) ? actorDescriptor : null);
			}
			return base.Get<T>();
		}

		public bool TryGetActorProfile(out AgentProfile actorProfile)
		{
			actorProfile = null;
			switch (_mode)
			{
			case Mode.AgentProfile:
				actorProfile = _actorProfile;
				break;
			case Mode.QuestGiver:
				if (base.OwningQuest != null && base.OwningQuest.QuestGiver != null)
				{
					actorProfile = base.OwningQuest.QuestGiver.AgentProfile;
				}
				break;
			case Mode.QuestVariable:
				actorProfile = _questVariable.GetValue<AgentProfile>(base.OwningQuest);
				break;
			case Mode.Any:
				Debug.LogException(new NotImplementedException());
				break;
			}
			return actorProfile != null;
		}

		private bool TryGetActorDescriptor(out AgentDescriptor actorDescriptor)
		{
			actorDescriptor = null;
			switch (_mode)
			{
			case Mode.AgentProfile:
				if ((bool)_actorProfile)
				{
					actorDescriptor = _actorProfile.GetDescriptor();
				}
				break;
			case Mode.QuestGiver:
				if (base.OwningQuest != null)
				{
					actorDescriptor = base.OwningQuest.QuestGiver;
				}
				break;
			case Mode.QuestVariable:
				actorDescriptor = _questVariable.GetValue<AgentDescriptor>(base.OwningQuest);
				break;
			case Mode.Any:
				Debug.LogException(new NotImplementedException());
				break;
			}
			return actorDescriptor != null;
		}

		public override bool ConditionsAreMet(QuestProperties questProperties)
		{
			return _spawnSettings.CanSpawn();
		}

		public override object Clone()
		{
			return new RescueLandmarkVariable(this);
		}
	}
}
