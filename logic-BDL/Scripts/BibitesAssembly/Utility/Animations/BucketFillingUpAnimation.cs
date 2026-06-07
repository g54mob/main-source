using UnityEngine;

namespace Utility.Animations
{
	public class BucketFillingUpAnimation : MonoBehaviour
	{
		public GameObject prefab;

		public Transform holder;

		private float rate = 25f;

		private float initialSpeed = 300f;

		private float lateralAmplitude = 0.25f;

		public float delay;

		private void Start()
		{
			delay = 1f;
			Time.fixedDeltaTime = 0.01f;
		}

		private void FixedUpdate()
		{
			delay -= Time.fixedDeltaTime;
			if (!(delay > 0f))
			{
				delay = 1f / Mathf.Lerp(1f, rate, Mathf.Pow(Mathf.Clamp01((Time.timeSinceLevelLoad - 5f) / 20f), 1.5f)) / Mathf.Lerp(1f, 4f, Mathf.Clamp01((Time.timeSinceLevelLoad - 25f) / 5f));
				Rigidbody2D component = Object.Instantiate(prefab, holder).GetComponent<Rigidbody2D>();
				component.gameObject.SetActive(value: true);
				component.position = holder.position;
				component.linearVelocity = new Vector2(lateralAmplitude * Random.Range(-1f, 1f), -1f).normalized * initialSpeed * Mathf.Lerp(1f, 3f, Mathf.Clamp01((Time.timeSinceLevelLoad - 25f) / 5f));
				component.angularVelocity = Random.Range(-180f, 180f);
				component.rotation = 360f * Random.value;
			}
		}
	}
}
