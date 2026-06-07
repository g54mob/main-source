using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.RenderTextureSystem
{
	public class RenderTextureSystem : SingletonBehaviour<RenderTextureSystem>
	{
		private struct RenderTextureCameraSetup
		{
			public CameraClearFlags clearFlags;

			public int cullingMask;

			public bool orthographic;

			public RenderingPath renderingPath;

			public float depth;

			public StereoTargetEyeMask stereoTargetEye;

			public float orthographicSize;

			public float fieldOfView;

			public float nearClipPlane;

			public float farClipPlane;

			public float aspect;

			public RenderTextureCameraSetup(CameraClearFlags clearFlags, int cullingMask, bool orthographic, RenderingPath renderingPath, float depth, StereoTargetEyeMask stereoTargetEye, float orthographicSize, float fieldOfView, float nearClipPlane, float farClipPlane, float aspect)
			{
				this.clearFlags = clearFlags;
				this.cullingMask = cullingMask;
				this.orthographic = orthographic;
				this.renderingPath = renderingPath;
				this.depth = depth;
				this.stereoTargetEye = stereoTargetEye;
				this.orthographicSize = orthographicSize;
				this.fieldOfView = fieldOfView;
				this.nearClipPlane = nearClipPlane;
				this.farClipPlane = farClipPlane;
				this.aspect = aspect;
			}
		}

		public LayerMask renderCamClearFlags;

		private readonly Queue<IRenderJob> jobs = new Queue<IRenderJob>();

		private IRenderJob currentJob;

		private RenderTexture currentRenderTexture;

		private Camera cam;

		private Vector3 suggestedPosition;

		private Quaternion suggestedRotation;

		private RenderTextureCameraSetup initialSetup;

		private RenderTextureCameraSetup currentSetup;

		public int PendingJobs => jobs.Count;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			SetupCamera();
		}

		public void AddRenderJob(IRenderJob job)
		{
			jobs.Enqueue(job);
		}

		private void Update()
		{
			if (Time.frameCount >= 2)
			{
				RenderNextJob();
			}
		}

		private void RenderNextJob()
		{
			if (currentJob != null)
			{
				if (!currentRenderTexture.autoGenerateMips)
				{
					currentRenderTexture.GenerateMips();
				}
				currentJob.OnRenderCompleted(currentRenderTexture);
				cam.targetTexture = null;
				currentRenderTexture = null;
				currentJob = null;
			}
			if (jobs.Count != 0)
			{
				currentJob = jobs.Dequeue();
				float num = currentJob.Prepare(suggestedPosition, suggestedRotation);
				if (cam.orthographic)
				{
					cam.orthographicSize = num;
				}
				else
				{
					cam.fieldOfView = num;
				}
				Vector2Int targetTextureSize = currentJob.GetTargetTextureSize();
				currentRenderTexture = new RenderTexture(targetTextureSize.x, targetTextureSize.y, 0, (!currentJob.NeedsAlpha) ? RenderTextureFormat.RGB565 : RenderTextureFormat.ARGB32);
				currentRenderTexture.useMipMap = true;
				currentRenderTexture.mipMapBias = currentJob.GetMipMapBias();
				cam.targetTexture = currentRenderTexture;
				cam.Render();
			}
		}

		private void SetupCamera()
		{
			cam = base.gameObject.GetComponent<Camera>();
			if (!cam)
			{
				cam = base.gameObject.AddComponent<Camera>();
			}
			cam.enabled = false;
			cam.clearFlags = CameraClearFlags.Color;
			cam.cullingMask = renderCamClearFlags;
			cam.orthographic = true;
			cam.renderingPath = RenderingPath.VertexLit;
			cam.depth = -100f;
			cam.stereoTargetEye = StereoTargetEyeMask.None;
			initialSetup = new RenderTextureCameraSetup(cam.clearFlags, cam.cullingMask, cam.orthographic, cam.renderingPath, cam.depth, cam.stereoTargetEye, cam.orthographicSize, cam.fieldOfView, cam.nearClipPlane, cam.farClipPlane, cam.aspect);
			currentSetup = initialSetup;
			CalculateSuggestedPoint();
		}

		private void UpdateCamera()
		{
			cam.clearFlags = currentSetup.clearFlags;
			cam.cullingMask = currentSetup.cullingMask;
			cam.orthographic = currentSetup.orthographic;
			cam.renderingPath = currentSetup.renderingPath;
			cam.depth = currentSetup.depth;
			cam.stereoTargetEye = currentSetup.stereoTargetEye;
			cam.orthographicSize = currentSetup.orthographicSize;
			cam.fieldOfView = currentSetup.fieldOfView;
			cam.nearClipPlane = currentSetup.nearClipPlane;
			cam.farClipPlane = currentSetup.farClipPlane;
			cam.aspect = currentSetup.aspect;
		}

		private void CalculateSuggestedPoint()
		{
			float num = (cam.nearClipPlane + cam.farClipPlane) / 2f;
			suggestedPosition = base.transform.position + base.transform.forward * num;
			suggestedRotation = Quaternion.LookRotation(base.transform.forward, base.transform.up);
		}

		public Camera GetCamera()
		{
			return cam;
		}

		public void SetClippingPlanes(float near, float far)
		{
			currentSetup.nearClipPlane = near;
			currentSetup.farClipPlane = far;
			cam.nearClipPlane = near;
			cam.farClipPlane = far;
		}

		public void SetAspectRatio(float aspect)
		{
			currentSetup.aspect = aspect;
			cam.aspect = aspect;
		}

		public void SetOrthographic(bool orthographic)
		{
			currentSetup.orthographic = orthographic;
			cam.orthographic = orthographic;
		}

		public void ResetCameraSetup()
		{
			currentSetup = initialSetup;
			UpdateCamera();
		}

		public void SetRenderPath(RenderingPath path)
		{
			currentSetup.renderingPath = path;
			cam.renderingPath = path;
		}

		public void ResetFov()
		{
			cam.fieldOfView = initialSetup.fieldOfView;
		}

		public void AbortRendering()
		{
			jobs.Clear();
			currentJob = null;
			if (currentRenderTexture != null)
			{
				currentRenderTexture.Release();
				currentRenderTexture = null;
			}
		}
	}
}
