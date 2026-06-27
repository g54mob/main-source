using Restory.Data.Audio.SoundBanks;
using Restory.Gameplay.Recycle;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class RecycleServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private RecycleServiceSfxSoundsDatabase soundsDatabase;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<RecycleService>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<RecycleServiceSFX>().FromNew().AsSingle()
				.WithArguments(soundsDatabase);
		}
	}
}
