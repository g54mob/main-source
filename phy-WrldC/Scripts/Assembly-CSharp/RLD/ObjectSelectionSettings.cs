using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectSelectionSettings : Settings
	{
		[SerializeField]
		private MultiSelectOverlapMode _multiSelectOverlapMode;

		[SerializeField]
		private GameObjectType _selectableObjectTypes = GameObjectType.Mesh | GameObjectType.Sprite | GameObjectType.Light | GameObjectType.ParticleSystem;

		[SerializeField]
		private int _selectableLayers = -1;

		[SerializeField]
		private int _duplicatableLayers = -1;

		[SerializeField]
		private int _deletableLayers = -1;

		private HashSet<GameObject> _nonSelectableObjects = new HashSet<GameObject>();

		private HashSet<Camera> _nonSelectableCameras = new HashSet<Camera>();

		[SerializeField]
		private bool _canClickSelect = true;

		[SerializeField]
		private bool _enableCyclicalClickSelect;

		[SerializeField]
		private bool _canMultiSelect = true;

		[SerializeField]
		private int _minMultiSelectSize = 3;

		public MultiSelectOverlapMode MultiSelectOverlapMode
		{
			get
			{
				return _multiSelectOverlapMode;
			}
			set
			{
				_multiSelectOverlapMode = value;
			}
		}

		public bool CanClickSelect
		{
			get
			{
				return _canClickSelect;
			}
			set
			{
				_canClickSelect = value;
			}
		}

		public bool EnableCyclicalClickSelect
		{
			get
			{
				return _enableCyclicalClickSelect;
			}
			set
			{
				_enableCyclicalClickSelect = value;
			}
		}

		public bool CanMultiSelect
		{
			get
			{
				return _canMultiSelect;
			}
			set
			{
				_canMultiSelect = value;
			}
		}

		public int SelectableLayers
		{
			get
			{
				return _selectableLayers;
			}
			set
			{
				_selectableLayers = value;
			}
		}

		public int DuplicatableLayers
		{
			get
			{
				return _duplicatableLayers;
			}
			set
			{
				_duplicatableLayers = value;
			}
		}

		public int DeletableLayers
		{
			get
			{
				return _deletableLayers;
			}
			set
			{
				_deletableLayers = value;
			}
		}

		public int MinMultiSelectSize
		{
			get
			{
				return _minMultiSelectSize;
			}
			set
			{
				_minMultiSelectSize = Mathf.Max(1, value);
			}
		}

		public bool IsCameraSelectable(Camera camera)
		{
			return !_nonSelectableCameras.Contains(camera);
		}

		public void SetCameraSelectable(Camera camera, bool isSelectable)
		{
			if (!(camera == null))
			{
				if (isSelectable)
				{
					_nonSelectableCameras.Remove(camera);
				}
				else
				{
					_nonSelectableCameras.Add(camera);
				}
			}
		}

		public void SetCameraCollectionSelectable(List<Camera> cameraCollection, bool areSelectable)
		{
			foreach (Camera item in cameraCollection)
			{
				SetCameraSelectable(item, areSelectable);
			}
		}

		public bool IsObjectTypeSelectable(GameObjectType gameObjectType)
		{
			return (_selectableObjectTypes & gameObjectType) != 0;
		}

		public void SetObjectTypeSelectable(GameObjectType gameObjectType, bool isSelectable)
		{
			_selectableObjectTypes |= gameObjectType;
		}

		public bool IsObjectLayerSelectable(int objectLayer)
		{
			return LayerEx.IsLayerBitSet(_selectableLayers, objectLayer);
		}

		public void SetObjectLayerSelectable(int objectLayer, bool isSelectable)
		{
			if (isSelectable)
			{
				_selectableLayers = LayerEx.SetLayerBit(_selectableLayers, objectLayer);
			}
			else
			{
				_selectableLayers = LayerEx.ClearLayerBit(_selectableLayers, objectLayer);
			}
		}

		public bool IsObjectSelectable(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			return !_nonSelectableObjects.Contains(gameObject);
		}

		public void SetObjectSelectable(GameObject gameObject, bool isSelectable)
		{
			if (!(gameObject == null))
			{
				if (isSelectable)
				{
					_nonSelectableObjects.Remove(gameObject);
				}
				else
				{
					_nonSelectableObjects.Add(gameObject);
				}
			}
		}

		public void SetObjectCollectionSelectable(List<GameObject> gameObjectCollection, bool areSelectable)
		{
			foreach (GameObject item in gameObjectCollection)
			{
				SetObjectSelectable(item, areSelectable);
			}
		}

		public void RemoveNullObjectRefs()
		{
			_nonSelectableObjects.RemoveWhere((GameObject item) => item == null);
		}

		public bool IsObjectLayerDuplicatable(int objectLayer)
		{
			return LayerEx.IsLayerBitSet(_duplicatableLayers, objectLayer);
		}

		public void SetObjectLayerDuplicatable(int objectLayer, bool isDuplicatable)
		{
			if (isDuplicatable)
			{
				_duplicatableLayers = LayerEx.SetLayerBit(_duplicatableLayers, objectLayer);
			}
			else
			{
				_duplicatableLayers = LayerEx.ClearLayerBit(_duplicatableLayers, objectLayer);
			}
		}

		public bool IsObjectLayerDeletable(int objectLayer)
		{
			return LayerEx.IsLayerBitSet(_deletableLayers, objectLayer);
		}
	}
}
