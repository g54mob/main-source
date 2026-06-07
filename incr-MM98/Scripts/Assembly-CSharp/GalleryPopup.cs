using System.Collections.Generic;
using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalleryPopup : Popup
{
	[SerializeField]
	private Transform entryParent;

	[SerializeField]
	private GalleryEntry entryPrefab;

	[SerializeField]
	private TMP_Text titleText;

	[SerializeField]
	private TMP_Text ownerText;

	[SerializeField]
	private TMP_Text resolutionText;

	[SerializeField]
	private TMP_Text sizeText;

	[SerializeField]
	private GameObject fullPopup;

	[SerializeField]
	private Button fullCloseButton;

	[SerializeField]
	private Image fullImage;

	[SerializeField]
	private TMP_Text fullTitle;

	[SerializeField]
	private TMP_Text fullDate;

	private readonly List<GalleryEntry> _entries = new List<GalleryEntry>();

	private Cats? _selected;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		fullCloseButton.onClick.AddListener(delegate
		{
			fullPopup.SetActive(value: false);
		});
		foreach (Cats value in EnumUtility.GetValues<Cats>())
		{
			GalleryEntry galleryEntry = Object.Instantiate(entryPrefab, entryParent);
			galleryEntry.Setup(value);
			galleryEntry.Selected += OnCatSelected;
			_entries.Add(galleryEntry);
		}
		OnCatSelected(Cats.Karma1);
	}

	public override void ShowContent()
	{
		ShuffleCats();
		base.ShowContent();
	}

	private void ShuffleCats()
	{
		for (int num = _entries.Count - 1; num > 0; num--)
		{
			int num2 = BiteRandom.NextInt(0, num + 1);
			List<GalleryEntry> entries = _entries;
			int index = num;
			List<GalleryEntry> entries2 = _entries;
			int index2 = num2;
			GalleryEntry galleryEntry = _entries[num2];
			GalleryEntry galleryEntry2 = _entries[num];
			GalleryEntry galleryEntry3 = (entries[index] = galleryEntry);
			galleryEntry3 = (entries2[index2] = galleryEntry2);
		}
		for (int i = 0; i < _entries.Count; i++)
		{
			_entries[i].transform.SetSiblingIndex(i);
		}
	}

	private void OnCatSelected(Cats cat)
	{
		if (_selected == cat)
		{
			ShowFull(cat);
		}
		else
		{
			SetSelected(cat);
		}
	}

	private void ShowFull(Cats cat)
	{
		CatData catData = cat.Value();
		fullImage.overrideSprite = catData.sprite;
		fullTitle.SetTextFormat("{0}.jpg", catData.sprite.name);
		fullDate.text = catData.date;
		fullPopup.SetActive(value: true);
	}

	private void SetSelected(Cats cat)
	{
		_selected = cat;
		foreach (GalleryEntry entry in _entries)
		{
			entry.SetSelected(cat);
		}
		CatData catData = cat.Value();
		titleText.SetTextFormat("{0}.jpg", catData.sprite.name);
		ownerText.SetText(catData.owner);
		resolutionText.SetTextFormat("{0}x{1}px", catData.sprite.rect.width, catData.sprite.rect.height);
		sizeText.SetTextFormat("{0}KiB", catData.filesize);
	}
}
