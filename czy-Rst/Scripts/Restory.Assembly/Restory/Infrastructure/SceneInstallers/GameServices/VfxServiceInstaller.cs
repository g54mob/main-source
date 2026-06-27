using Restory.Data.Audio.Soundbanks;
using Restory.Data.Effects;
using Restory.Gameplay.Effects;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class VfxServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private VfxEffectsDatabase vfxEffectsDatabase;

		[SerializeField]
		private SfxForVfxEffectsDatabase sfxForVfxEffectsDatabase;

		public override void InstallBindings()
		{
			InstallVfxService();
		}

		private void InstallVfxService()
		{
			base.Container.Bind<VfxFactory>().FromNew().AsSingle()
				.WithArguments(vfxEffectsDatabase)
				.WhenInjectedInto<VfxService>();
			base.Container.BindInterfacesAndSelfTo<VfxService>().FromNewComponentOnNewGameObject().AsSingle();
			base.Container.BindInterfacesTo<VfxServiceSFX>().FromNew().AsSingle()
				.WithArguments(sfxForVfxEffectsDatabase);
		}
	}
}
