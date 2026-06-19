using UnityEngine;

namespace Audio
{
	public class PlaneAudio : MonoBehaviour
	{
		public Transform listener;

		public AudioSource engineClose;

		public AudioSource engineFar;

		public AudioSource whoosh;

		public float maxDistance = 1000f;

		public float maxSpeed = 200f;

		private Vector3 lastPosition;

		private void Awake()
		{
			listener = Object.FindFirstObjectByType<AudioListener>().transform;
		}

		private void Start()
		{
			lastPosition = base.transform.position;
			engineClose.Play();
			engineFar.Play();
			whoosh.Play();
		}

		private void Update()
		{
			float num = Mathf.Clamp01(Vector3.Distance(base.transform.position, listener.position) / maxDistance);
			float num2 = Mathf.Clamp01((base.transform.position - lastPosition).magnitude / Time.deltaTime / maxSpeed);
			lastPosition = base.transform.position;
			engineClose.volume = 1f - num;
			engineFar.volume = num;
			whoosh.volume = num2 * (1f - num * 0.5f);
			engineClose.pitch = Mathf.Lerp(0.8f, 1.2f, num2);
			engineFar.pitch = Mathf.Lerp(0.7f, 1f, num2);
			whoosh.pitch = Mathf.Lerp(0.8f, 1.3f, num2);
		}
	}
}
