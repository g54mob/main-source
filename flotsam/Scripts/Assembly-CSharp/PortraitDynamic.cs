using UnityEngine;

public class PortraitDynamic : SceneBehaviour
{
	[SerializeField]
	private Transform _dynamicPortraitUIElement;

	public void Enable(Agent agent, Activity activity = Activity.DynamicPortrait)
	{
		Enable(agent.Descriptor, activity);
	}

	public void Enable(AgentDescriptor descriptor, Activity activity = Activity.DynamicPortrait)
	{
		_dynamicPortraitUIElement.gameObject.SetActive(value: true);
		PortraitGenerator.EnableDynamicPortraitDrifter(descriptor, activity);
	}

	public void Disable(Agent agent)
	{
		Disable((agent != null) ? agent.Descriptor : null);
	}

	public void Disable(AgentDescriptor descriptor)
	{
		if (PortraitGenerator.DisableDynamicPortraitDrifter(descriptor))
		{
			_dynamicPortraitUIElement.gameObject.SetActive(value: false);
		}
	}

	public bool IsEnabled()
	{
		return PortraitGenerator.IsDynamicPortraitDrifterEnabled();
	}

	public void SetActivity(Activity activity)
	{
		PortraitGenerator.SetDynamicPortraitActivity(activity);
	}
}
