using System;

[Serializable]
[Obsolete]
public class LandmarkRescueablePersistentData : ILandmarkInteractablePersistentData
{
	private AgentPersistentData[] _agents;

	private BirdPersistentData[] _birds;

	public void Restore(Landmark landmark)
	{
		LandmarkRescueable[] componentsInChildren = landmark.GetComponentsInChildren<LandmarkRescueable>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (_agents != null && i < _agents.Length)
			{
				AgentPersistentData agentPersistentData = _agents[i];
				if (agentPersistentData != null)
				{
					agentPersistentData.Restore(null);
					componentsInChildren[i].Restore(agentPersistentData.Instance);
					continue;
				}
			}
			if (_birds != null && i < _birds.Length)
			{
				BirdPersistentData birdPersistentData = _birds[i];
				if (birdPersistentData != null)
				{
					birdPersistentData.Restore(null);
					componentsInChildren[i].Restore(birdPersistentData.Instance);
				}
			}
		}
	}
}
