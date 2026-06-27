using System;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Restory.AssetManagement
{
	public class AssetManagementInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Addressables.InitializeAsync();
			InstallAssetProvider();
		}

		private void InstallAssetProvider()
		{
			base.Container.Bind(typeof(IAssetProvider), typeof(IInitializable), typeof(IDisposable)).To<AssetProvider>().AsSingle()
				.CopyIntoAllSubContainers();
		}
	}
}
