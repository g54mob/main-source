using Restory.Data.NPCs;
using Restory.Gameplay.NPCs;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class NpcServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private PrefabsForRandomNpcs prefabsForRandomNpcs;

		[SerializeField]
		private NpcServiceMain npcServicePrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<PrefabsForRandomNpcsProvidingService>().FromNew().AsSingle()
				.WithArguments(prefabsForRandomNpcs);
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(npcServicePrefab.gameObject);
			base.Container.Bind<NpcServiceMain>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<NpcFactory>().FromNew().AsSingle();
			base.Container.Bind<NpcCreationService>().FromNew().AsSingle();
		}
	}
}
