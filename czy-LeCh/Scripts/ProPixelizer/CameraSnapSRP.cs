using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Camera))]
public class CameraSnapSRP : MonoBehaviour
{
	public enum PixelSizeMode
	{
		FixedWorldSpacePixelSize = 0,
		UseCameraSize = 1
	}

	private IEnumerable<ObjectRenderSnapable> _snapables;

	private Camera _camera;

	public PixelSizeMode Mode;

	public float PixelSize = 0.032f;

	private void Start()
	{
		_camera = GetComponent<Camera>();
		if (!_camera.orthographic)
		{
			Debug.LogWarning("Camera snap is designed to prevent pixel creep in orthographic projection. It is not possible to fix creep using perspective projection, as object pixel size can change.");
		}
	}

	public void Update()
	{
		if (Mode == PixelSizeMode.FixedWorldSpacePixelSize)
		{
			_camera.orthographicSize = (float)_camera.scaledPixelHeight / 2f * PixelSize;
		}
		else
		{
			PixelSize = (float)_camera.scaledPixelHeight / 2f * _camera.orthographicSize;
		}
	}

	public void OnEnable()
	{
		RenderPipelineManager.beginCameraRendering += BeginCameraRendering;
		RenderPipelineManager.endCameraRendering += EndCameraRendering;
	}

	public void Unsubscribe()
	{
		RenderPipelineManager.beginCameraRendering -= BeginCameraRendering;
		RenderPipelineManager.endCameraRendering -= EndCameraRendering;
	}

	public void BeginCameraRendering(ScriptableRenderContext context, Camera camera)
	{
		if (camera == _camera)
		{
			Snap();
		}
	}

	public void EndCameraRendering(ScriptableRenderContext context, Camera camera)
	{
		if (camera == _camera)
		{
			Release();
		}
	}

	public void Snap()
	{
		if (_camera == null)
		{
			Unsubscribe();
			return;
		}
		UniversalRenderPipelineAsset universalRenderPipelineAsset = QualitySettings.renderPipeline as UniversalRenderPipelineAsset;
		if (universalRenderPipelineAsset == null)
		{
			universalRenderPipelineAsset = GraphicsSettings.renderPipelineAsset as UniversalRenderPipelineAsset;
		}
		if (universalRenderPipelineAsset == null)
		{
			throw new Exception("Render pipeline asset in QualitySettings and GraphicsSettings are either null or not a UniversalRenderPipelineAsset.");
		}
		float renderScale = universalRenderPipelineAsset.renderScale;
		_snapables = new List<ObjectRenderSnapable>(UnityEngine.Object.FindObjectsOfType<ObjectRenderSnapable>());
		((List<ObjectRenderSnapable>)_snapables).Sort((ObjectRenderSnapable comp1, ObjectRenderSnapable comp2) => comp1.TransformDepth.CompareTo(comp2.TransformDepth));
		foreach (ObjectRenderSnapable snapable in _snapables)
		{
			snapable.SaveTransform();
		}
		foreach (ObjectRenderSnapable snapable2 in _snapables)
		{
			snapable2.SnapAngles(_camera);
		}
		float num = 2f * _camera.orthographicSize / ((float)_camera.pixelHeight * renderScale);
		_camera.ResetWorldToCameraMatrix();
		Matrix4x4 cameraToWorldMatrix = _camera.cameraToWorldMatrix;
		Matrix4x4 worldToCameraMatrix = _camera.worldToCameraMatrix;
		foreach (ObjectRenderSnapable snapable3 in _snapables)
		{
			Vector3 position;
			if (snapable3.AlignPixelGrid)
			{
				Vector3 vector = worldToCameraMatrix.MultiplyPoint(snapable3.PixelGridReferencePosition);
				Vector3 vector2 = worldToCameraMatrix.MultiplyPoint(snapable3.WorldPositionPreSnap) - vector;
				float num2 = (float)snapable3.GetPixelSize() * num;
				Vector3 vector3 = new Vector3((float)Mathf.RoundToInt(vector2.x / num2) + snapable3.OffsetBias, (float)Mathf.RoundToInt(vector2.y / num2) + snapable3.OffsetBias, (float)Mathf.RoundToInt(vector2.z / num2) + snapable3.OffsetBias);
				Vector3 vector4 = new Vector3(Mathf.RoundToInt(vector.x / num), Mathf.RoundToInt(vector.y / num), Mathf.RoundToInt(vector.z / num));
				position = cameraToWorldMatrix.MultiplyPoint(num * vector4 + vector3 * num2);
			}
			else
			{
				Vector3 vector5 = worldToCameraMatrix.MultiplyPoint(snapable3.transform.position) / num;
				Vector3 vector6 = new Vector3((float)Mathf.RoundToInt(vector5.x) + snapable3.OffsetBias, (float)Mathf.RoundToInt(vector5.y) + snapable3.OffsetBias, (float)Mathf.RoundToInt(vector5.z) + snapable3.OffsetBias);
				position = cameraToWorldMatrix.MultiplyPoint(vector6 * num);
			}
			if (snapable3.SnapPosition)
			{
				snapable3.transform.position = position;
			}
		}
	}

	public void Release()
	{
		foreach (ObjectRenderSnapable item in _snapables.Reverse())
		{
			item.RestoreTransform();
		}
	}
}
