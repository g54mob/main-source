using UnityEngine;

namespace UniversalSettings.Demo
{
	public class PulseScale : MonoBehaviour
	{
		public float speed = 2f;

		private float pos;

		private AudioSource audioSource;

		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
		}

		private void Update()
		{
			pos += speed * Time.deltaTime;
			float num = Mathf.Sin(pos);
			float num2 = 0.3f + (1f + num) * 0.5f;
			base.transform.localScale = new Vector3(num2, num2, num2);
			if ((double)num >= 0.9 && !audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
	}
}
