using UnityEngine;
using UnityEngine.UI;

public class TransistorMobileTool : PinBasedMobileTool
{
	public static TransistorMobileTool inst;

	[Header("Vars")]
	public double beta;

	public int type;

	public InputField betaInput;

	public Dropdown typeDropdown;

	private Transistor t;

	public override void Awake()
	{
	}

	public static void IPC_BeginCreate(double b, int t)
	{
	}

	private void _IPC_BeginCreate(double b, int t)
	{
	}

	public static void IPC_UpdateProperty(double b, int t)
	{
	}

	public override void CancelEdit()
	{
	}

	public override void BeginCreate()
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

	private Transistor GetTransistor()
	{
		return null;
	}

	public void OpenProperties()
	{
	}

	public void EndEditBeta()
	{
	}

	public void ChangeType()
	{
	}
}
