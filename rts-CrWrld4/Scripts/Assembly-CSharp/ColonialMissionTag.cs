using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColonialMissionTag : MonoBehaviour
{
	public TextMeshProUGUI text;

	public Image thumbsUp;

	public Image thumbsDown;

	[NonSerialized]
	public ColonyMissionDetail colonialMissionDetail;

	private string _mytag;

	private int _voteState;

	public string mytag
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int voteState
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void OnClick()
	{
	}

	public void OnThumbsUp()
	{
	}

	public void OnThumbsDown()
	{
	}
}
