using UnityEngine;
using UnityEngine.UI;

public class TabMenuImageButton : TabMenuButton
{
	[SerializeField]
	private Image _image;

	public Sprite SelectedSprite;

	public Sprite DefaultSprite;

	protected override void OnTabSelected()
	{
	}

	protected override void OnEndTabSelected()
	{
	}
}
