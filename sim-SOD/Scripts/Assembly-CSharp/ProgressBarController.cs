using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
	public delegate void ValueChange(float newValue, int percentage);

	public string barName;

	public float value;

	public float secondaryValue;

	public float barMin;

	public float barMax;

	public float progress;

	public float secondaryProgress;

	private int progressInt;

	public bool usePips;

	public GameObject pipObject;

	public int pipValue;

	public int pipNumber;

	public bool useSecondaryPipValue;

	public int secondaryPipValue;

	public bool displayProgress;

	public bool displayPercentageSign;

	public bool setNameOnStart;

	public bool useFloorValueForPercent;

	public RectTransform rect;

	public TextMeshProUGUI barTitle;

	public TextMeshProUGUI progressText;

	public RectTransform barRect;

	public RectTransform progressRect;

	private RectTransform progressTextRect;

	private float pipXSize;

	public List<ProgressBarPipController> pips;

	public ProgressBarPipController hoverOverPip;

	public event ValueChange OnProgressChange
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	public void SetupPips()
	{
	}

	private void Start()
	{
	}

	public void SetName(string newName)
	{
	}

	public void SetValue(float setTo)
	{
	}

	public void SetSecondaryValue(float setTo)
	{
	}

	public void VisualUpdate()
	{
	}
}
