using System.Collections;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
	public bool isShaking;

	public bool isCamera;

	public IEnumerator Shake(float duration, float magnitude)
	{
		bool flag = true;
		if (isCamera)
		{
			flag = AccessibilityManager.doScreenshake;
		}
		if (!isShaking && flag)
		{
			isShaking = true;
			Vector3 originalPos = base.transform.localPosition;
			float elapsed = 0f;
			while (elapsed < duration)
			{
				float x = Random.Range(-1f, 1f) * magnitude;
				float y = Random.Range(-1f, 1f) * magnitude;
				base.transform.localPosition = new Vector3(x, y, originalPos.z);
				elapsed += Time.deltaTime;
				yield return null;
			}
			base.transform.localPosition = originalPos;
			isShaking = false;
		}
	}
}
