using Restory.Gameplay.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class DisassembleGameModeCanvasInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_DisassembleObjectGameModeCanvas disassembleGameModeCanvas;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_DisassembleObjectGameModeCanvas>().FromInstance(disassembleGameModeCanvas).AsSingle();
		}
	}
}
