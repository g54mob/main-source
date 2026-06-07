using UnityEngine;

namespace Utility
{
	public class VideoAnimationScript : MonoBehaviour
	{
		private Material mat;

		private SpriteRenderer sr;

		public float speed;

		public float progress;

		private void Start()
		{
			Time.timeScale = 1f;
			sr = GetComponent<SpriteRenderer>();
			mat = sr.material;
		}

		private void Update()
		{
			if (!(progress > 1f))
			{
				progress += speed * Time.deltaTime;
				mat.SetFloat("_InfectedRatio", progress);
			}
		}
	}
}
