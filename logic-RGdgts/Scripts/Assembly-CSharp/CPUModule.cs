using System;
using System.Collections.Generic;

public class CPUModule : Module
{
	public enum Commands
	{
		UpdateSourceCode = 1,
		UpdateChannelBindings = 2
	}

	public int channelsCount;

	private ModuleProperty eventChannelsProperty;

	protected static MultitoolConsoleService console;

	private ModuleProperty sourceProperty;

	private ModuleProperty timeProperty;

	private ModuleProperty deltaTimeProperty;

	private Dictionary<int, Module> channelBindings;

	private Dictionary<IntPtr, AsyncJobHandle> asyncJobs;

	public bool isPausedFromDebugger => false;

	public string compileError => null;

	public LuaRuntimeException runtimeException => null;

	public CpuStatus scriptStatus => default(CpuStatus);

	protected override void OnSetupFinished()
	{
	}

	public override void ApplyPermanentStorage(Storage storage, Storage permanentOnlyStorage = null)
	{
	}

	private void SetupChannelsProperties()
	{
	}

	public void Start()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	private void UpdateSourceCode()
	{
	}

	private void UpdateChannelBindings()
	{
	}

	protected override void OnUnsolder()
	{
	}

	protected override void OnSolder()
	{
	}

	public override void OnTurnOn()
	{
	}

	public override void OnTurnOff()
	{
	}

	public override void OnDebugBreak(LuaStacktrace stacktrace)
	{
	}

	public CodeAsset GetCodeAsset()
	{
		return null;
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public override TickLoop.UpdateResult OnTickUpdate(float deltaTime, float maxTime)
	{
		return default(TickLoop.UpdateResult);
	}

	public void OnModuleEvent<T>(int channelIndex, Module sender, T eventData) where T : EventData
	{
	}

	public void RegisterAsyncJob(AsyncJobHandle asyncJob)
	{
	}

	public void UnregisterAsyncJob(AsyncJobHandle asyncJob)
	{
	}

	private void DisposeAllAsyncJobs()
	{
	}

	public static void Script_LogInfo(string message)
	{
	}

	public static void Script_LogWarning(string message)
	{
	}

	public static void Script_LogError(string message)
	{
	}

	public static void Script_Write(string text)
	{
	}

	public static void Script_WriteLine(string text)
	{
	}

	public static void Script_SetFgColor(int colorId)
	{
	}

	public static void Script_SetBgColor(int colorId)
	{
	}

	public static void Script_ResetFgColor()
	{
	}

	public static void Script_ResetBgColor()
	{
	}

	public static void Script_ResetColors()
	{
	}

	public static void Script_SetCursorPos(int column, int line)
	{
	}

	public static void Script_SetCursorX(int column)
	{
	}

	public static void Script_SetCursorY(int line)
	{
	}

	public static void Script_MoveCursorX(int deltaColumn)
	{
	}

	public static void Script_MoveCursorY(int deltaLine)
	{
	}

	public static void Script_SaveCursorPosition()
	{
	}

	public static void Script_RestoreCursorPosition()
	{
	}

	public static void Script_Clear()
	{
	}

	public static void Script_ClearToEndLine()
	{
	}
}
