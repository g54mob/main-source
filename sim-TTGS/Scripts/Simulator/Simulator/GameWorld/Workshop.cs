using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class Workshop : MonoBehaviour, IControllable, IMainInteractable, ISensable, ICancelInputReceiver
	{
		[Header("Controller")]
		[SerializeField]
		private CinemachineCamera m_camera;

		[SerializeField]
		private EControllerContext m_context;

		[SerializeField]
		private Transform m_characterAnchor;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private InputHint m_inputHint;

		public Controller Controller { get; private set; }

		public bool IsControlled => Controller != null;

		public Vector3 Position => m_characterAnchor.position;

		public Quaternion Rotation => m_characterAnchor.rotation;

		public CinemachineCamera Camera => m_camera;

		public EControllerContext Context => m_context;

		protected virtual void OnEnable()
		{
			CameraManager.CamDeactivated += OnAnyCamDeactivated;
		}

		protected virtual void OnDisable()
		{
			CameraManager.CamDeactivated -= OnAnyCamDeactivated;
		}

		protected void QuitWorkshop()
		{
			if (IsControlled && Controller is PlayerController playerController && CanQuitWorkshop())
			{
				OnQuitWorkshop();
				playerController.TakeControlOfCharacter();
			}
		}

		protected virtual void OnQuitWorkshop()
		{
		}

		protected abstract bool CanQuitWorkshop();

		public virtual void OnControlledBy(Controller controller)
		{
			Controller = controller;
			if (Controller.IsPlayer)
			{
				PlayerCharacter.CameraDeactivated += OnControlledByPlayerPostBlend;
				ICancelInputReceiver.SetCurrent(this);
			}
		}

		public virtual void OnUncontrolledBy(Controller controller)
		{
			Controller = null;
			ICancelInputReceiver.SetCurrent(null);
		}

		public virtual bool CanMainInteract(Character character)
		{
			if (!IsControlled)
			{
				return character.IsControlled;
			}
			return false;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			character.Controller.TakeControl(this);
		}

		public virtual bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
			}
			return false;
		}

		public virtual void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
			}
		}

		public virtual void OnUnsensed()
		{
			m_outline.enabled = false;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
		}

		public virtual void OnCancel()
		{
			QuitWorkshop();
		}

		protected virtual void OnControlledByPlayerPostBlend()
		{
			PlayerCharacter.CameraDeactivated -= OnControlledByPlayerPostBlend;
			World.PlayerCharacter.Anchor(m_characterAnchor);
		}

		private void OnAnyCamDeactivated(ICinemachineCamera camera)
		{
			if (camera as Object == Camera)
			{
				OnCameraDeactivated();
			}
		}

		protected virtual void OnCameraDeactivated()
		{
		}
	}
}
