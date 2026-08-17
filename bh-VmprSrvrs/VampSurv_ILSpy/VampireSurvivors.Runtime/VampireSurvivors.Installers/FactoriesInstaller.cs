using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Installers;

public class FactoriesInstaller : MonoInstaller<FactoriesInstaller>
{
	private WeaponFactory _WeaponFactory;

	private ProjectileFactory _ProjectileFactory;

	private CharacterFactory _CharacterFactory;

	private AccessoriesFactory _AccessoriesFactory;

	private TilesetFactory _TilesetFactory;

	private EnemyFactory _EnemyFactory;

	private DestructibleFactory _DestructibleFactory;

	private PickupFactory _PickupFactory;

	private HeroVfxFactory _HeroVfxFactory;

	private FontFactory _FontFactory;

	private AssetReferenceLibrary _AssetReferenceLibrary;

	public override void InstallBindings()
	{
		//IL_001c: Expected O, but got I
		//IL_003c: Expected O, but got I
		//IL_005c: Expected O, but got I
		//IL_007c: Expected O, but got I
		//IL_009c: Expected O, but got I
		//IL_00bc: Expected O, but got I
		//IL_00dc: Expected O, but got I
		//IL_00fc: Expected O, but got I
		//IL_011c: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_015c: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder = ((DiContainer)0).BindInstance((object)_WeaponFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder2 = ((DiContainer)0).BindInstance((object)_ProjectileFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder3 = ((DiContainer)0).BindInstance((object)_CharacterFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder4 = ((DiContainer)0).BindInstance((object)_AccessoriesFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder5 = ((DiContainer)0).BindInstance((object)_TilesetFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder6 = ((DiContainer)0).BindInstance((object)_EnemyFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder7 = ((DiContainer)0).BindInstance((object)_DestructibleFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder8 = ((DiContainer)0).BindInstance((object)_PickupFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder9 = ((DiContainer)0).BindInstance((object)_HeroVfxFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder10 = ((DiContainer)0).BindInstance((object)_FontFactory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.FactoriesInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder11 = ((DiContainer)0).BindInstance((object)_AssetReferenceLibrary);
	}

	public FactoriesInstaller()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
