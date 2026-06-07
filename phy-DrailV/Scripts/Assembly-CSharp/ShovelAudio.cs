using System.Collections;
using DV.Utils;
using UnityEngine;

public class ShovelAudio : DebouncedSound
{
	public AudioClip coalSpawn;

	public AudioClip coalDrop;

	private Rigidbody rb;

	private Shovel shovel;

	private void Start()
	{
		SingletonBehaviour<CoroutineManager>.Instance.Run(Init());
	}

	private IEnumerator Init()
	{
		yield return null;
		rb = GetComponent<Rigidbody>();
		shovel = GetComponent<Shovel>();
		shovel.CoalSpawned += delegate(Transform t)
		{
			OnCoalSpawned(t, staticSpeed: true);
		};
		shovel.CoalUnloaded += delegate(Transform t)
		{
			OnCoalDropped(t);
		};
	}

	public void OnCoalSpawned(Transform coal, bool staticSpeed)
	{
		PlayDebounced(coalSpawn, coal.position, Mathf.Clamp01(staticSpeed ? 0.5f : (rb.velocity.sqrMagnitude * 3f)));
	}

	public void OnCoalDropped(Transform coal)
	{
		PlayDebounced(coalDrop, coal.position, Mathf.Clamp01(0.5f));
	}
}
