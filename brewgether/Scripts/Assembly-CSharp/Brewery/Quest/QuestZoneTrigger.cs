using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Quest
{
	[RequireComponent(typeof(Collider))]
	public class QuestZoneTrigger : MonoBehaviour
	{
		[Header("Zone Settings")]
		[Tooltip("Unique ID for this zone. Used as the event context (e.g., 'small_barn', 'big_barn', 'drug_hall')")]
		[SerializeField]
		private string zoneId;

		[Tooltip("Display name for UI/debug messages")]
		[SerializeField]
		private string zoneName;

		[Header("Trigger Settings")]
		[Tooltip("Only trigger once per player (recommended for quest completion zones)")]
		[SerializeField]
		private bool triggerOnce;

		[Tooltip("Layer mask for player detection. Leave default for Player layer.")]
		[SerializeField]
		private LayerMask playerLayerMask;

		[Header("Optional Quest Requirement")]
		[Tooltip("If set, only triggers if this quest chain is currently active. Leave empty to always trigger.")]
		[SerializeField]
		private string requiredQuestChainId;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private HashSet<ulong> triggeredPlayers;

		private void Awake()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		public void ResetForPlayer(ulong clientId)
		{
		}

		public void ResetAll()
		{
		}
	}
}
