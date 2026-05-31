using MyBox;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Data;
using __Project__.Scripts.WallPaintSystem;

public class FurnitureBox : MonoBehaviour, IInteractable
{
	[Separator("Components", false)]
	[SerializeField]
	private Image m_ShelfIconImage;

	[SerializeField]
	private MeshRenderer m_ProductIconImage;

	[SerializeField]
	private MeshRenderer m_ProductColorPoint;

	[SerializeField]
	private BoxSize m_Size;

	[SerializeField]
	private Animation m_Animation;

	[Separator("Carrying Settings", false)]
	[SerializeField]
	private Vector3 m_PositionOffset;

	[SerializeField]
	private Vector3 m_RotationOffset;

	[SerializeField]
	private Transform m_FurnitureSpawnPosition;

	[Separator("Animation Settings", false)]
	[SerializeField]
	private float m_AnimationDuration;

	[SerializeField]
	private float m_ScalingDownTime;

	private FurnitureBoxData m_Data;

	private NetworkFurnitureBox m_NetworkFurnitureBox;

	private Collider m_Collider;

	[HideInInspector]
	public BucketData bucketData;

	[HideInInspector]
	public DisplayData displayData;

	[HideInInspector]
	public VendingData vendingData;

	[HideInInspector]
	public CategorySignData categorySignData;

	[HideInInspector]
	public RackData rackData;

	[HideInInspector]
	public IceCreamManager.StandBoxData iceCreamStandData;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public FurnitureBoxData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public BoxSize Size => default(BoxSize);

	public Vector3 FurnitureSpawnPosition => default(Vector3);

	public InteractionType InteractionType => default(InteractionType);

	public NetworkFurnitureBox NetworkFurnitureBox => null;

	private void Initialize()
	{
	}

	private void Start()
	{
	}

	private void OnSave()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(int shelfID, bool newBox = false)
	{
	}

	public void Setup(bool newBox = false)
	{
	}

	public void SetupVending(VendingData data, bool newBox = false)
	{
	}

	public void SetupAsIceCreamStandBox(int furnitureId, IceCreamManager.StandBoxData standBoxData, bool newBox = false)
	{
	}

	public void SetupDisplay(DisplayData data, bool newBox = false)
	{
	}

	public void SetupRack(RackData data, bool newBox = false)
	{
	}

	public void SetupCategorySign(CategorySignData data, bool newBox = false)
	{
	}

	public void OpenBox()
	{
	}

	public void OpenBoxNetwork()
	{
	}

	public void PickUp()
	{
	}

	public void PickUp(PlayerInstance pickedPlayer)
	{
	}

	public bool InstantInteract()
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

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void ResetBox()
	{
	}

	private void SetIdle()
	{
	}

	public bool CustomInteract()
	{
		return false;
	}
}
