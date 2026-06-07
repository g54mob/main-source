using System.Collections.Generic;
using UnityEngine;

namespace DV.UIFramework
{
	public class InteractableGraphics : MonoBehaviour
	{
		public bool activeWhenInteractable;

		public List<GameObject> graphicsToFade = new List<GameObject>();

		private IHoverable interactable;

		private void Awake()
		{
			if (!TryGetComponent<IHoverable>(out interactable))
			{
				Debug.LogError("No IHoverable found on InteractableEffect!", this);
				return;
			}
			if (graphicsToFade == null)
			{
				graphicsToFade = new List<GameObject>();
			}
			SetupListeners(on: true);
		}

		private void OnEnable()
		{
			OnInteractableChanged(interactable);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				interactable.InteractabilityChanged += OnInteractableChanged;
			}
			else
			{
				interactable.InteractabilityChanged -= OnInteractableChanged;
			}
		}

		private void OnInteractableChanged(IHoverable sender)
		{
			foreach (GameObject item in graphicsToFade)
			{
				item.SetActive(sender.IsInteractable == activeWhenInteractable);
			}
		}
	}
}
