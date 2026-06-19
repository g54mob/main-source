using Unity.Entities;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

namespace Pug.Conversion
{
	[Preserve]
	[RequireDerived]
	public abstract class PostConverter
	{
		public virtual bool CanRunInStagingWorld => true;

		public ConversionManager ConversionManager { private get; set; }

		protected BlobAssetStore BlobAssetStore => ConversionManager.BlobAssetStore;

		protected EntityManager EntityManager => ConversionManager.EntityManager;

		protected bool IsServer => ConversionManager.IsServer;

		public abstract void PostConvert(GameObject authoring);

		protected Entity GetEntity(GameObject prefab)
		{
			return ConversionManager.GetPrefabEntityPostConvert(prefab);
		}

		protected void GetGhostConfig(GameObject authoring, Entity entity, out GhostPrefabCreation.Config config)
		{
			ConversionManager.GetGhostConfig(authoring, entity, out config);
		}

		protected static bool TryGetActiveComponent<T>(MonoBehaviour authoring, out T component) where T : MonoBehaviour
		{
			return TryGetActiveComponent<T>(authoring.gameObject, out component);
		}

		protected static bool TryGetActiveComponent<T>(GameObject authoring, out T component) where T : MonoBehaviour
		{
			if (!authoring.TryGetComponent<T>(out component))
			{
				return false;
			}
			if (!component.enabled)
			{
				component = null;
				return false;
			}
			return true;
		}
	}
}
