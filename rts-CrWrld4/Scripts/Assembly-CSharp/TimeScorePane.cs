using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScorePane : MonoBehaviour
{
	public TextMeshProUGUI missionTitle;

	public Text timeText;

	public Text militaryText;

	public Text ecoText;

	public Text unitsBuiltText;

	public Text unitsLostText;

	public Text peakCreeperText;

	public Text eggsTitle;

	public Text eggsText;

	private int lastUpdateCount;

	private float lastEco;

	private int lastUnitsBuilt;

	private int lastUnitsLost;

	private long lastPeakCreeper;

	private int lastEggs;

	private float lastStump;

	private int lastScore;

	public const float UNIT_BURDEN = 30f;

	public const float SCAPE_COST = 1f;

	public void Start()
	{
	}

	public void LateUpdate()
	{
	}

	public void RefreshTitle()
	{
	}
}
