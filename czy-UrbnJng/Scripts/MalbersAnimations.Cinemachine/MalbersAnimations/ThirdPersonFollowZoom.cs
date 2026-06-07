using Cinemachine;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Camera/Third Person Follow Zoom (Cinemachine)")]
	[DefaultExecutionOrder(121)]
	public class ThirdPersonFollowZoom : MonoBehaviour
	{
		[Tooltip("Update mode for the Aim Logic")]
		public UpdateType updateMode;

		[Tooltip("The Camera can rotate independent of the Game Time")]
		public BoolReference unscaledTime = new BoolReference(value: true);

		[Tooltip("Zoom In Min Value")]
		public FloatReference ZoomMin = new FloatReference(1f);

		[Tooltip("Zoom Out Max Value")]
		public FloatReference ZoomMax = new FloatReference(12f);

		[Tooltip("Zoom step changes")]
		public FloatReference ZoomStep = new FloatReference(1f);

		[Tooltip("Zoom smooth value to change between steps")]
		public FloatReference ZoomLerp = new FloatReference(5f);

		private Cinemachine3rdPersonFollow TPF;

		private float TargetZoom { get; set; }

		public bool UnScaledTime
		{
			get
			{
				return unscaledTime;
			}
			set
			{
				unscaledTime.Value = value;
			}
		}

		private void Start()
		{
			TPF = this.FindComponent<Cinemachine3rdPersonFollow>();
			if (TryGetComponent<ThirdPersonFollowTarget>(out var component))
			{
				TargetZoom = component.CameraDistance;
			}
		}

		public void ZoomIn()
		{
			if (TPF != null && base.enabled)
			{
				TargetZoom = Mathf.Clamp(TargetZoom - (float)ZoomStep, ZoomMin, ZoomMax);
			}
		}

		public void ZoomOut()
		{
			if (TPF != null && base.enabled)
			{
				TargetZoom = Mathf.Clamp(TargetZoom + (float)ZoomStep, ZoomMin, ZoomMax);
			}
		}

		public void SetZoom(bool zoom)
		{
			if (zoom)
			{
				ZoomOut();
			}
			else
			{
				ZoomIn();
			}
		}

		public void SetZoom(float zoom)
		{
			SetZoom(zoom < 0f);
		}

		private void FixedUpdate()
		{
			if (updateMode == UpdateType.FixedUpdate)
			{
				CalculateZoom(UnScaledTime ? Time.fixedUnscaledDeltaTime : Time.fixedDeltaTime);
			}
		}

		private void LateUpdate()
		{
			if (updateMode == UpdateType.LateUpdate)
			{
				CalculateZoom(UnScaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
			}
		}

		private void CalculateZoom(float deltaTime)
		{
			if ((bool)TPF)
			{
				TPF.CameraDistance = Mathf.Lerp(TPF.CameraDistance, TargetZoom, (float)ZoomLerp * deltaTime);
			}
		}
	}
}
