using UnityEngine;
using UnityEngine.UI;

public class CursorCustomization : MonoBehaviour, ICustomization
{
	[SerializeField]
	private Image previewImage;

	[SerializeField]
	private Transform entryParent;

	[SerializeField]
	private CursorEntry entryPrefab;

	[SerializeField]
	private Toggle trailingCursorToggle;

	private CursorSkin _selectedSkin;

	private bool _trailingCursor;

	public void Initialize()
	{
		foreach (CursorSkin value in EnumUtility.GetValues<CursorSkin>())
		{
			CursorEntry cursorEntry = Object.Instantiate(entryPrefab, entryParent);
			cursorEntry.Setup(value);
			cursorEntry.Selected += OnSkinSelected;
		}
		trailingCursorToggle.onValueChanged.AddListener(delegate(bool x)
		{
			_trailingCursor = x;
		});
	}

	public void Show()
	{
		_selectedSkin = Database.State.Customization.Cursor.Value;
		_trailingCursor = Database.State.Customization.TrailingCursor.Value;
		trailingCursorToggle.SetIsOnWithoutNotify(_trailingCursor);
		OnSkinSelected(_selectedSkin);
		base.gameObject.SetActive(value: true);
	}

	public void Apply()
	{
		Database.State.Customization.Cursor.Value = _selectedSkin;
		Database.State.Customization.TrailingCursor.Value = _trailingCursor;
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnSkinSelected(CursorSkin skin)
	{
		_selectedSkin = skin;
		Texture2D texture = skin.Value().texture;
		previewImage.overrideSprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
	}
}
