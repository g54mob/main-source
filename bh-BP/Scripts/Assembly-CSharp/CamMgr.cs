using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CamMgr : MonoBehaviour
{
	public static CamMgr I;

	public CamMode TgtCamMode;

	protected Plane _groundPlane;

	public Camera Cam;

	public Vector3 SteadyPos;

	protected float _minY;

	protected float _maxY;

	protected float _minX;

	protected float _maxX;

	protected Vector3 _viewCenterPos;

	protected bool _extentsDirty;

	protected bool _isMoving;

	public PostProcessVolume PostProc;

	public PostProcessLayer PPLayer;

	public SelectionOutlineSolidPP OutlineSettings;

	[Header("Screen Shake")]
	public float ScreenShakeSize;

	public float ScreenShakeLen;

	protected Vector3 _lastScreenShakeOffset;

	protected Vector3 _nextScreenShakeOffset;

	protected float _lastScreenShakeTime;

	protected const float kScreenShakeOffsetLen = 1f / 30f;

	[Header("Camera Swing")]
	protected Vector3 _swingSize;

	protected float _swingStartTime;

	protected float _swingEndTime;

	public AmplifyOcclusionEffect Occlusion;

	public int DefaultCullingMask;

	private const int kAssetsPPU = 16;

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	private void OnDestroy()
	{
	}

	protected virtual void RefreshPostProc()
	{
	}

	protected virtual void MyUpdate()
	{
	}

	public void RefreshExtents(bool force = false)
	{
	}

	public Vector3 GetWorldPos(Vector2 screenPos)
	{
		return default(Vector3);
	}

	public Vector3 GetWorldPosAtZ(Vector2 screenPos, float z)
	{
		return default(Vector3);
	}

	public virtual void SetSteadyPos(Vector3 pos)
	{
	}

	public virtual void MoveSteadyPos(Vector3 amt)
	{
	}

	public bool IsMoving()
	{
		return false;
	}

	public float GetOrthoSizeForPixelSize(int tgtPixelSize)
	{
		return 0f;
	}

	public float GetOrthoSizeForZoom(int zoom)
	{
		return 0f;
	}

	public int GetPixelZoom(int tgtPixelSize)
	{
		return 0;
	}

	public void SetOrtho(float ortho)
	{
	}

	public float GetCamSizeForBoard(int cols, int rows)
	{
		return 0f;
	}

	public Vector3 GetCamPosForBoard(int cols, int rows)
	{
		return default(Vector3);
	}

	public Vector3 GetCamPosForBoard(int minX, int minY, int maxX, int maxY)
	{
		return default(Vector3);
	}

	public virtual void ShakeScreen(float size, float len)
	{
	}

	public virtual void SwingCamera(Vector2 amt, float len)
	{
	}

	public virtual Vector3 ShakeSteadyPosIfNecessary(Vector3 pos)
	{
		return default(Vector3);
	}

	public float GetMinY()
	{
		return 0f;
	}

	public float GetMaxY()
	{
		return 0f;
	}

	public float GetMinX()
	{
		return 0f;
	}

	public float GetMaxX()
	{
		return 0f;
	}

	public Vector3 GetCenterPos()
	{
		return default(Vector3);
	}

	public float GetViewportHeight()
	{
		return 0f;
	}

	public Vector3 GetMouseWorldPos()
	{
		return default(Vector3);
	}

	public virtual Vector3 ScreenToWorldPos(Vector2 screenPos)
	{
		return default(Vector3);
	}

	public void SetOutlineColor(Color c)
	{
	}
}
