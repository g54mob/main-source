using System.IO.MemoryMappedFiles;
using UnityEngine;

public class ICMobileTool : ToolBase
{
	private static ICMobileTool inst;

	[Header("Prefabs")]
	public GameObject[] prefabs;

	public int pId;

	private MemoryMappedFile mmf;

	private MemoryMappedViewStream mmvStream;

	private readonly int compMask;

	private readonly int defMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public override void Awake()
	{
	}

	public static void IPC_BeginCreate(int pId)
	{
	}

	public static byte[] FetchEEPROM()
	{
		return null;
	}

	private void _IPC_BeginCreate(int pId)
	{
	}

	public static void IPC_UpdateEEPROM(byte[] data)
	{
	}

	public void BeginCreate(int pId)
	{
	}

	public BaseComponent GetEEPROM()
	{
		return null;
	}

	public void OpenEEPROMEditor()
	{
	}

	public override void EEPROMUpdated()
	{
	}

	public override void EEPROMUpdated(BaseComponent comp)
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void CancelCreation()
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

	public override void ApplyChanges()
	{
	}

	public override void CancelEdit()
	{
	}

	public override void Delete()
	{
	}

	public override void CreateFromSaveFile(params object[] args)
	{
	}

	public override void UndoDelete(params object[] args)
	{
	}

	public override void RedoCreate(params object[] args)
	{
	}

	public override void CreateFromVarData(params object[] args)
	{
	}

	public override void UndoValueChanges(params object[] args)
	{
	}

	public override void RedoValueChanges(params object[] args)
	{
	}

	public override void UpdateTransformValues()
	{
	}
}
