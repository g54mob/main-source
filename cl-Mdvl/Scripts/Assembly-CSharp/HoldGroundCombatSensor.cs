using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.CombatAi;
using NSMedieval.State;
using NSMedieval.Village.Map;

public class HoldGroundCombatSensor : CombatAiSensor
{
	private HumanoidInstance human;

	public HoldGroundCombatSensor(CombatAiAgent agent)
		: base(agent)
	{
	}

	public override void Dispose()
	{
		human = null;
		base.Dispose();
	}

	internal override void InitStates()
	{
	}

	public override void OnEnable()
	{
		human = base.CombatAgent as HumanoidInstance;
		UpdateHoldGroundNode();
	}

	public override void OnDisable()
	{
		if (human != null && !human.HasDisposed)
		{
			base.CombatAi.SetState(CombatAiState.HoldGroundGridPosition, null);
		}
	}

	private void UpdateHoldGroundNode()
	{
		if (human != null && !human.HasDisposed && !human.HasDied)
		{
			MapNode mapNode = human.PathDriver?.FinalDestinationNode ?? human.GetNode();
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(37, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Sensors\\HoldGroundCombatSensor.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(human);
				messageBuilder.AppendLiteral(" setting hold ground origin point to ");
				messageBuilder.AppendFormatted(mapNode?.Position);
			}
			Log.Debug(messageBuilder);
			base.CombatAi.SetState(CombatAiState.HoldGroundGridPosition, mapNode?.Position);
		}
	}

	internal override void Refresh()
	{
		base.Refresh();
		if (!base.CombatAi.IsStateSet(CombatAiState.HoldGroundGridPosition))
		{
			UpdateHoldGroundNode();
		}
	}
}
