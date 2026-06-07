using UnityEngine;
using UnityEngine.UI;

public class JumperWireMobileTool : WireBaseMobileTool
{
	private static JumperWireMobileTool inst;

	[Header("Materials")]
	public Material[] materials;

	[Header("Static Batching")]
	public GameObject jumperWireBatch;

	[Header("Color Selection")]
	public GameObject colorSelectionGameobject;

	public Image colorImage;

	private int currentColId;

	public static Material[] Materials => null;

	public override void Awake()
	{
	}

	public static void IPC_Initialise(int colId)
	{
	}

	public static void IPC_UpdateProperty(int colId)
	{
	}

	private void _IPC_Initialise(int colId)
	{
	}

	public override void CompleteCreate()
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

	public override void RedoValueChanges(params object[] args)
	{
	}

	public override void UndoValueChanges(params object[] args)
	{
	}

	public override void Initialise()
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

	public override void SwitchMethod()
	{
	}

	public override void CancelCurrent()
	{
	}

	public override void CancelCreation()
	{
	}
}
