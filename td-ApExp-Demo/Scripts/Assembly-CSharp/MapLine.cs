using UnityEngine;
using UnityEngine.UI;

public class MapLine : MonoBehaviour
{
	public Image Image { get; private set; }

	private void Awake()
	{
		Image = GetComponent<Image>();
	}

	public void ColorFade(Color color)
	{
		LeanTween.cancel(Image.rectTransform);
		if (!(Image.color == color))
		{
			LeanTween.color(Image.rectTransform, color, 0.25f).setIgnoreTimeScale(useUnScaledTime: true).setEase(LeanTweenType.linear)
				.setEaseLinear();
		}
	}

	private void Update()
	{
		Shader.SetGlobalFloat("_UnscaledTime", Time.unscaledTime);
	}

	public void DestroySelf()
	{
		Object.Destroy(base.gameObject);
	}
}
