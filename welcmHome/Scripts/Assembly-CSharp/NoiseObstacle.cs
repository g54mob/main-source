using FMOD.Studio;
using FMODUnity;
using Unity.Collections;
using UnityEngine;

public class NoiseObstacle : MonoBehaviour
{
	private NoiseManager noiseManager;

	public EventReference branchSound;

	public int loudness = 10;

	private void Start()
	{
		noiseManager = base.transform.parent.GetComponent<NoiseManager>();
	}

	private void Update()
	{
	}

	private void BatchOverlapSphere()
	{
		NativeArray<OverlapSphereCommand> commands = new NativeArray<OverlapSphereCommand>(1, Allocator.TempJob);
		NativeArray<ColliderHit> results = new NativeArray<ColliderHit>(1000, Allocator.TempJob);
		commands[0] = new OverlapSphereCommand(base.transform.position, 15f, QueryParameters.Default);
		OverlapSphereCommand.ScheduleBatch(commands, results, 1, 1000).Complete();
		foreach (ColliderHit item in results)
		{
			MonoBehaviour.print(item.collider.gameObject.name);
			if ((bool)item.collider.gameObject.GetComponentInChildren<AIFollower>())
			{
				item.collider.gameObject.GetComponentInChildren<AIFollower>().IncreaseLocalNoise(loudness * 15);
			}
		}
		commands.Dispose();
		results.Dispose();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayInteractSound();
			GetComponent<BoxCollider>().enabled = false;
			noiseManager.IncreaseGlobalNoiseObstacle();
			Object.Destroy(base.gameObject);
			BatchOverlapSphere();
		}
	}

	private void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(branchSound);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
