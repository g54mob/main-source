using System;
using System.Collections;
using Mirror;
using NBT.Tags;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MVerseHosting : MonoBehaviour
{
	public enum HOSTING_MODE
	{
		NONE = 0,
		INTERNET = 1,
		LAN = 2
	}

	public class InviteKey
	{
		public string connectLoc;

		public bool connectLAN;

		public int key;

		public string user;

		public bool validKey;

		public InviteKey()
		{
		}

		public InviteKey(string connectLoc, bool connectLAN, int key, string user)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void ReadData(Tag data)
		{
		}

		private TagCompound WriteData()
		{
			return null;
		}

		public string ExportInviteKey()
		{
			return null;
		}

		public void ImportInviteKey(string invitekey)
		{
		}

		public static string ArrayToBase64String(byte[] data)
		{
			return null;
		}

		public static byte[] Base64StringToArray(string encoded)
		{
			return null;
		}
	}

	public GameObject initializingPane;

	public GameObject controls;

	public GameObject disallowedPane;

	public Toggle internetToggle;

	public Toggle lanToggle;

	public TMP_InputField ipOverride;

	private float startTime;

	private string _currentInviteKey;

	[NonSerialized]
	public NetworkManager manager;

	private HOSTING_MODE _hostingMode;

	private float CONNECTTIMEOUT;

	public string currentInviteKey
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public HOSTING_MODE hostingMode
	{
		get
		{
			return default(HOSTING_MODE);
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void OnStartHosting()
	{
	}

	private void OnStartHostingInternet()
	{
	}

	private IEnumerator OnStartHostingInternetCo()
	{
		return null;
	}

	public void OnFinishStartHostingInternet()
	{
	}

	private void OnStartHostingLAN()
	{
	}

	public void OnStopHosting()
	{
	}

	private int GetRandomKey()
	{
		return 0;
	}

	private string GetInviteKey()
	{
		return null;
	}

	private string GetAddress()
	{
		return null;
	}
}
