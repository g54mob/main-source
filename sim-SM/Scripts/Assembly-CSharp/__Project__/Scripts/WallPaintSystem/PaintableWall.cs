using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Interaction;

namespace __Project__.Scripts.WallPaintSystem
{
	public class PaintableWall : MonoBehaviour, IInteractable
	{
		public BucketInteraction CurrentBucketInteraction;

		public PaintData paintData;

		public MeshRenderer wallRenderer;

		public List<PaintableWall> extraWalls;

		public int materialIndex;

		public InteractactableType Type => default(InteractactableType);

		public bool ContinousInteraction => false;

		public InteractionType InteractionType => default(InteractionType);

		public string InstantInteractionHint => null;

		public string HoldingInteractionHint => null;

		public string SecondInteractionHint => null;

		public string RepairInteractionHint => null;

		public bool NeedRepair { get; set; }

		public bool InstantInteract()
		{
			return false;
		}

		public bool CustomInteract()
		{
			return false;
		}

		public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
		{
			return false;
		}

		public bool RemoteInteract(string userId)
		{
			return false;
		}

		public bool HoldingInteract()
		{
			return false;
		}

		public void Initialize(PaintData data)
		{
		}

		private void SwitchMaterial(Material material)
		{
		}

		public void StartPaintMode(BucketInteraction bucketInteraction)
		{
		}
	}
}
