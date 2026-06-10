using System;
using TMPro;
using UnityEngine;

public class WizcardStats : MonoBehaviour
{
	[Flags]
	public enum CopyStat
	{
		None = 0,
		Attack = 1,
		Health = 2,
		Both = 3
	}

	private BoardSpace boardSpace;

	private TextMeshProUGUI textMeshPro;

	public CopyStat copyStat;

	private void Start()
	{
	}

	public void UpdateStats()
	{
	}
}
