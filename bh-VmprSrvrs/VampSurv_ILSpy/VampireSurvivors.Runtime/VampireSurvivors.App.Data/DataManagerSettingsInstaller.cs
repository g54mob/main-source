using Cpp2ILInjected;
using Zenject;

namespace VampireSurvivors.App.Data;

public class DataManagerSettingsInstaller : ScriptableObjectInstaller<DataManagerSettingsInstaller>
{
	private DataManagerSettings _Settings;

	public DataManagerSettings Settings => _Settings;

	public override void InstallBindings()
	{
		//IL_001c: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Data.DataManagerSettingsInstaller)+18]");
		IdScopeConcreteIdArgConditionCopyNonLazyBinder idScopeConcreteIdArgConditionCopyNonLazyBinder = ((DiContainer)0).BindInstance((object)_Settings);
	}
}
