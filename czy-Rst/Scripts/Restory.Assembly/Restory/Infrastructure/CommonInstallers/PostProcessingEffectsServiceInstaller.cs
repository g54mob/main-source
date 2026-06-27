using Restory.PostProcessing;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class PostProcessingEffectsServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject postProcessingEffectsServicePrefab;

		public override void InstallBindings()
		{
			InstallPostProcessingEffectsService();
		}

		private void InstallPostProcessingEffectsService()
		{
			PostProcessingEffectsService component = base.Container.InstantiateAndQueueForInject(postProcessingEffectsServicePrefab, base.transform).GetComponent<PostProcessingEffectsService>();
			base.Container.Bind<PostProcessingEffectsService>().FromInstance(component).AsSingle();
		}
	}
}
