using UnityEngine;
using UnityEngine.UI;

public class FlipBreederSettings : MonoBehaviour
{
	public InputField dutyCycleOn;

	public InputField dutyCycleOff;

	public InputField min;

	public InputField max;

	public InputField rate;

	public InputField min_AC;

	public InputField max_AC;

	public InputField rate_AC;

	private World.BreederStruct breederStruct;

	public void Show(World.BreederStruct breederStruct)
	{
	}

	public void Apply()
	{
	}
}
