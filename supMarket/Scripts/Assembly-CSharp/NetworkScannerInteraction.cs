using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkScannerInteraction : NetworkInteraction
{
	private ScannerInteraction m_ScannerInteraction;

	[SerializeField]
	private GameObject m_FakeScannerDevice;

	[SerializeField]
	private ScannerDevice m_ScannerDevice;

	private new PlayerInstance m_PlayerInstance;

	private PhotonView m_PhotonView;

	public PhotonView PhotonView => null;

	public PlayerInstance PlayerInstance => null;

	private void Awake()
	{
	}

	public void DestroyScannerDevice()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance _instance)
	{
	}

	protected override void Initialize()
	{
	}

	private void SyncCheckoutState_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncScannerInteractionState_RPC()
	{
	}

	public void ToggleFakeScanner_Broadcast(bool value)
	{
	}

	[PunRPC]
	public void ToggleFakeScanner_RPC(bool value)
	{
	}

	public void OpenFakeScanner(bool _isOpen)
	{
	}
}
