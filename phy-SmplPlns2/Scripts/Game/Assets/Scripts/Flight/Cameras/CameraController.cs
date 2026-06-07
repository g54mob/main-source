using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public abstract class CameraController
	{
		public virtual Vector3 AngularVelocity => Vector3.zero;

		public bool AutoSwitchWhenBelowWater { get; protected set; }

		public CameraManagerScript CameraManager { get; private set; }

		public Transform CameraTransform => CameraManager.CameraTransform;

		public CameraVantageScript CameraVantage { get; protected set; }

		public bool IsActive { get; set; }

		public virtual float IsCockpitAudio => 0f;

		public virtual bool IsFirstPerson => false;

		public virtual bool IsRecenterAvailable => false;

		public bool IsSelected { get; set; }

		public string Name { get; set; }

		public virtual float PreferredClosestShadowDistance => 2f;

		public bool RequiresDopplerFix { get; protected set; } = true;

		public bool RequiresPlaneCamera { get; protected set; }

		public CameraController(CameraManagerScript cameraManager)
		{
			IsActive = true;
			CameraManager = cameraManager;
		}

		public virtual void AddYaw(float yaw)
		{
			Debug.LogWarning("Base camera controller add yaw is not implemented.");
		}

		public virtual void AircraftRepositioned()
		{
		}

		public virtual bool AllowGunReticle(Transform targetingTransform)
		{
			return false;
		}

		public virtual bool AllowMissileLocking(Transform targetingTransform)
		{
			return false;
		}

		public virtual void HandleInput(InputEvent e)
		{
		}

		public virtual void HandlePinch(PinchEvent e)
		{
		}

		public virtual void HandleScroll(MouseScrollEvent e)
		{
		}

		public virtual void LateUpdate()
		{
		}

		public virtual void OnDeselected()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void OnSelected()
		{
		}

		public virtual void OnXRDisabled()
		{
		}

		public virtual void OnXREnabled()
		{
		}

		public virtual void RecenterView()
		{
		}

		public abstract void Update(int frameCount);

		public virtual void UpdateCursor()
		{
		}
	}
}
