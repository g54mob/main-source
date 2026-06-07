using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class SinusScaler : MonoBehaviour
	{
		public float frequency = 1f;

		public float amplitude = 1f;

		private void Start()
		{
		}

		private void Update()
		{
			base.transform.localScale = new Vector3(Mathf.Sin(Time.time * frequency) * amplitude, Mathf.Sin(Time.time * frequency) * amplitude, 0f);
		}
	}
}
