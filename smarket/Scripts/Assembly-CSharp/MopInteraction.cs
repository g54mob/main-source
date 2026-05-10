using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class MopInteraction : Interaction
{
	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private LayerMask m_MopInteractionLayer;

	[SerializeField]
	private float m_HoldingInteractionTime;

	[SerializeField]
	private Material m_AlienDirtMaterial;

	[SerializeField]
	private Camera m_ToolCamera;

	[SerializeField]
	private float m_MaxRaycastDistanceForward;

	[SerializeField]
	private float m_MaxRaycastDistanceDownward;

	[SerializeField]
	[Range(0f, 1f)]
	private float m_MovingObjectSmoothness;

	private Dirt m_Dirt;

	private ParticleSystem m_BubbleParticle;

	private Camera m_MainCamera;

	private bool m_HoldingUse;

	public bool m_IsFloorOrDirt;

	public Mop m_Mop;

	public ParticleSystem m_BubbleParticlePrefab;

	public Transform m_ParticleParent;

	private NetworkMopInteraction m_NetworkMopInteraction;

	private PlayerInstance m_PlayerInstance;

	public NetworkMopInteraction NetworkMopInteraction => null;

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

	public ParticleSystem BubbleParticle
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private PlayerInstance PlayerInstance => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void Awake()
	{
	}

	public void SwitchMop(bool isOpen, bool willAnimate)
	{
	}

	public void FakeSwitchMop(bool isOpen, bool willAnimate)
	{
	}

	public void CheckForInteraction()
	{
	}

	private void CheckHoldingInteraction()
	{
	}

	public void StopCleaningEffect()
	{
	}

	private void SetCurrentDirt(Dirt dirt)
	{
	}

	private void DirtHint(bool show)
	{
	}

	private void DefaultHints(bool show)
	{
	}

	public void CleanDirt(Dirt dirt)
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnBack()
	{
	}
}
