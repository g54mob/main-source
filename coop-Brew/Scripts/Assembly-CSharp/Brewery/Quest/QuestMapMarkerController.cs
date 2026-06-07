using System.Reflection;
using Brewery.Map;
using UnityEngine;

namespace Brewery.Quest
{
	public class QuestMapMarkerController : MonoBehaviour
	{
		[Header("Marker Configuration")]
		[Tooltip("Icon definition to use for the quest marker (contains the prefab)")]
		[SerializeField]
		private MapIconDefinition questIconDefinition;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private GameObject markerInstance;

		private MapIconTarget markerIconTarget;

		private Transform currentTarget;

		private FieldInfo registeredNPCsField;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnActiveQuestChanged(string questId)
		{
		}

		private void OnQuestStepChanged(string questId, int stepIndex, QuestStep step)
		{
		}

		private void OnQuestCompleted(string questId, QuestChain chain)
		{
		}

		private void OnQuestAccepted(string questId, QuestChain chain)
		{
		}

		private void RefreshMarker()
		{
		}

		private void ShowMarker(Transform target)
		{
		}

		private void HideMarker()
		{
		}

		private Transform FindTargetForCurrentStep()
		{
			return null;
		}

		private Transform FindNpcTransform(string npcId)
		{
			return null;
		}

		private Transform FindLocationTransform(string locationId)
		{
			return null;
		}

		private Transform FindItemTransform(string itemId)
		{
			return null;
		}

		private Transform FindDeliveryItemSource(QuestStep step)
		{
			return null;
		}
	}
}
