using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ADAMessageLogRow : MonoBehaviour
{
	public enum MESSAGE_TYPE
	{
		ASSESSMENT = 0,
		ANALYSIS = 1,
		INFOCACHE = 2,
		TRANSMISSION = 3,
		DATA = 4
	}

	public GameObject selectedBackground;

	public TMP_Text text;

	public Image icon;

	public GameObject unreadImage;

	public GameObject unreadBackground;

	[NonSerialized]
	public ADAMessageLog messageLog;

	private ADAMessages.RevealedMessage revealedMessage;

	private MESSAGE_TYPE _messageType;

	private string _key;

	private bool _selected;

	public MESSAGE_TYPE messageType
	{
		get
		{
			return default(MESSAGE_TYPE);
		}
		set
		{
		}
	}

	public string key
	{
		get
		{
			return null;
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

	public void Init(string key, MESSAGE_TYPE messageType)
	{
	}

	public void OnClick()
	{
	}
}
