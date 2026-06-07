using System;
using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalleryEntry : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image catImage;

	[SerializeField]
	private TMP_Text catFileName;

	[SerializeField]
	private Image catFileNameImage;

	[SerializeField]
	private Color textSelectedColor = Color.white;

	[SerializeField]
	private Color textUnselectedColor = Color.black;

	private Cats _cat;

	public event Action<Cats> Selected;

	private void Awake()
	{
		button.onClick.AddListener(delegate
		{
			this.Selected?.Invoke(_cat);
		});
	}

	public void Setup(Cats cat)
	{
		_cat = cat;
		CatData catData = cat.Value();
		catImage.overrideSprite = catData.sprite;
		catFileName.SetTextFormat("{0}.jpg", catData.sprite.name);
		catFileNameImage.enabled = false;
		catFileName.color = textUnselectedColor;
	}

	public bool SetSelected(Cats cat)
	{
		bool flag = object.Equals(_cat, cat);
		catFileNameImage.enabled = flag;
		catFileName.color = (flag ? textSelectedColor : textUnselectedColor);
		return flag;
	}
}
