using System.IO.MemoryMappedFiles;
using UnityEngine;

public class MicroControllerTool : PinBasedMobileTool
{
	public static MicroControllerTool inst;

	private MemoryMappedFile mmf;

	private MemoryMappedViewStream mmvStream;

	[Header("Code Editor")]
	public CodeEditor codeEditor;

	public override void Awake()
	{
	}

	public static void IPC_BeginCreate()
	{
	}

	private void IPC_ApplyChanges()
	{
	}

	private void IPC_CancelEdit()
	{
	}

	public override void BeginCreate()
	{
	}

	public static string CurrentCode()
	{
		return null;
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public override void CancelEdit()
	{
	}

	public void OpenProperties()
	{
	}

	public MicroController GetMC()
	{
		return null;
	}

	public static void IPC_UpdateProperty(string code)
	{
	}

	public void IPC_UpdateCode(string code)
	{
	}

	public void CodeUpdated()
	{
	}
}
