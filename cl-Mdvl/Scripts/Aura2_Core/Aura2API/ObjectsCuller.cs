using System.Collections.Generic;
using UnityEngine;

namespace Aura2API
{
	internal class ObjectsCuller<T> where T : CullableObject
	{
		private readonly List<T> _registredObjectsList;

		private T[] _visibleObjectsArray;

		private BoundingSphere[] _boundingSpheres;

		private int[] _visibleObjectsIndices;

		private FrustumSettings _frustumSettings;

		private FrustumCuller<T> _frustumCuller;

		public bool HasRegistredObjects => _registredObjectsList.Count > 0;

		public bool HasVisibleObjects => VisibleObjectsCount > 0;

		public int VisibleObjectsCount
		{
			get
			{
				if (_visibleObjectsArray == null)
				{
					return 0;
				}
				return _visibleObjectsArray.Length;
			}
		}

		public ObjectsCuller(Camera referenceCamera, FrustumSettings settings)
		{
			_registredObjectsList = new List<T>();
			_frustumCuller = new FrustumCuller<T>();
		}

		private void SetupCullingGroup()
		{
			_boundingSpheres = new BoundingSphere[_registredObjectsList.Count];
		}

		public void Register(T candidate)
		{
			if (!_registredObjectsList.Contains(candidate))
			{
				_registredObjectsList.Add(candidate);
				SetupCullingGroup();
			}
		}

		public void Unregister(T volume)
		{
			if (_registredObjectsList.Contains(volume))
			{
				_registredObjectsList.Remove(volume);
				SetupCullingGroup();
			}
		}

		public void Update(Camera referenceCamera, FrustumSettings settings)
		{
			if (HasRegistredObjects)
			{
				for (int i = 0; i < _registredObjectsList.Count; i++)
				{
					_boundingSpheres[i] = _registredObjectsList[i].BoundingSphere;
				}
				_visibleObjectsArray = _frustumCuller.GetVisibleObjects(referenceCamera, referenceCamera.nearClipPlane, settings.QualitySettings.farClipPlaneDistance, _registredObjectsList);
			}
			else
			{
				_visibleObjectsArray = null;
			}
		}

		public T[] GetVisibleObjects()
		{
			return _visibleObjectsArray;
		}
	}
}
