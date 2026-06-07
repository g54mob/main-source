using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class Controller : MonoBehaviour
	{
		public abstract bool IsPlayer { get; }

		public IControllable Controllable { get; private set; }

		public EControllerContext Context
		{
			get
			{
				if (Controllable == null)
				{
					return EControllerContext.NONE;
				}
				return Controllable.Context;
			}
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public bool TakeControl(IControllable controllable)
		{
			if (controllable == null)
			{
				return false;
			}
			IControllable controllable2 = Controllable;
			LeaveControl();
			OnTakeControl(controllable);
			GetInputReceiver(controllable);
			controllable.OnControlledBy(this);
			OnChangeControllable(controllable2, controllable);
			return true;
		}

		protected void LeaveControl()
		{
			if (Controllable != null)
			{
				Controllable.OnUncontrolledBy(this);
				OnLeaveControl();
				LoseInputReceiver();
			}
		}

		protected virtual void OnTakeControl(IControllable controllable)
		{
			Controllable = controllable;
		}

		protected virtual void OnLeaveControl()
		{
			Controllable = null;
		}

		protected virtual void OnChangeControllable(IControllable former, IControllable next)
		{
		}

		protected abstract void GetInputReceiver(IControllable controllable);

		protected abstract void LoseInputReceiver();
	}
}
