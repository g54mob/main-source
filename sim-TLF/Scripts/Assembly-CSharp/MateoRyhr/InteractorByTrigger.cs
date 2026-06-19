using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class InteractorByTrigger : MonoBehaviour
	{
		[SerializeField]
		private Interactor _interactor;

		[SerializeField]
		private InteractionType _interactionType;

		[Tooltip("Start point to check with raycast that is in front and not behind something")]
		[SerializeField]
		private Transform _isInFrontCheckStart;

		[SerializeField]
		private bool _checkThatIsInFront;

		public UnityEvent OnInteractableEnter;

		public UnityEvent OnInteractableExit;

		public InteractionType InteractionType => _interactionType;

		public string Message { get; private set; }

		private void OnTriggerEnter(Collider other)
		{
			if (_checkThatIsInFront && !CheckIsInFront(other))
			{
				return;
			}
			Interactable component = other.GetComponent<Interactable>();
			if (component.InteractionType == _interactionType)
			{
				if (_interactor.Interactable == null)
				{
					_interactor.Interactable = component;
				}
				OnInteractableEnter.Invoke();
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (_checkThatIsInFront && !CheckIsInFront(other))
			{
				return;
			}
			Interactable component = other.GetComponent<Interactable>();
			if (component.InteractionType == _interactionType)
			{
				if (_interactor.Interactable == null)
				{
					_interactor.Interactable = component;
				}
				OnInteractableEnter.Invoke();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			_interactor.Interactable = null;
			OnInteractableExit?.Invoke();
		}

		private bool CheckIsInFront(Collider interactable)
		{
			Vector3 direction = interactable.bounds.center - _isInFrontCheckStart.position;
			Physics.Raycast(_isInFrontCheckStart.position, direction, out var hitInfo);
			if (hitInfo.collider.gameObject.name == interactable.gameObject.name)
			{
				return true;
			}
			return false;
		}
	}
}
