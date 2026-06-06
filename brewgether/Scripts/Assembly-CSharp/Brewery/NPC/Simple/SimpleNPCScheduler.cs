using MyStuff.Environment;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	public class SimpleNPCScheduler : NetworkBehaviour
	{
		[Header("Time Configuration")]
		[Tooltip("Hour when NPCs start leaving home (morning)")]
		[SerializeField]
		private int wakeUpHour;

		[Tooltip("Hour when all NPCs forced to bar (evening)")]
		[SerializeField]
		private int barHourStart;

		[Tooltip("Hour when bar time ends (night)")]
		[SerializeField]
		private int barHourEnd;

		[Tooltip("Hour when NPCs must be home (night)")]
		[SerializeField]
		private int bedtimeHour;

		[Header("References")]
		[SerializeField]
		private TimeOfDayManager timeManager;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private int lastProcessedHour;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private void OnHourChanged(int hour)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
