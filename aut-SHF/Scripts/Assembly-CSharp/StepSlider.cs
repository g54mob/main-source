using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StepSlider : Slider
{
	[SerializeField]
	private float step;

	public override void OnMove(AxisEventData eventData)
	{
	}
}
