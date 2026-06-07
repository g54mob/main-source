using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	public class GPUIMaterialVariationDataProvider : GPUIDataProvider<int, GPUIMaterialVariationData>
	{
		public static GPUIMaterialVariationDataProvider _instance;

		public static GPUIMaterialVariationDataProvider Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GPUIMaterialVariationDataProvider();
					_instance.Initialize();
				}
				return _instance;
			}
		}

		public override void Initialize()
		{
			if (_instance != null && _instance != this)
			{
				Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Duplicate GPUIMaterialVariationDataProvider initialization.");
				return;
			}
			base.Initialize();
			GPUIRenderingSystem.InitializeRenderingSystem();
			GPUIRenderingSystem.AddDependentDisposable(this);
		}

		public void UpdateVariationBuffers()
		{
			if (!base.IsInitialized)
			{
				return;
			}
			foreach (GPUIMaterialVariationData value in base.Values)
			{
				value.UpdateVariationBuffer();
			}
		}

		internal void UpdateVariationBuffers(GPUICameraData cameraData)
		{
			UpdateVariationBuffers();
		}

		public static GPUIMaterialVariationData GetMaterialVariationData(GPUIMaterialVariationDefinition materialVariationDefinition, int renderKey)
		{
			return GetMaterialVariationDataWithHash(materialVariationDefinition, GPUIUtility.GenerateHash(materialVariationDefinition.GetInstanceID(), renderKey));
		}

		public static GPUIMaterialVariationData GetMaterialVariationDataWithHash(GPUIMaterialVariationDefinition materialVariationDefinition, int hash)
		{
			if (!Instance.TryGetData(hash, out var result))
			{
				result = new GPUIMaterialVariationData(materialVariationDefinition);
				result.Initialize();
				Instance.AddOrSet(hash, result);
			}
			return result;
		}
	}
}
