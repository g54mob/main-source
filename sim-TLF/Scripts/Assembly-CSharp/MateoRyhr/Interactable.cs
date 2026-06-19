using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class Interactable : MonoBehaviour, IGameObject
	{
		[SerializeField]
		private InteractionType _interactionType;

		[SerializeField]
		private string _message;

		private bool _enable;

		public UnityEvent OnInteraction;

		private GameObject _interactor;

		public InteractionType InteractionType => _interactionType;

		public string Message => _message;

		public GameObject GameObject => _interactor;

		private void Awake()
		{
			_enable = true;
		}

		public void Interact(GameObject interactor)
		{
			if (_enable)
			{
				_interactor = interactor;
				OnInteraction?.Invoke();
			}
		}

		public void Enable(float delay)
		{
			this.Invoke(delegate
			{
				_enable = true;
			}, delay);
		}

		public void Disable(float delay)
		{
			this.Invoke(delegate
			{
				_enable = false;
			}, delay);
		}
	}
}
