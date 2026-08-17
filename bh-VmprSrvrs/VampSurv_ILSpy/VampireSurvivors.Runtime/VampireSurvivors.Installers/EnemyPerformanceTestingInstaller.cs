using Cpp2ILInjected;
using UnityEngine;
using Zenject;

namespace VampireSurvivors.Installers;

public class EnemyPerformanceTestingInstaller : MonoInstaller<EnemyPerformanceTestingInstaller>
{
	public override void InstallBindings()
	{
	}

	public EnemyPerformanceTestingInstaller()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
