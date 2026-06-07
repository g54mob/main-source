using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class SceneRaycastFilter
	{
		private List<GameObjectType> _allowedObjectTypes = new List<GameObjectType>();

		private List<GameObject> _ignoreObjects = new List<GameObject>();

		private int _layerMask = -1;

		public List<GameObjectType> AllowedObjectTypes => _allowedObjectTypes;

		public List<GameObject> IgnoreObjects => _ignoreObjects;

		public int LayerMask
		{
			get
			{
				return _layerMask;
			}
			set
			{
				_layerMask = value;
			}
		}

		public void FilterHits(List<GameObjectRayHit> hits)
		{
			hits.RemoveAll((GameObjectRayHit item) => !AllowedObjectTypes.Contains(item.HitObject.GetGameObjectType()) || IgnoreObjects.Contains(item.HitObject) || !LayerEx.IsLayerBitSet(_layerMask, item.HitObject.layer));
		}
	}
}
