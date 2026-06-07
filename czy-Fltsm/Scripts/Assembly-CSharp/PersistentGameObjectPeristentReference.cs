using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class PersistentGameObjectPeristentReference
{
	public PersistentReference<Agent>.Reference AgentReference;

	public PersistentReference<Bird>.Reference BirdReference;

	public PersistentReference<Boat>.Reference BoatReference;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<Buildable>.Reference BuildableReference;

	private PersistentGameObjectPeristentReference()
	{
	}

	private bool Initialize(GameObject gameObject)
	{
		if (gameObject == null)
		{
			return true;
		}
		if (!TryPopulatePersistentReferenceComponent(gameObject, out AgentReference) && !TryPopulatePersistentReferenceComponent(gameObject, out BirdReference) && !TryPopulatePersistentReferenceComponent(gameObject, out BoatReference))
		{
			return TryPopulatePersistentReferenceComponent(gameObject, out BuildableReference);
		}
		return true;
	}

	public bool TryRestore(out GameObject gameObject)
	{
		if (!TryRestore(AgentReference, out gameObject) && !TryRestore(BirdReference, out gameObject) && !TryRestore(BoatReference, out gameObject))
		{
			return TryRestore(BuildableReference, out gameObject);
		}
		return true;
	}

	public bool TryRestoreAgent(out Agent agent)
	{
		return AgentReference.TryReturn(out agent);
	}

	private bool TryPopulatePersistentReferenceComponent<T>(GameObject gameObject, out PersistentReference<T>.Reference persistentReference) where T : IPersistentReference
	{
		T component = gameObject.GetComponent<T>();
		if (component == null)
		{
			persistentReference = null;
			return false;
		}
		persistentReference = new PersistentReference<T>.Reference(component);
		return true;
	}

	private bool TryRestore<T>(PersistentReference<T>.Reference persistentReference, out GameObject gameObject) where T : MonoBehaviour, IPersistentReference
	{
		if (persistentReference.TryReturn(out var instance))
		{
			gameObject = instance.gameObject;
			return true;
		}
		gameObject = null;
		return false;
	}

	public static implicit operator PersistentGameObjectPeristentReference(GameObject gameObject)
	{
		PersistentGameObjectPeristentReference persistentGameObjectPeristentReference = new PersistentGameObjectPeristentReference();
		if (persistentGameObjectPeristentReference.Initialize(gameObject))
		{
			return persistentGameObjectPeristentReference;
		}
		Debug.LogFormat("Reference to GameObject '{0}' could not be persisted!", gameObject.name);
		return persistentGameObjectPeristentReference;
	}

	public static implicit operator GameObject(PersistentGameObjectPeristentReference data)
	{
		if (data.TryRestore(out var gameObject))
		{
			return gameObject;
		}
		return null;
	}
}
