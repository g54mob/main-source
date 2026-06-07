using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class SelectObjectInTheWorldComponent : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		private float sphereCastRadius = 2f;

		[Header("References")]
		private Camera _camera;

		[Header("Logic")]
		[SerializeField]
		private bool canPassThroughUI;

		[SerializeField]
		private UnityEvent onObjectSelected;

		[SerializeField]
		private UnityEvent onBehaviourFailed;

		private void Start()
		{
			_camera = Camera.main;
		}

		public void SelectObjectByShootingRayFromCamera()
		{
			RaycastHit hitInfo;
			bool flag = Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000f);
			if ((canPassThroughUI || !EventSystem.current.IsPointerOverGameObject()) && flag)
			{
				GameObject objectToSelect = hitInfo.transform.gameObject;
				TrySelectObject(objectToSelect, hitInfo.point);
			}
		}

		public void SelectObjectByShootingSphereCastRayFromCamera()
		{
			RaycastHit hitInfo;
			bool flag = Physics.SphereCast(_camera.ScreenPointToRay(Input.mousePosition), sphereCastRadius, out hitInfo);
			if ((canPassThroughUI || !EventSystem.current.IsPointerOverGameObject()) && flag)
			{
				GameObject objectToSelect = hitInfo.transform.gameObject;
				TrySelectObject(objectToSelect, hitInfo.point);
			}
		}

		private void TrySelectObject(GameObject objectToSelect, Vector3 selectionWorldPos)
		{
			if (objectToSelect.TryGetComponent<SelectableObjectComponent>(out var component))
			{
				component.SelectObject(selectionWorldPos);
				onObjectSelected.Invoke();
			}
			else
			{
				onBehaviourFailed.Invoke();
			}
		}
	}
}
