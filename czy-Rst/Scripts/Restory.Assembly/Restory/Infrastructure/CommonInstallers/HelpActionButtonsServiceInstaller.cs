using Restory.UserInterface.HelpActions;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class HelpActionButtonsServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject helpActionButtonsServicePrefab;

		public override void InstallBindings()
		{
			HelpActionButtonsService component = base.Container.InstantiateAndQueueForInject(helpActionButtonsServicePrefab.gameObject).GetComponent<HelpActionButtonsService>();
			base.Container.BindInterfacesAndSelfTo<HelpActionButtonsService>().FromInstance(component).AsSingle();
		}
	}
}
