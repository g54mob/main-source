using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableDrifterSpawn : ScenarioTriggerableBase, IDialogueContextProvider
	{
		private enum Mode
		{
			Random = 0,
			Specific = 1
		}

		[Header("Spawn Drifter")]
		[SerializeField]
		private Mode _mode;

		[SerializeField]
		[ConditionalEnumHide("_mode", 1, true)]
		private AgentProfile _actorProfile;

		[SerializeField]
		private BearingFeatures _bearingFeatures;

		[SerializeReference]
		[InstantiateSerializeReference]
		private ILandmarkPickerSettings _landmarkPickerSettings;

		[SerializeField]
		private DialogueTrigger _dialogueTrigger;

		private LandmarkSpawner _landmarkSpawner;

		private AgentDescriptor _triggerActor;

		public DialogueTreeProperties DialogueProperties => null;

		public IReadOnlyList<DialogueTriggerType> SupportedTriggers => null;

		protected override bool Trigger(AgentDescriptor actor = null)
		{
			if (_mode == Mode.Random)
			{
				_landmarkPickerSettings.SpawnDrifter(out _landmarkSpawner, null);
			}
			else
			{
				_landmarkPickerSettings.SpawnDrifter(out _landmarkSpawner, _actorProfile.GetDescriptor());
			}
			if (_landmarkSpawner == null)
			{
				return false;
			}
			_landmarkSpawner.SetBearingFeatures(_bearingFeatures);
			_triggerActor = actor;
			_dialogueTrigger.Trigger(this);
			return true;
		}

		public bool TryGetActorDescriptor(DialogueContext.ActorType actorType, out AgentDescriptor actorDescriptor)
		{
			if (actorType == DialogueContext.ActorType.LandmarkDrifter && _triggerActor != null)
			{
				actorDescriptor = _triggerActor;
				return true;
			}
			return StoryManager.DialogueContext.TryGetActor(actorType, out actorDescriptor);
		}

		public bool TryGetLandmark(out LandmarkSpawner landmarkSpawner)
		{
			landmarkSpawner = _landmarkSpawner;
			return landmarkSpawner != null;
		}

		public bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
		{
			return false;
		}
	}
}
