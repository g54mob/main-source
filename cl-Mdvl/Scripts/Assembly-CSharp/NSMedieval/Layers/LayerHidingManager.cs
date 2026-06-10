using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Map;
using UnityEngine;

namespace NSMedieval.Layers
{
	public class LayerHidingManager : MonoSingleton<LayerHidingManager>
	{
		public event Action<float> LayerDownConstructablesEvent;

		public event Action<float> LayerUpConstructablesEvent;

		private void Start()
		{
			MonoSingleton<World>.Instance.LayerUpConstructablesEvent += OnLayerUpConstructables;
			MonoSingleton<World>.Instance.LayerDownConstructablesEvent += OnLayerDownConstructables;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
			Shader.SetGlobalFloat("_WorldLayer", 16f);
			Shader.SetGlobalFloat("_TreesHidden", 0f);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.LayerUpConstructablesEvent -= OnLayerUpConstructables;
				MonoSingleton<World>.Instance.LayerDownConstructablesEvent -= OnLayerDownConstructables;
			}
			this.LayerDownConstructablesEvent = null;
			this.LayerUpConstructablesEvent = null;
			base.OnDestroy();
		}

		private void OnLayerDownConstructables(float currentElevation)
		{
			this.LayerDownConstructablesEvent?.Invoke(currentElevation);
		}

		private void OnLayerUpConstructables(float currentElevation)
		{
			this.LayerUpConstructablesEvent?.Invoke(currentElevation);
		}

		private void OnMainSceneLeaving()
		{
			this.LayerDownConstructablesEvent = null;
			this.LayerUpConstructablesEvent = null;
		}
	}
}
