using System;
using UnityEngine;

namespace DV.Interaction
{
	public class StaticInteractionArea : MonoBehaviour, IInteractableTag
	{
		private class GOActiveDetector : MonoBehaviour
		{
			public event Action<bool> EnabledStateChanged;

			private void OnEnable()
			{
				this.EnabledStateChanged?.Invoke(obj: true);
			}

			private void OnDisable()
			{
				this.EnabledStateChanged?.Invoke(obj: false);
			}
		}

		[NonSerialized]
		public AGrabHandler grabHandler;

		private GOActiveDetector activeDetector;

		public InteractableTag InteractableTag => InteractableTag.StaticArea;

		public void Initialize(AGrabHandler grabHandler, int layer)
		{
			if (this.grabHandler != null)
			{
				Debug.LogError("grabHandler was already initialized! Something is wrong, reinitializing with new parameters", grabHandler);
			}
			this.grabHandler = grabHandler;
			base.gameObject.SetLayersRecursive(layer);
			if (grabHandler.gameObject.activeInHierarchy)
			{
				base.gameObject.SetActive(value: true);
			}
			activeDetector = grabHandler.gameObject.AddComponent<GOActiveDetector>();
			activeDetector.EnabledStateChanged += OnGrabberEnabledStateChanged;
		}

		private void OnGrabberEnabledStateChanged(bool enabled)
		{
			base.gameObject.SetActive(enabled);
		}

		private void OnDestroy()
		{
			if ((bool)activeDetector)
			{
				activeDetector.EnabledStateChanged -= OnGrabberEnabledStateChanged;
				UnityEngine.Object.Destroy(activeDetector);
				activeDetector = null;
			}
		}
	}
}
