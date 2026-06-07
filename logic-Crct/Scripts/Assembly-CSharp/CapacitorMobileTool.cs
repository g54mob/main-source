using UnityEngine;
using UnityEngine.UI;

public class CapacitorMobileTool : WireBaseMobileTool
{
	public static CapacitorMobileTool inst;

	[Header("Capacitor Vars")]
	public double farads;

	public int type;

	public InputField faradsInput;

	public Dropdown unitInput;

	public Dropdown typeInput;

	private Capacitor cap;

	public override void Awake()
	{
	}

	public static void IPC_Initialise(double f, int t)
	{
	}

	private void _IPC_Initialise(double f, int t)
	{
	}

	public static void IPC_UpdateProperty(double f, int t)
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

	private Capacitor GetCapacitor()
	{
		return null;
	}

	public void OpenProperties()
	{
	}

	public void EndEditFarads()
	{
	}

	public void UnitChanged()
	{
	}

	public void TypeChanged()
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
