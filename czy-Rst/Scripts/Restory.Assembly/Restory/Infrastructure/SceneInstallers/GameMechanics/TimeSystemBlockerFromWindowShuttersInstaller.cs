using Restory.Gameplay.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class TimeSystemBlockerFromWindowShuttersInstaller : MonoInstaller
	{
		[SerializeField]
		private TimeSystemBlockerFromWindowShutters prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<TimeSystemBlockerFromWindowShutters>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
