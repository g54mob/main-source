using Restory.Gameplay.InteractiveObjects;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class PersonalBoxServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private PersonalBoxService personalBoxServicePrefab;

		public override void InstallBindings()
		{
			InstallPersonalBoxService();
		}

		private void InstallPersonalBoxService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(personalBoxServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<PersonalBoxService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
