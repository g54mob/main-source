using R3;
using UnityEngine;

public class BackgroundRenderer : MonoBehaviour
{
	[SerializeField]
	private ImageWrapper image;

	private void Awake()
	{
		Database.State.Customization.Background.CombineLatest(Database.State.Customization.CustomBackground, (BackgroundSkin skin, bool custom) => (skin: skin, custom: custom)).Subscribe(image, delegate((BackgroundSkin skin, bool custom) x, ImageWrapper image)
		{
			HandleBackground(image, x);
		}).AddTo(this);
	}

	private static void HandleBackground(ImageWrapper image, (BackgroundSkin skin, bool custom) background)
	{
		if (background.custom)
		{
			image.ShowFitContain(CustomBackgroundUtility.Load(), null, Color.white);
			return;
		}
		BackgroundData backgroundData = background.skin.Value();
		image.Show(backgroundData.sprite, backgroundData.material, backgroundData.color);
	}
}
