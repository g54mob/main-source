using System;
using System.IO;
using TMPro;
using UnityEngine;

public class MissionPanelLoadBoxRow : MonoBehaviour
{
	public TextMeshProUGUI missionName;

	public TextMeshProUGUI missionTime;

	[NonSerialized]
	public bool selectable;

	[NonSerialized]
	public MissionPanelLoadBox missionPanelLoadBox;

	private float lastClickTime;

	private bool _selected;

	private FileInfo _file;

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

	public FileInfo file
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void OnLoad()
	{
	}
}
