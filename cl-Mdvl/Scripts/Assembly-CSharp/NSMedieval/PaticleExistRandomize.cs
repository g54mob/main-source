using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval
{
	public class PaticleExistRandomize : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 100f)]
		private float percentOfExistence = 50f;

		[SerializeField]
		private GameObject particleParent;

		private void Start()
		{
			MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate += UpdateEnvironmentParticles;
			UpdateEnvironmentParticles();
		}

		private void OnDestroy()
		{
			if (MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate -= UpdateEnvironmentParticles;
			}
		}

		private void RandomizeLeafParticlesOnTrees()
		{
			TreeView componentInParent = base.gameObject.GetComponentInParent<TreeView>();
			if (componentInParent.HasDisposed)
			{
				return;
			}
			PlantMapResourceInstance resourceInstance = componentInParent.ResourceInstance;
			if (resourceInstance != null && !resourceInstance.HasDisposed)
			{
				float num = Random.Range(0f, 100f);
				int currentPhase = resourceInstance.CurrentPhase;
				if (num > percentOfExistence || currentPhase == 0 || currentPhase == 1 || currentPhase == 4)
				{
					particleParent.SetActive(value: false);
				}
			}
		}

		private void UpdateEnvironmentParticles()
		{
			if ((bool)particleParent)
			{
				if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.EnvironmentParticles)
				{
					particleParent.SetActive(value: true);
					RandomizeLeafParticlesOnTrees();
				}
				else
				{
					particleParent.SetActive(value: false);
				}
			}
		}
	}
}
