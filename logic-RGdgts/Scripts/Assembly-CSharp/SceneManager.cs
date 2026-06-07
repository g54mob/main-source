using System;
using DG.Tweening;
using NodeCanvas.StateMachines;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public abstract class SceneManager : MonoBehaviour
{
	public enum GadgetAlignment
	{
		Center = 0,
		Left = 1,
		Right = 2
	}

	public struct GetGadgetEventArgs
	{
		public uint guid;

		public Action onComplete;

		public GetGadgetEventArgs(uint guid, Action onComplete)
		{
			this.guid = 0u;
			this.onComplete = null;
		}
	}

	public struct PrintGadgetEventArgs
	{
		public SerializedGadgetMetaData metadata;

		public Action onComplete;

		public PrintGadgetEventArgs(SerializedGadgetMetaData metadata, Action onComplete)
		{
			this.metadata = null;
			this.onComplete = null;
		}
	}

	public struct DestroyGadgetEventArgs
	{
		public Action onComplete;

		public DestroyGadgetEventArgs(Action onComplete)
		{
			this.onComplete = null;
		}
	}

	public struct ChangeGadgetCoverMaterialEventArgs
	{
		public GadgetCoverMaterial coverMaterial;

		public Action onComplete;

		public ChangeGadgetCoverMaterialEventArgs(GadgetCoverMaterial coverMaterial, Action onComplete)
		{
			this.coverMaterial = default(GadgetCoverMaterial);
			this.onComplete = null;
		}
	}

	public FSMOwner fsm;

	public Transform openCaseDestination;

	public BoxCollider2D gadgetArea;

	public Transform pointLight;

	public Light2D globalLight;

	public MultiTool multiTool;

	public SpriteRenderer invalidPositionMarker;

	[NonSerialized]
	[HideInInspector]
	public PixelCameraManager pixelCameraManager;

	private float invalidPositionMarkerTime;

	public const float resolutionX = 960f;

	public const float resolutionY = 540f;

	protected bool zoom;

	private Vector2 zoomCenterPoint;

	public Sequence zoomTween;

	[HideInInspector]
	public GadgetAlignment gadgetAlignment;

	[HideInInspector]
	public float gadgetXoffset;

	private Vector3 gadgetPosition;

	private Vector2 gadgetPositionVel;

	protected bool movingMotherboardInvalidPosition;

	protected Vector2 invalidPositionPoint;

	protected bool zoomIsOn;

	public Gadget gadget { get; private set; }

	[HideInInspector]
	public bool isGadgetAlignmentMoving { get; private set; }

	public Module operatingModule { get; protected set; }

	public Motherboard movingMotherboard { get; protected set; }

	public bool isDesktopMode { get; protected set; }

	public virtual void Setup()
	{
	}

	protected bool OverlapTriggerArea(Vector2 position, string name)
	{
		return false;
	}

	public virtual void UpdateGameplayInteractions()
	{
	}

	public virtual void OnSteamOverlay(bool activated)
	{
	}

	public void ZoomIn(Vector2 centerOn, Vector2 idlePosition)
	{
	}

	public void ZoomOut(Vector2 idlePosition)
	{
	}

	protected virtual void UpdateZoom(Vector2 zoomPosition, Vector2 idlePosition, bool disableZoom = false)
	{
	}

	public void SendEvent(string eventName, object value, object sender)
	{
	}

	public void SendEvent<T>(string eventName, T value, object sender)
	{
	}

	public Vector3 GetGadgetDestination(Gadget gadget, GadgetAlignment? gadgetAlignment = null)
	{
		return default(Vector3);
	}

	public Vector3 GetGadgetDestination(Bounds shapeBounds, GadgetAlignment? gadgetAlignment = null)
	{
		return default(Vector3);
	}

	public virtual Rect GetGadgetAreaRect()
	{
		return default(Rect);
	}

	protected virtual void Update()
	{
	}

	public virtual void SetGadget(Gadget gadget, bool positionImmediatly = false)
	{
	}

	public virtual bool DuplicateLocalGadget(string displayName)
	{
		return false;
	}

	public virtual bool TransformPrintedGadgetIntoLocal(string displayName = null)
	{
		return false;
	}

	public void CloseGadgetCover(float speed = 1f)
	{
	}

	public void OpenGadgetCover(float speed = 1f)
	{
	}

	public void ShowGadgetPcbSide(PcbSide side)
	{
	}

	public bool IsGadgetCoverOpen()
	{
		return false;
	}

	public bool IsMultitoolOpen()
	{
		return false;
	}

	public virtual void OnGadgetTurnOn(Gadget.State lastState)
	{
	}

	public virtual void OnGadgetTurnOff(Gadget.State lastState)
	{
	}

	public abstract void OnDestroyGadget();

	public void MoveMotherboard(Motherboard motherboard)
	{
	}

	public void GetGadget(uint guid, Action onComplete = null)
	{
	}

	public void PrintGadget(SerializedGadgetMetaData metadata, Action onComplete = null)
	{
	}

	public void DestroyGadget(Action onComplete = null)
	{
	}

	public void SetGadgetCoverMaterial(GadgetCoverMaterial coverMaterial, Action onComplete = null)
	{
	}

	protected void ShowInvalidPositionMarker(Vector2 position, float time = -1f)
	{
	}

	protected void HideInvalidPositionMarker(bool force = false)
	{
	}

	public void OnGadgetEdit()
	{
	}

	public virtual void OnSelectModule(ModuleId id)
	{
	}

	protected void StartLauncher()
	{
	}

	public virtual bool IsLampOn()
	{
		return false;
	}

	public virtual void SetLampState(bool state)
	{
	}

	public virtual void SetLampColor(Color color)
	{
	}

	public virtual void ShowMessage(string message, bool persistent)
	{
	}

	public virtual void ShowWarning(string message, bool persistent)
	{
	}

	public virtual void ShowError(string message, bool persistent)
	{
	}

	public virtual void HideMessage()
	{
	}

	public static bool Script_IsLampOn()
	{
		return false;
	}

	public static void Script_SetLampState(bool state)
	{
	}

	public static void Script_SetLampColor(Color color)
	{
	}

	public static void Script_ShowMessage(string message, bool persistent)
	{
	}

	public static void Script_ShowWarning(string message, bool persistent)
	{
	}

	public static void Script_ShowError(string message, bool persistent)
	{
	}

	public static void Script_HideMessage()
	{
	}
}
