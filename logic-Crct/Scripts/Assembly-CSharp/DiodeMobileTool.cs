using UnityEngine;
using UnityEngine.UI;

public class DiodeMobileTool : WireBaseMobileTool
{
	public DiodeType diodeType;

	[Header("Vars")]
	public double forwardVoltage;

	public double currentLeakage;

	public double maxCurrent;

	public double zVoltage;

	public int colorId;

	public InputField fVInput;

	public InputField leakageInput;

	public InputField maxIInput;

	public InputField zInput;

	private Diode d;

	private static DiodeMobileTool inst { get; set; }

	public override void Awake()
	{
	}

	public static void IPC_Initialise(double fV, double l, double zV, int t)
	{
	}

	private void _IPC_Initialise(double fV, double l, double zV, int t)
	{
	}

	public static void IPC_UpdateProperty(double fV, double l, double zV, int t)
	{
	}

	public override void CancelEdit()
	{
	}

	public void EndEditForwardVoltage()
	{
	}

	public void EndEditZVoltage()
	{
	}

	public void EndEditLeakage()
	{
	}

	public void EndEditMaxCurrent()
	{
	}

	public override void Initialise()
	{
	}

	public void InitialiseDiode(int type)
	{
	}

	public override void BeginCreate()
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	private Diode GetDiode()
	{
		return null;
	}

	public void OpenProperties()
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
