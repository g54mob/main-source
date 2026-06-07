using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MVersePlayerBadge : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public RawImage image;

	public Image playImage;

	public TextMeshProUGUI playerNameText;

	public TextMeshProUGUI timeText;

	public TextMeshProUGUI speedText;

	public TextMeshProUGUI chatText;

	public Image selectionIndicator;

	public Toggle miniMapToggle;

	public GameObject delayIndicator;

	public TextMeshProUGUI latencyText;

	public TextMeshProUGUI upsText;

	public TextMeshProUGUI natText;

	[NonSerialized]
	public MVersePlayerPrefab player;

	private byte[] mmData;

	private GameObject unitContainer;

	private int _playerNum;

	private double _latency;

	private int _ups;

	private byte _natType;

	private bool _selected;

	private int lagCounter;

	public int playerNum
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public double latency
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	public int ups
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte natType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static Color GetPlayerColor(int playerNum, bool full)
	{
		return default(Color);
	}

	public static string GetUnitContainerName(uint netId)
	{
		return null;
	}

	public void Init(MVersePlayerPrefab player, string playerName, int gameTime, int gameSpeed, bool gamePlaying)
	{
	}

	public void IndicateLag()
	{
	}

	public void Update()
	{
	}

	public void SetUnitContainerActive(bool selected)
	{
	}

	public void SetGameTime(int val)
	{
	}

	public void SetGameSpeed(int val)
	{
	}

	public void SetPlayerName(string val)
	{
	}

	public void SetGamePlaying(bool val)
	{
	}

	public void OnDestroy()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
