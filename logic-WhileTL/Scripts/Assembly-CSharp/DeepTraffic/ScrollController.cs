using UnityEngine;

namespace DeepTraffic
{
	public class ScrollController : ActiveComponent
	{
		private bool started;

		private Renderer renderer;

		private Vector2 offset;

		public float speedScale = 0.001f;

		public float accSum;

		protected override void OnInit()
		{
			base.OnInit();
			renderer = base.gameObject.GetComponent<Renderer>();
			accSum = 0f;
			renderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
			offset = new Vector2(0f, 0f);
			started = true;
		}

		private void Update()
		{
			if (started)
			{
				float t = offset.y + accSum * speedScale;
				accSum = 0f;
				t = Mathf.Repeat(t, 1f);
				offset.y = t;
				renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
			}
		}
	}
}
