using GPUInstancerPro.TerrainModule;
using UnityEngine;

namespace Assets.Scripts.Environment.Vegetation
{
	public class GpuiConfigurationScript : MonoBehaviour
	{
		protected GPUITreeManager TreeManager { get; private set; }

		protected virtual void OnDestroy()
		{
		}

		protected virtual void Start()
		{
			TreeManager = GetComponentInChildren<GPUITreeManager>();
		}
	}
}
