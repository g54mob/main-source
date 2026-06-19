using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	public int pixWidth;

	public int pixHeight;

	public float xOrg;

	public float yOrg;

	public float scale = 1f;

	private Texture2D noiseTex;

	private Color[] pix;

	private Renderer rend;

	private void Start()
	{
		rend = GetComponent<Renderer>();
		noiseTex = new Texture2D(pixWidth, pixHeight);
		pix = new Color[noiseTex.width * noiseTex.height];
		rend.material.mainTexture = noiseTex;
	}

	private void CalcNoise()
	{
		for (float num = 0f; num < (float)noiseTex.height; num += 1f)
		{
			for (float num2 = 0f; num2 < (float)noiseTex.width; num2 += 1f)
			{
				float x = xOrg + num2 / (float)noiseTex.width * scale;
				float y = yOrg + num / (float)noiseTex.height * scale;
				float num3 = Mathf.PerlinNoise(x, y);
				pix[(int)num * noiseTex.width + (int)num2] = new Color(num3, num3, num3);
			}
		}
		noiseTex.SetPixels(pix);
		noiseTex.Apply();
	}

	private void Update()
	{
		CalcNoise();
	}
}
