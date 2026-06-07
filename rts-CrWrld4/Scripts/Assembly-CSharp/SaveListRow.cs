using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveListRow : MonoBehaviour
{
	public TextMeshProUGUI missionName;

	public TextMeshProUGUI missionTime;

	[NonSerialized]
	public bool selectable;

	[NonSerialized]
	public SaveListBox saveListBox;

	private float lastClickTime;

	[NonSerialized]
	public ScrollRect scrollView;

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

	private void Start()
	{
	}

	public void OnClick()
	{
	}
}
