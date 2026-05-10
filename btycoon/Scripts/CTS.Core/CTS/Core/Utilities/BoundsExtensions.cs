using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class BoundsExtensions
	{
		public static Vector3 InvertExtentsXZ(this Bounds bounds)
		{
			return new Vector3(bounds.extents.z, bounds.extents.y, bounds.extents.x);
		}

		public static Vector3 InvertSizeXZ(this Bounds bounds)
		{
			return new Vector3(bounds.size.z, bounds.size.y, bounds.size.x);
		}

		public static Bounds EncapsulateChildren(this Bounds bounds, Transform p_rootEmpty)
		{
			bool flag = false;
			if (p_rootEmpty.childCount == 0)
			{
				Debug.LogWarning("No Child Object to calculate Bounds from by using AutoBounds");
				return bounds;
			}
			for (int i = 0; i < p_rootEmpty.childCount; i++)
			{
				if (p_rootEmpty.GetChild(i).TryGetComponent<Renderer>(out var component))
				{
					if (flag)
					{
						bounds.Encapsulate(component.bounds);
						continue;
					}
					bounds = component.bounds;
					flag = true;
				}
			}
			return bounds;
		}

		public static Bounds EncapsulateRenderers(this Bounds bounds, Renderer[] p_renderers)
		{
			bool flag = false;
			for (int i = 0; i < p_renderers.Length; i++)
			{
				if (flag)
				{
					bounds.Encapsulate(p_renderers[i].bounds);
					continue;
				}
				bounds = p_renderers[i].bounds;
				flag = true;
			}
			return bounds;
		}
	}
}
