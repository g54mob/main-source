using NSEipix.Base;
using NSMedieval.Map;
using UnityEngine;

namespace NSMedieval.Layers
{
	public class HideSlope : HideLayerBase, IMapObjectElevation
	{
		[SerializeField]
		private MeshRenderer[] meshes;

		private bool hidden;

		public override void HideMapObject(float realWorldLevel)
		{
			if (HideLayerBase.Equal(GetElevation(), realWorldLevel - 0.5f) && !hidden)
			{
				hidden = true;
				base.HideMapObject(realWorldLevel);
				HideMesh(meshes);
			}
		}

		public override void ShowMapObject(float realWorldLevel)
		{
			if (GetElevation() < realWorldLevel - 0.5f && hidden)
			{
				hidden = false;
				base.ShowMapObject(realWorldLevel);
				ShowMesh(meshes);
			}
		}

		public void RemoveFromCache()
		{
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= HideMapObject;
			MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= ShowMapObject;
		}

		private void Start()
		{
			SetElevation(base.transform.position.y / (float)World.MapBlockHeight + base.Offset);
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += HideMapObject;
			MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent += ShowMapObject;
		}

		private void OnDestroy()
		{
			if (MonoSingleton<LayerHidingManager>.IsInstantiated())
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= HideMapObject;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= ShowMapObject;
			}
		}
	}
}
