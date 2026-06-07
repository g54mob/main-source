using UnityEngine;

public class ScaleWithDistanceToPlayer : MonoBehaviour
{
	[SerializeField]
	private float minScale;

	[SerializeField]
	private float maxScale;

	[SerializeField]
	private float distanceScaleMultiplier;

	private float distanceToPlayer;

	private void Start()
	{
		base.transform.localScale = Vector3.zero;
	}

	private void FixedUpdate()
	{
	}
}
