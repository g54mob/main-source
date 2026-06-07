using System;
using UnityEngine;

public class MVerseManager : MonoBehaviour
{
	public static MVerseManager instance;

	[NonSerialized]
	public MVersePlayerPrefab playerPrefab;

	public GameObject mverseNetworkManager;

	public GameObject mverseNetworkManagerLAN;

	public GameObject mverseEOSSDKComponent;

	public MVerseHosting.InviteKey clientInviteKey;

	public string lastAuthResponse;

	private void Awake()
	{
	}

	public MVerseNetworkManager GetManager()
	{
		return null;
	}

	public bool IsLAN()
	{
		return false;
	}

	public void Reset()
	{
	}
}
