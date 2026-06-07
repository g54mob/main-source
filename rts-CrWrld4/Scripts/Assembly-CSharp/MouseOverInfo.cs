using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverInfo : MonoBehaviour
{
	public Image terrainBar;

	public Image creeperBar;

	public Image breederCreeperBar;

	public Image breederACBar;

	public Text terrainText;

	public Text creeperText;

	public Text breederCreeperText;

	public Text breederACText;

	public Text posText;

	public Text fpsText;

	public Text fpsTitle;

	public GameObject breederCreeperContainer;

	public GameObject breederACContainer;

	public GameObject specialContainer;

	public GameObject ecoContainer;

	public Text specialText;

	public Text specialText2;

	public Image specialBackground;

	public GameObject inhibitorStateGraph;

	public TextMeshProUGUI inhibitorStateGraphPercent;

	public RectTransform inhibitorStateGraphBar;

	public GameObject burstButton;

	private Image inhibitorStateGraphBarImage;

	public GameObject cutoffMeter;

	public GameObject infoGraph;

	public GameObject infoGraphHitImage;

	private int lastCellX;

	private int lastCellY;

	public Color creeperBarColor;

	public Color acBarColor;

	private bool lastThrottledFrameRate;

	private Color normalRateColor;

	private Color throttledRateColor;

	private bool _moveTextRight;

	private bool moveTextRight
	{
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	private void Refresh()
	{
	}
}
