using Dhs5.Utility.Tags;
using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class Character : MonoBehaviour, IControllable
	{
		[Header("Character")]
		[SerializeField]
		private GameplayTagsList m_tags;

		[Header("Grab")]
		[SerializeField]
		protected CharacterGrabber m_grabber;

		public abstract bool IsPlayer { get; }

		public Controller Controller { get; private set; }

		public bool IsControlled => Controller != null;

		public Vector3 Position => base.transform.position;

		public Vector3 Forward => base.transform.forward;

		public Quaternion Rotation => base.transform.rotation;

		public abstract CinemachineCamera Camera { get; }

		public EControllerContext Context => EControllerContext.CHARACTER;

		protected virtual void OnEnable()
		{
			this.RegisterGameplayTags(m_tags);
		}

		protected virtual void OnDisable()
		{
			this.UnregisterGameplayTags();
		}

		public virtual void OnControlledBy(Controller controller)
		{
			Controller = controller;
		}

		public virtual void OnUncontrolledBy(Controller controller)
		{
			Controller = null;
		}

		public IGrabbable GetGrabbable()
		{
			if (m_grabber == null)
			{
				return null;
			}
			return m_grabber.GetGrabbable();
		}

		public bool HasGrabbable(out IGrabbable grabbable)
		{
			grabbable = GetGrabbable();
			return grabbable != null;
		}

		public bool CanGiveGrabbable(out IGrabbable grabbable)
		{
			if (m_grabber == null)
			{
				grabbable = null;
				return false;
			}
			return m_grabber.CanGive(out grabbable);
		}

		public IGrabbable GiveGrabbableTo(IGrabber grabber)
		{
			IGrabbable grabbable = m_grabber.GiveTo(grabber);
			OnGave(grabbable);
			return grabbable;
		}

		public virtual bool CanGrab(IGrabbable grabbable)
		{
			IStackable stackable;
			if (m_grabber != null && m_grabber.CanGrab(grabbable))
			{
				return !HasStackable(out stackable);
			}
			return false;
		}

		public bool Grab(IGrabbable grabbable)
		{
			if (CanGrab(grabbable) && m_grabber.Grab(grabbable))
			{
				OnGrab(grabbable);
				return true;
			}
			return false;
		}

		public bool TakeFrom(IGiver giver)
		{
			if (giver.CanGive(out var grabbable) && CanGrab(grabbable) && m_grabber.Grab(giver.GiveTo(m_grabber)))
			{
				OnGrab(grabbable);
				return true;
			}
			return false;
		}

		public bool Drop(out IGrabbable grabbable)
		{
			if (m_grabber != null && m_grabber.Drop(out grabbable))
			{
				OnDrop(grabbable);
				return true;
			}
			grabbable = null;
			return false;
		}

		protected virtual void OnGave(IGrabbable grabbable)
		{
		}

		protected virtual void OnGrab(IGrabbable grabbable)
		{
		}

		protected virtual void OnDrop(IGrabbable grabbable)
		{
		}

		public virtual bool CanHandleStackable(IStackable stackable)
		{
			IGrabbable grabbable;
			return !m_grabber.HasGrabbable(out grabbable);
		}

		public abstract void OnHandleStackable(IStackable stackable);

		public abstract bool HasStackable(out IStackable stackable);

		public abstract bool CanGiveStackable();

		public abstract IStackable GiveStackable();
	}
}
