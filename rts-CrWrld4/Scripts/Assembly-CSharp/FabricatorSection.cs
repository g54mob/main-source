using System;
using UnityEngine;
using UnityEngine.UI;

public class FabricatorSection : MonoBehaviour
{
	public RawImage wareImage;

	public Text wareAmtText;

	public Dropdown wareDropdown;

	public int sectionNum;

	private int[] wareNums;

	[NonSerialized]
	public Fabricator fabricator;

	private void OnDisable()
	{
	}

	public void SetWares(int[] wareNums)
	{
	}

	public void SetWare(int wareNum)
	{
	}

	public int GetWare()
	{
		return 0;
	}

	public void OnWareChanged(int index)
	{
	}

	private void RefreshImage(int wareNum)
	{
	}
}
