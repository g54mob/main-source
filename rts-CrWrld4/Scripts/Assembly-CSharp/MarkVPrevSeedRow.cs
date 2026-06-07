using System;
using TMPro;
using UnityEngine;

public class MarkVPrevSeedRow : MonoBehaviour
{
	public TextMeshProUGUI seedText;

	[NonSerialized]
	public bool selectable;

	[NonSerialized]
	public MarkVPrevSeeds markVPrevSeeds;

	private string _seed;

	public string seed
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
