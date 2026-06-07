using Lean.Pool;
using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.WallPaintSystem;

public class IceCreamBucket : MonoBehaviour, IInteractable, IPoolable
{
	public const int k_Max = 50;

	[SerializeField]
	private Transform m_GraphicsContainer;

	[SerializeField]
	private Vector3 m_PositionOffset;

	[SerializeField]
	private Vector3 m_RotationOffset;

	[SerializeField]
	private BucketPlacingMode m_PlacingMode;

	[SerializeField]
	private SkinnedMeshRenderer m_FillRenderer;

	[SerializeField]
	private Renderer m_BucketRenderer;

	private bool m_IsHolding;

	private PhotonView m_PhotonView;

	private NetworkIceCreamBucket m_NetworkIceCreamBucket;

	public IceCreamFlavour Flavour => null;

	public IceCreamFlavourData Data { get; set; }

	public BucketPlacingMode PlacingMode => null;

	public IceCreamBucketBox OwnerBox { get; set; }

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint { get; }

	public string SecondInteractionHint { get; }

	public string RepairInteractionHint { get; }

	public PhotonView PhotonView => null;

	public NetworkIceCreamBucket NetworkIceCreamBucket => null;

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void Consume(int value, out int totalConsumed, bool fromPlayer)
	{
		totalConsumed = default(int);
	}

	public void UpdateGraphics()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public void GrabThis(PlayerInstance playerInstance)
	{
	}

	public void GrabThisOrder(PlayerInstance playerInstance)
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

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public void Despawn()
	{
	}

	public void ResetHolding()
	{
	}

	public void Initialize(IceCreamFlavourData iceCreamFlavourData)
	{
	}
}
