using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.EmailSystems.NarrativeEmailButtons;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class EmailServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject prefab;

		public override void InstallBindings()
		{
			InstallNarrativeEmailButtonsProcessingServices();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab);
			base.Container.Bind<EmailService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<EmailOrdersService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<EmailNamesService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<EmailCommentsService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallNarrativeEmailButtonsProcessingServices()
		{
			base.Container.BindInterfacesAndSelfTo<EmailButtonSendEmailLetterHandler>().FromNew().AsSingle()
				.WhenInjectedInto<NarrativeEmailLettersButtonPressDispatcher>();
			base.Container.BindInterfacesAndSelfTo<EmailButtonPaymentBillHandler>().FromNew().AsSingle()
				.WhenInjectedInto<NarrativeEmailLettersButtonPressDispatcher>();
			base.Container.BindInterfacesAndSelfTo<EmailButtonCreateNpcVisitHandler>().FromNew().AsSingle()
				.WhenInjectedInto<NarrativeEmailLettersButtonPressDispatcher>();
			base.Container.BindInterfacesAndSelfTo<EmailButtonDeliverObjectToPlayerHandler>().FromNew().AsSingle()
				.WhenInjectedInto<NarrativeEmailLettersButtonPressDispatcher>();
			base.Container.BindInterfacesAndSelfTo<EmailButtonActivateApplicationSettingsHandler>().FromNew().AsSingle()
				.WhenInjectedInto<NarrativeEmailLettersButtonPressDispatcher>();
			base.Container.BindInterfacesAndSelfTo<EmailButtonRemoveQuestItemHandler>().FromNew().AsSingle()
				.WhenInjectedInto(typeof(NarrativeEmailLettersButtonPressDispatcher), typeof(NarrativeEmailLettersButtonAvailabilityChecker));
			base.Container.BindInterfacesAndSelfTo<EmailButtonSubtractMoneyHandler>().FromNew().AsSingle()
				.WhenInjectedInto(typeof(NarrativeEmailLettersButtonPressDispatcher), typeof(NarrativeEmailLettersButtonAvailabilityChecker));
			base.Container.BindInterfacesAndSelfTo<NarrativeEmailLettersButtonPressDispatcher>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<NarrativeEmailLettersButtonAvailabilityChecker>().FromNew().AsSingle();
		}
	}
}
