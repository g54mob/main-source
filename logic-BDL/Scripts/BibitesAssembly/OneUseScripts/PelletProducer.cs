using ManagementScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace OneUseScripts
{
	public class PelletProducer : MonoBehaviour
	{
		private BibiteBody body;

		private BibiteGenes genes;

		private float period = 0.5f;

		private float progress;

		private float pelletSize;

		public void Start()
		{
			body = GetComponent<BibiteBody>();
			genes = body.gene;
			body.growth.onGrowth.AddListener(OnGrowth);
			period = 0.5f / genes.metabolicRate;
			OnGrowth();
		}

		private void FixedUpdate()
		{
			progress += Time.fixedDeltaTime;
			if (!(progress < period))
			{
				progress -= period;
				Transform transform = base.transform;
				Vector3 value = transform.position - transform.up * (8f * body.d1Size);
				float value2 = pelletSize * MatterMaterialManager.PlantParameters.energyDensity.val;
				WorldObjectsSpawner.Instance.SpawnPlantPellet(value, value2);
			}
		}

		public void OnGrowth(float val = 0f)
		{
			pelletSize = body.baseBodyArea * 0.1f;
		}
	}
}
