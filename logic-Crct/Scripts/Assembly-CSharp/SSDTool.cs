using UnityEngine;
using UnityEngine.UI;

public class SSDTool : PinBasedMobileTool
{
	public static SSDTool inst;

	[Header("7 Seg Display Vars")]
	public double maxCurrent;

	public double forwardVoltage;

	public bool anode;

	public InputField maxCurrentInput;

	public InputField fVoltageInput;

	public Dropdown typeDropdown;

	private SevenSegDisplay seg;

	public override void Awake()
	{
	}

	public static void IPC_BeginCreate(double fV, double maxI, int t)
	{
	}

	private void _IPC_BeginCreate(double fV, double maxI, int t)
	{
	}

	public static void IPC_UpdateProperty(double fV, double maxI, int t)
	{
	}

	public override void CancelEdit()
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

	private void IPC_ApplyChanges()
	{
	}

	private void IPC_CancelEdit()
	{
	}

	private SevenSegDisplay GetSeg()
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

	public void ChangeType()
	{
	}
}
