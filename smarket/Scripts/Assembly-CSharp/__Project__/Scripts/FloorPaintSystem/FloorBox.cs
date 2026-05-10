using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Multiplayer.Customization;

namespace __Project__.Scripts.FloorPaintSystem
{
	public class FloorBox : MonoBehaviour, IInteractable
	{
		private FloorTextureData m_TextureData;

		private FloorBoxData m_Data;

		private FloorSo m_FloorSo;

		public FurnitureBoxPlacingMode placingMode;

		public Vector3 positionOffset;

		public bool isCarrying;

		private int m_MaxFloorCount;

		private bool m_InAnimationTransition;

		private float m_AnimationTransitionTime;

		private float m_ClosingBoxTime;

		[SerializeField]
		private GameObject m_IconCanvas;

		[SerializeField]
		private MeshRenderer m_FloorImage;

		private List<PaintableFloor> m_PaintableFloors;

		[SerializeField]
		private Animation m_Animation;

		[SerializeField]
		private Transform m_ProductsParent;

		private bool m_hasFloorsSpawned;

		[SerializeField]
		private Transform m_PivotObject;

		private NetworkFloorBox m_NetworkFloorBox;

		private bool m_IsOccupied;

		public InteractactableType Type => default(InteractactableType);

		public bool ContinousInteraction => false;

		public InteractionType InteractionType => default(InteractionType);

		public string InstantInteractionHint => null;

		public string HoldingInteractionHint => null;

		public string SecondInteractionHint => null;

		public string RepairInteractionHint => null;

		public bool NeedRepair { get; set; }

		public FloorBoxData Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public FloorTextureType TextureType => default(FloorTextureType);

		public int FloorId => 0;

		public NetworkFloorBox NetworkFloorBox => null;

		public bool HasFloors => false;

		public bool InAnimationTransition => false;

		public bool IsOccupied
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool InstantInteract()
		{
			return false;
		}

		public bool HoldingInteract()
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

		public void HoldBox()
		{
		}

		public void HoldBox(PlayerInstance playerInstance)
		{
		}

		public void Initialize(FloorBoxData data, bool newBox)
		{
		}

		public void OpenBox()
		{
		}

		public void OpenBoxNetwork()
		{
		}

		public void CloseBox(bool force = false)
		{
		}

		public void CloseBoxNetwork()
		{
		}

		private void SetInAnimationTransition()
		{
		}

		private void SpawnFloorObjects()
		{
		}

		private void DespawnFloorObjects()
		{
		}

		public void PaintFloor()
		{
		}

		public PaintableFloor GetNextFloor()
		{
			return null;
		}

		public void ResetBox()
		{
		}

		private void SetIdle()
		{
		}
	}
}
