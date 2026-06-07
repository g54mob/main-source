using UnityEngine;

namespace AllIn1SpriteShader
{
	public class DemoRandomColorSwap : MonoBehaviour
	{
		private Material mat;

		private readonly int colorSwapRed = Shader.PropertyToID("_ColorSwapRed");

		private readonly int colorSwapGreen = Shader.PropertyToID("_ColorSwapGreen");

		private readonly int colorSwapBlue = Shader.PropertyToID("_ColorSwapBlue");

		private void Start()
		{
			if (GetComponent<SpriteRenderer>() != null)
			{
				mat = GetComponent<Renderer>().material;
				if (mat != null)
				{
					InvokeRepeating("NewColor", 0f, 0.6f);
					return;
				}
				Debug.LogError("No material found");
				Object.Destroy(this);
			}
		}

		private void NewColor()
		{
			mat.SetColor(colorSwapRed, GenerateColor());
			mat.SetColor(colorSwapGreen, GenerateColor());
			mat.SetColor(colorSwapBlue, GenerateColor());
		}

		private Color GenerateColor()
		{
			return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
		}
	}
}
