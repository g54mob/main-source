using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyMissionPanel : MonoBehaviour
{
	public delegate void Function();

	[NonSerialized]
	public GalaxyMissionData gmd;

	[NonSerialized]
	public GameSpace.CATEGORY category;

	[NonSerialized]
	public int colonyID;

	public RawImage mapPreview;

	public TMP_Text mapTitle;

	public TMP_Text mapDesc;

	public GameObject playPane;

	public GameObject infoPane;

	public GameObject playLogPane;

	public PlayLogPanel playLogPanel;

	public MissionPanelLoadBox missionPanelLoadBox;

	public GameObject playSelectedIndicator;

	public GameObject infoSelectedIndicator;

	public GameObject playLogSelectedIndicator;

	public Text playText;

	public GameObject playSavedIndicator;

	private bool hasSavedMissions;

	private static Dictionary<string, int> viewState;

	public static bool IsEmbeddedCategory(GameSpace.CATEGORY category)
	{
		return false;
	}

	public void OnEnable()
	{
	}

	public void InvokeNextFrame(Function function)
	{
	}

	private IEnumerator _InvokeNextFrame(Function function)
	{
		return null;
	}

	public void Refresh()
	{
	}

	public void OnLaunch(string fileName)
	{
	}

	public void OnPlay()
	{
	}

	public void OnRestart()
	{
	}

	public void OnInfo()
	{
	}

	public void OnPlayLog()
	{
	}

	public void OnDisable()
	{
	}
}
