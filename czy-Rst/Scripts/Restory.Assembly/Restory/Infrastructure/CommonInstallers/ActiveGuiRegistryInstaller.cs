using Restory.UserInterface;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class ActiveGuiRegistryInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject prefab;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<ActiveGuiRegistry>().FromComponentInNewPrefab(prefab).AsSingle();
			base.Container.BindFactory<GUI_FocusedPanelChecker, GUI_FocusedPanelChecker.Factory>().AsSingle();
		}
	}
}
