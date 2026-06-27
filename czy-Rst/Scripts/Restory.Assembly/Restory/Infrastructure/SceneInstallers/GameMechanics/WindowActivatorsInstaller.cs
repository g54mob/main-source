using Restory.Gameplay.OverlayActivators;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public sealed class WindowActivatorsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallNotepadActivator();
			InstallInventoryActivator();
			InstallWebBrowserActivator();
			InstallWindowActivatorsController();
			InstallCleaningToolsWindowActivator();
			InstallDevicePainterPanelActivator();
			InstallRegularPaymentActivator();
			InstallIPauseMenuActivator();
		}

		private void InstallNotepadActivator()
		{
			base.Container.BindInterfacesAndSelfTo<NotepadActivator>().FromNew().AsSingle();
		}

		private void InstallInventoryActivator()
		{
			base.Container.BindInterfacesAndSelfTo<InventoryActivator>().FromNew().AsSingle();
		}

		private void InstallWebBrowserActivator()
		{
			base.Container.BindInterfacesAndSelfTo<PcActivator>().FromNew().AsSingle();
		}

		private void InstallCleaningToolsWindowActivator()
		{
			base.Container.BindInterfacesAndSelfTo<CleaningToolsSelectionWindowActivator>().FromNew().AsSingle();
		}

		private void InstallWindowActivatorsController()
		{
			base.Container.BindInterfacesAndSelfTo<WindowActivatorsController>().FromNew().AsSingle();
		}

		private void InstallRegularPaymentActivator()
		{
			base.Container.BindInterfacesAndSelfTo<RegularPaymentActivator>().FromNew().AsSingle();
		}

		private void InstallIPauseMenuActivator()
		{
			base.Container.BindInterfacesAndSelfTo<PauseMenuActivator>().FromNew().AsSingle();
		}

		private void InstallDevicePainterPanelActivator()
		{
			base.Container.BindInterfacesAndSelfTo<DevicePainterPanelActivator>().FromNew().AsSingle();
		}
	}
}
