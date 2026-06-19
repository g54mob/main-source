using UnityEngine;

public abstract class CreatureBehaviour : MonoBehaviour
{
	protected Creature _creature;

	protected CreatureSpawner _parentSpawner;

	public void Initiate(CreatureSpawner parentSpawner, Creature creature)
	{
	}

	protected abstract void OnInitiate();
}
