using System.Collections.Generic;
using UnityEngine;

public class DetailedDevice : MonoBehaviour
{
	public enum TearDownType
	{
		Unscrew = 0,
		TearDown = 1,
		Desolder = 2,
		RemoveChip = 3
	}

	public List<TearDownType> progress;

	public GameObject baseShell;

	public GameObject[] coverShell;

	public GameObject[] screws;

	public GameObject pcb;

	public GameObject chips;
}
