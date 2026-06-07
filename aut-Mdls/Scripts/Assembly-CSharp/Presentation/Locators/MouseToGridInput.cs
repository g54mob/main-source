using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Logic.Factory;
using Presentation.FactoryFloor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Factory/Tools/MouseToGridPosition", fileName = "MouseToGridPosition", order = 0)]
	public class MouseToGridInput : ScriptableObject
	{
		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private LayerMask _layerMaskPlane;

		[SerializeField]
		private LayerMask _operatorMaskPlane;

		[SerializeField]
		private InputActionReference _pointerPosition;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private CurrentFactoryLayer _currentFactoryLayer;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private BoolVariableSO _isCursorHoveringUI;

		private Vector3 _lastPosition = Vector3.zero;

		public Vector3 GetSelectedMapPosition()
		{
			Vector3 pos = _pointerPosition.action.ReadValue<Vector2>();
			pos.z = _cameraLocator.Camera.nearClipPlane;
			if (Physics.Raycast(_cameraLocator.Camera.ScreenPointToRay(pos), out var hitInfo, 500f, _layerMaskPlane))
			{
				_lastPosition = hitInfo.point;
			}
			return _lastPosition;
		}

		public FactoryObjectView GetSelectedFactoryObjectView()
		{
			if (_isCursorHoveringUI.Value)
			{
				return null;
			}
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = _cameraLocator.Camera.nearClipPlane;
			if (Physics.Raycast(_cameraLocator.Camera.ScreenPointToRay(mousePosition), out var hitInfo, 500f, _operatorMaskPlane))
			{
				return hitInfo.collider.GetComponent<FactoryObjectView>();
			}
			return null;
		}

		public FactoryObjectView GetSelectedFactoryObjectView(out Vector3 hitPos)
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = _cameraLocator.Camera.nearClipPlane;
			if (Physics.Raycast(_cameraLocator.Camera.ScreenPointToRay(mousePosition), out var hitInfo, 500f, _operatorMaskPlane))
			{
				hitPos = hitInfo.point;
				return hitInfo.collider.GetComponent<FactoryObjectView>();
			}
			hitPos = Vector3.zero;
			return null;
		}

		public FactoryObjectView GetHoveredViewOrGridView()
		{
			if (_isCursorHoveringUI.Value)
			{
				return null;
			}
			FactoryObjectView view = GetSelectedFactoryObjectView();
			if (view == null && (bool)FactoryObjectViewManager.Instance)
			{
				Vector3 selectedMapPosition = GetSelectedMapPosition();
				FactoryObject objectAt = _currentFactoryLayer.Value.GetObjectAt(_gridLocator.GetCellPosition(selectedMapPosition));
				if (objectAt != null)
				{
					FactoryObjectViewManager.Instance.TryGetFactoryObjectView(objectAt.CreatedId, out view);
				}
			}
			return view;
		}

		public FactoryObjectView GetHoveredViewOrGridView(out Vector3 hitPos)
		{
			FactoryObjectView view = GetSelectedFactoryObjectView(out hitPos);
			if (view == null && (bool)FactoryObjectViewManager.Instance)
			{
				Vector3 worldPosition = (hitPos = GetSelectedMapPosition());
				FactoryObject objectAt = _currentFactoryLayer.Value.GetObjectAt(_gridLocator.GetCellPosition(worldPosition));
				if (objectAt != null)
				{
					FactoryObjectViewManager.Instance.TryGetFactoryObjectView(objectAt.CreatedId, out view);
				}
			}
			return view;
		}

		public bool TryGetSelectedIslandObject(out IslandObject islandObject)
		{
			Vector3 selectedMapPosition = GetSelectedMapPosition();
			Vector3Int cellPosition = _gridMapLocator.GetCellPosition(selectedMapPosition);
			return _islandLayer.TryGetIslandAtGridPosition(cellPosition, out islandObject);
		}

		public bool TryGetSelectedIslandObject(in Vector3Int position, out IslandObject islandObject)
		{
			Vector3Int cellPosition = _gridMapLocator.GetCellPosition(position);
			return _islandLayer.TryGetIslandAtGridPosition(cellPosition, out islandObject);
		}
	}
}
