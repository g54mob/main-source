using FullInspector;
using JetBrains.Annotations;

[UsedImplicitly(ImplicitUseKindFlags.Access | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
public class TH20FullInspectorSettingsCustomiser : fiSettingsProcessor
{
	public void Process()
	{
		fiSettings.RootDirectory = "Assets/Plugins/FullInspector2/";
		fiSettings.RootGeneratedDirectory = "Assets/Code/Generated/FullInspector2/";
		fiSettings.EnableAnimation = false;
		fiSettings.DefaultPageMinimumCollectionLength = 40;
		fiSettings.SerializeAutoProperties = false;
		fiSettings.InspectorAutomaticReferenceInstantation = true;
		fiSettings.InspectorAutomaticReferenceInstantiationAllowedDepth = 3;
		fiSettings.EnableGlobalOrdering = true;
	}
}
