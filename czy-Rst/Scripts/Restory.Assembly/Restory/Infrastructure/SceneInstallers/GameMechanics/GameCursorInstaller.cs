using Restory.Gameplay.GameCursor;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public sealed class GameCursorInstaller : MonoInstaller
	{
		[SerializeField]
		private CursorIcons cursorIcons;

		[SerializeField]
		private DisassembleToolCursor disassembleToolCursorPrefab;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GameCursorDetector>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<UICursorDetector>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<CursorDetectorService>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<CursorSelectionService>().FromNew().AsSingle();
			PauseCursorController instance = new PauseCursorController();
			base.Container.QueueForInject(instance);
			base.Container.BindInterfacesTo<PauseCursorController>().FromInstance(instance).AsSingle();
			base.Container.Bind<CursorIcons>().FromInstance(cursorIcons);
			base.Container.BindInterfacesAndSelfTo<VirtualCursorPresenter>().FromNew().AsSingle();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(disassembleToolCursorPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DisassembleToolCursor>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
