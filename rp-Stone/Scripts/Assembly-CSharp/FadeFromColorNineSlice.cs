using UnityEngine;

[RequireComponent(typeof(DialogNineSlice))]
public class FadeFromColorNineSlice : MonoBehaviour
{
	public float fadeSpeed = 1f;

	public float opacity = 1f;

	public Color opaqueColor = Color.white;

	private DialogNineSlice myNineSlice;

	private float targetAlpha;

	private float currentAlpha;

	private void Update()
	{
		if (currentAlpha > targetAlpha)
		{
			currentAlpha -= Time.deltaTime * fadeSpeed;
			if (currentAlpha < targetAlpha)
			{
				currentAlpha = targetAlpha;
			}
			UpdateColorForAlpha();
		}
		else if (currentAlpha < targetAlpha)
		{
			currentAlpha += Time.deltaTime * fadeSpeed;
			if (currentAlpha > targetAlpha)
			{
				currentAlpha = targetAlpha;
			}
			UpdateColorForAlpha();
		}
	}

	public void SetToOpaque()
	{
		targetAlpha = 1f;
		currentAlpha = 1f;
		UpdateColorForAlpha();
	}

	public void SetToNormal()
	{
		targetAlpha = 0f;
		currentAlpha = 0f;
		UpdateColorForAlpha();
	}

	public void FadeToOpaque()
	{
		targetAlpha = 1f;
	}

	public void FadeToNormal()
	{
		targetAlpha = 0f;
	}

	private void UpdateColorForAlpha()
	{
		Color defaultBackgroundColor = GameStates.Singleton.asciiRenderer.defaultBackgroundColor;
		myNineSlice.edgeSymbols.bgColor = Color.Lerp(defaultBackgroundColor, opaqueColor, Mathf.Clamp01(currentAlpha * opacity));
	}

	private void Awake()
	{
		myNineSlice = GetComponent<DialogNineSlice>();
	}
}
