using Brewery.Map;
using HighlightPlus;
using InteractionSystem;
using UnityEngine;

namespace Brewery.NPC.Resurrection
{
	public class GraveController : MonoBehaviour, IInteractable
	{
		[Header("Child Transforms")]
		[Tooltip("Where the priest stands during the resurrection ceremony.")]
		[SerializeField]
		private Transform priestStandPoint;

		[Tooltip("Where the NPC spawns after resurrection.")]
		[SerializeField]
		private Transform npcSpawnPoint;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private MeshRenderer[] meshRenderers;

		private Collider[] colliders;

		private MapIconTarget mapIconTarget;

		private HighlightEffect highlightEffect;

		private string assignedNpcId;

		private string assignedDisplayName;

		private bool isOccupied;

		public bool IsOccupied => false;

		public string AssignedNpcId => null;

		public string AssignedDisplayName => null;

		public Vector3 PriestStandPosition => default(Vector3);

		public Vector3 NPCSpawnPoint => default(Vector3);

		private void Awake()
		{
		}

		public void AssignNPC(string npcId, string displayName, bool instant)
		{
		}

		public void ClearAssignment(bool instant)
		{
		}

		private void SetVisibility(bool visible)
		{
		}

		private void ShowWithAnimation()
		{
		}

		private void HideWithAnimation()
		{
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		public bool ShouldRemainFocused(ulong clientId)
		{
			return false;
		}
	}
}
