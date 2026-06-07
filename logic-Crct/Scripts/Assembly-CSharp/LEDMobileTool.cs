using UnityEngine;
using UnityEngine.UI;

public class LEDMobileTool : WireBaseMobileTool
{
	public Material[] ledMaterials;

	public float[] ledLighting;

	public Color[] ledColors;

	[Header("LED Vars")]
	public double forwardVoltage;

	public double maxCurrent;

	public int colorId;

	public InputField fVInput;

	public InputField maxIInput;

	[Header("Color Selection")]
	public GameObject colorSelectionGameobject;

	public Image colorImage;

	private LED led;

	private static LEDMobileTool inst { get; set; }

	public static Material[] LEDMaterials => null;

	public static float[] LEDLight => null;

	public override void Awake()
	{
	}

	public static void IPC_Initialise(double fV, double i, int c)
	{
	}

	private void _IPC_Initialise(double fV, double i, int c)
	{
	}

	public static void IPC_UpdateProperty(double fV, double i)
	{
	}

	public static void UpdateColor(int i)
	{
	}

	public override void CancelEdit()
	{
	}

	public override void Initialise()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public void OpenColorSelection()
	{
	}

	public void CloseColorSelection()
	{
	}

	public void ChangeColor(int id)
	{
	}

	private LED GetLED()
	{
		return null;
	}

	public void OpenProperties()
	{
	}

	public void EndEditVoltage()
	{
	}

	public void EndEditCurrent()
	{
	}

	public override void ProcessVarDataBegin()
	{
	}

	public override void ProcessVarDataComplete()
	{
	}

	public override void ProcessVarDataDrag()
	{
	}
}
