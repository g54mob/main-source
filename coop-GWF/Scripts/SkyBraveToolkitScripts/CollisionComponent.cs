using UnityEngine;
using UnityEngine.Events;

public class CollisionComponent : MonoBehaviour
{
	public LayerMask allowedLayers;

	public bool IsColliderDisabledAfterTrigger;

	public UnityEvent<Collider> OnCollisionEnterEvent;

	public UnityEvent<Collider> OnCollisionStayEvent;

	public UnityEvent<Collider> OnCollisionExitEvent;

	private Collider _collider;

	private void Awake()
	{
		_collider = GetComponent<Collider>();
	}

	private void OnCollisionEnter(Collision other)
	{
		if (IsLayerAllowed(other.gameObject.layer))
		{
			OnCollisionEnterEvent.Invoke(other.collider);
			Invoke("DisableGameObjectAfterTrigger", 0.1f);
		}
	}

	private void OnCollisionStay(Collision other)
	{
		if (IsLayerAllowed(other.gameObject.layer))
		{
			OnCollisionStayEvent.Invoke(other.collider);
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (IsLayerAllowed(other.gameObject.layer))
		{
			OnCollisionExitEvent.Invoke(other.collider);
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
