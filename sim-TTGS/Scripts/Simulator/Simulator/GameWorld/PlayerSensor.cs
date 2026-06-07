using Dhs5.Utility.Updates;
using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class PlayerSensor : Sensor
	{
		public enum EPhysicMode
		{
			NONE = 0,
			GROUND = 1,
			WALLS = 2,
			CEILING = 3
		}

		public delegate void SensableChange(ISensable former, ISensable next);

		private Collider m_sensedCollider;

		private RaycastHit m_physicTargetHit;

		private static ISensable _current;

		public override bool IsPlayer => true;

		public Collider SensedCollider => m_sensedCollider;

		public EPhysicMode PhysicMode { get; set; }

		public bool SensePhysicTarget { get; private set; }

		public RaycastHit PhysicTargetHit => m_physicTargetHit;

		public static event SensableChange SensableChanged;

		private void OnEnable()
		{
			HUDPopup.ActiveStateChanged += OnHUDPopupActiveStateChanged;
		}

		private void OnDisable()
		{
			HUDPopup.ActiveStateChanged -= OnHUDPopupActiveStateChanged;
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			Updater.RegisterChannelCallback(register: true, EUpdateChannel.SENSORS, OnUpdate);
			CameraManager.BlendStarted += Unsense;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			Updater.RegisterChannelCallback(register: false, EUpdateChannel.SENSORS, OnUpdate);
			CameraManager.BlendStarted -= Unsense;
		}

		public static ISensable GetSensable()
		{
			return _current;
		}

		private void OnUpdate(float deltaTime)
		{
			if (!CameraManager.IsBlending)
			{
				Sense();
			}
		}

		private void Sense()
		{
			Ray ray = TransientManager<CameraManager>.Instance.Camera.ScreenPointToRay(new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f));
			if (Physics.Raycast(ray, out var hitInfo, PlayerSensorSettings.SensableMaxDistance, PlayerSensorSettings.SensableMask, QueryTriggerInteraction.Collide) && TryGetSensable(hitInfo, out var sensable))
			{
				SetSensable(sensable);
				m_sensedCollider = hitInfo.collider;
			}
			else
			{
				Unsense(default(CinemachineCore.BlendEventParams));
			}
			switch (PhysicMode)
			{
			case EPhysicMode.NONE:
				SensePhysicTarget = false;
				break;
			case EPhysicMode.GROUND:
				SensePhysicTarget = Physics.Raycast(ray, out m_physicTargetHit, PlayerSensorSettings.GroundMaxDistance, PlayerSensorSettings.GroundMask, QueryTriggerInteraction.Ignore);
				break;
			case EPhysicMode.WALLS:
				SensePhysicTarget = Physics.Raycast(ray, out m_physicTargetHit, PlayerSensorSettings.GroundMaxDistance, PlayerSensorSettings.WallsMask, QueryTriggerInteraction.Ignore);
				break;
			case EPhysicMode.CEILING:
				SensePhysicTarget = Physics.Raycast(ray, out m_physicTargetHit, PlayerSensorSettings.GroundMaxDistance, PlayerSensorSettings.CeilingMask, QueryTriggerInteraction.Ignore);
				break;
			}
		}

		private void Unsense(CinemachineCore.BlendEventParams _)
		{
			SetSensable(null);
			m_sensedCollider = null;
		}

		protected virtual bool TryGetSensable(RaycastHit hit, out ISensable sensable)
		{
			if (hit.collider.TryGetComponent<ISensable>(out sensable))
			{
				if (sensable.CanBeSensed())
				{
					return true;
				}
				if (sensable is SensableLink sensableLink)
				{
					return sensableLink.HasSensable(out sensable);
				}
			}
			sensable = null;
			return false;
		}

		protected override void OnSensed(ISensable sensable)
		{
			base.OnSensed(sensable);
			_current = sensable;
		}

		protected override void OnUnsensed(ISensable sensable)
		{
			base.OnUnsensed(sensable);
			_current = null;
		}

		protected override void OnChangeSensable(ISensable former, ISensable next)
		{
			base.OnChangeSensable(former, next);
			PlayerSensor.SensableChanged?.Invoke(former, next);
		}

		private void OnHUDPopupActiveStateChanged(bool isActive)
		{
			if (isActive)
			{
				Unsense(default(CinemachineCore.BlendEventParams));
			}
		}
	}
}
