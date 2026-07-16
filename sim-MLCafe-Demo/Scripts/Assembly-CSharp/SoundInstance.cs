using System;
using UnityEngine;

[Serializable]
public class SoundInstance
{
	private Guid id;

	private GameObject gameObject;

	private AudioSource source;

	public SoundInstance(GameObject gameObject, AudioSource source)
	{
		id = Guid.NewGuid();
		this.gameObject = gameObject;
		this.source = source;
	}

	public Guid GetId()
	{
		return id;
	}

	public AudioSource GetSource()
	{
		return source;
	}

	public GameObject GetWorldInstance()
	{
		return gameObject;
	}

	public void DestroyInstance()
	{
		UnityEngine.Object.Destroy(gameObject);
	}
}
