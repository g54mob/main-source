using System;
using System.Collections.Generic;
using UnityEngine;

public class Gadget : MonoBehaviour, ILogOrigin
{
	public enum State
	{
		None = 0,
		Off = 1,
		On = 2
	}

	public enum DestroyMode
	{
		Default = 0,
		EndOfFrame = 1,
		Immediate = 2
	}

	public Transform motherboardsTransform;

	private State pendingState;

	private Dictionary<uint, Module> modulesDictionary;

	public MultitoolConnectorModule multitoolConnector;

	private uint nextModuleGuid;

	private bool locked;

	private bool destroy;

	private GadgetCoverMaterial _coverMaterial;

	private float _ticksPerSecond;

	private float lastTicksPerSecondUpdateTime;

	private float _currentTicksPerSecond;

	private float currentTicksPerSecond;

	private TickLoop tickLoop;

	private bool wasConnectedToMultitool;

	public uint guid;

	public SerializedGadgetMetaData metadata;

	public List<Motherboard> motherboards;

	[HideInInspector]
	public InteractableArchivableGadget interactableArchivable;

	public AssetContainer assetContaniner;

	private static GameObject basePrefab;

	public bool debugging;

	private IRetroDebuggerListener debuggerListener;

	public Motherboard.Position position { get; private set; }

	public State state { get; private set; }

	public Transform cableSocket => null;

	public bool screenshootMode { get; private set; }

	public GadgetCoverMaterial coverMaterial
	{
		get
		{
			return default(GadgetCoverMaterial);
		}
		set
		{
		}
	}

	public bool isDestroying => false;

	public float ticksPerSecond
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool isOn => false;

	public bool isLocal => false;

	public bool isReadOnly => false;

	public bool isConnectedToMultitool => false;

	public bool isCoverOpen => false;

	public bool isPendingStateChange => false;

	public string displayName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string description
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public DateTime creationDate
	{
		get
		{
			return default(DateTime);
		}
		set
		{
		}
	}

	public DateTime lastEditDate
	{
		get
		{
			return default(DateTime);
		}
		set
		{
		}
	}

	public DateTime lastViewDate
	{
		get
		{
			return default(DateTime);
		}
		set
		{
		}
	}

	public ICollection<Module> modules => null;

	public List<CPUModule> cpus => null;

	public bool isLocked => false;

	public Module.InteractionMode modulesInteractionMode { get; private set; }

	public ModuleId debugCpu { get; private set; }

	public LuaStacktrace debugStacktrace { get; private set; }

	public bool HasPowerButton()
	{
		return false;
	}

	public bool HasSecurityChip()
	{
		return false;
	}

	public T GetModule<T>() where T : Module
	{
		return null;
	}

	public T GetModule<T>(ModuleId moduleId) where T : Module
	{
		return null;
	}

	public List<GadgetPermissions.Category> GetNeededPermissionsCategories()
	{
		return null;
	}

	public ulong GetNeededPermissionsMask()
	{
		return 0uL;
	}

	public void OnPermissionsChange()
	{
	}

	public float GetCurrentTicksPerSecond()
	{
		return 0f;
	}

	private void ShowAllModulesAndProperties()
	{
	}

	private static Gadget Create()
	{
		return null;
	}

	private void LoadBuiltinAssets()
	{
	}

	public void Destroy(DestroyMode mode = DestroyMode.Default)
	{
	}

	public static Gadget Create(Motherboard.Position position)
	{
		return null;
	}

	private void Awake()
	{
	}

	public Motherboard AddMotherboard(MotherboardSectionEnum sectionEnum, int rotation)
	{
		return null;
	}

	public Motherboard AddMotherboard(MotherboardShape shape)
	{
		return null;
	}

	public void RemoveMotherboard(Motherboard motherboard)
	{
	}

	public void SetCoverInteractionMode(MotherboardCover.InteractionMode interactionMode, bool force = false)
	{
	}

	public void SetCoverInteractionMask(Mask mask)
	{
	}

	public void Lock()
	{
	}

	public void Unlock()
	{
	}

	public void OnCoverOpen(Motherboard motherboard)
	{
	}

	public void OnCoverClose(Motherboard motherboard)
	{
	}

	public void OnShowPcbSide(MotherboardPcb pcb, PcbSide pcbSide)
	{
	}

	public void ShowPcbSide(PcbSide side)
	{
	}

	public void EnableScreenshootMode()
	{
	}

	public void DisableScreenshootMode()
	{
	}

	public void StartArchivableInteraction()
	{
	}

	public void SetState(State state, bool forceNow = false)
	{
	}

	public void ExecutePendingStateChange()
	{
	}

	public void SetModulesInteractionMode(Module.InteractionMode interactionMode)
	{
	}

	public void SetPosition(Motherboard.Position position, bool immediate = false)
	{
	}

	private void CopyConfiguredToRuntimeProperties(bool overridePersistent = false)
	{
	}

	public void SolderModule(Module module, Motherboard motherboard, PcbSide pcbSide, Vector2? position = null, int? rotation = null)
	{
	}

	public void UnsolderModule(Module module)
	{
	}

	public Module GetModule(ModuleId moduleId)
	{
		return null;
	}

	public Module GetModule(Vector2 position)
	{
		return null;
	}

	public void CheckNeededModules()
	{
	}

	public void ApplySticker(Sticker sticker, Motherboard motherboard, Vector2 position, bool immediate)
	{
	}

	public void RemoveSticker(Sticker sticker, Motherboard motherboard, bool immediate, bool willMoveImmediatly)
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	public ICollection<Module> GetExecutionSortedModules()
	{
		return null;
	}

	public T GetExecutionSortedModuleOfType<T>(int index) where T : Module
	{
		return null;
	}

	public bool IsPositionChangeComplete()
	{
		return false;
	}

	public string GetUniqueDisplayName(string displayName)
	{
		return null;
	}

	public Bounds GetSceneBounds()
	{
		return default(Bounds);
	}

	public Bounds GetBoundsAtPosition(Vector3 position)
	{
		return default(Bounds);
	}

	public void CloseCover(float speed = 1f)
	{
	}

	public void OpenCover(float speed = 1f)
	{
	}

	public Sticker GetSticker(Vector2 position)
	{
		return null;
	}

	public Motherboard.Group[] GetMotherboardGroups()
	{
		return null;
	}

	public void OnDebugBreak(ModuleId cpuId, LuaStacktrace stacktrace)
	{
	}

	public void EnableDebugger(IRetroDebuggerListener listener)
	{
	}

	public void DisableDebugger()
	{
	}

	public void OnDebugBreakpointsChange(CodeAsset codeAsset)
	{
	}

	public void DebugNextStep()
	{
	}

	public void DebugContinue()
	{
	}
}
