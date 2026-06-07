using UnityEngine;

namespace CurvedUI
{
	public class CUI_PerlinNoiseRotation : MonoBehaviour
	{
		public float samplingSpeed = 1f;

		public float maxrotation = 60f;

		private RectTransform rectie;

		private void Start()
		{
			rectie = base.transform as RectTransform;
		}

		private void Update()
		{
			rectie.localEulerAngles = new Vector3(0f, 0f, Mathf.PerlinNoise(Time.time * samplingSpeed, Time.time * samplingSpeed).Remap(0f, 1f, 0f - maxrotation, maxrotation));
		}
	}
}
