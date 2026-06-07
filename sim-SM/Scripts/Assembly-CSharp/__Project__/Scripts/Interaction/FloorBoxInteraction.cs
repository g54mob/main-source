using UnityEngine;
using __Project__.Scripts.FloorPaintSystem;
using __Project__.Scripts.Multiplayer.Customization;

namespace __Project__.Scripts.Interaction
{
	public class FloorBoxInteraction : global::Interaction
	{
		[SerializeField]
		private float m_MaxRaycastDistance;

		[SerializeField]
		private LayerMask m_FloorBoxInteractionLayer;

		[SerializeField]
		private float m_FloorPlacementInterval;

		[SerializeField]
		private float m_MinTimeToStartPlacingAfterOpeningBox;

		[SerializeField]
		private Vector3 m_targetScaleForFloorAnimation;

		private FloorBox m_CurrentFloorBox;

		private PaintableFloor m_CurrentTargetFloor;

		private bool m_PlacingMode;

		private bool m_IsBoxOpen;

		private float m_LastPlaceTime;

		private TrashBin m_CurrentTrashBin;

		private Camera m_MainCamera;

		private RaycastHit m_Hit;

		private Ray m_Ray;

		private bool m_HoldingUse;

		private bool m_HoldingTake;

		private NetworkFloorBoxInteraction m_NetworkFloorBoxInteraction;

		private PlayerInstance m_PlayerInstance;

		public bool IsWaitingAvailability;

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

		public FloorBox CurrentFloorBox => null;

		private PlayerInstance PlayerInstance => null;

		public NetworkFloorBoxInteraction NetworkFloorBoxInteraction => null;

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

		private void OnUse(bool down)
		{
		}

		private void OnTake(bool down)
		{
		}

		private void OnDrop(bool down = false)
		{
		}

		private void OnRotate(bool clockvise)
		{
		}

		private void OnBack()
		{
		}

		private void OnThrow(bool isDown)
		{
		}

		public void Throw()
		{
		}

		public void ThrowOrder(FloorBox floorBox)
		{
		}

		public void LocalThrow()
		{
		}

		private void OnClose()
		{
		}

		public void CancelInteracitonForOnlyMultiplayer()
		{
		}

		private void CheckForInteraction()
		{
		}

		private void DropBox()
		{
		}

		public void DropBox(FloorBox floorBox)
		{
		}

		private void SetCurrentFloor(PaintableFloor floor)
		{
		}

		private void PaintFloor()
		{
		}

		public void ReplaceFloor(FloorBox floorBox, PaintableFloor targetFloor)
		{
		}

		public void ReplaceFloorOrder(FloorBox heldFloorBox, PaintableFloor targetFloor)
		{
		}

		private void ThrowIntoTrashBin()
		{
		}

		public void Network_ThrowIntoTrashBin(string userID)
		{
		}

		private void SetCurrentTrashBin(TrashBin trashBin)
		{
		}

		private void DefaultHints(bool show)
		{
		}

		private void UpdateOpeningBoxHint()
		{
		}

		private void PlacingModeHints(bool show)
		{
		}

		private void TrashBinHint(bool show)
		{
		}

		private void FloorHints(bool show)
		{
		}
	}
}
