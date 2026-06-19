using System;
using Data;
using Zenject;

namespace Infrastructure.Installers
{
	[Obsolete]
	public class PlayerDataInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<PlayerData>().AsSingle();
		}
	}
}
