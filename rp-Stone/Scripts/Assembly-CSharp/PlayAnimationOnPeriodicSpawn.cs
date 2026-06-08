using UnityEngine;

public class PlayAnimationOnPeriodicSpawn : MonoBehaviour
{
	public int playOnTic;

	private AsciiAnimation anim;

	private CharacterPeriodicSpawner spawner;

	private int lastTics = -1;

	private void Update()
	{
		if (anim != null && spawner != null && lastTics != spawner.elapsedTics)
		{
			lastTics = spawner.elapsedTics;
			if (playOnTic == lastTics)
			{
				anim.Play();
			}
		}
	}

	private void Awake()
	{
		anim = GetComponent<AsciiAnimation>();
		spawner = GetComponent<CharacterPeriodicSpawner>();
	}
}
