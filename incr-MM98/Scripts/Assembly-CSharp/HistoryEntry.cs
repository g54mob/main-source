using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryEntry : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image boxArtImage;

	[SerializeField]
	private TMP_Text boxArtText;

	[SerializeField]
	private Image gameNameImage;

	[SerializeField]
	private TMP_Text gameNameText;

	[SerializeField]
	private Color textSelectedColor = Color.white;

	[SerializeField]
	private Color textUnselectedColor = Color.black;

	private HistoryEntryData _data;

	private BoxArtTexture _texture;

	public event Action<HistoryEntryData> Selected;

	private void Awake()
	{
		button.onClick.AddListener(delegate
		{
			this.Selected?.Invoke(_data);
		});
	}

	private void OnDestroy()
	{
		_texture.Dispose();
	}

	public void Setup(HistoryEntryData data)
	{
		_data = data;
		_texture = data.BoxArt.Texture(data.Release);
		boxArtImage.overrideSprite = _texture.Sprite;
		boxArtText.SetText(data.Title);
		gameNameText.SetText(data.Title);
		gameNameImage.enabled = false;
		gameNameText.color = textUnselectedColor;
	}

	public bool SetSelected(HistoryEntryData data)
	{
		bool flag = object.Equals(_data, data);
		gameNameImage.enabled = flag;
		gameNameText.color = (flag ? textSelectedColor : textUnselectedColor);
		return flag;
	}
}
