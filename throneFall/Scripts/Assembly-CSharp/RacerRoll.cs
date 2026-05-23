using Pathfinding.RVO;
using UnityEngine;

public class RacerRoll : MonoBehaviour
{
	public RVOController rvo;

	public float speedMultiplier = 4f;

	public Transform targetTransform;

	private void Update()
	{
		targetTransform.Rotate(rvo.velocity.sqrMagnitude * speedMultiplier * Time.deltaTime, 0f, 0f, Space.Self);
	}
}
