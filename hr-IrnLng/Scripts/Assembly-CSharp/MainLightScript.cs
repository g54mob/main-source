using UnityEngine;

public class MainLightScript : MonoBehaviour
{
	private Light MyLight;

	public bool DoRave;

	private Color OriginalColor;

	public float RaveSpeed;

	private Color Color1;

	private Color Color2;

	private Color RaveColor;

	private float Lerp;

	private void Start()
	{
		MyLight = GetComponent<Light>();
		OriginalColor = MyLight.color;
		Color2 = OriginalColor;
		SetColor();
	}

	private void Update()
	{
		if (DoRave)
		{
			Lerp += Time.deltaTime * RaveSpeed;
			if (Lerp >= 1f)
			{
				Lerp -= 1f;
				SetColor();
			}
			RaveColor = new Color(Mathf.Lerp(Color1.r, Color2.r, Lerp), Mathf.Lerp(Color1.g, Color2.g, Lerp), Mathf.Lerp(Color1.b, Color2.b, Lerp));
			MyLight.color = RaveColor;
		}
		else
		{
			MyLight.color = OriginalColor;
		}
	}

	public void SetColor()
	{
		Color1 = Color2;
		Color2 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		Lerp = 0f;
	}
}
