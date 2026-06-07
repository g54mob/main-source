using Factory;
using FixMath;
using Motorways.Audio;
using Rendering.RenderFeatures;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour, IReleasedFromScopeHandler
{
	public RectFixed debugPlayableArea;

	public bool debugDisplayPlayableArea;

	public Vector2 debugPlayerOffset;

	public CustomBlurData customBlur;

	[SerializeField]
	private Camera _defaultCamera;

	[SerializeField]
	private Camera _overlayCamera;

	[SerializeField]
	private Camera _uiCamera;

	private int _overlayLayerIndex;

	public Camera DefaultCamera => _defaultCamera;

	public Camera UICamera => _uiCamera;

	public bool PostProcessingEnabled { get; set; } = true;

	public float OrthographicSize
	{
		get
		{
			return _defaultCamera.orthographicSize;
		}
		set
		{
			_defaultCamera.orthographicSize = value;
		}
	}

	public float Width => _defaultCamera.pixelWidth;

	public float Height => _defaultCamera.pixelHeight;

	public Vector2 Dimensions => _defaultCamera.pixelRect.size;

	public float AspectRatio => _defaultCamera.aspect;

	public int OverlayLayerIndex => _overlayLayerIndex;

	public void Awake()
	{
		_defaultCamera = GetComponent<Camera>();
		for (int i = 0; i < 32; i++)
		{
			if ((_overlayCamera.cullingMask & (1 << i)) != 0)
			{
				_overlayLayerIndex = i;
				break;
			}
		}
	}

	public void SetPosition(Vector3 position)
	{
		position.z = base.transform.position.z;
		base.transform.position = position;
	}

	public void AttachCameraToCanvas(Canvas canvas, CameraLayer layer)
	{
		canvas.worldCamera = layer switch
		{
			CameraLayer.UI => _uiCamera, 
			CameraLayer.Overlay => _overlayCamera, 
			_ => _defaultCamera, 
		};
	}

	public void LateUpdate()
	{
		_overlayCamera.orthographicSize = _defaultCamera.orthographicSize;
		_overlayCamera.nearClipPlane = _defaultCamera.nearClipPlane;
		_overlayCamera.farClipPlane = _defaultCamera.farClipPlane;
		_overlayCamera.rect = _defaultCamera.rect;
		_uiCamera.orthographicSize = _defaultCamera.orthographicSize;
		_uiCamera.nearClipPlane = _defaultCamera.nearClipPlane;
		_uiCamera.farClipPlane = _defaultCamera.farClipPlane;
		_uiCamera.rect = _defaultCamera.rect;
	}

	public Vector3 GetWorldFromScreen(Vector2 screenPos)
	{
		Vector3 result = _defaultCamera.ScreenToWorldPoint(screenPos);
		result.z = 0f;
		return result;
	}

	public Vector2 GetScreenFromWorld(Vector3 worldPos)
	{
		return _defaultCamera.WorldToScreenPoint(worldPos);
	}

	public Vector2 GetScreenFromWorld(Vector3Fixed worldPos)
	{
		return GetScreenFromWorld((Vector3)worldPos);
	}

	public Bounds GetScreenBounds(float aspectRatio = -1f)
	{
		float num = ((aspectRatio > 0f) ? aspectRatio : ((float)Screen.width / (float)Screen.height));
		float num2 = _defaultCamera.orthographicSize * 2f;
		return new Bounds(base.transform.position, new Vector3(num2 * num, num2, 0f));
	}

	public Vector2 GetPanFromWorld(Vector3 worldPos)
	{
		return Get.Pan(GetScreenFromWorld(worldPos));
	}

	public float GetAttenuationFromWorld(Vector3 worldPos, bool zoom = true, float falloffFactor = 5f)
	{
		return Get.Attenuation(GetScreenFromWorld(worldPos), zoom, falloffFactor);
	}

	public Vector2 GetPanFromScreen(Vector2 screenPos)
	{
		return Get.Pan(screenPos);
	}

	public float GetAttenuationFromScreen(Vector2 screenPos, bool zoom = true, float falloffFactor = 5f)
	{
		return Get.Attenuation(screenPos, zoom, falloffFactor);
	}

	public void OnReleasedFromScope(IScope scope)
	{
		if (Application.isPlaying)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Object.DestroyImmediate(base.gameObject);
		}
	}
}
