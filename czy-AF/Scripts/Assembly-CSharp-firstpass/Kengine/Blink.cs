using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Blink")]
	public class Blink : MonoBehaviour
	{
		public float chance = 50f;

		private void Start()
		{
			InvokeRepeating("PerformBlink", 0f, 0.1f);
		}

		private void PerformBlink()
		{
			if (Random.value > chance / 100f)
			{
				base.gameObject.SetActive(!base.gameObject.activeInHierarchy);
			}
		}
	}
}
