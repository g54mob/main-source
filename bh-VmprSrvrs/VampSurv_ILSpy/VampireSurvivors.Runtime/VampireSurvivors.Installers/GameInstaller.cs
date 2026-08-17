using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.VFX;
using Zenject;

namespace VampireSurvivors.Installers;

public class GameInstaller : MonoInstaller<GameInstaller>
{
	public override void InstallBindings()
	{
		//IL_001c: Expected O, but got I
		//IL_009b: Expected O, but got I
		//IL_011a: Expected O, but got I
		//IL_0199: Expected O, but got I
		Install();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric = ((DiContainer)0).BindInterfacesAndSelfTo<LevelUpFactory>();
		BindInfo bindInfo = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo2 = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo2.MarkAsUniqueSingleton = true;
		BindInfo bindInfo3 = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo3.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric2 = ((DiContainer)0).BindInterfacesAndSelfTo<ShopFactory>();
		BindInfo bindInfo4 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo4.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo5 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo5.MarkAsUniqueSingleton = true;
		BindInfo bindInfo6 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo6.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric3 = ((DiContainer)0).BindInterfacesAndSelfTo<LimitBreakManager>();
		BindInfo bindInfo7 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo7.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo8 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo8.MarkAsUniqueSingleton = true;
		BindInfo bindInfo9 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo9.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric4 = ((DiContainer)0).BindInterfacesAndSelfTo<MainGamePage>();
		ScopeConcreteIdArgConditionCopyNonLazyBinder scopeConcreteIdArgConditionCopyNonLazyBinder = ((FromBinder)fromBinderNonGeneric4).FromComponentsInHierarchyBase((Func<Component, bool>)null, true);
		BindInfo bindInfo10 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo10.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo11 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo11.MarkAsUniqueSingleton = true;
		BindInfo bindInfo12 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo12.NonLazy = true;
	}

	private void Install()
	{
		//IL_0016: Expected O, but got I
		//IL_00ad: Expected O, but got I
		//IL_012c: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_02a9: Expected O, but got I
		//IL_0340: Expected O, but got I
		//IL_03bf: Expected O, but got I
		//IL_043e: Expected O, but got I
		//IL_04bd: Expected O, but got I
		//IL_053c: Expected O, but got I
		//IL_05bb: Expected O, but got I
		//IL_063a: Expected O, but got I
		//IL_06b9: Expected O, but got I
		//IL_0738: Expected O, but got I
		//IL_07b7: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric = ((DiContainer)0).BindInterfacesAndSelfTo<GameManager>();
		ScopeConcreteIdArgConditionCopyNonLazyBinder scopeConcreteIdArgConditionCopyNonLazyBinder = ((FromBinder)fromBinderNonGeneric).FromComponentsInHierarchyBase((Func<Component, bool>)null, true);
		BindInfo bindInfo = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo2 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo2.MarkAsUniqueSingleton = true;
		BindInfo bindInfo3 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo3.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric2 = ((DiContainer)0).BindInterfacesAndSelfTo<ArcanaManager>();
		BindInfo bindInfo4 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo4.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo5 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo5.MarkAsUniqueSingleton = true;
		BindInfo bindInfo6 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo6.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric3 = ((DiContainer)0).BindInterfacesAndSelfTo<LootManager>();
		BindInfo bindInfo7 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo7.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo8 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo8.MarkAsUniqueSingleton = true;
		BindInfo bindInfo9 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo9.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric4 = ((DiContainer)0).BindInterfacesAndSelfTo<WeaponsFacade>();
		BindInfo bindInfo10 = ((IfNotBoundBinder)fromBinderNonGeneric4)._003CBindInfo_003Ek__BackingField;
		bindInfo10.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo11 = ((IfNotBoundBinder)fromBinderNonGeneric4)._003CBindInfo_003Ek__BackingField;
		bindInfo11.MarkAsUniqueSingleton = true;
		BindInfo bindInfo12 = ((IfNotBoundBinder)fromBinderNonGeneric4)._003CBindInfo_003Ek__BackingField;
		bindInfo12.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric5 = ((DiContainer)0).BindInterfacesAndSelfTo<AccessoriesFacade>();
		BindInfo bindInfo13 = ((IfNotBoundBinder)fromBinderNonGeneric5)._003CBindInfo_003Ek__BackingField;
		bindInfo13.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo14 = ((IfNotBoundBinder)fromBinderNonGeneric5)._003CBindInfo_003Ek__BackingField;
		bindInfo14.MarkAsUniqueSingleton = true;
		BindInfo bindInfo15 = ((IfNotBoundBinder)fromBinderNonGeneric5)._003CBindInfo_003Ek__BackingField;
		bindInfo15.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric6 = ((DiContainer)0).BindInterfacesAndSelfTo<Stage>();
		ScopeConcreteIdArgConditionCopyNonLazyBinder scopeConcreteIdArgConditionCopyNonLazyBinder2 = ((FromBinder)fromBinderNonGeneric6).FromComponentsInHierarchyBase((Func<Component, bool>)null, true);
		BindInfo bindInfo16 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder2)._003CBindInfo_003Ek__BackingField;
		bindInfo16.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo17 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder2)._003CBindInfo_003Ek__BackingField;
		bindInfo17.MarkAsUniqueSingleton = true;
		BindInfo bindInfo18 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder2)._003CBindInfo_003Ek__BackingField;
		bindInfo18.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric7 = ((DiContainer)0).BindInterfacesAndSelfTo<VFXManager>();
		BindInfo bindInfo19 = ((IfNotBoundBinder)fromBinderNonGeneric7)._003CBindInfo_003Ek__BackingField;
		bindInfo19.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo20 = ((IfNotBoundBinder)fromBinderNonGeneric7)._003CBindInfo_003Ek__BackingField;
		bindInfo20.MarkAsUniqueSingleton = true;
		BindInfo bindInfo21 = ((IfNotBoundBinder)fromBinderNonGeneric7)._003CBindInfo_003Ek__BackingField;
		bindInfo21.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric8 = ((DiContainer)0).BindInterfacesAndSelfTo<PickupManager>();
		BindInfo bindInfo22 = ((IfNotBoundBinder)fromBinderNonGeneric8)._003CBindInfo_003Ek__BackingField;
		bindInfo22.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo23 = ((IfNotBoundBinder)fromBinderNonGeneric8)._003CBindInfo_003Ek__BackingField;
		bindInfo23.MarkAsUniqueSingleton = true;
		BindInfo bindInfo24 = ((IfNotBoundBinder)fromBinderNonGeneric8)._003CBindInfo_003Ek__BackingField;
		bindInfo24.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric9 = ((DiContainer)0).BindInterfacesAndSelfTo<HeroVfxManager>();
		BindInfo bindInfo25 = ((IfNotBoundBinder)fromBinderNonGeneric9)._003CBindInfo_003Ek__BackingField;
		bindInfo25.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo26 = ((IfNotBoundBinder)fromBinderNonGeneric9)._003CBindInfo_003Ek__BackingField;
		bindInfo26.MarkAsUniqueSingleton = true;
		BindInfo bindInfo27 = ((IfNotBoundBinder)fromBinderNonGeneric9)._003CBindInfo_003Ek__BackingField;
		bindInfo27.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric10 = ((DiContainer)0).BindInterfacesAndSelfTo<DestructibleManager>();
		BindInfo bindInfo28 = ((IfNotBoundBinder)fromBinderNonGeneric10)._003CBindInfo_003Ek__BackingField;
		bindInfo28.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo29 = ((IfNotBoundBinder)fromBinderNonGeneric10)._003CBindInfo_003Ek__BackingField;
		bindInfo29.MarkAsUniqueSingleton = true;
		BindInfo bindInfo30 = ((IfNotBoundBinder)fromBinderNonGeneric10)._003CBindInfo_003Ek__BackingField;
		bindInfo30.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric11 = ((DiContainer)0).BindInterfacesAndSelfTo<RewardManager>();
		BindInfo bindInfo31 = ((IfNotBoundBinder)fromBinderNonGeneric11)._003CBindInfo_003Ek__BackingField;
		bindInfo31.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo32 = ((IfNotBoundBinder)fromBinderNonGeneric11)._003CBindInfo_003Ek__BackingField;
		bindInfo32.MarkAsUniqueSingleton = true;
		BindInfo bindInfo33 = ((IfNotBoundBinder)fromBinderNonGeneric11)._003CBindInfo_003Ek__BackingField;
		bindInfo33.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric12 = ((DiContainer)0).BindInterfacesAndSelfTo<TreasureFactory>();
		BindInfo bindInfo34 = ((IfNotBoundBinder)fromBinderNonGeneric12)._003CBindInfo_003Ek__BackingField;
		bindInfo34.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo35 = ((IfNotBoundBinder)fromBinderNonGeneric12)._003CBindInfo_003Ek__BackingField;
		bindInfo35.MarkAsUniqueSingleton = true;
		BindInfo bindInfo36 = ((IfNotBoundBinder)fromBinderNonGeneric12)._003CBindInfo_003Ek__BackingField;
		bindInfo36.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric13 = ((DiContainer)0).BindInterfacesAndSelfTo<PhysicsManager>();
		BindInfo bindInfo37 = ((IfNotBoundBinder)fromBinderNonGeneric13)._003CBindInfo_003Ek__BackingField;
		bindInfo37.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo38 = ((IfNotBoundBinder)fromBinderNonGeneric13)._003CBindInfo_003Ek__BackingField;
		bindInfo38.MarkAsUniqueSingleton = true;
		BindInfo bindInfo39 = ((IfNotBoundBinder)fromBinderNonGeneric13)._003CBindInfo_003Ek__BackingField;
		bindInfo39.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric14 = ((DiContainer)0).BindInterfacesAndSelfTo<GoldFeverController>();
		BindInfo bindInfo40 = ((IfNotBoundBinder)fromBinderNonGeneric14)._003CBindInfo_003Ek__BackingField;
		bindInfo40.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo41 = ((IfNotBoundBinder)fromBinderNonGeneric14)._003CBindInfo_003Ek__BackingField;
		bindInfo41.MarkAsUniqueSingleton = true;
		BindInfo bindInfo42 = ((IfNotBoundBinder)fromBinderNonGeneric14)._003CBindInfo_003Ek__BackingField;
		bindInfo42.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric15 = ((DiContainer)0).BindInterfacesAndSelfTo<GizmoManager>();
		BindInfo bindInfo43 = ((IfNotBoundBinder)fromBinderNonGeneric15)._003CBindInfo_003Ek__BackingField;
		bindInfo43.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo44 = ((IfNotBoundBinder)fromBinderNonGeneric15)._003CBindInfo_003Ek__BackingField;
		bindInfo44.MarkAsUniqueSingleton = true;
		BindInfo bindInfo45 = ((IfNotBoundBinder)fromBinderNonGeneric15)._003CBindInfo_003Ek__BackingField;
		bindInfo45.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric16 = ((DiContainer)0).BindInterfacesAndSelfTo<ParticleManager>();
		BindInfo bindInfo46 = ((IfNotBoundBinder)fromBinderNonGeneric16)._003CBindInfo_003Ek__BackingField;
		bindInfo46.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo47 = ((IfNotBoundBinder)fromBinderNonGeneric16)._003CBindInfo_003Ek__BackingField;
		bindInfo47.MarkAsUniqueSingleton = true;
		BindInfo bindInfo48 = ((IfNotBoundBinder)fromBinderNonGeneric16)._003CBindInfo_003Ek__BackingField;
		bindInfo48.NonLazy = true;
	}

	private void InstallData()
	{
		//IL_0016: Expected O, but got I
		//IL_0095: Expected O, but got I
		//IL_0114: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric = ((DiContainer)0).BindInterfacesAndSelfTo<LevelUpFactory>();
		BindInfo bindInfo = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo2 = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo2.MarkAsUniqueSingleton = true;
		BindInfo bindInfo3 = ((IfNotBoundBinder)fromBinderNonGeneric)._003CBindInfo_003Ek__BackingField;
		bindInfo3.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric2 = ((DiContainer)0).BindInterfacesAndSelfTo<ShopFactory>();
		BindInfo bindInfo4 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo4.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo5 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo5.MarkAsUniqueSingleton = true;
		BindInfo bindInfo6 = ((IfNotBoundBinder)fromBinderNonGeneric2)._003CBindInfo_003Ek__BackingField;
		bindInfo6.NonLazy = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric3 = ((DiContainer)0).BindInterfacesAndSelfTo<LimitBreakManager>();
		BindInfo bindInfo7 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo7.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo8 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo8.MarkAsUniqueSingleton = true;
		BindInfo bindInfo9 = ((IfNotBoundBinder)fromBinderNonGeneric3)._003CBindInfo_003Ek__BackingField;
		bindInfo9.NonLazy = true;
	}

	private void InstallUI()
	{
		//IL_0016: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.GameInstaller)+20]");
		FromBinderNonGeneric fromBinderNonGeneric = ((DiContainer)0).BindInterfacesAndSelfTo<MainGamePage>();
		ScopeConcreteIdArgConditionCopyNonLazyBinder scopeConcreteIdArgConditionCopyNonLazyBinder = ((FromBinder)fromBinderNonGeneric).FromComponentsInHierarchyBase((Func<Component, bool>)null, true);
		BindInfo bindInfo = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo.Scope = ScopeTypes.Singleton;
		BindInfo bindInfo2 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo2.MarkAsUniqueSingleton = true;
		BindInfo bindInfo3 = ((IfNotBoundBinder)scopeConcreteIdArgConditionCopyNonLazyBinder)._003CBindInfo_003Ek__BackingField;
		bindInfo3.NonLazy = true;
	}

	private void InstallMobile()
	{
	}

	public GameInstaller()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
