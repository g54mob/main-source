using System.Collections;
using UnityEngine;

public class HJInitialPosition : MonoBehaviour
{
	public bool max = true;

	private IEnumerator Start()
	{
		yield return WaitFor.Seconds(2f);
		HingeJoint component = GetComponent<HingeJoint>();
		JointSpring spring = component.spring;
		spring.targetPosition = (max ? component.limits.max : component.limits.min);
		component.spring = spring;
	}
}
