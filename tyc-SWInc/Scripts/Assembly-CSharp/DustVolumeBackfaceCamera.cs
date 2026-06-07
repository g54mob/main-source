using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class DustVolumeBackfaceCamera : MonoBehaviour
{
	public LayerMask dustVolumeLayer;

	public Shader backfaceDepthShader;

	[Range(0.25f, 1f)]
	public float resolutionScale = 0.5f;

	private Camera _mainCam;

	private Camera _backfaceCam;

	private RenderTexture _rt;

	private static readonly int BackfaceTexID = Shader.PropertyToID("_DustBackfaceTex");

	private static readonly int InvProjID = Shader.PropertyToID("_DustInvProj");

	private static readonly int CamToWorldID = Shader.PropertyToID("_DustCamToWorld");

	private void OnEnable()
	{
		_mainCam = GetComponent<Camera>();
		_mainCam.depthTextureMode |= DepthTextureMode.Depth;
		EnsureCamera();
		EnsureRT();
	}

	private void OnDisable()
	{
		Cleanup();
	}

	private void OnPreCull()
	{
		if (_mainCam == null)
		{
			_mainCam = GetComponent<Camera>();
		}
		if (!(backfaceDepthShader == null))
		{
			_mainCam.depthTextureMode |= DepthTextureMode.Depth;
			EnsureCamera();
			EnsureRT();
			SyncCameraSettings(_mainCam, _backfaceCam);
			_backfaceCam.cullingMask = dustVolumeLayer;
			_backfaceCam.clearFlags = CameraClearFlags.Color;
			_backfaceCam.backgroundColor = new Color(_mainCam.farClipPlane, 0f, 0f, 0f);
			_backfaceCam.targetTexture = _rt;
			_backfaceCam.enabled = false;
			Shader.SetGlobalTexture(BackfaceTexID, _rt);
			Shader.SetGlobalMatrix(InvProjID, _mainCam.projectionMatrix.inverse);
			Shader.SetGlobalMatrix(CamToWorldID, _mainCam.cameraToWorldMatrix);
			_backfaceCam.RenderWithShader(backfaceDepthShader, "");
		}
	}

	private void EnsureCamera()
	{
		if (!(_backfaceCam != null))
		{
			GameObject gameObject = new GameObject("Dust Backface Camera");
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			gameObject.transform.SetParent(base.transform, false);
			_backfaceCam = gameObject.AddComponent<Camera>();
			_backfaceCam.enabled = false;
		}
	}

	private void EnsureRT()
	{
		int num = Mathf.Max(1, Mathf.RoundToInt((float)Screen.width * resolutionScale));
		int num2 = Mathf.Max(1, Mathf.RoundToInt((float)Screen.height * resolutionScale));
		if (_rt != null && (_rt.width != num || _rt.height != num2))
		{
			_rt.Release();
			Object.DestroyImmediate(_rt);
			_rt = null;
		}
		if (_rt == null)
		{
			_rt = new RenderTexture(num, num2, 24, RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear);
			_rt.name = "Dust Backface Depth";
			_rt.filterMode = FilterMode.Bilinear;
			_rt.wrapMode = TextureWrapMode.Clamp;
			_rt.Create();
		}
	}

	private void SyncCameraSettings(Camera src, Camera dst)
	{
		dst.CopyFrom(src);
		dst.allowHDR = false;
		dst.allowMSAA = false;
		dst.renderingPath = RenderingPath.Forward;
		dst.useOcclusionCulling = false;
	}

	private void Cleanup()
	{
		if (_rt != null)
		{
			_rt.Release();
			Object.DestroyImmediate(_rt);
			_rt = null;
		}
		if (_backfaceCam != null)
		{
			Object.DestroyImmediate(_backfaceCam.gameObject);
			_backfaceCam = null;
		}
	}
}
