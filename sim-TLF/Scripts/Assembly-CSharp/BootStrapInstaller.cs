using AssembleSystem;
using Assets.Scripts.Player.Stats;
using Data;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Converters;
using Loxodon.Framework.Contexts;
using Player;
using Player.Stats;
using Services;
using UI.Converters;
using UI.Craft;
using UnityEngine;
using UniversalInventorySystem;
using Zenject;

public class BootStrapInstaller : MonoInstaller, IInitializable
{
	public override void InstallBindings()
	{
		ApplicationContext applicationContext = Loxodon.Framework.Contexts.Context.GetApplicationContext();
		new BindingServiceBundle(applicationContext.GetContainer()).Start();
		applicationContext.GetContainer().Resolve<IConverterRegistry>().Register("InverseBool", new InverseBoolConverter());
		BindPlayerData();
		BindMoneyService();
		BindInputService();
		BindInventory();
		BindHUD();
		BindAssembleSystem();
		BindCraftItemUIFactory();
		BindCraftItemUIService();
		BindPlayerEquipService();
		BindPlayerStatsService();
		BindPlayerConsumingService();
		base.Container.BindInterfacesAndSelfTo<BootStrapInstaller>().FromInstance(this).AsSingle();
	}

	private void BindMoneyService()
	{
		base.Container.Bind<IMoneyService>().To<MoneyService>().FromNew()
			.AsSingle();
	}

	private void BindPlayerData()
	{
		base.Container.Bind<PlayerData>().FromInstance(new PlayerData
		{
			FlyCoinsBalance = 6.699999809265137
		}).AsSingle();
	}

	private void BindPlayerConsumingService()
	{
		base.Container.Bind<IPlayerConsumeService>().To<PlayerConsumeService>().FromNew()
			.AsSingle();
	}

	private void BindPlayerStatsService()
	{
		base.Container.Bind<IPlayerStatsService>().To<PlayerStatsService>().FromNew()
			.AsSingle();
	}

	private void BindPlayerEquipService()
	{
		base.Container.Bind<IPlayerEquipService>().To<PlayerEquipService>().FromNew()
			.AsSingle();
	}

	private void BindInputService()
	{
		base.Container.BindInterfacesAndSelfTo<PlayerInputService>().FromNew().AsSingle();
	}

	private void BindCraftItemUIService()
	{
		base.Container.Bind<ICraftUIService>().To<CraftUIService>().FromNew()
			.AsSingle();
	}

	private void BindCraftItemUIFactory()
	{
		base.Container.BindFactoryCustomInterface<CraftItemView, CraftItemView.Factory, ICraftItemFactory>().FromFactory<CraftItemFactory>();
	}

	private void BindInventory()
	{
		base.Container.BindInterfacesAndSelfTo<InventoryHandler>().AsSingle().NonLazy();
		base.Container.Bind<IInventoryService>().To<InventoryService>().AsSingle()
			.WithArguments(10)
			.NonLazy();
	}

	private void BindHUD()
	{
	}

	private void BindAssembleSystem()
	{
		base.Container.Bind<IAssembleSystemService>().To<AssembleSystemService>().AsSingle();
	}

	public void Initialize()
	{
	}

	private void LoadingCompleted(AsyncOperation operation)
	{
		Debug.Log("Game Scene Loaded");
	}
}
