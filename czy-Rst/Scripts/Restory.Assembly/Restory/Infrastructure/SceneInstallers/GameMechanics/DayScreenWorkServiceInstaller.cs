using Restory.Gameplay.DayStartScreen;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DayScreenWorkServiceInstaller : MonoInstaller
	{
		[SerializeField]
		[Min(0f)]
		private float transitionDuration = 3.5f;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<DayScreenWorkService>().FromNew().AsSingle()
				.WithArguments(transitionDuration);
		}
	}
}
