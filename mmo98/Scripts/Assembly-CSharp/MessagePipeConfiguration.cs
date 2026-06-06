using MessagePipe;
using UnityEngine;

[DefaultExecutionOrder(-999)]
public static class MessagePipeConfiguration
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	public static void InitializeSceneMessagePipe()
	{
		BuiltinContainerBuilder builtinContainerBuilder = new BuiltinContainerBuilder();
		builtinContainerBuilder.AddMessagePipe(ConfigureGlobalOptions);
		RegisterSceneBrokers(builtinContainerBuilder);
		RegisterTestBrokers(builtinContainerBuilder);
		GlobalMessagePipe.SetProvider(builtinContainerBuilder.BuildServiceProvider());
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	public static void InitializePersistentMessagePipe()
	{
		BuiltinContainerBuilder builtinContainerBuilder = new BuiltinContainerBuilder();
		builtinContainerBuilder.AddMessagePipe(ConfigurePersistentOptions);
		RegisterPersistentBrokers(builtinContainerBuilder);
		RegisterTestBrokers(builtinContainerBuilder);
		PersistentMessagePipe.SetProvider(builtinContainerBuilder.BuildServiceProvider());
	}

	private static void ConfigureGlobalOptions(MessagePipeOptions options)
	{
		options.EnableCaptureStackTrace = true;
	}

	private static void ConfigurePersistentOptions(MessagePipeOptions options)
	{
	}

	private static void RegisterTestBrokers(BuiltinContainerBuilder builder)
	{
		builder.AddMessageBroker<int>();
		builder.AddMessageBroker<string>();
	}

	private static void RegisterPersistentBrokers(BuiltinContainerBuilder builder)
	{
		builder.AddMessageBroker<SceneLoaded>();
	}

	private static void RegisterSceneBrokers(BuiltinContainerBuilder builder)
	{
		builder.AddMessageBroker<DevelopmentAttempted>();
		builder.AddMessageBroker<FirstGameReleased>();
		builder.AddMessageBroker<RehiredContinue>();
		builder.AddMessageBroker<Prestiged>();
		builder.AddMessageBroker<GnormanActionFinished>();
		builder.AddMessageBroker<GnormanActionStarted>();
		builder.AddMessageBroker<GnormanActionStepStarted>();
		builder.AddMessageBroker<GnormanStepPerformed>();
		builder.AddMessageBroker<MinesweeperFinished>();
		builder.AddMessageBroker<MinesweeperFlagged>();
		builder.AddMessageBroker<MinesweeperMouse>();
		builder.AddMessageBroker<MinesweeperRestarted>();
		builder.AddMessageBroker<MinesweeperRevealed>();
		builder.AddMessageBroker<MinesweeperTimerStarted>();
		builder.AddMessageBroker<OperationFinished>();
		builder.AddMessageBroker<OperationLocked>();
		builder.AddMessageBroker<OperationStarted>();
		builder.AddMessageBroker<OperationUnlocked>();
		builder.AddMessageBroker<ProfileConfirmDeletion>();
		builder.AddMessageBroker<ProfileCreated>();
		builder.AddMessageBroker<ProfileDeleted>();
		builder.AddMessageBroker<ProfileLoaded>();
		builder.AddMessageBroker<ResearchBought>();
		builder.AddMessageBroker<UpgradeBought>();
		builder.AddMessageBroker<AchievementUnlocked>();
		builder.AddMessageBroker<SalvagedLootItem>();
		builder.AddMessageBroker<SoldLootItem>();
		builder.AddMessageBroker<GamepadTextInputDismissed>();
	}
}
