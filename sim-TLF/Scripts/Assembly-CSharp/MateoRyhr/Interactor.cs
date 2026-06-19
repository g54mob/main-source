using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class Interactor : MonoBehaviour, IInteractor
	{
		private Interactable _interactable;

		public UnityEvent OnInteractableEnter;

		public UnityEvent OnInteractableExit;

		private bool _hasInteractable;

		public Interactable Interactable
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

		public void Interact()
		{
			if (_interactable != null)
			{
				_interactable.Interact(base.gameObject);
			}
		}

		private void FixedUpdate()
		{
			if (Interactable != null)
			{
				if (!_hasInteractable)
				{
					OnInteractableEnter?.Invoke();
					_hasInteractable = true;
				}
			}
			else if (_hasInteractable)
			{
				OnInteractableExit?.Invoke();
				_hasInteractable = false;
			}
		}
	}
}
