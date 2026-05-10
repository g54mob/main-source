using UnityEngine;
using __Project__.Scripts.Multiplayer.Customization;
using __Project__.Scripts.WallPaintSystem;

namespace __Project__.Scripts.Interaction
{
	public class BucketInteraction : global::Interaction
	{
		public PaintBucket selectedBucket;

		private int m_ColorIndex;

		private int m_PaintCount;

		private bool m_PlacingMode;

		[SerializeField]
		private float m_MaxRaycastDistance;

		[SerializeField]
		private LayerMask m_BucketInteractionLayer;

		private Camera m_MainCamera;

		private RaycastHit m_Hit;

		private Ray m_Ray;

		private RackSlot m_CurrentRackSlot;

		private TrashBin m_CurrentTrashBin;

		private PaintableWall m_CurrentWall;

		private bool m_HoldingUse;

		private float m_HoldingTime;

		private float m_HoldingInteractionTime;

		private PlayerInstance m_PlayerInstance;

		private NetworkBucketInteraction m_NetworkBucketInteraction;

		private bool m_InAnimationTransition;

		public override IInteractable Interactable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool Enable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsPaintLeft => false;

		private PlayerInstance PlayerInstance => null;

		public NetworkBucketInteraction NetworkBucketInteraction => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void SetPaintCount(int count)
		{
		}

		public void CheckForInteraction()
		{
		}

		private void CheckHoldingInteraction()
		{
		}

		private void OnUse(bool down)
		{
		}

		private void OnDrop(bool down = false)
		{
		}

		private void OnBack()
		{
		}

		private void OnClose()
		{
		}

		private void BoxUpBucket()
		{
		}

		public void BoxUpBucketNetwork(PaintBucket remoteSelectedBucket)
		{
		}

		private void DropBucket()
		{
		}

		public void DropBucketOrder(PaintBucket paintBucket)
		{
		}

		private void ThrowIntoTrashBin()
		{
		}

		public void ThrowIntoTrashBin_Order(Vector3 playSoundPosition)
		{
		}

		private void PaintWall()
		{
		}

		public void StartPainting(PaintableWall wall)
		{
		}

		public void StartPainting_Order(PaintBucket remoteBucket, PaintableWall wall)
		{
		}

		private void SwitchMaterialData(MeshRenderer wallRenderer, Material material, int index)
		{
		}

		public void GrabPaintBucket(PaintBucket bucket)
		{
		}

		private void SetCurrentTrashBin(TrashBin trashBin)
		{
		}

		private void SetCurrentWall(PaintableWall wall)
		{
		}

		private void DefaultHints(bool show)
		{
		}

		private void PaintWallHints(bool show)
		{
		}

		private void PlacingModeHints(bool show)
		{
		}

		private void TrashBinHint(bool show)
		{
		}

		private void RackHints(bool show)
		{
		}
	}
}
