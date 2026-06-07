using System.Collections.Generic;
using UnityEngine;

public class VideoChipModule : RendererModule
{
	public enum Commands
	{
		UpdateMode = 1
	}

	public class Touch_EventData : EventData
	{
		public bool TouchDown;

		public bool TouchUp;

		public Vector2 Value;

		public Touch_EventData()
		{
		}

		public Touch_EventData(bool touchDown, bool touchUp, Vector2Int value)
		{
		}
	}

	public int renderBuffersCount;

	public Interactable touchInteractable;

	private RenderTexture screenRenderTexture;

	private RenderTexture screenVisibleRenderTexture;

	private List<IScreenModule> screens;

	private ModuleProperty modeProperty;

	private VideoChipMode_DataSelectionEnum mode;

	private ModuleProperty widthProperty;

	private ModuleProperty heightProperty;

	private ModuleProperty renderBuffersProperty;

	private ModuleProperty touchStateProperty;

	private ModuleProperty touchDownProperty;

	private ModuleProperty touchUpProperty;

	private ModuleProperty touchPositionProperty;

	private Vector2Int origin;

	private int screenWidth;

	private int screenHeight;

	private int renderTarget;

	private bool isTouchPressed;

	private bool isTouchDown;

	private bool isTouchUp;

	private RenderBufferAsset[] renderBuffers;

	private int lastTouchUpdateFrame;

	private bool isTouchInside;

	protected override void OnSetupFinished()
	{
	}

	public RenderTexture GetVisibleRenderTexture()
	{
		return null;
	}

	public void RegisterScreen(IScreenModule screen)
	{
	}

	public void RemoveMonitor(IScreenModule screen)
	{
	}

	private void RefreshSizeProperties()
	{
	}

	public override void DeallocResources()
	{
	}

	public override void OnTurnOn()
	{
	}

	public override void OnTurnOff()
	{
	}

	public void RefreshScreens()
	{
	}

	private void RefreshRenderTarget()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	private void SetMode(VideoChipMode_DataSelectionEnum mode)
	{
	}

	private void SetupScreenRenderTexture(int width, int height)
	{
	}

	private void UpdateTouch(Vector2Int coord)
	{
	}

	private void Update()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public override void OnPostTickUpdate()
	{
	}

	public Vector2Int GetScreenOrigin()
	{
		return default(Vector2Int);
	}

	public Vector2Int GetScreenSize()
	{
		return default(Vector2Int);
	}

	private Vector2Int GetTouchCoord()
	{
		return default(Vector2Int);
	}

	public void OnTouchInteractionDown()
	{
	}

	public void OnTouchInteractionUp()
	{
	}

	public void RenderOnScreen_Script()
	{
	}

	public void RenderOnBuffer_Script(int index)
	{
	}

	public void SetRenderBufferSize(int index, int width, int height)
	{
	}
}
