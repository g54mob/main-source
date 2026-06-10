using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("✫ Going Medieval")]
[Description("Returns true if the target is defeated")]
public class IsBuildingType : ConditionTask<CommanderAgentProxy>
{
	public BBParameter<IDamageTakingAgent> target;

	public BuildingType buildingType;

	protected override string info => $"{target} is a {buildingType}";

	protected override bool OnCheck()
	{
		if (target?.value == null)
		{
			return false;
		}
		if (target.value is BaseBuildingInstance baseBuildingInstance)
		{
			return baseBuildingInstance.BuildingType.HasFlag(buildingType);
		}
		return false;
	}
}
