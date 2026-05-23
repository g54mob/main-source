using System.Collections.Generic;
using PolyAndCode.UI;
using UnityEngine;

public class AssetManagement : MonoBehaviour, IRecyclableScrollRectDataSource
{
	[SerializeField]
	private RecyclableScrollRect _recyclableScrollRect;

	[SerializeField]
	private int _dataLength;

	private bool firstInit;

	private int currentFilter;

	private List<AssetManagementDeviceLineData> deviceList;

	private List<AssetManagementDeviceLineData> switchList;

	private List<AssetManagementDeviceLineData> serverList;

	private List<AssetManagementDeviceLineData> brokenList;

	private List<AssetManagementDeviceLineData> eolList;

	private List<AssetManagementDeviceLineData> offList;

	public int GetItemCount()
	{
		return 0;
	}

	public void SetCell(ICell cell, int index)
	{
	}

	private void OnEnable()
	{
	}

	public void ButtonFilterAll()
	{
	}

	public void ButtonFilterSwitches()
	{
	}

	public void ButtonFilterServers()
	{
	}

	public void ButtonFilterBroken()
	{
	}

	public void ButtonFilterEOL()
	{
	}

	public void ButtonFilterOff()
	{
	}
}
