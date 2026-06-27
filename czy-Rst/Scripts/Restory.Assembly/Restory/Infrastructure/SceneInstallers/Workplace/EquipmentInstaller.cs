using System;
using Mandragora.PWS;
using Restory.Audio;
using Restory.Data.Effects;
using Restory.Gameplay;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.CashRegisters;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Equipment.DevicePaintingTools.Calculations;
using Restory.Gameplay.Equipment.DevicePaintingTools.Services;
using Restory.Gameplay.Equipment.PersonalComputers;
using Restory.Gameplay.Equipment.TableLamps;
using Restory.Gameplay.Equipment.Ultrasonic;
using Restory.Gameplay.Equipment.Views;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.Workplace
{
	public class EquipmentInstaller : MonoInstaller
	{
		[SerializeField]
		private SmallElementBin smallElementBin;

		[SerializeField]
		private ElementCleaner elementCleaner;

		[SerializeField]
		private GameObject solderingStationObject;

		[SerializeField]
		private InventoryBox inventoryBox;

		[SerializeField]
		private NotepadInteractiveWorkplaceItem notepad;

		[SerializeField]
		private PcInteractiveWorkplaceItem pc;

		[SerializeField]
		private PcKeyboardInteractiveWorkplaceItem pcKeyboard;

		[SerializeField]
		private TrashCan trashCan;

		[SerializeField]
		private GameObject shredder;

		[SerializeField]
		private CashRegister cashRegister;

		[SerializeField]
		private SonicBath sonicBath;

		[SerializeField]
		private DevicePainter devicePainter;

		[SerializeField]
		private TableLamp tableLamp;

		[SerializeField]
		private LightTimeView[] tableLampLightTimeViews = Array.Empty<LightTimeView>();

		[SerializeField]
		private CleaningVfxSettings cleaningVfxSettings;

		public override void InstallBindings()
		{
			InstallSmallElementBin();
			InstallElementCleaner();
			InstallSolderingStation();
			InstallInventoryBox();
			InstallNotepad();
			InstallPC();
			InstallTrashCan();
			InstallShredder();
			InstallCashRegister();
			InstallSonicBath();
			InstallTableLamp();
			InstallDevicePainter();
		}

		private void InstallSmallElementBin()
		{
			base.Container.BindInterfacesAndSelfTo<SmallElementBin>().FromComponentOn(smallElementBin.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ToolActivator>().FromInstance(smallElementBin.GetComponentInChildren<ToolActivator>()).AsCached();
		}

		private void InstallElementCleaner()
		{
			base.Container.Bind<CleaningVfxSettings>().FromInstance(cleaningVfxSettings).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ElementCleaner>().FromComponentOn(elementCleaner.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ToolActivator>().FromComponentOn(elementCleaner.gameObject).AsCached();
			base.Container.BindInterfacesAndSelfTo<CleanerActivator>().FromComponentOn(elementCleaner.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CleanerBrush>().FromComponentOn(elementCleaner.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CleanColorCalculator>().FromComponentOn(elementCleaner.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ShineEffectApplierToMaterialInstances>().FromComponentOn(elementCleaner.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CleaningSuccessSFX>().FromComponentOn(elementCleaner.gameObject).AsSingle();
			base.Container.Bind<ConcreteGameObjectPool>().FromNew().WithArguments(cleaningVfxSettings.CleanedResidueVfxPrefab.gameObject)
				.WhenInjectedInto<CleaningVFX>();
			base.Container.Bind<GameObjectPool>().FromNew().WhenInjectedInto<CleaningVFX>();
		}

		private void InstallSolderingStation()
		{
			base.Container.BindInterfacesAndSelfTo<ToolActivator>().FromComponentOn(solderingStationObject).AsCached();
		}

		private void InstallInventoryBox()
		{
			base.Container.BindInterfacesAndSelfTo<InventoryBox>().FromComponentOn(inventoryBox.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<InventoryBoxDetector>().FromNew().AsSingle();
		}

		private void InstallNotepad()
		{
			base.Container.Bind<NotepadInteractiveWorkplaceItem>().FromComponentOn(notepad.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<NotebookActivator>().FromComponentOn(notepad.gameObject).AsSingle();
		}

		private void InstallPC()
		{
			base.Container.Bind<PcKeyboardInteractiveWorkplaceItem>().FromComponentOn(pcKeyboard.gameObject).AsSingle();
			base.Container.Bind<PcInteractiveWorkplaceItem>().FromComponentOn(pc.gameObject).AsSingle();
			base.Container.Bind<PcDriveActivator>().FromComponentOn(pc.gameObject).AsSingle();
		}

		private void InstallTrashCan()
		{
			base.Container.BindInterfacesAndSelfTo<TrashCan>().FromComponentOn(trashCan.gameObject).AsSingle();
		}

		private void InstallShredder()
		{
			base.Container.BindInterfacesAndSelfTo<Shredder>().FromInstance(shredder.GetComponentInChildren<Shredder>()).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ToolActivator>().FromInstance(shredder.GetComponentInChildren<ToolActivator>()).AsCached();
		}

		private void InstallCashRegister()
		{
			base.Container.Bind<CashRegister>().FromComponentOn(cashRegister.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CashRegisterActivator>().FromInstance(cashRegister.gameObject.GetComponentInChildren<CashRegisterActivator>()).AsSingle();
		}

		private void InstallSonicBath()
		{
			base.Container.Bind<SonicBath>().FromComponentOn(sonicBath.gameObject).AsSingle()
				.WhenInjectedInto<UltrasonicService>();
			base.Container.BindInterfacesAndSelfTo<ToolActivator>().FromInstance(sonicBath.GetComponentInChildren<ToolActivator>()).AsCached();
		}

		private void InstallTableLamp()
		{
			base.Container.Bind<TableLamp>().FromComponentOn(tableLamp.gameObject).AsSingle();
			LightTimeView[] array = tableLampLightTimeViews;
			foreach (LightTimeView instance in array)
			{
				base.Container.Bind<LightTimeView>().WithId("TableLampLightTimeView").FromInstance(instance)
					.AsCached();
			}
		}

		private void InstallDevicePainter()
		{
			base.Container.Bind<DevicePainter>().FromInstance(devicePainter).AsSingle();
			base.Container.Bind<PaintingBrush>().FromComponentOn(devicePainter.gameObject).AsSingle();
			base.Container.Bind<PaintingToolWorkplaceItem>().FromComponentOn(devicePainter.gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<PaintingToolWorkplaceItemDetector>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<ToolActivator>().FromComponentOn(devicePainter.gameObject).AsCached();
			base.Container.BindInterfacesAndSelfTo<DevicePainterTextureLoggingService>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<PaintingColorCalculator>().FromComponentOn(devicePainter.gameObject).AsSingle();
			base.Container.Bind<PaintingBrushSFX>().FromComponentOn(devicePainter.gameObject).AsSingle();
		}
	}
}
