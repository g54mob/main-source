using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	public abstract class ResourceExportingModule : CGModule
	{
		public GameObject SaveToScene(Transform parent = null)
		{
			return null;
		}

		protected abstract GameObject SaveResourceToScene(Component managedResource, Transform newParent);
	}
}
