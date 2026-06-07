using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraOverlays : MonoBehaviour
{
	[SerializeField]
	private Camera _camera;

	[SerializeField]
	private Camera _overlayCamera;

	[SerializeField]
	private Volume _overlayVolume;

	private UniversalAdditionalCameraData _data;

	private void Awake()
	{
		_data = _camera.GetUniversalAdditionalCameraData();
		SetOverlayType(Overlays.OverlayType);
		GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayUpdated);
	}

	private void OnOverlayUpdated(GameEvent gameEvent)
	{
		if (gameEvent is OverlayEvent overlayEvent)
		{
			SetOverlayType(overlayEvent.OverlayType);
		}
	}

	private void SetOverlayType(Overlays.Type overlayType)
	{
		if (overlayType == Overlays.Type.None || overlayType == Overlays.Type.Architect)
		{
			DisableOverlay();
		}
		else
		{
			EnableOverlay();
		}
	}

	private void EnableOverlay()
	{
		_data.cameraStack.AddUnique(_overlayCamera);
		_overlayVolume.enabled = true;
	}

	private void DisableOverlay()
	{
		_data.cameraStack.Remove(_overlayCamera);
		_overlayVolume.enabled = false;
	}
}
