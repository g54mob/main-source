using System;
using Cpp2ILInjected;
using DG.Tweening.Core;
using PhaserPort;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.Tools;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.Installers;

public class CoreInstaller : MonoInstaller<CoreInstaller>
{
	private GameObject _Graphy;

	private GameObject _InGameDebugConsole;

	private DlcCatalog _DlcCatalog;

	private BaseGameData _BaseGameData;

	private MainMenuBackgroundFactory _MainMenuBackgroundFactory;

	public void Awake()
	{
		string version = Application.version;
		string message = "[VERSION_INFO][GAME] :: Vampire Survivors - " + version;
		Debug.LogWarning(message);
	}

	public override void InstallBindings()
	{
		//IL_005d: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_00ff: Expected I4, but got I8
		//IL_00ff: Expected O, but got I
		//IL_0122: Expected I4, but got I8
		//IL_0122: Expected O, but got I
		//IL_0145: Expected I4, but got I8
		//IL_0145: Expected O, but got I
		//IL_0168: Expected I4, but got I8
		//IL_0168: Expected O, but got I
		//IL_018b: Expected I4, but got I8
		//IL_018b: Expected O, but got I
		//IL_01ae: Expected I4, but got I8
		//IL_01ae: Expected O, but got I
		//IL_01d1: Expected I4, but got I8
		//IL_01d1: Expected O, but got I
		//IL_01f4: Expected I4, but got I8
		//IL_01f4: Expected O, but got I
		//IL_0217: Expected I4, but got I8
		//IL_0217: Expected O, but got I
		//IL_023a: Expected I4, but got I8
		//IL_023a: Expected O, but got I
		//IL_025d: Expected I4, but got I8
		//IL_025d: Expected O, but got I
		//IL_0280: Expected I4, but got I8
		//IL_0280: Expected O, but got I
		//IL_02a3: Expected I4, but got I8
		//IL_02a3: Expected O, but got I
		//IL_02c6: Expected I4, but got I8
		//IL_02c6: Expected O, but got I
		//IL_02e9: Expected I4, but got I8
		//IL_02e9: Expected O, but got I
		//IL_030c: Expected I4, but got I8
		//IL_030c: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_03a5: Expected O, but got I
		//IL_0424: Expected O, but got I
		//IL_04a3: Expected O, but got I
		//IL_0522: Expected O, but got I
		//IL_05a1: Expected O, but got I
		//IL_0620: Expected O, but got I
		//IL_069f: Expected O, but got I
		//IL_071e: Expected O, but got I
		//IL_079d: Expected O, but got I
		//IL_081c: Expected O, but got I
		//IL_089b: Expected O, but got I
		//IL_091a: Expected O, but got I
		//IL_0999: Expected O, but got I
		//IL_0a18: Expected O, but got I
		//IL_0a97: Expected O, but got I
		//IL_0b16: Expected O, but got I
		//IL_0b95: Expected O, but got I
		//IL_0c14: Expected O, but got I
		//IL_0c93: Expected O, but got I
		//IL_0d12: Expected O, but got I
		//IL_0d91: Expected O, but got I
		//IL_0e10: Expected O, but got I
		//IL_0e95: Expected O, but got I
		//IL_0eaf: Expected O, but got I
		//IL_0f4a: Expected O, but got I
		DG.Tweening.Core.TweenManager.SetCapacities(1250, 312);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003900");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
		SetupGraphics();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		SignalBusInstaller signalBusInstaller = ((DiContainer)0).Instantiate<SignalBusInstaller>();
		signalBusInstaller.InstallBindings();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		SignalsInstaller signalsInstaller = ((DiContainer)0).Instantiate<SignalsInstaller>();
		signalsInstaller.InstallBindings();
		_Graphy.SetActive(value: false);
		_InGameDebugConsole.SetActive(value: false);
		DlcSystem.Init(_DlcCatalog);
		BaseGame._baseGameData = _BaseGameData;
		Application.runInBackground = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder = ((DiContainer)0).BindInitializableExecutionOrder<SystemPlatform>(-210);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder2 = ((DiContainer)0).BindInitializableExecutionOrder<PlayerOptions>(-200);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder3 = ((DiContainer)0).BindInitializableExecutionOrder<DataManager>(-190);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder4 = ((DiContainer)0).BindInitializableExecutionOrder<ManifestLoader>(-185);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder5 = ((DiContainer)0).BindInitializableExecutionOrder<SoundManager>(-180);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder6 = ((DiContainer)0).BindInitializableExecutionOrder<SpriteManager>(-170);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder7 = ((DiContainer)0).BindInitializableExecutionOrder<MaterialManager>(-160);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder8 = ((DiContainer)0).BindInitializableExecutionOrder<GameSessionData>(-150);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder9 = ((DiContainer)0).BindInitializableExecutionOrder<PlayerStats>(-140);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder10 = ((DiContainer)0).BindInitializableExecutionOrder<AchievementManager>(-120);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder11 = ((DiContainer)0).BindInitializableExecutionOrder<AdventureProgressManager>(-115);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder12 = ((DiContainer)0).BindInitializableExecutionOrder<SpellsManager>(-110);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder13 = ((DiContainer)0).BindInitializableExecutionOrder<PentagramManager>(-100);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder14 = ((DiContainer)0).BindInitializableExecutionOrder<LobbiesManager>(-100);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder15 = ((DiContainer)0).BindDisposableExecutionOrder<SystemPlatform>(-210);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		CopyNonLazyBinder copyNonLazyBinder16 = ((DiContainer)0).BindDisposableExecutionOrder<PlayerOptions>(-190);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric = ((DiContainer)0).BindInterfacesAndSelfTo<SystemPlatform>();
		BindInfo bindInfo = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo2 = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo2.MarkAsUniqueSingleton = true;
		BindInfo bindInfo3 = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo3.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric2 = ((DiContainer)0).BindInterfacesAndSelfTo<PlayerOptions>();
		BindInfo bindInfo4 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo4.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo5 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo5.MarkAsUniqueSingleton = true;
		BindInfo bindInfo6 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo6.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric3 = ((DiContainer)0).BindInterfacesAndSelfTo<DataManager>();
		BindInfo bindInfo7 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo7.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo8 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo8.MarkAsUniqueSingleton = true;
		BindInfo bindInfo9 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo9.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric4 = ((DiContainer)0).BindInterfacesAndSelfTo<SoundManager>();
		BindInfo bindInfo10 = ((IfNotBoundBinder)fromBinderNonGeneric4)._003CBindInfo_003Ek__BackingField;
		bindInfo10.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo11 = ((IfNotBoundBinder)fromBinderNonGeneric4)._003CBindInfo_003Ek__BackingField;
		bindInfo11.MarkAsUniqueSingleton = true;
		BindInfo bindInfo12 = ((IfNotBoundBinder)fromBinderNonGeneric4)._003CBindInfo_003Ek__BackingField;
		bindInfo12.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric5 = ((DiContainer)0).BindInterfacesAndSelfTo<SpriteManager>();
		BindInfo bindInfo13 = ((IfNotBoundBinder)fromBinderNonGeneric5)._003CBindInfo_003Ek__BackingField;
		bindInfo13.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo14 = ((IfNotBoundBinder)fromBinderNonGeneric5)._003CBindInfo_003Ek__BackingField;
		bindInfo14.MarkAsUniqueSingleton = true;
		BindInfo bindInfo15 = ((IfNotBoundBinder)fromBinderNonGeneric5)._003CBindInfo_003Ek__BackingField;
		bindInfo15.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric6 = ((DiContainer)0).BindInterfacesAndSelfTo<MaterialManager>();
		BindInfo bindInfo16 = ((IfNotBoundBinder)fromBinderNonGeneric6)._003CBindInfo_003Ek__BackingField;
		bindInfo16.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo17 = ((IfNotBoundBinder)fromBinderNonGeneric6)._003CBindInfo_003Ek__BackingField;
		bindInfo17.MarkAsUniqueSingleton = true;
		BindInfo bindInfo18 = ((IfNotBoundBinder)fromBinderNonGeneric6)._003CBindInfo_003Ek__BackingField;
		bindInfo18.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric7 = ((DiContainer)0).BindInterfacesAndSelfTo<GameSessionData>();
		BindInfo bindInfo19 = ((IfNotBoundBinder)fromBinderNonGeneric7)._003CBindInfo_003Ek__BackingField;
		bindInfo19.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo20 = ((IfNotBoundBinder)fromBinderNonGeneric7)._003CBindInfo_003Ek__BackingField;
		bindInfo20.MarkAsUniqueSingleton = true;
		BindInfo bindInfo21 = ((IfNotBoundBinder)fromBinderNonGeneric7)._003CBindInfo_003Ek__BackingField;
		bindInfo21.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric8 = ((DiContainer)0).BindInterfacesAndSelfTo<PlayerStats>();
		BindInfo bindInfo22 = ((IfNotBoundBinder)fromBinderNonGeneric8)._003CBindInfo_003Ek__BackingField;
		bindInfo22.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo23 = ((IfNotBoundBinder)fromBinderNonGeneric8)._003CBindInfo_003Ek__BackingField;
		bindInfo23.MarkAsUniqueSingleton = true;
		BindInfo bindInfo24 = ((IfNotBoundBinder)fromBinderNonGeneric8)._003CBindInfo_003Ek__BackingField;
		bindInfo24.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric9 = ((DiContainer)0).BindInterfacesAndSelfTo<LobbiesManager>();
		BindInfo bindInfo25 = ((IfNotBoundBinder)fromBinderNonGeneric9)._003CBindInfo_003Ek__BackingField;
		bindInfo25.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo26 = ((IfNotBoundBinder)fromBinderNonGeneric9)._003CBindInfo_003Ek__BackingField;
		bindInfo26.MarkAsUniqueSingleton = true;
		BindInfo bindInfo27 = ((IfNotBoundBinder)fromBinderNonGeneric9)._003CBindInfo_003Ek__BackingField;
		bindInfo27.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric10 = ((DiContainer)0).BindInterfacesAndSelfTo<AchievementManager>();
		BindInfo bindInfo28 = ((IfNotBoundBinder)fromBinderNonGeneric10)._003CBindInfo_003Ek__BackingField;
		bindInfo28.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo29 = ((IfNotBoundBinder)fromBinderNonGeneric10)._003CBindInfo_003Ek__BackingField;
		bindInfo29.MarkAsUniqueSingleton = true;
		BindInfo bindInfo30 = ((IfNotBoundBinder)fromBinderNonGeneric10)._003CBindInfo_003Ek__BackingField;
		bindInfo30.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric11 = ((DiContainer)0).BindInterfacesAndSelfTo<AdventureProgressManager>();
		BindInfo bindInfo31 = ((IfNotBoundBinder)fromBinderNonGeneric11)._003CBindInfo_003Ek__BackingField;
		bindInfo31.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo32 = ((IfNotBoundBinder)fromBinderNonGeneric11)._003CBindInfo_003Ek__BackingField;
		bindInfo32.MarkAsUniqueSingleton = true;
		BindInfo bindInfo33 = ((IfNotBoundBinder)fromBinderNonGeneric11)._003CBindInfo_003Ek__BackingField;
		bindInfo33.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric12 = ((DiContainer)0).BindInterfacesAndSelfTo<PentagramManager>();
		BindInfo bindInfo34 = ((IfNotBoundBinder)fromBinderNonGeneric12)._003CBindInfo_003Ek__BackingField;
		bindInfo34.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo35 = ((IfNotBoundBinder)fromBinderNonGeneric12)._003CBindInfo_003Ek__BackingField;
		bindInfo35.MarkAsUniqueSingleton = true;
		BindInfo bindInfo36 = ((IfNotBoundBinder)fromBinderNonGeneric12)._003CBindInfo_003Ek__BackingField;
		bindInfo36.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric13 = ((DiContainer)0).BindInterfacesAndSelfTo<EggManager>();
		BindInfo bindInfo37 = ((IfNotBoundBinder)fromBinderNonGeneric13)._003CBindInfo_003Ek__BackingField;
		bindInfo37.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo38 = ((IfNotBoundBinder)fromBinderNonGeneric13)._003CBindInfo_003Ek__BackingField;
		bindInfo38.MarkAsUniqueSingleton = true;
		BindInfo bindInfo39 = ((IfNotBoundBinder)fromBinderNonGeneric13)._003CBindInfo_003Ek__BackingField;
		bindInfo39.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric14 = ((DiContainer)0).BindInterfacesAndSelfTo<SpellsManager>();
		BindInfo bindInfo40 = ((IfNotBoundBinder)fromBinderNonGeneric14)._003CBindInfo_003Ek__BackingField;
		bindInfo40.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo41 = ((IfNotBoundBinder)fromBinderNonGeneric14)._003CBindInfo_003Ek__BackingField;
		bindInfo41.MarkAsUniqueSingleton = true;
		BindInfo bindInfo42 = ((IfNotBoundBinder)fromBinderNonGeneric14)._003CBindInfo_003Ek__BackingField;
		bindInfo42.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric15 = ((DiContainer)0).BindInterfacesAndSelfTo<UnityServicesManager>();
		BindInfo bindInfo43 = ((IfNotBoundBinder)fromBinderNonGeneric15)._003CBindInfo_003Ek__BackingField;
		bindInfo43.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo44 = ((IfNotBoundBinder)fromBinderNonGeneric15)._003CBindInfo_003Ek__BackingField;
		bindInfo44.MarkAsUniqueSingleton = true;
		BindInfo bindInfo45 = ((IfNotBoundBinder)fromBinderNonGeneric15)._003CBindInfo_003Ek__BackingField;
		bindInfo45.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric16 = ((DiContainer)0).BindInterfacesAndSelfTo<ResolutionManager>();
		BindInfo bindInfo46 = ((IfNotBoundBinder)fromBinderNonGeneric16)._003CBindInfo_003Ek__BackingField;
		bindInfo46.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo47 = ((IfNotBoundBinder)fromBinderNonGeneric16)._003CBindInfo_003Ek__BackingField;
		bindInfo47.MarkAsUniqueSingleton = true;
		BindInfo bindInfo48 = ((IfNotBoundBinder)fromBinderNonGeneric16)._003CBindInfo_003Ek__BackingField;
		bindInfo48.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric17 = ((DiContainer)0).BindInterfacesAndSelfTo<ManifestLoader>();
		BindInfo bindInfo49 = ((IfNotBoundBinder)fromBinderNonGeneric17)._003CBindInfo_003Ek__BackingField;
		bindInfo49.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo50 = ((IfNotBoundBinder)fromBinderNonGeneric17)._003CBindInfo_003Ek__BackingField;
		bindInfo50.MarkAsUniqueSingleton = true;
		BindInfo bindInfo51 = ((IfNotBoundBinder)fromBinderNonGeneric17)._003CBindInfo_003Ek__BackingField;
		bindInfo51.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric18 = ((DiContainer)0).BindInterfacesAndSelfTo<MemorySystem>();
		BindInfo bindInfo52 = ((IfNotBoundBinder)fromBinderNonGeneric18)._003CBindInfo_003Ek__BackingField;
		bindInfo52.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo53 = ((IfNotBoundBinder)fromBinderNonGeneric18)._003CBindInfo_003Ek__BackingField;
		bindInfo53.MarkAsUniqueSingleton = true;
		BindInfo bindInfo54 = ((IfNotBoundBinder)fromBinderNonGeneric18)._003CBindInfo_003Ek__BackingField;
		bindInfo54.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric19 = ((DiContainer)0).BindInterfacesAndSelfTo<CheatsController>();
		BindInfo bindInfo55 = ((IfNotBoundBinder)fromBinderNonGeneric19)._003CBindInfo_003Ek__BackingField;
		bindInfo55.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo56 = ((IfNotBoundBinder)fromBinderNonGeneric19)._003CBindInfo_003Ek__BackingField;
		bindInfo56.MarkAsUniqueSingleton = true;
		BindInfo bindInfo57 = ((IfNotBoundBinder)fromBinderNonGeneric19)._003CBindInfo_003Ek__BackingField;
		bindInfo57.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric20 = ((DiContainer)0).BindInterfacesAndSelfTo<MultiplayerManager>();
		BindInfo bindInfo58 = ((IfNotBoundBinder)fromBinderNonGeneric20)._003CBindInfo_003Ek__BackingField;
		bindInfo58.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo59 = ((IfNotBoundBinder)fromBinderNonGeneric20)._003CBindInfo_003Ek__BackingField;
		bindInfo59.MarkAsUniqueSingleton = true;
		BindInfo bindInfo60 = ((IfNotBoundBinder)fromBinderNonGeneric20)._003CBindInfo_003Ek__BackingField;
		bindInfo60.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric21 = ((DiContainer)0).BindInterfacesAndSelfTo<PixelFontManager>();
		BindInfo bindInfo61 = ((IfNotBoundBinder)fromBinderNonGeneric21)._003CBindInfo_003Ek__BackingField;
		bindInfo61.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo62 = ((IfNotBoundBinder)fromBinderNonGeneric21)._003CBindInfo_003Ek__BackingField;
		bindInfo62.MarkAsUniqueSingleton = true;
		BindInfo bindInfo63 = ((IfNotBoundBinder)fromBinderNonGeneric21)._003CBindInfo_003Ek__BackingField;
		bindInfo63.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric22 = ((DiContainer)0).BindInterfacesAndSelfTo<TwitchIntegration>();
		BindInfo bindInfo64 = ((IfNotBoundBinder)fromBinderNonGeneric22)._003CBindInfo_003Ek__BackingField;
		bindInfo64.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo65 = ((IfNotBoundBinder)fromBinderNonGeneric22)._003CBindInfo_003Ek__BackingField;
		bindInfo65.MarkAsUniqueSingleton = true;
		BindInfo bindInfo66 = ((IfNotBoundBinder)fromBinderNonGeneric22)._003CBindInfo_003Ek__BackingField;
		bindInfo66.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric23 = ((DiContainer)0).BindInterfacesAndSelfTo<AdventureManager>();
		BindInfo bindInfo67 = ((IfNotBoundBinder)fromBinderNonGeneric23)._003CBindInfo_003Ek__BackingField;
		bindInfo67.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo68 = ((IfNotBoundBinder)fromBinderNonGeneric23)._003CBindInfo_003Ek__BackingField;
		bindInfo68.MarkAsUniqueSingleton = true;
		BindInfo bindInfo69 = ((IfNotBoundBinder)fromBinderNonGeneric23)._003CBindInfo_003Ek__BackingField;
		bindInfo69.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder = ((DiContainer)0).BindInstance((object)_MainMenuBackgroundFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric24 = ((DiContainer)0).BindInterfacesAndSelfTo<LevelPlayHelper>();
		GameObjectCreationParameters gameObjectInfo = new GameObjectCreationParameters();
		NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder nameTransformScopeConcreteIdArgConditionCopyNonLazyBinder = ((FromBinder)fromBinderNonGeneric24).FromNewComponentOnNewGameObject(gameObjectInfo);
		TransformScopeConcreteIdArgConditionCopyNonLazyBinder transformScopeConcreteIdArgConditionCopyNonLazyBinder = nameTransformScopeConcreteIdArgConditionCopyNonLazyBinder.WithGameObjectName("LevelPlayHelper");
		BindInfo bindInfo70 = ((IfNotBoundBinder)transformScopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo70.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo71 = ((IfNotBoundBinder)transformScopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo71.MarkAsUniqueSingleton = true;
		BindInfo bindInfo72 = ((IfNotBoundBinder)transformScopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo72.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.CoreInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric25 = ((DiContainer)0).BindInterfacesAndSelfTo<MainMenuLoader>();
		BindInfo bindInfo73 = ((IfNotBoundBinder)fromBinderNonGeneric25)._003CBindInfo_003Ek__BackingField;
		bindInfo73.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo74 = ((IfNotBoundBinder)fromBinderNonGeneric25)._003CBindInfo_003Ek__BackingField;
		bindInfo74.MarkAsUniqueSingleton = true;
		BindInfo bindInfo75 = ((IfNotBoundBinder)fromBinderNonGeneric25)._003CBindInfo_003Ek__BackingField;
		bindInfo75.NonLazy = true;
	}

	private unsafe void SetupGraphics()
	{
		//IL_031e: Expected O, but got I4
		//IL_0327: Expected O, but got I4
		//IL_037b: Expected O, but got I4
		//IL_03ef: Expected O, but got I4
		//IL_010b: Expected I, but got O
		//IL_016c: Expected I, but got O
		//IL_01cd: Expected I, but got O
		//IL_027f: Expected O, but got Ref
		//IL_0231: Expected I, but got O
		//IL_012e->IL012e: Incompatible stack heights: 1 vs 0
		//IL_018f->IL018f: Incompatible stack heights: 1 vs 0
		//IL_01f0->IL01f0: Incompatible stack heights: 1 vs 0
		//IL_0254->IL0254: Incompatible stack heights: 1 vs 0
		int width;
		int ret = default(int);
		System.ParamsArray ret2;
		if (PlayerPrefs.HasKey("VS_SavedResolutionX"))
		{
			int num = PlayerPrefs.GetInt("VS_SavedResolutionX", 0);
			width = num;
		}
		else
		{
			Screen.get_currentResolution_Injected(out *(Resolution*)(&ret));
			ret2 = (System.ParamsArray)ret;
			object obj = 0;
			width = ret;
		}
		int height;
		if (PlayerPrefs.HasKey("VS_SavedResolutionY"))
		{
			int num2 = PlayerPrefs.GetInt("VS_SavedResolutionY", 0);
			height = num2;
		}
		else
		{
			Screen.get_currentResolution_Injected(out *(Resolution*)(&ret2));
			height = ret >> 32;
			object obj = 0;
		}
		int fullscreenMode;
		if (PlayerPrefs.HasKey("VS_SavedWindowedMode"))
		{
			int num3 = PlayerPrefs.GetInt("VS_SavedWindowedMode", 0);
			fullscreenMode = num3;
		}
		else
		{
			fullscreenMode = 1;
		}
		int num5;
		if (PlayerPrefs.HasKey("VS_SavedRefreshRate"))
		{
			int num4 = PlayerPrefs.GetInt("VS_SavedRefreshRate", 0);
			num5 = num4;
		}
		else
		{
			num5 = 0;
		}
		int targetFrameRate;
		if (PlayerPrefs.HasKey("VS_SavedFrameRate"))
		{
			int num6 = PlayerPrefs.GetInt("VS_SavedFrameRate", 0);
			targetFrameRate = num6;
		}
		else
		{
			targetFrameRate = 60;
		}
		int num7 = PlayerPrefs.GetInt("VS_VSyncEnabled", 1);
		object obj2 = num7 - 1;
		bool vSyncCount = obj2 == null;
		QualitySettings.vSyncCount = (vSyncCount ? 1 : 0);
		bool flag = num5 == -1;
		int preferredRefreshRate = 0;
		if (!flag)
		{
			preferredRefreshRate = num5;
		}
		object[] array = new object[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj3 = default(object);
		if (obj3 != null)
		{
			nint num8 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj5 = default(object);
		if (obj5 != null)
		{
			nint num9 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			bool flag3 = obj6 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj7 = default(object);
		if (obj7 != null)
		{
			nint num10 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			bool flag4 = obj8 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int num11 = default(int);
		object obj9 = (FullScreenMode)num11;
		if (obj9 != null)
		{
			nint num12 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag5 = obj10 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ret2 = new System.ParamsArray(array);
		object obj11 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Setting screen resolution: {0} x {1} @{2}hz (WindowedMode: {3})", (System.ParamsArray)(&obj11));
		Debug.Log(message);
		Screen.SetResolution(width, height, (FullScreenMode)fullscreenMode, preferredRefreshRate);
		Application.targetFrameRate = targetFrameRate;
		GraphicsSettings.useScriptableRenderPipelineBatching = true;
		if (!RenderingHelper.TryApplySavedOrientation())
		{
			Screen.RequestOrientation(ScreenOrientation.LandscapeLeft);
		}
	}

	private static void SetupOrientations()
	{
		//IL_0023: Expected O, but got I
		if (RenderingHelper.TryApplySavedOrientation())
		{
			return;
		}
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v87 @ rax_v4 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	private static void UpdateLogging()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003900");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
	}

	public CoreInstaller()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
