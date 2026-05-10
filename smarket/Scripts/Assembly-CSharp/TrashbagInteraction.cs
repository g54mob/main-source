using Photon.Pun;
using UnityEngine;

public class TrashbagInteraction : Interaction
{
	[SerializeField]
	private LayerMask m_TrashBagInteractionLayer;

	[SerializeField]
	private Camera m_ToolCamera;

	[SerializeField]
	private float m_MaxRaycastDistance;

	private Garbage m_Garbage;

	private Camera m_MainCamera;

	private bool m_IsTrashCan;

	public TrashBag m_TrashBag;

	private PlayerInstance m_PlayerInstance;

	private PhotonView _photonView;

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

	private PlayerInstance PlayerInstance => null;

	public PhotonView PhotonView => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnUse(bool down)
	{
	}

	public void EnableTrashBag()
	{
	}

	public void CheckForInteraction()
	{
	}

	private void SetCurrentGarbage(Garbage garbage)
	{
	}

	private void DisableTrashBag()
	{
	}

	private void DisableLocal()
	{
	}

	[PunRPC]
	public void DisableTrashBag_RPC(string userID)
	{
	}

	private void GarbageHint(bool show)
	{
	}

	private void TrashCanHint(bool show)
	{
	}
}
