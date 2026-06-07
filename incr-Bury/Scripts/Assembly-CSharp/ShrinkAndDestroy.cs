using System.Collections;
using UnityEngine;

public class ShrinkAndDestroy : MonoBehaviour
{
	public float timeBeforeShrink;

	public float shrinkSpeed = 1f;

	private float startingScaleX;

	private bool isShrinking;

	private void Start()
	{
		startingScaleX = base.transform.localScale.x;
		if (timeBeforeShrink > 0f)
		{
			StartCoroutine(WaitThenShrink());
		}
		else
		{
			isShrinking = true;
		}
		if (shrinkSpeed == 0f)
		{
			shrinkSpeed = 1f;
		}
	}

	private void Update()
	{
		if (isShrinking && base.transform.localScale.x > 0f)
		{
			base.transform.localScale -= Vector3.one * (shrinkSpeed * Time.deltaTime * startingScaleX);
			if (base.transform.localScale.x < 0f)
			{
				base.transform.localScale = Vector3.zero;
				Object.Destroy(base.gameObject);
			}
		}
	}

	private IEnumerator WaitThenShrink()
	{
		yield return new WaitForSeconds(timeBeforeShrink);
		isShrinking = true;
	}
}
