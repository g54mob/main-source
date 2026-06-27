using System.Collections.Generic;
using UnityEngine;

namespace SleepyNodes
{
	[CreateNodeMenu("Entity/Spawn Entity")]
	[NodeWidth(400)]
	[NodeName("Spawn Entity")]
	public class State_SpawnMapEntity : StateNode
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false, connectionType = ConnectionType.Override, backingValue = ShowBackingValue.Never)]
		public StateNode To;

		public bool SetContextVariable;

		public EntityContextKeys LastSpawnedEntity;

		public string ID;

		public string DisplayName;

		public bool PresetIcon;

		public MapEntityIcon Icon;

		public Sprite IconRaw;

		public EntityRoles Role;

		public MapEntityStates StartingState;

		public int Health;

		public int Armour;

		public int Stars;

		public int Scale;

		public List<ShellDefinition> ImmuneShells;

		[Header("Spawn Count")]
		public int NumberToSpawn;

		public LocationSelection LocationToSpawn;

		private string lastSpawnedEntityID;

		private string lastSpawnedEntityName;

		public override void ResetNode()
		{
		}

		public override void OnEnter(NodeExecutionState state)
		{
		}

		public override void OnExecute(NodeExecutionState state)
		{
		}

		public static string IncrementTrailingNumber(string input)
		{
			return null;
		}
	}
}
