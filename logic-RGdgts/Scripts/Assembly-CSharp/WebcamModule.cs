using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WebcamModule : Module
{
	public class IsActiveChange_EventData : EventData
	{
		public bool IsActive;

		public bool IsAvailable;

		public bool AccessDenied;

		public IsActiveChange_EventData()
		{
		}

		public IsActiveChange_EventData(bool isActive, bool isAvailable, bool accessDenied)
		{
		}
	}

	public int width;

	public int height;

	public SpriteRenderer ledLightRenderer;

	public Light2D ledLight;

	public float blinkSpeed;

	public float blinkPow;

	private WebCamTexture webcamTexture;

	private RenderBufferAsset renderBuffer;

	private Material ledLightMaterial;

	private static Material blitMaterial;

	private ModuleProperty renderTargetProperty;

	private ModuleProperty isActiveProperty;

	private ModuleProperty isAvailableProperty;

	private ModuleProperty accessDeniedProperty;

	private static HashSet<string> unsupportedDevices;

	private bool firstTickEvent;

	public bool IsActive => false;

	public bool IsAvailable => false;

	public bool IsAccessDenied => false;

	public Vector2Int GetSize()
	{
		return default(Vector2Int);
	}

	protected override void OnSetupFinished()
	{
	}

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

	private void EnableWebcam()
	{
	}

	private void DisableWebcam()
	{
	}

	public override void OnTurnOn()
	{
	}

	public override void OnTurnOff()
	{
	}

	public override void OnGadgetPermissionsChange()
	{
	}

	protected override void OnSolder()
	{
	}

	protected override void OnUnsolder()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	private void LateUpdate()
	{
	}

	protected override void UpdateVisuals()
	{
	}

	private void UpdateLed()
	{
	}

	public override GadgetPermissions.Category[] GetNeededPermissionsCategories()
	{
		return null;
	}

	public RenderBufferAsset GetRenderBuffer_Script()
	{
		return null;
	}
}
