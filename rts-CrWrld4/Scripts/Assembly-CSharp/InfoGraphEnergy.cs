using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class InfoGraphEnergy : MonoBehaviour
{
	public enum DISPLAY_MODE
	{
		TOTAL = 0,
		DELTA = 1
	}

	public const float INFO_GRAPH_WIDTH = 180f;

	public GameObject eventLinePrefab;

	public Transform eventLineContainer;

	public GameObject eventInfoPanel;

	public Text eventInfoText;

	public Image totalBorder;

	public Image deltaBorder;

	private List<InfoGraphEventLine> eventLines;

	public UILineRenderer energyProductionLineRenderer;

	public UILineRenderer energyUsedLineRenderer;

	public UILineRenderer energyDeficitLineRenderer;

	public Text energyProducedText;

	public Text energyUsedText;

	public Text energyDeficitText;

	private Vector2[] epLinePoints;

	private Vector2[] euLinePoints;

	private Vector2[] edLinePoints;

	private float xDelta;

	private InfoGraphEventLine currentEventLine;

	private int eventVerticalPos;

	private Color selectedButtonColor;

	private Color unselectedButtonColor;

	private DISPLAY_MODE _DisplayMode;

	private int lastAddEventLineTime;

	private int lastEventLogCount;

	private int lastNewDataCount;

	public DISPLAY_MODE DisplayMode
	{
		get
		{
			return default(DISPLAY_MODE);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void RemoveEventLine(InfoGraphEventLine el)
	{
	}

	private void LateUpdate()
	{
	}

	private double Max(double a, double b, double c)
	{
		return 0.0;
	}

	private void UpdateGraph(bool force)
	{
	}

	private int GetTime()
	{
		return 0;
	}

	public void OnDisplayModeTotalClicked()
	{
	}

	public void OnDisplayModeDeltaClicked()
	{
	}
}
