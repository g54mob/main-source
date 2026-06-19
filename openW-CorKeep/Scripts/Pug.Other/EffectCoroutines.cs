using System.Collections;
using UnityEngine;

public static class EffectCoroutines
{
	public static IEnumerator Shake(Transform transform, float duration = 0.4f, float magnitude = 0.0625f, float frequency = 20f)
	{
		float elapsed = 0f;
		Vector3 originalPosition = transform.localPosition;
		int fixedFrame = -1;
		int fixedUpdatesPerSecond = (int)(1f / Time.fixedDeltaTime);
		while (elapsed < duration)
		{
			fixedFrame = (fixedFrame + 1) % (fixedUpdatesPerSecond + 1);
			if ((float)fixedFrame % ((float)fixedUpdatesPerSecond / frequency) == 0f)
			{
				float num = Random.Range(-1f, 1f) * magnitude;
				float num2 = Random.Range(-1f, 1f) * magnitude;
				num = Mathf.Round(num / 0.0625f) * 0.0625f;
				num2 = Mathf.Round(num2 / 0.0625f) * 0.0625f;
				transform.localPosition = new Vector3(originalPosition.x + num, originalPosition.y + num2, originalPosition.z);
			}
			elapsed += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = originalPosition;
	}
}
