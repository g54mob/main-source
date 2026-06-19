using Computer.Services;
using Computer.Sites.Services.Delivery;
using Michsky.DreamOS;
using UI.Commander;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
	public class ComputerInstaller : MonoInstaller
	{
		[SerializeField]
		private WebBrowserManager _webBrowserManager;

		[SerializeField]
		private CommanderManager _commanderManager;

		[SerializeField]
		private MailManager _mailManager;

		public override void InstallBindings()
		{
			base.Container.Bind<WebBrowserManager>().FromInstance(_webBrowserManager).AsSingle();
			base.Container.Bind<CommanderManager>().FromInstance(_commanderManager).AsSingle();
			base.Container.Bind<MailManager>().FromInstance(_mailManager).AsSingle();
			base.Container.BindInterfacesAndSelfTo<SiteDeliveryService>().FromNew().AsSingle();
			base.Container.Bind<IMailService>().To<MailService>().FromNew()
				.AsSingle();
			base.Container.BindInterfacesAndSelfTo<CommanderViewModel>().FromNew().AsSingle();
		}
	}
}
