using System;
using UnityEngine;

namespace CompassNavigatorPro
{
	public class BeaconAnimator : MonoBehaviour
	{
		private static class ShaderParams
		{
			public static int EmissionMap = Shader.PropertyToID("_EmissionMap");

			public static int EmissionColor = Shader.PropertyToID("_EmissionColor");
		}

		public float intensity = 5f;

		public float duration;

		public Color tintColor;

		private float startingTime;

		private Material mat;

		private Color fullyTransparentColor;

		private Color originalColor;

		private void Awake()
		{
			mat = GetComponent<Renderer>().material;
			fullyTransparentColor = new Color(0f, 0f, 0f, 0f);
			duration = 1f;
		}

		private void Start()
		{
			startingTime = Time.time;
			originalColor = mat.color * tintColor * intensity;
			mat.SetColor(ShaderParams.EmissionColor, tintColor);
			UpdateColor();
		}

		private void OnDisable()
		{
			DestroyBeacon();
		}

		private void Update()
		{
			float time = Time.time;
			mat.mainTextureOffset = new Vector2(time * -0.25f, time * -0.25f);
			mat.SetTextureOffset(ShaderParams.EmissionMap, new Vector2(time * -0.15f, time * -0.2f));
			UpdateColor();
		}

		private void UpdateColor()
		{
			float num = ((duration <= 0f) ? 1f : Mathf.Clamp01((Time.time - startingTime) / duration));
			if (num >= 1f)
			{
				DestroyBeacon();
				return;
			}
			float t = Ease(num);
			mat.color = Color.Lerp(fullyTransparentColor, originalColor, t);
		}

		private float Ease(float t)
		{
			return Mathf.Sin(t * MathF.PI);
		}

		private void DestroyBeacon()
		{
			if (mat != null)
			{
				UnityEngine.Object.DestroyImmediate(mat);
				mat = null;
			}
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}
}
