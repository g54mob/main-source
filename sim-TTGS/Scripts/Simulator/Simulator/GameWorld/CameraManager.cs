using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Simulator.GameWorld
{
	public class CameraManager : TransientManager<CameraManager>
	{
		[Header("Camera")]
		[SerializeField]
		private Camera m_camera;

		[SerializeField]
		private CinemachineBrain m_brain;

		[SerializeField]
		private CinemachineBrainEvents m_brainEvents;

		[Header("Raycaster")]
		[SerializeField]
		private PhysicsRaycaster m_raycaster;

		private int m_layerFlagValueVisualEffects;

		private static bool _graphicRaycasterEnabled;

		public Camera Camera => m_camera;

		public CinemachineBrain Brain => m_brain;

		public static bool IsBlending { get; private set; }

		public static bool UpdateFPSCameras { get; set; } = true;

		public static bool GraphicRaycasterEnabled
		{
			get
			{
				return _graphicRaycasterEnabled;
			}
			set
			{
				_graphicRaycasterEnabled = value;
				if (TransientManager<CameraManager>.Instance != null)
				{
					TransientManager<CameraManager>.Instance.m_raycaster.enabled = value;
				}
			}
		}

		public static event Action<CinemachineCore.BlendEventParams> BlendStarted;

		public static event Action BlendFinished;

		public static event Action PostBlendFinished;

		public static event Action<ICinemachineCamera> CamActivated;

		public static event Action<ICinemachineCamera> CamDeactivated;

		private void OnBlendStarted(CinemachineCore.BlendEventParams blendEventParams)
		{
			IsBlending = true;
			CameraManager.BlendStarted?.Invoke(blendEventParams);
		}

		private void OnBlendFinished(ICinemachineMixer mixer, ICinemachineCamera cam)
		{
			CameraManager.BlendFinished?.Invoke();
			IsBlending = false;
			CameraManager.PostBlendFinished?.Invoke();
		}

		private void OnCamActivated(ICinemachineMixer mixer, ICinemachineCamera cam)
		{
			CameraManager.CamActivated?.Invoke(cam);
		}

		private void OnCamDeactivated(ICinemachineMixer mixer, ICinemachineCamera cam)
		{
			CameraManager.CamDeactivated?.Invoke(cam);
		}

		private void Start()
		{
			m_layerFlagValueVisualEffects = LayerMask.NameToLayer("VisualEffects");
			OnVisualEffectsValueChanged_UpdateCullingMask(AccessibilityApplicationOptions.VisualEffects);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			AccessibilityApplicationOptions.VisualEffects.OnValueChanged += OnVisualEffectsValueChanged_UpdateCullingMask;
			m_brainEvents.BlendCreatedEvent.AddListener(OnBlendStarted);
			m_brainEvents.BlendFinishedEvent.AddListener(OnBlendFinished);
			m_brainEvents.CameraActivatedEvent.AddListener(OnCamActivated);
			m_brainEvents.CameraDeactivatedEvent.AddListener(OnCamDeactivated);
			m_raycaster.enabled = GraphicRaycasterEnabled;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			AccessibilityApplicationOptions.VisualEffects.OnValueChanged -= OnVisualEffectsValueChanged_UpdateCullingMask;
			m_brainEvents.BlendCreatedEvent.RemoveListener(OnBlendStarted);
			m_brainEvents.BlendFinishedEvent.RemoveListener(OnBlendFinished);
			m_brainEvents.CameraActivatedEvent.RemoveListener(OnCamActivated);
			m_brainEvents.CameraDeactivatedEvent.RemoveListener(OnCamDeactivated);
		}

		private void OnVisualEffectsValueChanged_UpdateCullingMask(bool value)
		{
			if (value)
			{
				m_camera.cullingMask |= 1 << m_layerFlagValueVisualEffects;
			}
			else
			{
				m_camera.cullingMask &= ~(1 << m_layerFlagValueVisualEffects);
			}
		}
	}
}
