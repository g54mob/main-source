using UnityEngine;

public class MatchPosition : MonoBehaviour
{
	[SerializeField]
	private Transform transToMatch;

	private void Update()
	{
		base.transform.position = transToMatch.position;
	}
}
