using System;
using System.Collections.Generic;

[Serializable]
public class ActorDescriptorPersistentData
{
	private List<ActorDescriptor.PersistentDataBase> _actorDescriptors;

	public ActorDescriptorPersistentData(IEnumerable<ActorDescriptor> actorDescriptors)
	{
		_actorDescriptors = new List<ActorDescriptor.PersistentDataBase>();
		foreach (ActorDescriptor actorDescriptor in actorDescriptors)
		{
			_actorDescriptors.Add(actorDescriptor.GetPersistentData());
		}
	}

	public void Restore()
	{
		foreach (ActorDescriptor.PersistentDataBase actorDescriptor in _actorDescriptors)
		{
			actorDescriptor.Restore();
		}
	}
}
