using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Resources
{
	public abstract class MapResourceController<T, TK> : MonoSingleton<T> where T : MonoBehaviour where TK : MapResourceInstance
	{
		public delegate void ResourceHolderHandler(string modelId, Vector3 position, string prefabId);

		public delegate void ResourceHandler(TK resource);

		public delegate void ResourceListHandler(List<TK> resources);

		public event ResourceHolderHandler CreateResourceEvent;

		public event ResourceListHandler CreateResourceListEvent;

		public event ResourceHandler DestroyResourceEvent;

		public event ResourceHandler ReinstanceResourceEvent;

		public event ResourceHandler AddMiningMarkerEvent;

		public void ReinstanceResource(TK resourceInstace)
		{
			this.ReinstanceResourceEvent?.Invoke(resourceInstace);
		}

		public void AddMiningMarker(TK resourceInstace)
		{
			this.AddMiningMarkerEvent?.Invoke(resourceInstace);
		}

		public void CreateResource(string modelId, Vector3 position, string prefabId)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\MapResourceController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Create resource ");
				messageBuilder.AppendFormatted(modelId);
				messageBuilder.AppendLiteral(" at ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(" with prefab ");
				messageBuilder.AppendFormatted(prefabId);
			}
			Log.Trace(messageBuilder);
			this.CreateResourceEvent?.Invoke(modelId, position, prefabId);
		}

		public void CreateResource(List<TK> resourceList)
		{
			this.CreateResourceListEvent?.Invoke(resourceList);
		}

		public void DestroyResource(TK instance)
		{
			this.DestroyResourceEvent?.Invoke(instance);
		}
	}
}
