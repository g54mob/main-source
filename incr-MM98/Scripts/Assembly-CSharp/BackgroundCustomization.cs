using UnityEngine;
using UnityEngine.UI;

public class BackgroundCustomization : MonoBehaviour, ICustomization
{
	[SerializeField]
	private ImageWrapper previewImage;

	[SerializeField]
	private Transform entryParent;

	[SerializeField]
	private BackgroundEntry entryPrefab;

	[SerializeField]
	private Button customButton;

	private BackgroundSkin _selectedSkin;

	private bool _customSkin;

	public void Initialize()
	{
		customButton.onClick.AddListener(delegate
		{
			CustomBackgroundUtility.Select(OnCustomSelected);
		});
		foreach (BackgroundSkin value in EnumUtility.GetValues<BackgroundSkin>())
		{
			BackgroundEntry backgroundEntry = Object.Instantiate(entryPrefab, entryParent);
			backgroundEntry.Setup(value);
			backgroundEntry.Selected += OnSkinSelected;
		}
	}

	public void Show()
	{
		_selectedSkin = Database.State.Customization.Background.Value;
		_customSkin = Database.State.Customization.CustomBackground.Value;
		if (_customSkin)
		{
			OnCustomSelected(CustomBackgroundUtility.Load());
		}
		else
		{
			OnSkinSelected(_selectedSkin);
		}
		base.gameObject.SetActive(value: true);
	}

	public void Apply()
	{
		Database.State.Customization.Background.Value = _selectedSkin;
		Database.State.Customization.CustomBackground.OnNext(_customSkin);
		if (!_customSkin)
		{
			CustomBackgroundUtility.Delete();
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnSkinSelected(BackgroundSkin skin)
	{
		_selectedSkin = skin;
		_customSkin = false;
		BackgroundData backgroundData = skin.Value();
		previewImage.Show(backgroundData.sprite, backgroundData.material, backgroundData.color);
	}

	private void OnCustomSelected(byte[] raw)
	{
		_customSkin = true;
		previewImage.Show(raw, null, Color.white);
	}
}
