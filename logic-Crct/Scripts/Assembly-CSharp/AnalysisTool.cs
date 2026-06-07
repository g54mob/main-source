using UnityEngine;
using UnityEngine.UI;

public class AnalysisTool : MonoBehaviour
{
	private static AnalysisTool inst;

	public Material analysisMat;

	[Header("View Type")]
	public Text viewTypeText;

	public static ViewType viewType;

	[Header("Floor")]
	public Renderer floorRend;

	public Material floorStdMat;

	public Material floorXrayMat;

	[Header("GridLines")]
	public GridLines gridLines;

	public Color changeValue;

	[Header("Material Override")]
	public Material materialOverride;

	[Header("Current Display")]
	public Canvas analysisCanvas;

	public Gradient voltageGradient;

	public Gradient currentGradient;

	public AnimationCurve currentCurve;

	public Texture2D gradientTex;

	public RawImage gradientDisplay;

	public Text maxValText;

	public Text minValText;

	public float currentLogBase;

	private Color glMajorColor;

	private Color glMinorColor;

	private float maxVal;

	private float minVal;

	public static Material AnalysisMat => null;

	public static void SetViewType(ViewType viewt)
	{
	}

	public static void VoltageDisplay()
	{
	}

	public static void CurrentDisplay()
	{
	}

	public void SwitchViewType()
	{
	}

	public static void AnalysisOff()
	{
	}

	private void Update()
	{
	}

	public static Color VoltageColour(float val)
	{
		return default(Color);
	}

	public static Color CurrentColour(float val)
	{
		return default(Color);
	}

	private void Awake()
	{
	}

	private void CreateScaleTex2D(Gradient grad)
	{
	}

	private void ShowAnalysis(bool show)
	{
	}
}
