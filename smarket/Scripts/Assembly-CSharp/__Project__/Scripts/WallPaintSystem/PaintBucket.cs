using NaisuPorter.CommonScripts;
using UnityEngine;
using __Project__.Scripts.Interaction;
using __Project__.Scripts.Multiplayer.Customization;

namespace __Project__.Scripts.WallPaintSystem
{
	public class PaintBucket : MonoBehaviour, IInteractable
	{
		[HideInInspector]
		public int colorIndex;

		public BucketData bucketData;

		public SerializableVector3 positionOffset;

		[HideInInspector]
		public bool isAlreadySpawned;

		[HideInInspector]
		public int paintCount;

		[SerializeField]
		private int m_MaxPaintCount;

		[SerializeField]
		private Transform m_PivotRef;

		[SerializeField]
		private GameObject m_PaintObject;

		private MeshRenderer m_ObjectRenderer;

		public int bucketID;

		[SerializeField]
		public Renderer[] renderersToHighlight;

		public BucketPlacingMode placingMode;

		public bool isHolding;

		[SerializeField]
		private Wobble wobble;

		private NetworkPaintBucket m_NetworkPaintBucket;

		public NetworkPaintBucket NetworkPaintBucket => null;

		public InteractactableType Type => default(InteractactableType);

		public bool ContinousInteraction => false;

		public InteractionType InteractionType => default(InteractionType);

		public string InstantInteractionHint => null;

		public string HoldingInteractionHint => null;

		public string SecondInteractionHint => null;

		public string RepairInteractionHint => null;

		public bool NeedRepair { get; set; }

		public bool InAnimationTransition { get; set; }

		public void Initialize(bool isRacked, BucketData data)
		{
		}

		private float GetPaintRatio(int offset)
		{
			return 0f;
		}

		public void PaintWall(BucketInteraction currentBucketInteraction)
		{
		}

		private void TweenMaterial(float target)
		{
		}

		private void BucketFinished()
		{
		}

		public void GrabThis(PlayerInstance playerInstance)
		{
		}

		public void GrabThisOrder(PlayerInstance playerInstance)
		{
		}

		public bool InstantInteract()
		{
			return false;
		}

		public bool HoldingInteract()
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

		public bool CustomInteract()
		{
			return false;
		}

		public void PaintFinished(PlayerInstance interactedPlayer)
		{
		}

		public void Despawn()
		{
		}

		public void ManualUpdate()
		{
		}

		public void UpdateWobble()
		{
		}

		public void StopWobble()
		{
		}
	}
}
