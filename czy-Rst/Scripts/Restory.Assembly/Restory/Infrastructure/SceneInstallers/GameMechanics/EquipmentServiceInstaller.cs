using Restory.Gameplay.Equipment;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class EquipmentServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private EquipmentService equipmentServicePrefab;

		public override void InstallBindings()
		{
			InstallEquipmentServices();
		}

		private void InstallEquipmentServices()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(equipmentServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<EquipmentService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
