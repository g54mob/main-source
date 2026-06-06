using System.Collections.Generic;

public interface IDialogueContextProvider
{
	DialogueTreeProperties DialogueProperties { get; }

	IReadOnlyList<DialogueTriggerType> SupportedTriggers { get; }

	bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType);

	bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker)
	{
		mainSpeaker = null;
		return false;
	}

	bool TryGetActorDescriptor(DialogueContext.ActorType actorType, out AgentDescriptor actorDescriptor)
	{
		return StoryManager.DialogueContext.TryGetActor(actorType, out actorDescriptor);
	}

	bool TryGetLandmark(out LandmarkSpawner landmarkSpawner)
	{
		landmarkSpawner = null;
		return false;
	}
}
