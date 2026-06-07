using UnityEngine;
using UnityEngine.UI;

public class ImageWrapper : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private RawImage rawImage;

	[SerializeField]
	private Vector2Int textureSize = new Vector2Int(1920, 1080);

	private Texture2D _texture;

	private void OnDestroy()
	{
		Object.Destroy(_texture);
	}

	private void ValidateTexture()
	{
		if (!_texture)
		{
			rawImage.texture = (_texture = new Texture2D(textureSize.x, textureSize.y));
		}
	}

	public void Show(Sprite sprite, Material material, Color color)
	{
		image.gameObject.SetActive(value: true);
		rawImage.gameObject.SetActive(value: false);
		image.overrideSprite = sprite;
		image.material = material;
		image.color = color;
	}

	public void Show(byte[] raw, Material material, Color color)
	{
		image.gameObject.SetActive(value: false);
		rawImage.gameObject.SetActive(value: true);
		ValidateTexture();
		_texture.LoadImage(raw);
		rawImage.material = material;
		rawImage.color = color;
	}

	public void ShowFitContain(byte[] raw, Material material, Color color)
	{
		Show(raw, material, color);
		rawImage.rectTransform.anchorMin = Vector2.zero;
		rawImage.rectTransform.anchorMax = Vector2.one;
		rawImage.rectTransform.sizeDelta = Vector2.zero;
	}
}
