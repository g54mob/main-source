using Pathfinding.RVO;
using UnityEngine;

public class WheelRollAnimator : MonoBehaviour
{
	public RVOController rvo;

	public float speedMultiplier = 4f;

	public Transform[] targetTransforms;

	private float currentRotationSpeed;

	private void Update()
	{
		currentRotationSpeed = rvo.velocity.sqrMagnitude * speedMultiplier * Time.deltaTime;
		Transform[] array = targetTransforms;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Rotate(currentRotationSpeed, 0f, 0f, Space.Self);
		}
	}
}
