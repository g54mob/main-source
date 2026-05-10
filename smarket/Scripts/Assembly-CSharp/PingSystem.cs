using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PingSystem : MonoBehaviourPun
{
	[SerializeField]
	private float spamCooldown;

	[SerializeField]
	private LayerMask raycastMask;

	[SerializeField]
	private float maxDistance;

	[SerializeField]
	private PingMarker markerPrefab;

	[SerializeField]
	private int poolSize;

	[SerializeField]
	private float pingTTL;

	[SerializeField]
	private float surfaceOffset;

	[SerializeField]
	private float cameraPull;

	private readonly Queue<PingMarker> _pool;

	private readonly Dictionary<string, PingMarker> _activeByUserID;

	private float _lastSendTime;

	private Camera _cam;

	private void Awake()
	{
	}

	public void OnPingInput(InputAction.CallbackContext context)
	{
	}

	private void TryPing()
	{
	}

	[PunRPC]
	private void RPC_SpawnPing(Vector3 pos, string userID)
	{
	}

	private PingMarker Get()
	{
		return null;
	}

	private void OnMarkerDespawn(PingMarker m)
	{
	}

	private void Prewarm()
	{
	}

	private void Expand(int count)
	{
	}

	private static Color GetPlayerColor(string userID)
	{
		return default(Color);
	}
}
