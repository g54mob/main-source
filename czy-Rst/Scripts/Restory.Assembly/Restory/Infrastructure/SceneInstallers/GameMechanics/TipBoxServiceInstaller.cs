using Restory.Data.Tips;
using Restory.Gameplay.Tips;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class TipBoxServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private TipsGeneratorSettings tipsGeneratorSettings;

		public override void InstallBindings()
		{
			InstallTipBoxService();
			InstallTipsGenerator();
		}

		private void InstallTipBoxService()
		{
			base.Container.BindInterfacesAndSelfTo<TipBoxService>().AsSingle();
		}

		private void InstallTipsGenerator()
		{
			base.Container.Bind<TipsGeneratorSettings>().FromInstance(tipsGeneratorSettings).AsSingle()
				.WhenInjectedInto<TipsGenerator>();
			base.Container.BindInterfacesAndSelfTo<TipsGenerator>().AsSingle();
		}
	}
}
