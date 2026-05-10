using System.Collections.Generic;
using MyBox;
using UnityEngine;
using UnityEngine.AI;
using __Project__.Scripts.Multiplayer;

public class Baker : MonoBehaviour, IInteractable
{
	public enum BakerStateType
	{
		Idle = 0,
		Moving = 1,
		FrozenSearching = 2,
		RestockOven = 3,
		DropBox = 4,
		ReturnBoxToRack = 5,
		CollectBakedProduct = 6,
		RestockBakedProducts = 7
	}

	public class StateMachine
	{
		private IState currentState;

		public IState CurrentState => null;

		public void ChangeState(IState newState)
		{
		}

		public void Update()
		{
		}
	}

	public interface IState
	{
		void Enter();

		void Update();

		void Exit();
	}

	public enum BakerWarningType
	{
		NoDisplay = 0,
		NoRack = 1
	}

	public BakerStateType State;

	public int CurrentProductId;

	public Oven CurrentOven;

	[HideInInspector]
	public LayerMask m_CurrentBoxLayer;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private float m_BoostCost;

	[SerializeField]
	private BoostIndicator m_BoostIndicator;

	[SerializeField]
	private float m_BoostAmount;

	[SerializeField]
	private float m_PlacingProductsInterval;

	[SerializeField]
	private List<float> m_BakerWalkingSpeeds;

	[SerializeField]
	private List<float> m_BakerPlacingSpeeds;

	private Box m_CurrentBox;

	private DisplaySlot m_CurrentOvenSlot;

	[SerializeField]
	private Transform m_BoxHolder;

	private BakerAnimationController m_AnimationController;

	private StateMachine m_StateMachine;

	private bool m_CarryingBox;

	private Crate m_BakerCrate;

	private float m_LastSpeechTime;

	private float m_SpeechShowFrequence;

	private BakerIdleState m_BakerIdleState;

	private FrozenSearchingState m_FrozenSearchingState;

	private RestockOvenState m_RestockOvenState;

	private DropBoxState m_DropBoxState;

	private ReturnBoxToRack m_ReturnBoxToRack;

	private CollectBakedProductState m_CollectBakedProductState;

	private RestockBakedProductsState m_RestockBakedProductsState;

	private readonly float m_BoxTransitionTime;

	private NetworkBaker m_NetworkBaker;

	private GameObject m_CurrentSpeechObject;

	private int m_CurrentBoostLevel;

	public NetworkBaker NetworkBaker => null;

	public GameObject CurrentSpeechObject
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool CarryingBox
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float PlacingProductsInterval => 0f;

	public DisplaySlot CurrentOvenSlot
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Box CurrentBox
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Crate BakerCrate
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public BoostIndicator BoostIndicator
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetIdleState()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetSearchingState()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetRestockOvenState()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetDropBoxState()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetReturnBoxToRackState()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetCollectBakedProductState()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetRestockBakedProductsState()
	{
	}

	public void ShowSpeechText(BakerWarningType warningType)
	{
	}

	public void ToggleBakerCrate(bool active)
	{
	}

	public bool IsCarryingCrate()
	{
		return false;
	}

	public void TakeProducctFromOven()
	{
	}

	public void PickUpBox(Box box)
	{
	}

	public void PickUpBox(RackSlot rackSlot)
	{
	}

	public void PickUpBox_Network(bool isFromRack, Box box, RackSlot rackSlot = null)
	{
	}

	public void DropCurrentBox()
	{
	}

	public void DropCurrentBox_Network()
	{
	}

	public void DropBoxToGround()
	{
	}

	public void PlaceProduct_Network(DisplaySlot displaySlot, Box box, int productId)
	{
	}

	public void TakeProductFromOven_Network(DisplaySlot displaySlot)
	{
	}

	public void PlaceProductToDisplay_Network(DisplaySlot displaySlot, int productId)
	{
	}

	public void PlaceBoxToRack_Network(RackSlot rackSlot, Box box)
	{
	}

	private void SetBakerBoost(int boostLevel)
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

	public void BoostBakerNetwork()
	{
	}

	public void SetBoostBakerNetwork(float boostAmount)
	{
	}

	public Box GetCurrentBox()
	{
		return null;
	}
}
