using UnityEngine;

public class LerpPositionToTarget : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private float lerpSpeed;

	private void Update()
	{
		base.transform.position = Vector3.Lerp(base.transform.position, target.position, lerpSpeed * Time.deltaTime);
	}
}
