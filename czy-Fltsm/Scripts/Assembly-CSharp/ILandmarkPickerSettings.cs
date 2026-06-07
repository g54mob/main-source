public interface ILandmarkPickerSettings
{
	void SetOwningQuest(Quest owningQuest);

	bool Spawn(ILandmarkBehaviourProvider landmarkBehaviourProvider);

	bool Spawn(out LandmarkSpawner landmarkSpawner, ILandmarkBehaviourProvider landmarkBehaviourProvider);

	bool SpawnDrifter(ActorDescriptor actorDescriptor, QuestProperties questToAssign = null, ILandmarkBehaviourProvider landmarkBehaviourProvider = null);

	bool SpawnDrifter(out LandmarkSpawner landmarkSpawner, ActorDescriptor actorDescriptor, QuestProperties questToAssign = null, ILandmarkBehaviourProvider landmarkBehaviourProvider = null);

	bool CanSpawn();
}
