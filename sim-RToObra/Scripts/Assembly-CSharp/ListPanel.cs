using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListPanel : MonoBehaviour
{
	public enum Mode
	{
		Normal = 0,
		Controlled = 1
	}

	public class Item
	{
		public readonly string[] texts;

		public readonly object data;

		public readonly bool strike;

		public readonly bool grey;

		public Item(string text_, object data_ = null, bool strike_ = false, bool grey_ = false)
		{
			texts = new string[1] { text_ };
			data = data_;
			strike = strike_;
			grey = grey_;
		}

		public Item(string[] texts_, object data_ = null, bool strike_ = false, bool grey_ = false)
		{
			texts = texts_;
			data = data_;
			strike = strike_;
			grey = grey_;
		}
	}

	public class Spec
	{
		public string title;

		public Sprite bannerSprite;

		public string bannerOverlaySpriteName;

		public Material bannerSpriteMaterial;

		public float bannerScale = 1f;

		public List<Item> items = new List<Item>();

		public int selectedIndex = -1;

		public OnItemSelected onItemSelected;

		public TextAnchor[] alignments;

		public float outsideAlpha;

		public bool manualBackHandling;

		public object data;

		public Spec(OnItemSelected onItemSelected_ = null, string title_ = "", object data_ = null)
		{
			onItemSelected = onItemSelected_;
			title = title_;
			data = data_;
		}

		public Spec SetBanner(Sprite bannerSprite_, string bannerOverlaySpriteName_ = null, float bannerScale_ = 1f, Material bannerSpriteMaterial_ = null)
		{
			bannerSprite = bannerSprite_;
			bannerOverlaySpriteName = bannerOverlaySpriteName_;
			bannerScale = bannerScale_;
			bannerSpriteMaterial = bannerSpriteMaterial_;
			return this;
		}
	}

	public delegate void OnItemSelected(Spec spec, Item item);

	public Button prevPageButton;

	public Button nextPageButton;

	public GameObject spacerPanel;

	public GameObject pageButtonsPanel;

	public Image outsideImage;

	public LayoutElement centerLayoutElement;

	public List<ListButton> listButtons;

	public Text pageNumberText;

	public RectTransform bannerRow;

	public Image bannerImage;

	public GameObject titleHolder;

	public Text titleText;

	public GameObject itemsHolder;

	public Image bannerOverlayImage;

	public Sprite[] bannerOverlaySprites;

	public AudioKit audioKit;

	public bool playOpenCloseSounds;

	private Mode mode;

	private int curPage;

	private int numPages;

	private NavOrg navOrg;

	private Spec spec;

	private int numColumns;

	private int numItemsPerPage;

	private TextGenerator utilTextGenerator;

	private float preferredWidth;

	[NonSerialized]
	public UnityEvent whenOpen = new UnityEvent();

	[NonSerialized]
	public UnityEvent whenClose = new UnityEvent();

	public int selectedIndex { get; private set; }

	public bool isOpen
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
	}

	public int pageCount
	{
		get
		{
			return numPages;
		}
	}

	public Spec curSpec
	{
		get
		{
			return spec;
		}
	}

	public void Open(Spec spec_, Mode mode_ = Mode.Normal)
	{
		if (whenOpen != null)
		{
			whenOpen.Invoke();
		}
		if (audioKit != null && playOpenCloseSounds)
		{
			audioKit.Play("popup-open");
		}
		mode = mode_;
		spec = spec_;
		selectedIndex = spec.selectedIndex;
		if (spec.items.Count <= listButtons.Count)
		{
			numItemsPerPage = spec.items.Count;
			numPages = ((numItemsPerPage > 0) ? (1 + Mathf.Max(0, (spec.items.Count - 1) / numItemsPerPage)) : 0);
		}
		else
		{
			numItemsPerPage = listButtons.Count;
			for (int i = 0; i < listButtons.Count; i++)
			{
				numPages = 1 + Mathf.Max(0, (spec.items.Count - 1) / numItemsPerPage);
				int num = numItemsPerPage - spec.items.Count % numItemsPerPage;
				if (num == numItemsPerPage || num < numPages)
				{
					break;
				}
				numItemsPerPage--;
			}
		}
		for (int j = 0; j < numItemsPerPage; j++)
		{
			listButtons[j].isLastItemOnPage = j == numItemsPerPage - 1;
		}
		for (int k = numItemsPerPage; k < listButtons.Count; k++)
		{
			listButtons[k].gameObject.SetActive(false);
		}
		itemsHolder.gameObject.SetActive(numItemsPerPage > 0);
		int page = ((numItemsPerPage > 0) ? (Mathf.Max(0, selectedIndex) / numItemsPerPage) : 0);
		if (!string.IsNullOrEmpty(spec.title))
		{
			titleText.text = spec.title;
			titleText.gameObject.SetActive(true);
			titleHolder.gameObject.SetActive(true);
		}
		else
		{
			titleHolder.gameObject.SetActive(false);
			titleText.gameObject.SetActive(false);
		}
		if (spec.bannerSprite != null)
		{
			bannerRow.gameObject.SetActive(true);
			bannerImage.sprite = spec.bannerSprite;
			bannerImage.material = ((!(spec.bannerSpriteMaterial != null)) ? Graphic.defaultGraphicMaterial : spec.bannerSpriteMaterial);
			RectTransform rectTransform = bannerImage.transform as RectTransform;
			rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.x * spec.bannerSprite.rect.height / spec.bannerSprite.rect.width);
			bannerRow.transform.localScale = spec.bannerScale * Vector3.one;
			bannerRow.GetComponent<LayoutElement>().minHeight = Mathf.Ceil(140f * spec.bannerScale);
			if (!string.IsNullOrEmpty(spec.bannerOverlaySpriteName))
			{
				bool active = false;
				Sprite[] array = bannerOverlaySprites;
				foreach (Sprite sprite in array)
				{
					if (sprite.name == spec.bannerOverlaySpriteName)
					{
						bannerOverlayImage.sprite = sprite;
						active = true;
					}
				}
				bannerOverlayImage.gameObject.SetActive(active);
			}
			else
			{
				bannerOverlayImage.gameObject.SetActive(false);
			}
		}
		else
		{
			bannerRow.gameObject.SetActive(false);
		}
		if (titleHolder.gameObject.activeSelf)
		{
			CustomVerticalLayoutGroup component = titleHolder.GetComponent<CustomVerticalLayoutGroup>();
			RectOffset padding = component.padding;
			padding.top = ((!bannerRow.gameObject.activeSelf) ? padding.bottom : 0);
			component.padding = padding;
		}
		if (navOrg == null)
		{
			navOrg = new NavOrg();
			foreach (ListButton listButton in listButtons)
			{
				ListButton b = listButton;
				listButton.button.onClick.AddListener(delegate
				{
					OnClickItemButton(b);
				});
				navOrg.Add(listButton.button);
			}
			utilTextGenerator = new TextGenerator();
			navOrg.MakeVerticalList();
			preferredWidth = centerLayoutElement.preferredWidth;
		}
		numColumns = 1;
		foreach (Item item in spec.items)
		{
			numColumns = Mathf.Max(numColumns, item.texts.Length);
		}
		if (numColumns > 1)
		{
			TextGenerationSettings generationSettings = listButtons[0].texts[0].GetGenerationSettings(new Vector2(10000f, 100f));
			float[] array2 = new float[numColumns];
			float num2 = 5f;
			foreach (Item item2 in spec.items)
			{
				for (int num3 = 0; num3 < numColumns; num3++)
				{
					if (item2.texts.Length == numColumns)
					{
						array2[num3] = Mathf.Round(Mathf.Max(array2[num3], utilTextGenerator.GetPreferredWidth(item2.texts[num3], generationSettings)));
					}
				}
			}
			float num4 = 0f;
			for (int num5 = 0; num5 < numColumns; num5++)
			{
				num4 += array2[num5];
			}
			num4 += num2 * (float)(numColumns - 1);
			num4 = 2 * (Mathf.RoundToInt(num4) / 2);
			centerLayoutElement.preferredWidth = Mathf.Max(preferredWidth, num4);
			foreach (ListButton listButton2 in listButtons)
			{
				listButton2.SetMultiColumn(array2, num2, spec.alignments);
			}
		}
		else
		{
			foreach (ListButton listButton3 in listButtons)
			{
				listButton3.SetSingleColumn((spec.alignments == null || spec.alignments.Length <= 0) ? TextAnchor.MiddleCenter : spec.alignments[0]);
			}
			centerLayoutElement.preferredWidth = preferredWidth;
		}
		outsideImage.color = new Color(0f, 0f, 0f, spec.outsideAlpha);
		if (mode == Mode.Normal)
		{
			base.gameObject.SetActive(true);
		}
		SetPage(page, true);
	}

	public void SetCurrentSelection()
	{
		int num = curPage * numItemsPerPage;
		for (int i = 0; i < numItemsPerPage; i++)
		{
			ListButton listButton = listButtons[i];
			if (i + num < spec.items.Count && i + num == Mathf.Max(0, selectedIndex))
			{
				SelectionHelper.SetCurrent(listButton.button);
				break;
			}
		}
	}

	private void SetPage(int page, bool selectButtonAtSelectedIndex = false)
	{
		if (spec.items == null)
		{
			return;
		}
		page = Mathf.Clamp(page, 0, numPages - 1);
		int num = page * numItemsPerPage;
		for (int i = 0; i < numItemsPerPage; i++)
		{
			ListButton listButton = listButtons[i];
			if (i + num < spec.items.Count)
			{
				listButton.gameObject.SetActive(true);
				listButton.columns = spec.items[i + num].texts;
				listButton.strikeVisible = spec.items[i + num].strike;
				listButton.greyedOut = spec.items[i + num].grey;
				listButton.button.interactable = listButton.hasValue && !spec.items[i + num].grey;
				if (i + num == Mathf.Max(0, selectedIndex))
				{
					listButton.arrowsVisible = i + num == selectedIndex;
					if (selectButtonAtSelectedIndex)
					{
						SelectionHelper.SetCurrent(listButton.button);
					}
				}
				else
				{
					listButton.arrowsVisible = false;
				}
			}
			else
			{
				if (numPages == 1)
				{
					listButton.gameObject.SetActive(false);
				}
				else
				{
					listButton.gameObject.SetActive(true);
				}
				listButton.button.interactable = false;
				listButton.arrowsVisible = false;
				listButton.strikeVisible = false;
				listButton.ClearAllText();
			}
		}
		navOrg.Apply();
		spacerPanel.SetActive(numPages > 1);
		pageButtonsPanel.SetActive(numPages > 1);
		prevPageButton.gameObject.SetActive(page > 0);
		nextPageButton.gameObject.SetActive(page < numPages - 1);
		pageNumberText.text = string.Format("{0} / {1}", page + 1, numPages);
		if (SelectionHelper.GetCurrentSelectable() == null)
		{
			SelectionHelper.SetCurrent(listButtons[0].button);
		}
		curPage = page;
	}

	public void Update()
	{
		if (RInput.GetButtonRepeating(37) || RInput.GetButtonDown(21) || RInput.GetButtonDown(51))
		{
			OnClickPrevPage();
		}
		else if (RInput.GetButtonRepeating(38) || RInput.GetButtonDown(22) || RInput.GetButtonDown(52))
		{
			OnClickNextPage();
		}
		else if (numPages == 0 && (RInput.GetButtonDown(17) || RInput.GetButtonDown(44)))
		{
			OnClickOutside();
		}
	}

	public void OnClickOutside()
	{
		SendItemSelected(-1);
	}

	public void OnClickItemButton(ListButton button)
	{
		selectedIndex = curPage * numItemsPerPage + listButtons.IndexOf(button);
		SendItemSelected(selectedIndex);
	}

	public void GoDelta(int delta, bool preserveSelectedPosition = true)
	{
		if (delta < 0 && curPage > 0)
		{
			SetPage(curPage - 1);
			if (audioKit != null)
			{
				audioKit.Play("selchange");
			}
			if (!preserveSelectedPosition)
			{
				SelectionHelper.SetCurrent(listButtons[numItemsPerPage - 1].button);
			}
		}
		else if (delta > 0 && curPage < numPages - 1)
		{
			SetPage(curPage + 1);
			if (audioKit != null)
			{
				audioKit.Play("selchange");
			}
			if (!preserveSelectedPosition)
			{
				SelectionHelper.SetCurrent(listButtons[0].button);
			}
		}
	}

	public void OnClickPrevPage()
	{
		GoDelta(-1);
	}

	public void OnClickNextPage()
	{
		GoDelta(1);
	}

	private void SendItemSelected(int index)
	{
		if (mode == Mode.Normal)
		{
			base.gameObject.SetActive(false);
		}
		if (audioKit != null && playOpenCloseSounds)
		{
			audioKit.Play("popup-close");
		}
		Spec spec = this.spec;
		this.spec = null;
		if (spec.onItemSelected != null)
		{
			spec.onItemSelected(spec, (index < 0) ? null : spec.items[index]);
		}
		if (whenClose != null)
		{
			whenClose.Invoke();
		}
	}
}
