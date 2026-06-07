using UnityEngine;

public abstract class ActorProperties : ScriptableObject
{
	[SerializeField]
	private ActorType _actorType;

	public ActorType ActorType => _actorType;

	public virtual void Initialize()
	{
	}
}
