using UnityEngine;

public class PositionMatcher : MonoBehaviour
{
	[SerializeField]
	private Transform transformToMatch;

	[SerializeField]
	private Vector3 offset;

	private void Update()
	{
		base.transform.position = transformToMatch.position + offset;
	}
}
