using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/UI Packet Simulation", fileName = "UIPacketSimulation")]
public class UIPacketSimulation : ScriptableObject, IIntervalIncrementalSimulation, IIncrementalSimulation
{
	public float chance = 1E-05f;

	public float basePing = 60f;

	public float maxPing = 999f;

	public float fastSpeed = 3f;

	public float slowSpeed = 0.5f;

	public float minLength = 0.05f;

	public float maxLength = 0.2f;

	private UIRegistry _registry;

	public float UpdateInterval => 0.5f;

	public void Registered(UIRegistry? registry)
	{
		if (!registry.HasValue)
		{
			throw new NullReferenceException("Trying to register " + base.name + " without a valid UI registry.");
		}
		_registry = registry.Value;
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		if (Database.State.Game.Launched.Value && Database.State.Datacenters.Details.Count != 0 && !((double)UnityEngine.Random.value > (double)chance * Database.State.Resources.Players.Value))
		{
			float t = Mathf.Clamp01(Mathf.Log(Database.State.Resources.Ping.Value / basePing) / Mathf.Log(maxPing / basePing));
			float speed = Mathf.Lerp(fastSpeed, slowSpeed, t);
			float length = Mathf.Lerp(minLength, maxLength, t);
			_registry.view.world.TriggerPacket(speed, length);
		}
	}
}
