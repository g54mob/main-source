using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
	public float minScale = 1f;

	public float maxScale = 2f;

	private float targetScale;

	private void Start()
	{
		targetScale = maxScale;
	}

	private void FixedUpdate()
	{
		if (base.transform.localScale.x < targetScale)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + Time.deltaTime, base.transform.localScale.y, base.transform.localScale.z);
			if (base.transform.localScale.x >= maxScale)
			{
				targetScale = minScale;
			}
		}
		else if (base.transform.localScale.x > targetScale)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x - Time.deltaTime, base.transform.localScale.y, base.transform.localScale.z);
			if (base.transform.localScale.x <= minScale)
			{
				targetScale = maxScale;
			}
		}
	}
}
