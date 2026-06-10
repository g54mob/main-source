using System.Collections.Generic;
using UnityEngine;

namespace Aura2API
{
	internal class FrustumCuller<T> where T : CullableObject
	{
		public T[] GetVisibleObjects(Camera camera, float nearClipPlane, float farClipPlane, T[] candidateObjects)
		{
			Plane[] frustumPlanes = camera.GetFrustumPlanes(nearClipPlane, farClipPlane);
			List<T> list = new List<T>();
			for (int i = 0; i < candidateObjects.Length; i++)
			{
				if (candidateObjects[i].CheckFrustumOverlap(frustumPlanes))
				{
					list.Add(candidateObjects[i]);
				}
			}
			return list.ToArray();
		}

		public T[] GetVisibleObjects(Camera camera, float nearClipPlane, float farClipPlane, List<T> candidateObjects)
		{
			return GetVisibleObjects(camera, nearClipPlane, farClipPlane, candidateObjects.ToArray());
		}
	}
}
