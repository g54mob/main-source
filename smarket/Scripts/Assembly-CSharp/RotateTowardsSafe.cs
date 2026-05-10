using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

[Category("Movement/Direct")]
[Description("Rotate the agent towards the target per frame, if not too close to the destination")]
public class RotateTowardsSafe : ActionTask<Transform>
{
	[RequiredField]
	public BBParameter<GameObject> target;

	public BBParameter<float> speed;

	[SliderField(1, 180)]
	public BBParameter<float> angleDifference;

	public BBParameter<Vector3> upVector;

	public bool waitActionFinish;

	protected override void OnUpdate()
	{
	}
}
