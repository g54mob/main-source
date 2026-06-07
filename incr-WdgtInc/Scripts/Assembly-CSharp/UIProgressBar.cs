using System.Collections;
using UnityEngine;

public class UIProgressBar : MonoBehaviour
{
	[SerializeField]
	private RectTransform _fill;

	public void UpdateProgress(float progress)
	{
		_fill.localScale = new Vector3(progress, 1f, 1f);
	}

	public void SetScale(Vector2 scale)
	{
		(base.transform as RectTransform).sizeDelta *= scale;
	}

	public void ResetProgress()
	{
		StartCoroutine(ClearProgress());
	}

	public IEnumerator ClearProgress()
	{
		yield return new WaitForSeconds(0.1f);
		if (_fill.localScale.x == 1f)
		{
			UpdateProgress(0f);
		}
	}
}
