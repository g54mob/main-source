using Photon.Pun;
using UnityEngine;

[DisallowMultipleComponent]
public class PhotonNetworkStatsManager : MonoBehaviourPunCallbacks
{
	[Header("Genel Ayarlar")]
	public bool resetStatsOnStart;

	public float logInterval;

	[Header("Eşik Değerler (Byte/s)")]
	public int outgoingThreshold;

	public int incomingThreshold;

	[Header("Ping Eşiği (ms)")]
	public int pingThreshold;

	private float _timer;

	private long _lastOutPacketsBytes;

	private long _lastInPacketsBytes;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
