using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class PlayerProfileServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject playerProfileServicePrefab;

		public override void InstallBindings()
		{
			PlayerProfileService component = base.Container.InstantiateAndQueueForInject(playerProfileServicePrefab).GetComponent<PlayerProfileService>();
			base.Container.BindInterfacesAndSelfTo<PlayerProfileService>().FromInstance(component).AsSingle();
			base.Container.BindInterfacesAndSelfTo<PlayerProfileChangeObserver>().AsSingle().CopyIntoAllSubContainers();
		}
	}
}
