using UnityEngine;

[CreateAssetMenu(fileName = "Grad Viz", menuName = "Btn/CoolGradViz")]
public class CoolGradViz : ScriptableObject
{
	[NamedArray(typeof(CoolButtonState))]
	public GradVizState[] States;

	public GradVizState GetState(CoolButtonState state)
	{
		return null;
	}
}
