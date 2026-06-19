using System;
using UnityEngine;

[Serializable]
public class SessionConfiguration
{
	[field: SerializeField]
	public int MaxNumberOfPlayers { get; private set; } = 8;

	[field: SerializeField]
	public int SimulationTickRate { get; private set; } = 20;

	[field: SerializeField]
	public int SimulationDistance { get; private set; } = 50;

	[field: SerializeField]
	public int AutoSaveInterval { get; private set; } = 60;

	[field: SerializeField]
	public int NetworkSendRate { get; private set; } = 20;

	[field: SerializeField]
	public bool UseGhostSendSystemOverrides { get; private set; }

	[field: SerializeField]
	public int GhostSendSystemMaxSendEntitiesCeil { get; private set; }

	[field: SerializeField]
	public int GhostSendSystemMaxSendEntitiesFloor { get; private set; }

	[field: SerializeField]
	public int GhostSendSystemMaxSendChunks { get; private set; }
}
