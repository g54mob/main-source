using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Diseases/Vital")]
public class VitalDisease : Disease
{
	private const string EFFECT_FORMAT = "+1 {0}";

	[SerializeField]
	private VitalType _vitalType;

	private Agent _agent;

	public override void OnDayStarted(Agent agent)
	{
		base.OnDayStarted(agent);
		_agent = agent;
		if (_agent.Vitals.Pollution.CurrentDisease == this && _agent.Vitals.TryReturnProject(_vitalType, out var project))
		{
			project.FinishedEvent.AddListener(OnVitalProjectFinished);
		}
	}

	public override string GetEffectDescription()
	{
		return $"+1 {EffectDescription}";
	}

	protected override void AddEffectsToTooltip(TooltipBuilder builder)
	{
		builder.AppendEffect(GetEffectDescription());
	}

	private void OnVitalProjectFinished(Project project, bool succes)
	{
		project.FinishedEvent.RemoveListener(OnVitalProjectFinished);
		if (succes)
		{
			_agent.Vitals.TryAddConsumeProject(_vitalType, noDeath: true);
		}
	}
}
