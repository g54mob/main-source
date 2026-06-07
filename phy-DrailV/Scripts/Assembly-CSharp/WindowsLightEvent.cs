using UnityEngine;

public class WindowsLightEvent : TimeBasedEvent
{
	public Material[] materials;

	public bool[] initialState;

	public bool currentState;

	public float fromTime;

	public float toTime;

	public bool LightsOn { get; private set; }

	public override void UpdateTime(float time)
	{
		LightsOn = !(time > fromTime) || !(time < toTime);
		SetMaterials(LightsOn);
	}

	private void SetMaterials(bool enabled)
	{
		if (currentState == enabled)
		{
			return;
		}
		Material[] array = materials;
		foreach (Material material in array)
		{
			if (enabled)
			{
				material.EnableKeyword("_EMISSION");
			}
			else
			{
				material.DisableKeyword("_EMISSION");
			}
		}
		currentState = enabled;
	}

	public override void Initialize()
	{
		initialState = new bool[materials.Length];
		for (int i = 0; i < materials.Length; i++)
		{
			initialState[i] = materials[i].IsKeywordEnabled("_EMISSION");
		}
		currentState = true;
		SetMaterials(enabled: false);
	}

	public override void Dispose()
	{
		for (int i = 0; i < initialState.Length; i++)
		{
			if (initialState[i])
			{
				materials[i].EnableKeyword("_EMISSION");
			}
			else
			{
				materials[i].DisableKeyword("_EMISSION");
			}
		}
	}
}
