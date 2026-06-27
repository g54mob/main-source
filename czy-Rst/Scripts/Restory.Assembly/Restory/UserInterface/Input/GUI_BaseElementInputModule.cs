using System;
using Restory.Gameplay.PlayerInput;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UserInterface.Input
{
	public abstract class GUI_BaseElementInputModule : UIBehaviour, IDisposable
	{
		private IPlayerInput playerInput;

		private bool subscribed;

		public IPlayerInput PlayerInput => playerInput;

		[Inject]
		private void Construct(IPlayerInput playerInput, DisposableManager disposableManager)
		{
			this.playerInput = playerInput;
			disposableManager.Add(this);
			if (base.isActiveAndEnabled && CanSubscribeInput())
			{
				SubscribeInput();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (playerInput != null && CanSubscribeInput())
			{
				SubscribeInput();
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (playerInput != null)
			{
				UnsubscribeInput();
				subscribed = false;
			}
		}

		protected abstract bool CanSubscribeInput();

		protected abstract void OnSubscribeInput();

		protected abstract void OnUnsubscribeInput();

		public bool IsSubscribed()
		{
			return subscribed;
		}

		protected void SubscribeInput()
		{
			if (!subscribed)
			{
				subscribed = true;
				OnSubscribeInput();
			}
		}

		protected void UnsubscribeInput()
		{
			if (subscribed)
			{
				OnUnsubscribeInput();
				subscribed = false;
			}
		}

		protected void SubscribeOrUnsubscribeInput()
		{
			if (CanSubscribeInput())
			{
				SubscribeInput();
			}
			else
			{
				UnsubscribeInput();
			}
		}

		public virtual void Dispose()
		{
			if (playerInput != null)
			{
				OnUnsubscribeInput();
			}
		}
	}
}
