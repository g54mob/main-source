using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class TriggerableComponent : MonoBehaviour
	{
		public LayerMask allowedLayers;

		public bool IsColliderDisabledAfterTrigger;

		public UnityEvent<Collider> OnTriggerEnterEvent;

		public UnityEvent<Collider> OnTriggerStayEvent;

		public UnityEvent<Collider> OnTriggerExitEvent;

		public UnityEvent<Collider2D> OnTriggerEnter2DEvent;

		public UnityEvent<Collider2D> OnTriggerStay2DEvent;

		public UnityEvent<Collider2D> OnTriggerExit2DEvent;

		private Collider _collider;

		private void Awake()
		{
			_collider = GetComponent<Collider>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (IsLayerAllowed(other.gameObject.layer))
			{
				OnTriggerEnterEvent.Invoke(other);
				Invoke("DisableGameObjectAfterTrigger", 0.1f);
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (IsLayerAllowed(other.gameObject.layer))
			{
				OnTriggerStayEvent.Invoke(other);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (IsLayerAllowed(other.gameObject.layer))
			{
				OnTriggerExitEvent.Invoke(other);
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (IsLayerAllowed(other.gameObject.layer))
			{
				OnTriggerEnter2DEvent.Invoke(other);
				Invoke("DisableGameObjectAfterTrigger", 0.1f);
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (IsLayerAllowed(other.gameObject.layer))
			{
				OnTriggerStay2DEvent.Invoke(other);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (IsLayerAllowed(other.gameObject.layer))
			{
				OnTriggerExit2DEvent.Invoke(other);
			}
		}

		private bool IsLayerAllowed(int layer)
		{
			return ((int)allowedLayers & (1 << layer)) != 0;
		}

		private void DisableGameObjectAfterTrigger()
		{
			if (IsColliderDisabledAfterTrigger)
			{
				_collider.enabled = false;
			}
		}

		private void OnDisable()
		{
		}
	}
}
