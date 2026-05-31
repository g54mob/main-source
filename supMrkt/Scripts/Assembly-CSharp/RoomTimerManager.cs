using ExitGames.Client.Photon;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomTimerManager : MonoBehaviourPunCallbacks
{
	[SerializeField]
	private TextMeshProUGUI timerText;

	private double roomStartTime;

	private bool timeSynced;

	private const string ROOM_START_TIME_KEY = "roomStartTime";

	private void Start()
	{
	}

	public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
	{
	}

	public override void OnJoinedRoom()
	{
	}

	private void Update()
	{
	}
}
