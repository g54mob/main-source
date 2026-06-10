using TMPro;
using UnityEngine;

public class EvidenceLocationalControls : MonoBehaviour
{
	public InfoWindow parentWindow;

	[Header("Location Controls")]
	public ButtonController locateOnMapButton;

	public ButtonController plotRouteButton;

	public ButtonController fastTravelButton;

	public JuiceController plotRouteJuice;

	public JuiceController autoTravelJuice;

	public bool fastTravelEnabled;

	[Header("Job Posting Controls")]
	public ButtonController acceptJobButton;

	public TextMeshProUGUI acceptJobText;

	[Header("Take Item Controls")]
	public ButtonController takeItemButton;

	public TextMeshProUGUI takeItemText;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnNewRoutePlotted()
	{
	}

	public void OnRouteRemoved()
	{
	}

	public void OnFastTravelStarted()
	{
	}

	public void OnFastTravelEnded()
	{
	}

	private void UpdateRouteTooltip()
	{
	}

	private void UpdateAutoTravelTooltip()
	{
	}

	public void CheckEnabled()
	{
	}

	private void UpdateFastTravelAvailability()
	{
	}

	public void OnLocateOnMap()
	{
	}

	public void OnPlotRoute()
	{
	}

	public void OnFastTravel()
	{
	}

	public void OnAcceptJob()
	{
	}

	public void OnTakeItem()
	{
	}
}
