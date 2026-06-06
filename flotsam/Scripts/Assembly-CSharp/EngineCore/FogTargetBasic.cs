namespace EngineCore
{
	public class FogTargetBasic : FogTarget
	{
		public GlobalFogDefinitionScriptableObject TargetFogDefinitionScriptableObject;

		[ConditionalHide("TargetFogDefinitionScriptableObject", true, true)]
		public GlobalFogDefinition TargetFogDefinition = new GlobalFogDefinition();

		public override GlobalFogDefinition GetCurrentFogDefinition()
		{
			if ((bool)TargetFogDefinitionScriptableObject)
			{
				return TargetFogDefinitionScriptableObject.FogDefinition;
			}
			return TargetFogDefinition;
		}
	}
}
