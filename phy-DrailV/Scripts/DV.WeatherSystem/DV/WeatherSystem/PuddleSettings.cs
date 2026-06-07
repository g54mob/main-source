using DV.Utils;
using UnityEngine;

namespace DV.WeatherSystem
{
	public class PuddleSettings : SingletonBehaviour<PuddleSettings>
	{
		private int textureID = Shader.PropertyToID("_PuddleTexture");

		private int scaleID = Shader.PropertyToID("_PuddleScale");

		private int thresholdID = Shader.PropertyToID("_PuddleThreshold");

		private int smoothnessID = Shader.PropertyToID("_PuddleSmoothness");

		public Texture2D puddleTexture;

		public float puddleScale;

		public float puddleThreshold;

		public float puddleSmoothness;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private void OnValidate()
		{
			UploadSettings();
		}

		protected override void Awake()
		{
			base.Awake();
			UploadSettings();
		}

		public void UploadSettings()
		{
			Shader.SetGlobalTexture(textureID, puddleTexture);
			Shader.SetGlobalFloat(scaleID, puddleScale);
			Shader.SetGlobalFloat(thresholdID, puddleThreshold);
			Shader.SetGlobalFloat(smoothnessID, puddleSmoothness);
		}

		public float SamplePuddles(Vector3 position)
		{
			Vector2 vector = new Vector2(position.x, position.z) / puddleScale;
			vector.x = Mathf.Repeat(vector.x, 1f);
			vector.y = Mathf.Repeat(vector.y, 1f);
			vector.x *= puddleTexture.width - 1;
			vector.y *= puddleTexture.height - 1;
			Color pixel = puddleTexture.GetPixel((int)vector.x, (int)vector.y);
			pixel.r /= puddleThreshold;
			return pixel.r;
		}
	}
}
