public interface IDialogueInteractable
{
	DialogueTreeProperties DialogueProperties { get; }

	bool IsRadioMessage => false;

	bool Queue => true;

	float Delay => 0f;

	void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue);

	bool TryGetEntryPoint(out DialogueNodeProperties entryPoint);

	bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker);

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
