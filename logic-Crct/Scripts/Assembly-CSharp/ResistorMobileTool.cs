using UnityEngine;
using UnityEngine.UI;

public class ResistorMobileTool : WireBaseMobileTool
{
	[Header("Resistor Vars")]
	public float ohms;

	public float maxPower;

	public InputField ohmsInput;

	public InputField maxPowerInput;

	public Image[] bands;

	[Header("Bands")]
	public Color[] bandColours;

	private Resistor r;

	private static ResistorMobileTool inst { get; set; }

	public static Color[] BandColours => null;

	public override void Awake()
	{
	}

	public static void IPC_Initialise(float o, float mp)
	{
	}

	private void _IPC_Initialise(float o, float mp)
	{
	}

	public static void IPC_UpdateProperty(float ohms, float maxPower)
	{
	}

	public override void CancelEdit()
	{
	}

	private void UpdateBandColours(ref Image[] bands, float ohms)
	{
	}

	public override void Initialise()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	private Resistor GetResistor()
	{
		return null;
	}

	public void OpenProperties()
	{
	}

	public void EndEditOhms()
	{
	}

	public void EndEditMaxPower()
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
