using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Installers;

public class MultiplayerInstaller : MonoInstaller<MultiplayerInstaller>
{
	private CoopConfig _CoopConfig;

	public override void InstallBindings()
	{
		//IL_001c: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Installers.MultiplayerInstaller)+20]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder = ((DiContainer)0).BindInstance((object)_CoopConfig);
	}

	public MultiplayerInstaller()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
