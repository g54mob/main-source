using UnityEngine;

namespace DV.UI
{
	public static class GraphicsReferencesExtensions
	{
		public static GraphicsReferences GetGraphicsReferences(this GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			if (!go.TryGetComponent<GraphicsReferences>(out var component))
			{
				component = go.AddComponent<GraphicsReferences>();
			}
			component.Initialize();
			return component;
		}

		public static GraphicsReferences GetGraphicsReferences(this Behaviour b)
		{
			if (!(b == null))
			{
				return b.gameObject.GetGraphicsReferences();
			}
			return null;
		}
	}
}
