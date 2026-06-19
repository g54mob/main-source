using System;
using System.Collections.Generic;
using UnityEngine;

public class EventTerminalAuthoring : MonoBehaviour
{
	[Serializable]
	public struct EventTerminalSequence
	{
		public EventTerminalAction action;

		public ConnectionAndDirection target;

		[Min(0f)]
		public float duration;
	}

	[Serializable]
	public struct AlwaysActiveConnection
	{
		public ConnectionAndDirection connection;
	}

	[Min(0f)]
	public float radius;

	[Min(0f)]
	public float duration = 60f;

	public LootTableID lootTable;

	public List<AlwaysActiveConnection> alwaysActiveConnections;

	public List<EventTerminalSequence> eventSequence;

	[Min(0f)]
	public int loopIndex;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		for (int i = 0; i < 32; i++)
		{
			float f = (float)i / 32f * 2f * MathF.PI;
			float f2 = (float)(i + 1) / 32f * 2f * MathF.PI;
			Vector3 vector = base.transform.position + new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f)) * radius;
			Vector3 to = base.transform.position + new Vector3(Mathf.Cos(f2), 0f, Mathf.Sin(f2)) * radius;
			Gizmos.DrawLine(vector, to);
		}
	}
}
