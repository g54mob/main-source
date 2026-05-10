using UnityEngine;

public class IceCreamInteraction : Interaction
{
	[SerializeField]
	private IceCreamSpoonGraphics m_SpoonGraphics;

	private NetworkIceCreamStand m_NetworkStand;

	private IceCreamCone m_HeldCone;

	[SerializeField]
	private Transform m_ConeHandContainer;

	private PlayerInstance m_PlayerInstance;

	private IceCreamConeInteractable m_ConeInteractable;

	private IceCreamFlavourInteractable m_FlavourInteractable;

	private Customer m_TargetCustomer;

	private IceCreamTrashBin m_TargetTrashBin;

	private Camera m_MainCamera;

	private const float k_RaycastDistance = 5f;

	private bool m_IsMouseHeld;

	private float m_HoldTimer;

	private const float k_HoldDuration = 1f;

	private NetworkIceCreamInteraction m_NetworkInteraction;

	private IceCreamToppingInteractable m_TargetTopping;

	public IceCreamSpoonGraphics SpoonGraphics => null;

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

	public bool HasCone => false;

	public IceCreamCone Cone => null;

	private PlayerInstance PlayerInstance => null;

	public NetworkIceCreamInteraction NetworkIceCreamInteraction => null;

	public IceCreamStand ControlledStand { get; set; }

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClose()
	{
	}

	private void BoxUpStand()
	{
	}

	private void OnRotated(bool clockwise)
	{
	}

	private void OnUsed(bool isDown)
	{
	}

	private void PlaceFurniture()
	{
	}

	public void PlaceFurnitureOrder(Vector3 playSoundPosition)
	{
	}

	private void OnBack()
	{
	}

	private void ResetCustomerTarget()
	{
	}

	private bool TryUpdateCustomerTarget(RaycastHit hit)
	{
		return false;
	}

	private T ResetInteractable<T>(T target) where T : MonoBehaviour
	{
		return null;
	}

	private bool TrySetInteractable<T>(RaycastHit hit, T current, out T result) where T : MonoBehaviour
	{
		result = null;
		return false;
	}

	private void LookForInteractables()
	{
	}

	private void Update()
	{
	}

	public void AddConeAndAnimate(IceCreamCone coneInstance)
	{
	}

	public void AddCone(IceCreamCone coneInstance)
	{
	}

	public void HandIceCream(Customer customer)
	{
	}

	public void RemoveCone()
	{
	}

	public void BoxUpStandNetwork()
	{
	}

	public void OnBackOrder()
	{
	}

	public void SetIdleHints()
	{
	}

	public void SetConeInteractionHints()
	{
	}

	public void SetToppingInteractionHints()
	{
	}

	public void SetFlavourInteractionHints()
	{
	}

	public void SetIceCreamTrashHints()
	{
	}

	public void SetCustomerInteractionHints()
	{
	}

	public void ToggleSpoonGraphics(bool value)
	{
	}

	public void CancelInteractionForOnlyMultiplayer()
	{
	}
}
