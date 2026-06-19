using System;
using Items;
using JSAM;
using UnityEngine;
using UnityEngine.Events;

namespace WorldEnvironment.FunctionalObjects
{
	[RequireComponent(typeof(Collider))]
	public class SwitchHoldingPoint : MonoBehaviour, IUsable
	{
		public UnityEvent HoldingStart;

		public UnityEvent HoldingEnd;

		[SerializeField]
		private bool _interactable;

		protected Action<bool> StateChanged;

		private bool _holding;

		public bool Interactable
		{
			get
			{
				return _interactable;
			}
			set
			{
				_interactable = value;
			}
		}

		public bool Holding => _holding;

		void IUsable.UnUse()
		{
			AudioManager.PlaySound(InteractionLibrarySounds.SwitchHeavyClick);
			_holding = false;
			StateChanged?.Invoke(_holding);
			if (_interactable)
			{
				HoldingEnd?.Invoke();
			}
		}

		void IUsable.Use()
		{
			AudioManager.PlaySound(InteractionLibrarySounds.SwitchHeavyClick);
			_holding = true;
			StateChanged?.Invoke(_holding);
			if (_interactable)
			{
				HoldingStart?.Invoke();
			}
		}
	}
}
