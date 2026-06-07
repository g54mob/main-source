using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RetroLauncher;
using UnityEngine;

public class RetroNativeCore : Controller
{
	[Serializable]
	public struct OsDesktopInfo
	{
		public RetroAgentInfo gameProcess;

		public RetroAgentInfo launcherProcess;

		public List<RetroAgentInfo> agents;
	}

	[Serializable]
	public struct RetroProcessInfo
	{
		public ulong processId;

		public ulong windowHwnd;
	}

	[Serializable]
	public struct RetroAgentInfo
	{
		public int gadgetType;

		public ulong gadgetId;

		public ulong processId;

		public ulong windowHwnd;

		public ulong permissionsMask;

		public ulong neededPermissionsMask;
	}

	[Serializable]
	public class CheckResult
	{
		public LuaTypeError[] errors;
	}

	public struct Callbacks
	{
		public delegate void Write(IntPtr value);

		public delegate void OnDebugBreak(uint moduleId, IntPtr stacktrace);

		public delegate string GetSourceCode(IntPtr namePtr);

		public delegate LuaNativeArray GetSourceBreakpoints(IntPtr namePtr);

		public delegate void OnCheckSourceResult(uint id, IntPtr resultPtr);

		public delegate void OnAutocompleteResult(uint id, IntPtr resultPtr);

		public delegate T GetProperty<T>(IntPtr propertyPtr);

		public delegate void SetProperty<T>(IntPtr propertyPtr, T value);

		public delegate T GetPropertyArray<T>(IntPtr propertyPtr, int index);

		public delegate void SetPropertyArray<T>(IntPtr propertyPtr, int index, T value);

		public delegate int GetPropertyArrayLength(IntPtr propertyPtr);

		public delegate T GetPropertyDictionary<T>(IntPtr propertyPtr, FromLuaString key);

		public delegate void SetPropertyDictionary<T>(IntPtr propertyPtr, FromLuaString key, T value);

		public delegate int GetPropertyDictionaryCount(IntPtr propertyPtr);

		public delegate LuaNativeTable GetPropertyDictionaryKeys(IntPtr propertyPtr);

		public delegate T GetPropertyMatrix2D<T>(IntPtr propertyPtr, int indexX, int indexY);

		public delegate void SetPropertyMatrix2D<T>(IntPtr propertyPtr, int indexX, int indexY, T value);

		public delegate int GetPropertyMatrix2DWidth(IntPtr propertyPtr);

		public delegate int GetPropertyMatrix2DHeight(IntPtr propertyPtr);

		public delegate ToLuaString GetAssetName(LuaAssetReference assetPtr);

		public delegate bool IsAssetValid(LuaAssetReference assetPtr);

		public Write write;

		public OnDebugBreak onDebugBreak;

		public GetSourceCode getSourceCode;

		public GetSourceBreakpoints getSourceBreakpoints;

		public OnCheckSourceResult onCheckSourceResult;

		public OnAutocompleteResult onAutocompleteResult;

		public GetProperty<bool> getPropertyBool;

		public GetProperty<ToLuaString> getPropertyString;

		public GetProperty<float> getPropertyNumber;

		public GetProperty<LuaSelection> getPropertySelection;

		public GetProperty<uint> getPropertyModuleId;

		public GetProperty<LuaAssetReference> getPropertyAsset;

		public GetProperty<Color> getPropertyColor;

		public GetProperty<Vector2> getPropertyVector2;

		public GetProperty<Vector3> getPropertyVector3;

		public GetProperty<ToLuaInputSource> getPropertyInputSource;

		public SetProperty<bool> setPropertyBool;

		public SetProperty<FromLuaString> setPropertyString;

		public SetProperty<float> setPropertyNumber;

		public SetProperty<LuaSelection> setPropertySelection;

		public SetProperty<uint> setPropertyModuleId;

		public SetProperty<LuaAssetReference> setPropertyAsset;

		public SetProperty<Color> setPropertyColor;

		public SetProperty<Vector2> setPropertyVector2;

		public SetProperty<Vector3> setPropertyVector3;

		public SetProperty<FromLuaInputSource> setPropertyInputSource;

		public GetPropertyArray<bool> getPropertyArrayBool;

		public GetPropertyArray<ToLuaString> getPropertyArrayString;

		public GetPropertyArray<float> getPropertyArrayNumber;

		public GetPropertyArray<LuaSelection> getPropertyArraySelection;

		public GetPropertyArray<uint> getPropertyArrayModuleId;

		public GetPropertyArray<LuaAssetReference> getPropertyArrayAsset;

		public GetPropertyArray<Color> getPropertyArrayColor;

		public GetPropertyArray<Vector2> getPropertyArrayVector2;

		public GetPropertyArray<Vector3> getPropertyArrayVector3;

		public GetPropertyArray<ToLuaInputSource> getPropertyArrayInputSource;

		public SetPropertyArray<uint> setPropertyArrayBool;

		public SetPropertyArray<FromLuaString> setPropertyArrayString;

		public SetPropertyArray<float> setPropertyArrayNumber;

		public SetPropertyArray<LuaSelection> setPropertyArraySelection;

		public SetPropertyArray<uint> setPropertyArrayModuleId;

		public SetPropertyArray<LuaAssetReference> setPropertyArrayAsset;

		public SetPropertyArray<Color> setPropertyArrayColor;

		public SetPropertyArray<Vector2> setPropertyArrayVector2;

		public SetPropertyArray<Vector3> setPropertyArrayVector3;

		public SetPropertyArray<FromLuaInputSource> setPropertyArrayInputSource;

		public GetPropertyArrayLength getPropertyArrayLength;

		public GetPropertyDictionary<bool> getPropertyDictionaryBool;

		public GetPropertyDictionary<ToLuaString> getPropertyDictionaryString;

		public GetPropertyDictionary<float> getPropertyDictionaryNumber;

		public GetPropertyDictionary<LuaSelection> getPropertyDictionarySelection;

		public GetPropertyDictionary<LuaAssetReference> getPropertyDictionaryAsset;

		public GetPropertyDictionary<Color> getPropertyDictionaryColor;

		public GetPropertyDictionary<Vector2> getPropertyDictionaryVector2;

		public GetPropertyDictionary<Vector3> getPropertyDictionaryVector3;

		public GetPropertyDictionary<ToLuaInputSource> getPropertyDictionaryInputSource;

		public SetPropertyDictionary<uint> setPropertyDictionaryBool;

		public SetPropertyDictionary<FromLuaString> setPropertyDictionaryString;

		public SetPropertyDictionary<float> setPropertyDictionaryNumber;

		public SetPropertyDictionary<LuaSelection> setPropertyDictionarySelection;

		public SetPropertyDictionary<LuaAssetReference> setPropertyDictionaryAsset;

		public SetPropertyDictionary<Color> setPropertyDictionaryColor;

		public SetPropertyDictionary<Vector2> setPropertyDictionaryVector2;

		public SetPropertyDictionary<Vector3> setPropertyDictionaryVector3;

		public SetPropertyDictionary<FromLuaInputSource> setPropertyDictionaryInputSource;

		public GetPropertyDictionaryCount getPropertyDictionaryCount;

		public GetPropertyDictionaryKeys getPropertyDictionaryKeys;

		public GetPropertyMatrix2D<bool> getPropertyMatrix2DBool;

		public GetPropertyMatrix2D<ToLuaString> getPropertyMatrix2DString;

		public GetPropertyMatrix2D<float> getPropertyMatrix2DNumber;

		public GetPropertyMatrix2D<LuaSelection> getPropertyMatrix2DSelection;

		public GetPropertyMatrix2D<Color> getPropertyMatrix2DColor;

		public GetPropertyMatrix2D<Vector2> getPropertyMatrix2DVector2;

		public GetPropertyMatrix2D<Vector3> getPropertyMatrix2DVector3;

		public GetPropertyMatrix2D<ToLuaInputSource> getPropertyMatrix2DInputSource;

		public SetPropertyMatrix2D<uint> setPropertyMatrix2DBool;

		public SetPropertyMatrix2D<FromLuaString> setPropertyMatrix2DString;

		public SetPropertyMatrix2D<float> setPropertyMatrix2DNumber;

		public SetPropertyMatrix2D<LuaSelection> setPropertyMatrix2DSelection;

		public SetPropertyMatrix2D<Color> setPropertyMatrix2DColor;

		public SetPropertyMatrix2D<Vector2> setPropertyMatrix2DVector2;

		public SetPropertyMatrix2D<Vector3> setPropertyMatrix2DVector3;

		public SetPropertyMatrix2D<FromLuaInputSource> setPropertyMatrix2DInputSource;

		public GetPropertyMatrix2DWidth getPropertyMatrix2DWidth;

		public GetPropertyMatrix2DHeight getPropertyMatrix2DHeight;

		public GetAssetName getAssetName;

		public IsAssetValid isAssetValid;

		public AsyncJobHandle.IsCompleteCallback isAsyncJobComplete;

		public AsyncJobHandle.DisposeCallback disposeAsyncJob;
	}

	private class Wrapper
	{
		[PreserveSig]
		public static extern void Core_SendException(string type, string message);

		[PreserveSig]
		public static extern void Core_SetAsyncJob(IntPtr asyncJobResultGetter, IntPtr csJobPtr);

		[PreserveSig]
		public static extern void Core_InitComplete();

		[PreserveSig]
		public static extern void Core_CleanGadget();

		[PreserveSig]
		public static extern void Core_CleanAll();

		[PreserveSig]
		public static extern void Core_SetCallbacks(Callbacks callbacks);

		[PreserveSig]
		public static extern void Core_RegisterModuleGestaltProperty(int moduleGestaltId, int propertyId, string name, Data.Container container, Data.Types type, int selectionGestaltId, int moduleIdType, bool sameMotherboard, AssetType assetType, bool isReadonly, string table);

		[PreserveSig]
		public static extern void Core_SetModuleGestaltMethodCallback(int moduleGestaltId, string methodName, IntPtr callback);

		[PreserveSig]
		public static extern void Core_SetGlobalMethodCallback(string tableName, string methodName, IntPtr callback);

		[PreserveSig]
		public static extern void Core_SetAssetMethodCallback(AssetType assetType, string methodName, IntPtr callback);

		[PreserveSig]
		public static extern void Core_SetAssetPropertyCallbacks(AssetType assetType, string methodName, IntPtr setCallback, IntPtr getCallback);

		[PreserveSig]
		public static extern void Core_RegisterModuleGestalt(int moduleGestaltId, string name);

		[PreserveSig]
		public static extern void Core_RegisterSelectionGestalt(int selectionGestaltId, string name);

		[PreserveSig]
		public static extern void Core_RegisterSelectionGestaltValue(int selectionGestaltId, string name, int value);

		[PreserveSig]
		public static extern void Gadget_AddModule(uint moduleId, string moduleName, int moduleGestaltId, uint motherboardId, IntPtr module);

		[PreserveSig]
		public static extern void Gadget_AddCPUModule(uint moduleId, string moduleName, int moduleGestaltId, uint motherboardId, IntPtr module);

		[PreserveSig]
		public static extern void Gadget_RemoveModule(uint moduleId);

		[PreserveSig]
		public static extern uint Gadget_CheckSourceRequest(string filename, string source);

		[PreserveSig]
		public static extern IntPtr Gadget_LintSource(string filename, string source);

		[PreserveSig]
		public static extern IntPtr Gadget_AstQuery(string filename, string source, int line, int column);

		[PreserveSig]
		public static extern uint Gadget_AutoCompleteRequest(string filename, string source, int line, int column);

		[PreserveSig]
		public static extern void Gadget_SetDebug(bool enabled);

		[PreserveSig]
		public static extern void Gadget_OnBreakpointsChange(string moduleId);

		[PreserveSig]
		public static extern void Module_SetPropertyCSPtr(uint moduleId, int propertyId, IntPtr propertyPtr);

		[PreserveSig]
		public static extern void Module_OnTurnOn(uint moduleId);

		[PreserveSig]
		public static extern void Module_OnTurnOff(uint moduleId);

		[PreserveSig]
		public static extern TickLoop.UpdateResult Module_OnTickUpdate(uint moduleId, float deltaTime, int maxTimeMs);

		[PreserveSig]
		public static extern bool CPU_LoadSource(uint moduleId, string filename);

		[PreserveSig]
		public static extern CpuStatus CPU_GetStatus(uint moduleId);

		[PreserveSig]
		public static extern bool CPU_GetDebugPause(uint moduleId);

		[PreserveSig]
		public static extern IntPtr CPU_QueryDebugSymbol(uint moduleId, string filename, int line, int column, int stacktraceLine);

		[PreserveSig]
		public static extern IntPtr CPU_GetCompileError(uint moduleId);

		[PreserveSig]
		public static extern IntPtr CPU_GetRuntimeException(uint moduleId);

		[PreserveSig]
		public static extern void CPU_DebugContinue(uint moduleId);

		[PreserveSig]
		public static extern void CPU_DebugNextStep(uint moduleId);

		[PreserveSig]
		public static extern void CPU_AddChannelEvent(uint moduleId, int index, uint sender, LuaNativeTable argument);

		[PreserveSig]
		public static extern void Util_StartProcess(string path);

		[PreserveSig]
		public static extern void Util_OpenOSDirectory(string path);

		[PreserveSig]
		public static extern void Util_OpenOSDirectoryAndSelectFile(string path);

		[PreserveSig]
		public static extern void Util_InstallThumbnailProvider();

		[PreserveSig]
		public static extern IntPtr Util_ListAvailableComPorts();

		[PreserveSig]
		public static extern IntPtr Core_SetupPixelDataTextureUpdateCallback(uint requestId, ulong pixelDataPtr);

		[PreserveSig]
		public static extern IntPtr OsDesktop_GetMainWindow();

		[PreserveSig]
		public static extern IntPtr OsDesktop_GetSteamLibraryFolder(uint appId);

		[PreserveSig]
		public static extern IntPtr OsDesktop_GetSteamGameFolder(uint appId);

		[PreserveSig]
		public static extern bool OsDesktop_OnGameStart();

		[PreserveSig]
		public static extern void OsDesktop_OnGameStop();

		[PreserveSig]
		public static extern bool OsDesktop_OnLauncherAgentStart(GadgetType gadgetType, ulong gadgetId);

		[PreserveSig]
		public static extern void OsDesktop_OnLauncherAgentStarted(ulong permissionsMask, ulong neededPermissionsMask);

		[PreserveSig]
		public static extern void OsDesktop_OnLauncherAgentStop();

		[PreserveSig]
		public static extern void OsDesktop_OnLauncherAgentPermissionsChange(ulong permissionsMask);

		[PreserveSig]
		public static extern IntPtr OsDesktop_GetOsDesktopInfo();
	}

	public delegate T AssetProperyGetterType<T>(IntPtr assetPtr);

	public delegate void AssetProperySetterType<T>(IntPtr assetPtr, T value);

	public class AutocompleteRequest
	{
		public RetroUIText.TextCoord beginCoord;

		public string filter;

		public AutocompleteRequest(RetroUIText.TextCoord beginCoord, string filter)
		{
		}
	}

	public class StringsResult
	{
		public string[] values;
	}

	private class SourceCodeRequest
	{
		public bool done;

		public string sourceCode;
	}

	private class SourceBreakpointsRequest
	{
		public bool done;

		public HashSet<int> breakpoints;
	}

	public static ModuleId currentModuleId;

	private static Dictionary<uint, Action<uint, CheckResult>> checkSourceRequestes;

	private static Dictionary<uint, Action<uint, AutocompleteResult>> autocompleteRequestes;

	public static void SendException(Exception e)
	{
	}

	public static void SendException(string type, string message)
	{
	}

	public static void OnReturnAsyncJob(IGenericAsyncJob asyncJob)
	{
	}

	public static void InitComplete()
	{
	}

	public static void CleanGadget()
	{
	}

	public static void CleanAll()
	{
	}

	public static void RegisterModuleGestalt(int moduleGestaltId, string name)
	{
	}

	public static void RegisterSelectionGestalt(int selectionGestaltId, string name)
	{
	}

	public static void RegisterSelectionGestaltValue(int selectionGestaltId, string name, int id)
	{
	}

	public static void RegisterModuleGestaltProperty(ModuleGestaltEnum moduleGestaltId, int propertyId, string name, Data.Container container, Data.Types type, DataSelectionGestaltEnum selectionGestaltEnum, ModuleGestaltEnum moduleIdType, bool sameMotherboard, AssetType assetType, bool isReadonly, string table)
	{
	}

	public static void SetModuleGestaltMethodCallback<DELEGATE_TYPE>(int moduleGestaltId, string methodName, DELEGATE_TYPE callback)
	{
	}

	public static void SetGlobalMethodCallback<DELEGATE_TYPE>(string tableName, string methodName, DELEGATE_TYPE callback)
	{
	}

	public static void SetAssetMethodCallback<DELEGATE_TYPE>(AssetType assetType, string methodName, DELEGATE_TYPE callback)
	{
	}

	public static void SetAssetPropertyCallbacks<RETURN_TYPE, PARAMETER_TYPE>(AssetType assetType, string methodName, AssetProperyGetterType<RETURN_TYPE> getCallback, AssetProperySetterType<PARAMETER_TYPE> setCallback)
	{
	}

	public static void Gadget_AddModule(Module module)
	{
	}

	public static void Gadget_RemoveModule(Module module)
	{
	}

	public static uint Gadget_CheckSourceRequest(string filename, string source, Action<uint, CheckResult> onComplete)
	{
		return 0u;
	}

	public static string Gadget_LintSource(string filename, string source)
	{
		return null;
	}

	public static string Gadget_AstQuery(string filename, string source, int line, int column)
	{
		return null;
	}

	public static uint Gadget_AutoCompleteRequest(string filename, string source, AutocompleteRequest request, Action<uint, AutocompleteResult> onComplete)
	{
		return 0u;
	}

	public static void Gadget_SetDebug(bool enabled)
	{
	}

	public static void Gadget_OnBreakpointsChange(string sourceName)
	{
	}

	public static void Module_OnTurnOn(ModuleId moduleId)
	{
	}

	public static void Module_OnTurnOff(ModuleId moduleId)
	{
	}

	public static TickLoop.UpdateResult Module_OnTickUpdate(ModuleId moduleId, float deltaTime, int maxTimeMs)
	{
		return default(TickLoop.UpdateResult);
	}

	public static bool CPU_LoadSource(ModuleId moduleId, string filename)
	{
		return false;
	}

	public static CpuStatus CPU_GetStatus(ModuleId moduleId)
	{
		return default(CpuStatus);
	}

	public static bool CPU_GetDebugPause(ModuleId moduleId)
	{
		return false;
	}

	public static string CPU_QueryDebugSymbol(ModuleId moduleId, string filename, int line, int column, int stacktraceLine)
	{
		return null;
	}

	public static string CPU_GetCompileError(ModuleId moduleId)
	{
		return null;
	}

	public static LuaRuntimeException CPU_GetRuntimeException(ModuleId moduleId)
	{
		return null;
	}

	public static void CPU_DebugContinue(ModuleId moduleId)
	{
	}

	public static void CPU_DebugNextStep(ModuleId moduleId)
	{
	}

	public static void CPU_AddChannelEvent(ModuleId moduleId, int index, ModuleId sender, LuaTable argument)
	{
	}

	public static void Util_StartProcess(string path)
	{
	}

	public static void Util_OpenOSDirectory(string path)
	{
	}

	public static void Util_OpenOSDirectoryAndSelectFile(string path)
	{
	}

	public static void Util_InstallThumbnailProvider()
	{
	}

	public static StringsResult Util_ListAvailableComPorts()
	{
		return null;
	}

	public static IntPtr Core_SetupPixelDataTextureUpdateCallback(uint requestId, ulong pixelDataPtr)
	{
		return (IntPtr)0;
	}

	public static IntPtr OsDesktop_GetMainWindow()
	{
		return (IntPtr)0;
	}

	public static string OsDesktop_GetSteamLibraryFolder(uint appId)
	{
		return null;
	}

	public static string OsDesktop_GetSteamGameFolder(uint appId)
	{
		return null;
	}

	public static bool OsDesktop_OnGameStart()
	{
		return false;
	}

	public static void OsDesktop_OnGameStop()
	{
	}

	public static bool OsDesktop_OnLauncherAgentStart(GadgetType type, ulong id)
	{
		return false;
	}

	public static void OsDesktop_OnLauncherAgentStarted(ulong permissionsMask, ulong neededPermissionsMask)
	{
	}

	public static void OsDesktop_OnLauncherAgentStop()
	{
	}

	public static void OsDesktop_OnLauncherAgentPermissionsChange(ulong permissionsMask)
	{
	}

	public static OsDesktopInfo OsDesktop_GetOsDesktopInfo()
	{
		return default(OsDesktopInfo);
	}

	private static void WriteCallback(IntPtr strPtr)
	{
	}

	private static void OnDebugBreak(uint moduleId, IntPtr stacktracePtr)
	{
	}

	public static string GetSourceCode(IntPtr namePtr)
	{
		return null;
	}

	public static LuaNativeArray GetSourceBreakpoints(IntPtr namePtr)
	{
		return null;
	}

	public static void OnCheckSourceResult(uint id, IntPtr resultPtr)
	{
	}

	public static void OnAutocompleteResult(uint id, IntPtr resultPtr)
	{
	}

	public static ToLuaString GetAssetName(LuaAssetReference assetRef)
	{
		return default(ToLuaString);
	}

	public static bool IsAssetValid(LuaAssetReference assetRef)
	{
		return false;
	}

	public override void Init()
	{
	}

	private void OnApplicationQuit()
	{
	}
}
