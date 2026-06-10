using NGS.MeshFusionPro;
using NSEipix.Base;
using NSMedieval.Layers;
using NSMedieval.Map;
using UnityEngine;

namespace Layering
{
	public class LayerObjectHideMeshFusion : MonoBehaviour
	{
		private void Start()
		{
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += OnLayerVisibilityChanged;
			MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent += OnLayerVisibilityChanged;
			OnLayerVisibilityChanged(MonoSingleton<World>.Instance.LayerLevel);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<LayerHidingManager>.IsInstantiated())
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= OnLayerVisibilityChanged;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= OnLayerVisibilityChanged;
			}
		}

		private void OnLayerVisibilityChanged(float level)
		{
			float y = base.gameObject.GetComponent<BaseCombinedObject>().Bounds.min.y;
			float num = level * (float)World.MapBlockHeight;
			bool flag = y <= num;
			if (base.gameObject.activeSelf != flag)
			{
				base.gameObject.SetActive(flag);
			}
		}
	}
}
