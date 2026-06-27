using Restory.Data.Equipment;
using Restory.Scripts.Restory.Gameplay.Equipment.DevicePaintingTools.Tables;
using UnityEngine;
using Zenject;

namespace Restory.Scripts.Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DevicePaintingSettingsInstaller : MonoInstaller
	{
		[SerializeField]
		private PaintingSettings paintingSettings;

		[SerializeField]
		private DevicePaintingThresholdsParametersTable devicePaintingThresholdsParametersTable;

		public override void InstallBindings()
		{
			InstallPaintingSettings();
			InstallDevicePaintingThresholdsParametersTable();
		}

		private void InstallPaintingSettings()
		{
			base.Container.Bind<PaintingSettings>().FromInstance(paintingSettings).AsSingle();
		}

		private void InstallDevicePaintingThresholdsParametersTable()
		{
			base.Container.Bind<DevicePaintingThresholdsParametersTable>().FromInstance(devicePaintingThresholdsParametersTable).AsSingle();
		}
	}
}
