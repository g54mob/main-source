using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera Main Script")]
public class TOD_Camera : MonoBehaviour
{
	public Vector3 DomePosOffset = Vector3.zero;

	public bool DomePosToCamera = true;

	public float DomeScaleFactor = 0.95f;

	public bool DomeScaleToFarClip = true;

	public TOD_Sky sky;

	private Camera cameraComponent;

	private Transform cameraTransform;

	public bool HDR
	{
		get
		{
			if (!cameraComponent)
			{
				return false;
			}
			return cameraComponent.allowHDR;
		}
	}

	public void DoDomePosToCamera()
	{
		Vector3 position = cameraTransform.position + cameraTransform.rotation * DomePosOffset;
		sky.Components.DomeTransform.position = position;
	}

	public void DoDomeScaleToFarClip()
	{
		float num = DomeScaleFactor * cameraComponent.farClipPlane;
		Vector3 localScale = new Vector3(num, num, num);
		sky.Components.DomeTransform.localScale = localScale;
	}

	protected virtual void OnDisable()
	{
		RenderPipelineManager.beginContextRendering -= OnBeginFrameRendering;
	}

	protected void OnEnable()
	{
		cameraComponent = GetComponent<Camera>();
		cameraTransform = GetComponent<Transform>();
		if (!sky)
		{
			sky = Object.FindFirstObjectByType(typeof(TOD_Sky)) as TOD_Sky;
		}
		RenderPipelineManager.beginContextRendering += OnBeginFrameRendering;
	}

	protected void OnValidate()
	{
		DomeScaleFactor = Mathf.Clamp(DomeScaleFactor, 0.01f, 1f);
	}

	protected void Update()
	{
		if ((bool)sky && sky.Initialized)
		{
			sky.Components.Camera = this;
			if (cameraComponent.clearFlags != CameraClearFlags.Color)
			{
				cameraComponent.clearFlags = CameraClearFlags.Color;
			}
			if (cameraComponent.backgroundColor != Color.clear)
			{
				cameraComponent.backgroundColor = Color.clear;
			}
			RenderSettings.skybox = sky.Resources.Skybox;
		}
	}

	private void OnBeginFrameRendering(ScriptableRenderContext context, List<Camera> cameras)
	{
		if ((bool)sky && sky.Initialized)
		{
			if (DomeScaleToFarClip)
			{
				DoDomeScaleToFarClip();
			}
			if (DomePosToCamera)
			{
				DoDomePosToCamera();
			}
		}
	}
}
