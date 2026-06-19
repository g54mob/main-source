using Services.Save.Mail;
using Zenject;

namespace Installers
{
	public class MailSaveInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<MailSaveService>().FromNew().AsSingle();
		}
	}
}
