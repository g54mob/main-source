using Restory.Data.Disassemble.StateMachine;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Disassemble;
using Restory.Gameplay.Disassemble.StateMachine;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DisassembleGameModeInstaller : MonoInstaller
	{
		[SerializeField]
		private DisassembleStateMachine disassembleStateMachinePrefab;

		[SerializeField]
		private DisassembleGameMode disassembleGameModePrefab;

		[SerializeField]
		private CompetitionGameMode competitionGameModePrefab;

		[SerializeField]
		private CheckDeviceConfig checkDeviceConfig;

		[SerializeField]
		private TransitionToCleaningConfig transitionToCleaningConfig;

		[SerializeField]
		private TransitionFromCleaningConfig transitionFromCleaningConfig;

		[SerializeField]
		private ElementToInventoryConfirmationDialogueConfig elementToInventoryConfirmationDialogueConfig;

		public override void InstallBindings()
		{
			InstallDisassembleStateMachine();
			InstallDisassembleGameMode();
			InstallCompetitionGameMode();
		}

		private void InstallDisassembleStateMachine()
		{
			base.Container.BindInstance(checkDeviceConfig).AsSingle().WhenInjectedInto<CheckDeviceDisassembleState>();
			base.Container.BindInstance(transitionToCleaningConfig).AsSingle().WhenInjectedInto<TransitionToCleaningDisassembleState>();
			base.Container.BindInstance(transitionFromCleaningConfig).AsSingle().WhenInjectedInto<TransitionFromCleaningDisassembleState>();
			base.Container.BindInstance(elementToInventoryConfirmationDialogueConfig).AsSingle().WhenInjectedInto<ElementToInventoryConfirmationDialogueDisassembleState>();
			base.Container.BindFactory<DisabledDisassembleState, DisabledDisassembleState.Factory>();
			base.Container.BindFactory<EmptyDisassembleState, EmptyDisassembleState.Factory>();
			base.Container.BindFactory<DetectionDisassembleState, DetectionDisassembleState.Factory>();
			base.Container.BindFactory<DismantleDisassembleState, DismantleDisassembleState.Factory>();
			base.Container.BindFactory<DraggingDisassembleState, DraggingDisassembleState.Factory>();
			base.Container.BindFactory<InstallingDisassembleState, InstallingDisassembleState.Factory>();
			base.Container.BindFactory<TransitionToCleaningDisassembleState, TransitionToCleaningDisassembleState.Factory>();
			base.Container.BindFactory<CleaningDisassembleState, CleaningDisassembleState.Factory>();
			base.Container.BindFactory<TransitionFromCleaningDisassembleState, TransitionFromCleaningDisassembleState.Factory>();
			base.Container.BindFactory<CheckDeviceDisassembleState, CheckDeviceDisassembleState.Factory>();
			base.Container.BindFactory<PaintingDisassembleState, PaintingDisassembleState.Factory>();
			base.Container.BindFactory<ElementToInventoryConfirmationDialogueDisassembleState, ElementToInventoryConfirmationDialogueDisassembleState.Factory>();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(disassembleStateMachinePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DisassembleStateMachine>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallDisassembleGameMode()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(disassembleGameModePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DisassembleGameMode>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<DisassembleRotationController>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallCompetitionGameMode()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(competitionGameModePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<CompetitionGameMode>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<CompetitionsDeviceContainersTrackingService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<CompetitionsResultsTrackingService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CompetitionsLastSubmittedDeviceTrackingService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CompetitionsApp>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
