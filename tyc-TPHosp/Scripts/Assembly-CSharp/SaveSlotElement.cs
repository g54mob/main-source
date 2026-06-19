using System.Globalization;
using TH20;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveSlotElement : MonoBehaviour
{
	[SerializeField]
	private Image _screenshotImage;

	[SerializeField]
	private TextMeshProUGUI _foundationNameText;

	[SerializeField]
	private TextMeshProUGUI _timeAndDateText;

	[SerializeField]
	private TextMeshProUGUI _totalStarsText;

	[SerializeField]
	private TextMeshProUGUI _totalSilverText;

	[SerializeField]
	private TextMeshProUGUI _totalFoundationValueText;

	[SerializeField]
	private Transform _existingSlotParent;

	[SerializeField]
	private Transform _emptySlotParent;

	[SerializeField]
	private DynamicButton _selectButton;

	[SerializeField]
	private DynamicButton _deleteButton;

	[SerializeField]
	private DynamicButton _copyButton;

	[SerializeField]
	private DynamicButton _newButton;

	private Texture2D _screenshotTexture;

	private void Awake()
	{
		_screenshotTexture = new Texture2D(1, 1, TextureFormat.DXT1, mipChain: false);
	}

	public void SetupWithSave(MetagameSaveHeader metagameSaveHeader, UnityAction selectButtonPressedFunction, UnityAction deleteButtonPressedFunction)
	{
		if (metagameSaveHeader.ThumbnailPNG != null)
		{
			_screenshotTexture.LoadImage(metagameSaveHeader.ThumbnailPNG);
			_screenshotImage.overrideSprite = Sprite.Create(_screenshotTexture, new Rect(0f, 0f, _screenshotTexture.width, _screenshotTexture.height), new Vector2(0f, 0f));
			_screenshotImage.color = Color.white;
		}
		else
		{
			_screenshotImage.overrideSprite = null;
		}
		_foundationNameText.text = metagameSaveHeader.OrganisationName;
		_timeAndDateText.text = metagameSaveHeader.Date.ToString(CultureInfo.CurrentCulture);
		_totalStarsText.text = StringUtils.FormatNumber(metagameSaveHeader.TotalStars);
		_totalSilverText.text = StringUtils.FormatSilverCurrency(metagameSaveHeader.TotalSilver);
		_totalFoundationValueText.text = StringUtils.FormatCurrency(metagameSaveHeader.TotalFoundationValue);
		_existingSlotParent.gameObject.SetActive(value: true);
		_emptySlotParent.gameObject.SetActive(value: false);
		_selectButton.onPrimaryDown.AddListener(selectButtonPressedFunction);
		_deleteButton.onPrimaryDown.AddListener(deleteButtonPressedFunction);
	}

	public void SetupEmpty(UnityAction newButtonPressedFunction)
	{
		_existingSlotParent.gameObject.SetActive(value: false);
		_emptySlotParent.gameObject.SetActive(value: true);
		_newButton.onPrimaryDown.AddListener(newButtonPressedFunction);
	}

	public void Clear()
	{
		_selectButton.onPrimaryDown.RemoveAllListeners();
		_deleteButton.onPrimaryDown.RemoveAllListeners();
		_copyButton.onPrimaryDown.RemoveAllListeners();
		_newButton.onPrimaryDown.RemoveAllListeners();
	}
}
