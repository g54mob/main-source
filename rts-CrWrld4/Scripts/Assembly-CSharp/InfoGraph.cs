using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class InfoGraph : MonoBehaviour
{
	public enum DISPLAY_MODE
	{
		TOTAL = 0,
		DELTA = 1,
		COVER = 2
	}

	public const float INFO_GRAPH_WIDTH = 190f;

	public GameObject eventLinePrefab;

	public Transform eventLineContainer;

	public GameObject eventInfoPanel;

	public Text eventInfoText;

	public GameObject horizontalLine;

	public Image totalBorder;

	public Image deltaBorder;

	public Image coverBorder;

	public Text titleText;

	private List<InfoGraphEventLine> eventLines;

	public UILineRenderer creeperLineRenderer;

	public UILineRenderer acLineRenderer;

	public UILineRenderer creeperAvgLineRenderer;

	public UILineRenderer acAvgLineRenderer;

	public Text creeperText;

	public Text acText;

	private Vector2[] creeperLinePoints;

	private Vector2[] acLinePoints;

	private Vector2[] creeperAvgLinePoints;

	private Vector2[] acAvgLinePoints;

	private float xDelta;

	private InfoGraphEventLine currentEventLine;

	private int eventVerticalPos;

	private Color selectedButtonColor;

	private Color unselectedButtonColor;

	private DISPLAY_MODE _DisplayMode;

	private int lastAddEventLineTime;

	private Color32 unitDestroyedEventColor;

	private Color32 unitBuildingDestroyedEventColor;

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

	private InfoGraphEventLine AddEventLine(Color color)
	{
		return null;
	}

	public void RemoveEventLine(InfoGraphEventLine el)
	{
	}

	private void LateUpdate()
	{
	}

	private void UpdateGraph(bool force)
	{
	}

	private float GetDeltaVal(double val)
	{
		return 0f;
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

	public void OnDisplayModeCoverClicked()
	{
	}
}
