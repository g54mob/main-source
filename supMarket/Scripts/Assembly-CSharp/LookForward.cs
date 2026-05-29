using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

public class LookForward : ActionTask<NavMeshAgent>
{
	[RequiredField]
	public BBParameter<GameObject> target;

	public BBParameter<float> turningSpeed;

	public BBParameter<float> stoppingDistance;

	protected override void OnUpdate()
	{
	}
}
