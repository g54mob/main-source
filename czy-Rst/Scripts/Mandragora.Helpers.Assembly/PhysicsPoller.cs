using System;
using UnityEngine;

public class PhysicsPoller : MonoBehaviour
{
	private static PhysicsPoller Instance;

	private static void StaticInit()
	{
		if (Instance == null)
		{
			GameObject obj = new GameObject("PhysicsPoller");
			UnityEngine.Object.DontDestroyOnLoad(obj);
			Instance = obj.AddComponent<PhysicsPoller>();
		}
	}

	private void Awake()
	{
		if (Physics.autoSimulation || Physics.autoSyncTransforms || Physics2D.autoSyncTransforms)
		{
			throw new Exception("The project uses a custom physics poller to simulate and sync physics! Disable auto-simulate and auto-sync in physics and physics2D settings!");
		}
	}

	private void Update()
	{
		if (!(Time.deltaTime <= 0f))
		{
			Physics.Simulate(Time.deltaTime);
			Physics2D.Simulate(Time.deltaTime);
		}
	}
}
