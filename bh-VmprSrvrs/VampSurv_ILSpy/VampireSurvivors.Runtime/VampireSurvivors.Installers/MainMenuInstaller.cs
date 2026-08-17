using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Framework;
using Zenject;

namespace VampireSurvivors.Installers;

public class MainMenuInstaller : MonoInstaller<MainMenuInstaller>
{
	private BestiaryFactory _BestiaryFactory;

	public override void InstallBindings()
	{
		//IL_001c: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.MainMenuInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder = ((DiContainer)0).BindInstance((object)_BestiaryFactory);
	}

	public MainMenuInstaller()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
