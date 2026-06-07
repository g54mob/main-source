using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class HoverObjectInTheWorldComponent : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		private float sphereCastRadius = 2f;

		[Header("References")]
		private Camera _camera;

		[Header("Logic")]
		public SelectableObjectComponent hoveredGameObject;

		[SerializeField]
		private UnityEvent onObjectHovered;

		[SerializeField]
		private UnityEvent onObjectHoverExit;

		[SerializeField]
		private UnityEvent onBehaviourFailed;

		private void Start()
		{
			_camera = Camera.main;
		}

		public void HoverObjectByShootingRayFromCamera()
		{
			if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo, 1000f))
			{
				GameObject objectToSelect = hitInfo.transform.gameObject;
				TryHoverObject(objectToSelect, hitInfo.point);
			}
			else
			{
				hoveredGameObject?.OnHoverExit();
				hoveredGameObject = null;
				onObjectHoverExit.Invoke();
			}
		}

		public void HoverObjectByShootingSphereCastRayFromCamera()
		{
			if (Physics.SphereCast(_camera.ScreenPointToRay(Input.mousePosition), sphereCastRadius, out var hitInfo))
			{
				GameObject objectToSelect = hitInfo.transform.gameObject;
				TryHoverObject(objectToSelect, hitInfo.point);
			}
			else
			{
				hoveredGameObject?.OnHoverExit();
				hoveredGameObject = null;
				onObjectHoverExit.Invoke();
			}
		}

		private void TryHoverObject(GameObject objectToSelect, Vector3 selectionWorldPos)
		{
			if (objectToSelect.TryGetComponent<SelectableObjectComponent>(out var component))
			{
				component.HoverObject(selectionWorldPos);
				onObjectHovered.Invoke();
				hoveredGameObject = component;
			}
			else
			{
				onBehaviourFailed.Invoke();
			}
		}
	}
}
