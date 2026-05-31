using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using __Project__.Scripts.WallPaintSystem;

public class RackSlot : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Highlightable m_Highlightable;

	[SerializeField]
	private Transform m_InteractionPosition;

	[SerializeField]
	private Label m_Label;

	private List<Box> m_Boxes;

	private List<PaintBucket> m_Buckets;

	private RackSlotData m_Data;

	private Tween m_ColliderEnabler;

	private Rack m_Rack;

	private RackLabelMaskController m_LabelMaskController;

	public Rack OwnRack => null;

	public bool Full => false;

	public int CurrentBoxID => 0;

	public RackSlotData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Box> Boxes => null;

	public Vector3 InteractionPosition => default(Vector3);

	public Quaternion InteractionRotation => default(Quaternion);

	public bool HasBox => false;

	public bool HasLabel => false;

	public bool HasProduct => false;

	public int ProductCount => 0;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public bool EnableBoxColliders
	{
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Initialize()
	{
	}

	public void InitializeEmptySlot()
	{
	}

	public void Initialize(Box box)
	{
	}

	public int GetIndexFromRack()
	{
		return 0;
	}

	public void ClearLabel()
	{
	}

	public void ClearLabelNetwork()
	{
	}

	public bool IsBoxAlreadyExistInRack(int boxID, Box box)
	{
		return false;
	}

	public void AddBox(int boxID, Box box, bool modifyInstancing = true)
	{
	}

	public void RefreshLabel()
	{
	}

	public void AddBucket(int boxID, PaintBucket bucket)
	{
	}

	[ContextMenu("ReOrderBoxesPosition")]
	public void RePositionBoxes()
	{
	}

	[ContextMenu("RepositionBoxesSoft")]
	public void RepositionBoxesSoft()
	{
	}

	public void RepositionBoxesFaster()
	{
	}

	public Box GetMinBoxInRack()
	{
		return null;
	}

	public bool CanTakeBoxFromRack()
	{
		return false;
	}

	public Box TakeBoxFromRack()
	{
		return null;
	}

	public void UpdateRackedBoxDatas()
	{
	}

	public int WholesaleOrderRemoveProductFromBox(int count)
	{
		return 0;
	}

	public void RemoveFromRackManagerWhileCarrying()
	{
	}

	public void AddBackToRackManagerAfterPlaced()
	{
	}

	[ContextMenu("SetLabel")]
	public void SetLabel()
	{
	}

	public void ResetSlot()
	{
	}

	public int GetProductCountById()
	{
		return 0;
	}

	public bool InstantInteract()
	{
		return false;
	}

	public void InteractWithBox(Box box)
	{
	}

	public void InteractWithBox(Box box, string userId)
	{
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

	public void RequestLabelMaskUpdate()
	{
	}
}
