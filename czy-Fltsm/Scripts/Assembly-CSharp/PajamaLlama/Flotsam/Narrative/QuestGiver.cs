using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public struct QuestGiver
	{
		public enum Type
		{
			ActorType = 0,
			ActorProfile = 1,
			Interactor = 2
		}

		[Serializable]
		private struct ActorTypeFields
		{
			public DialogueContext.ActorType ActorType;

			[ConditionalEnumHide("ActorType", 8, true)]
			public QuestProperties QuestProperties;

			public AgentDescriptor GetActorDescriptor()
			{
				if (ActorType == DialogueContext.ActorType.QuestGiver && QuestProperties != null && StoryManager.TryGetQuest(QuestProperties, out var questInstance))
				{
					return questInstance.QuestGiver;
				}
				if (StoryManager.DialogueContext.TryGetActor(ActorType, out var actor))
				{
					return actor;
				}
				Debug.LogException(new Exception($"Unable to get actor of type {ActorType}, falling back on 'First Mate'"));
				return StoryManager.DialogueContext.GetActor(DialogueContext.ActorType.FirstMate);
			}
		}

		[SerializeField]
		private Type _type;

		[SerializeField]
		[ConditionalEnumHide("_type", 0, true)]
		private ActorTypeFields _actorTypeFields;

		[SerializeField]
		[ConditionalEnumHide("_type", 1, true)]
		private AgentProfile _actorProfile;

		public AgentDescriptor GetActorDescriptor(AgentDescriptor interactor = null)
		{
			switch (_type)
			{
			case Type.ActorType:
				return _actorTypeFields.GetActorDescriptor();
			case Type.ActorProfile:
				if (_actorProfile != null)
				{
					return _actorProfile.GetDescriptor();
				}
				Debug.LogException(new Exception("Unable to return ActorDescriptor, ActorProfile is 'NULL'. Falling back on 'First Mate"));
				break;
			case Type.Interactor:
				if (interactor != null)
				{
					return interactor;
				}
				Debug.LogException(new Exception("Unable to return interactor ActorDescriptor, because it is 'NULL'. Falling back on 'First Mate'"));
				break;
			}
			return StoryManager.DialogueContext.GetActor(DialogueContext.ActorType.FirstMate);
		}
	}
}
