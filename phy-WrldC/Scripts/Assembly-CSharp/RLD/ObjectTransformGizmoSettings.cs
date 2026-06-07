using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectTransformGizmoSettings : Settings
	{
		[SerializeField]
		private int _transformableLayers = -1;

		private HashSet<GameObject> _nonTransformableObjects = new HashSet<GameObject>();

		public int TransformableLayers
		{
			get
			{
				return _transformableLayers;
			}
			set
			{
				_transformableLayers = value;
			}
		}

		public bool IsLayerTransformable(int objectLayer)
		{
			return LayerEx.IsLayerBitSet(_transformableLayers, objectLayer);
		}

		public void SetLayerTransformable(int objectLayer, bool isTransformable)
		{
			if (isTransformable)
			{
				_transformableLayers = LayerEx.SetLayerBit(_transformableLayers, objectLayer);
			}
			else
			{
				_transformableLayers = LayerEx.ClearLayerBit(_transformableLayers, objectLayer);
			}
		}

		public bool IsObjectTransformable(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			return !_nonTransformableObjects.Contains(gameObject);
		}

		public void SetObjectTransformable(GameObject gameObject, bool isTransformable)
		{
			if (!(gameObject == null))
			{
				if (isTransformable)
				{
					_nonTransformableObjects.Remove(gameObject);
				}
				else
				{
					_nonTransformableObjects.Add(gameObject);
				}
			}
		}

		public void SetObjectCollectionTransformable(List<GameObject> gameObjectCollection, bool areTransformable)
		{
			foreach (GameObject item in gameObjectCollection)
			{
				SetObjectTransformable(item, areTransformable);
			}
		}
	}
}
