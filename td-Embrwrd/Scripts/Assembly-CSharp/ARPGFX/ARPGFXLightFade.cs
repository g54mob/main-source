using UnityEngine;

namespace ARPGFX
{
	public class ARPGFXLightFade : MonoBehaviour
	{
		[Header("Seconds to dim the light")]
		public float life;

		public bool killAfterLife;

		private Light li;

		private float initIntensity;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
