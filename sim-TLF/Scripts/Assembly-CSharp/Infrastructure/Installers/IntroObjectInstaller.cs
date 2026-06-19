using Intro;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
	public class IntroObjectInstaller : MonoInstaller
	{
		[SerializeField]
		private IntroSequencePlayer _sequencePlayerPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<IntroSequencePlayer>().FromComponentInNewPrefab(_sequencePlayerPrefab).AsSingle()
				.NonLazy();
		}
	}
}
