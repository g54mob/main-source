using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
	public class IdleState : IState
	{
		public Oven Oven;

		public void Enter()
		{
		}

		public void Update()
		{
		}

		public void Exit()
		{
		}
	}

	public class BakingState : IState
	{
		public Oven Oven;

		public void Enter()
		{
		}

		public void Update()
		{
		}

		public void Exit()
		{
		}

		private void Baking()
		{
		}
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

	[SerializeField]
	private ExpenseType m_ExpenseType;

	public float CurrentBakeTime;

	public float BakeDuration;

	public GameObject OvenBakeLights;

	public GameObject OvenBakeLights_Orange;

	public GameObject OvenBakeLights_Green;

	public AudioSource OvenBakingSound;

	public AudioSource OvenBakingDoneSound;

	public Slider BakeProgressSlider;

	public Image BakeProgressSliderImage;

	public Gradient colorBlend;

	[SerializeField]
	private OvenDoor m_OvenDoor;

	[SerializeField]
	private OvenStartButton m_OvenStartButton;

	private List<DisplaySlot> m_DisplaySlots;

	private Display m_Display;

	private Baker m_CurrentBaker;

	private StateMachine m_StateMachine;

	private IdleState m_IdleState;

	private BakingState m_BakingState;

	private NetworkOven m_NetworkOven;

	[SerializeField]
	private List<Transform> m_IdlePoints;

	[SerializeField]
	private bool m_DebugIdleVisualization;

	public OvenStartButton OvenStartButton => null;

	public NetworkOven NetworkOven => null;

	public OvenDoor OvenDoor => null;

	public Display Display => null;

	public List<Transform> IdlePoints
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool IsBaking()
	{
		return false;
	}

	public void OvenDoorControl(bool IsOvenDoorOpen)
	{
	}

	public void OvenDoorControl_Response(bool IsOvenDoorOpen)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDisplayPlaced()
	{
	}

	public Transform GetIdlePoint()
	{
		return null;
	}

	private void VisualizeIdleSelection()
	{
	}

	public void ToggleBakeryLights(bool isOn)
	{
	}

	private void ReorderProducts()
	{
	}

	private void Start()
	{
	}

	public void NetworkReorder()
	{
	}

	private void Update()
	{
	}

	public void SetIdleState()
	{
	}

	public void SetBakeState()
	{
	}

	public void SwitchOvenDoor(bool isOpen)
	{
	}

	private void OnFurnitureStartPlacingMode(GameObject obj)
	{
	}

	private void OnProductRemoved(DisplaySlot slot)
	{
	}

	public void ReleaseBaker()
	{
	}

	public void SetBaker(Baker baker)
	{
	}

	public Baker GetBaker()
	{
		return null;
	}

	public List<OvenProduct> GetProductsInOven()
	{
		return null;
	}

	public bool HasProduct()
	{
		return false;
	}

	public bool IsDoorAvailable()
	{
		return false;
	}

	public void StartBake()
	{
	}

	public bool IsBakeAvailable()
	{
		return false;
	}

	public int StartBake_Response()
	{
		return 0;
	}

	public void AnimateBakeButton_Network()
	{
	}

	public void StartBake_Network()
	{
	}

	public void FinishBake()
	{
	}

	public void FinishBake_Response()
	{
	}

	public void FinishBakeProducts()
	{
	}

	public List<DisplaySlot> GetDisplaySlots()
	{
		return null;
	}

	public bool HasBakedProduct()
	{
		return false;
	}

	public bool IsBakingConditionDone()
	{
		return false;
	}
}
