using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

public abstract class Module : MotherboardRenderable, Data.IDataOwner, ILogOrigin
{
	public enum States
	{
		None = 0,
		Soldered = 1,
		Moving = 2,
		Drawer = 3,
		Running = 4
	}

	public enum Positioning
	{
		Center = 0,
		Border = 1,
		None = 2,
		MotherboardSlot = 3
	}

	public enum InteractionMode
	{
		None = 0,
		ReadOnly = 1,
		DrawerMode = 2,
		EditMode = 3,
		SelectMode = 4,
		PlayMode = 5
	}

	public class EventData
	{
		public string Type;
	}

	public class Storage
	{
		public Dictionary<int, ModuleProperty.Storage> configuredProperties;

		public Dictionary<int, ModuleProperty.Storage> runtimeProperties;
	}

	public class CustomizationDictionaryKeyAttribute : Attribute
	{
	}

	[NonSerialized]
	[HideInInspector]
	public GCHandle gcHandle;

	[Space]
	public TurnableSpriteRenderer overrideShadowRenderer;

	[Space]
	public Positioning positioning;

	public int borderOffset;

	public Vector2Int slotOffset;

	[Space]
	public PixelShape mainPixelShape;

	public PixelShape casePixelShape;

	public PixelShape color1PixelShape;

	public PixelShape color2PixelShape;

	public PixelShape bottomPixelShape;

	public bool forceAlwaysBottomShapeInteraction;

	[NonSerialized]
	[HideInInspector]
	public PixelShape visiblePixelShape;

	[HideInInspector]
	public PixelShape[] playModePixelShapes;

	[Space]
	public TurnableSpriteRenderer[] color1renderers;

	public TurnableSpriteRenderer[] color2renderers;

	[HideInInspector]
	public ModulePixelShapePreset mainPixelShapeRotationPresets;

	[HideInInspector]
	public ModulePixelShapePreset casePixelShapeRotationPresets;

	[HideInInspector]
	public ModulePixelShapePreset color1PixelShapeRotationPresets;

	[HideInInspector]
	public ModulePixelShapePreset color2PixelShapeRotationPresets;

	[HideInInspector]
	public ModulePixelShapePreset overrideBottomPixelShapeRotationPresets;

	[HideInInspector]
	public ModulePixelShapePreset[] playModePixelShapesRotationPresets;

	private HashSet<int> pendingCommands;

	public int defaultColor1;

	public int defaultColor2;

	[HideInInspector]
	public Dictionary<int, List<CustomizableRenderer>> customizableRenderers;

	[CustomizationDictionaryKey]
	public Dictionary<int, Dictionary<int, string>> customizableDynamicValues;

	[NonSerialized]
	[HideInInspector]
	public Interactable interactable;

	[NonSerialized]
	[HideInInspector]
	public Interactable[] playModeInteractables;

	[NonSerialized]
	[HideInInspector]
	public InteractableProxy[] playModeInteractableProxies;

	protected Dictionary<int, ModuleProperty> _runtimeProperties;

	protected Dictionary<int, ModuleProperty> _configuredProperties;

	protected States state;

	private Dictionary<int, MethodInfo> _operations;

	private SpriteShadow shadow;

	private Tweener shadowTween;

	[NonSerialized]
	[HideInInspector]
	public ModuleDescriptor moduleDescriptor;

	private Dictionary<CPUModule, List<int>> channelBindings;

	private static FieldInfo light2dTargetSortingLayerField;

	public int color1 { get; private set; }

	public int color2 { get; private set; }

	public bool isSoldered => false;

	public Vector2 slotPosition => default(Vector2);

	public Vector2 borderPosition => default(Vector2);

	public InteractionMode interactionMode { get; private set; }

	public ModuleGestalt moduleGestalt { get; private set; }

	public ModuleGestalt.Variation moduleGestaltVariation { get; private set; }

	public Dictionary<int, ModuleProperty> runtimeProperties => null;

	public Dictionary<int, ModuleProperty> configuredProperties => null;

	public bool isOn => false;

	public static Module Create(ModuleDescriptor moduleDescriptor)
	{
		return null;
	}

	private void Awake()
	{
	}

	private void InitPlayModeInteractables()
	{
	}

	public void UpdateInteractables()
	{
	}

	protected virtual void Setup()
	{
	}

	public void CleanUp()
	{
	}

	public override void SetRenderingMode(RenderingMode renderingMode, bool force = false)
	{
	}

	public void Solder(Motherboard motherboard, PcbSide pcbSide, Vector2? position = null, int? rotation = null)
	{
	}

	public void Unsolder()
	{
	}

	protected virtual void OnSolder()
	{
	}

	protected virtual void OnUnsolder()
	{
	}

	public virtual void OnGadgetDeserialized()
	{
	}

	public virtual void OnDebugBreak(LuaStacktrace stacktrace)
	{
	}

	public void OnNewCoverTextures()
	{
	}

	private void RefreshCaseRenderersTexture()
	{
	}

	public void Destroy()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void SetState(States newState)
	{
	}

	public void Rotate()
	{
	}

	public override void SetRotation(int rotationI)
	{
	}

	public Bounds GetBounds()
	{
		return default(Bounds);
	}

	public Vector2 GetSize(int rotationI)
	{
		return default(Vector2);
	}

	public void SetColor(int slot, int colorI)
	{
	}

	private TurnableSpriteRenderer[] GetColorTargets(int slot)
	{
		return null;
	}

	public bool IsPositionOverColorTarget(Vector2 position, out int slot)
	{
		slot = default(int);
		return false;
	}

	public void SetInteractionMode(InteractionMode interactionMode, Mask mask = null, bool force = false)
	{
	}

	public void RefreshPixelShape()
	{
	}

	public float GetBorderWidth()
	{
		return 0f;
	}

	public ModuleProperty GetRuntimeProperty(int id)
	{
		return null;
	}

	public ModuleProperty GetConfiguredProperty(int id)
	{
		return null;
	}

	public void CopyConfiguredToRuntimeProperties(bool overridePersistent = false)
	{
	}

	public void CopyConfiguredPropertiesFromAgent(Module module)
	{
	}

	public virtual FloatRange GetLimitsForProperty(int propertyId)
	{
		return default(FloatRange);
	}

	public virtual void OnTurnOff()
	{
	}

	public virtual void OnTurnOn()
	{
	}

	public virtual void OnMultitoolConnect()
	{
	}

	public virtual void OnMultitoolDisconnect()
	{
	}

	public virtual void OnGadgetPermissionsChange()
	{
	}

	protected virtual void UpdateInputSources()
	{
	}

	protected virtual void UpdateVisuals()
	{
	}

	public virtual void RunCommand(int commandId)
	{
	}

	public void ClearPendingCommands()
	{
	}

	public void ExecutePendingCommands()
	{
	}

	public virtual GadgetPermissions.Category[] GetNeededPermissionsCategories()
	{
		return null;
	}

	protected virtual void ExecuteCommand(int commandId)
	{
	}

	public virtual string GetRealValueStringForProperty(int propertyId, float value)
	{
		return null;
	}

	protected virtual void OnSetupFinished()
	{
	}

	protected virtual void OnCleanUpFinished()
	{
	}

	protected virtual void OnBeforeCopyConfiguredToRuntimeProperties()
	{
	}

	public virtual void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public virtual TickLoop.UpdateResult OnTickUpdate(float deltaTime, float maxTime)
	{
		return default(TickLoop.UpdateResult);
	}

	public virtual void OnPostTickUpdate()
	{
	}

	public virtual void AllocResources()
	{
	}

	public virtual void DeallocResources()
	{
	}

	public virtual List<KeyValuePair<int, int>> GetSerializableTexturesLabels()
	{
		return null;
	}

	public virtual int GetTextureIndexForLabel(int label)
	{
		return 0;
	}

	public virtual SerializedModuleData ComposeSerializedData()
	{
		return null;
	}

	public virtual SerializedModuleData.PersistentState ComposePersistentSerializedData()
	{
		return null;
	}

	public virtual void ApplySerializedData(SerializedModuleData serializedData, SerializedModuleData.PersistentState persistentSerializedData = null)
	{
	}

	public virtual Storage ComposePermanentStorage(bool persistentDataOnly = false)
	{
		return null;
	}

	public virtual void ApplyPermanentStorage(Storage permanentStorage, Storage persistentOnlyPermanentStorage = null)
	{
	}

	public virtual string GetDynamicDataSelectionName(int propertyId, Data.Selection selection)
	{
		return null;
	}

	public virtual Dictionary<int, string> GetDynamicDataSelectionValues(int propertyId)
	{
		return null;
	}

	public virtual bool IsHardwarePropertySupported(int propertyId)
	{
		return false;
	}

	public void RemoveChannelBindings(CPUModule cpu)
	{
	}

	public void AddChannelBinding(CPUModule cpu, int channelIndex)
	{
	}

	protected void SendEvent<T>(T eventData) where T : EventData
	{
	}

	public void SetCustomization(int propertyId, int value)
	{
	}
}
