using Items.Box.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Infrastructure.Installers
{
	public class BoxFactoryInstaller : MonoInstaller
	{
		[SerializeField]
		private AssetReference _boxAssetReference;

		public override void InstallBindings()
		{
			base.Container.Bind<IItemBoxFactory>().To<ItemBoxFactory>().FromNew()
				.AsSingle()
				.WithArguments(new object[1] { _boxAssetReference });
		}
	}
}
