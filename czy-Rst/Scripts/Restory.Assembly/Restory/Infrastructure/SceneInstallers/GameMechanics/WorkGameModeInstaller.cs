using Restory.Gameplay.Work;
using Restory.Gameplay.Work.StateMachine;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class WorkGameModeInstaller : MonoInstaller
	{
		[SerializeField]
		private WorkStateMachine workStateMachinePrefab;

		[SerializeField]
		private WorkGameMode workGameModePrefab;

		public override void InstallBindings()
		{
			InstallWorkGameMode();
			InstallWorkStateMachine();
		}

		private void InstallWorkStateMachine()
		{
			base.Container.BindFactory<DisabledWorkState, DisabledWorkState.Factory>();
			base.Container.BindFactory<DetectionWorkState, DetectionWorkState.Factory>();
			base.Container.BindFactory<DraggingWorkState, DraggingWorkState.Factory>();
			base.Container.BindFactory<DialogueWorkState, DialogueWorkState.Factory>();
			base.Container.BindFactory<HackingWorkState, HackingWorkState.Factory>();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(workStateMachinePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<WorkStateMachine>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallWorkGameMode()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(workGameModePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<WorkGameMode>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
