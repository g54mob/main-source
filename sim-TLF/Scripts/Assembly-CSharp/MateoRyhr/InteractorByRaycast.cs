using UnityEngine;

namespace MateoRyhr
{
	public class InteractorByRaycast : MonoBehaviour
	{
		[SerializeField]
		private Interactor _interactor;

		[SerializeField]
		private Transform _interactionOrigin;

		[SerializeField]
		private FloatVariable _interactionDistance;

		[SerializeField]
		private LayerMask _raycastCheckLayers;

		[SerializeField]
		private LayerMask _interactableLayer;

		private Ray _ray;

		private void FixedUpdate()
		{
			CheckForInteractable();
		}

		private void CheckForInteractable()
		{
			_ray = new Ray(_interactionOrigin.position, _interactionOrigin.forward);
			if (Physics.Raycast(_ray, out var hitInfo, _interactionDistance.Value, _raycastCheckLayers))
			{
				if (_interactableLayer.LayerContains(hitInfo.transform.gameObject.layer))
				{
					if (_interactor.Interactable != null)
					{
						if (_interactor.Interactable.gameObject.GetInstanceID() != hitInfo.transform.gameObject.GetInstanceID())
						{
							_interactor.Interactable = hitInfo.collider.GetComponentInParent<Interactable>();
						}
					}
					else
					{
						_interactor.Interactable = hitInfo.collider.GetComponentInParent<Interactable>();
					}
				}
				else
				{
					_interactor.Interactable = null;
				}
			}
			else
			{
				_interactor.Interactable = null;
			}
		}
	}
}
