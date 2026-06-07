using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Newspaper : MonoBehaviour
{
	public enum Section
	{
		All = 0,
		Review = 1,
		Industry = 2,
		Business = 3
	}

	[Serializable]
	public struct Story
	{
		public string Title;

		public string Content;

		public string Image;

		public Section Section;

		public float Priority;

		public Story(string title, string content, Section section, string image, float priority)
		{
			Title = title;
			Content = content;
			Section = section;
			Image = image;
			Priority = priority;
		}
	}

	public RectTransform rect;

	private bool Show;

	public GameObject[] Columns;

	public GameObject StoryPrefab;

	public ScrollRect ScrollArea;

	public GUICombobox SectionSelector;

	public ButtonCounter Counter;

	private int _newsCount;

	private int _newNewsCount;

	private int ColumnCounter;

	[NonSerialized]
	public Dictionary<SDateTime, List<Story>> Stories = new Dictionary<SDateTime, List<Story>>();

	private List<GUIStory> CurrentContent = new List<GUIStory>();

	public static Newspaper Instance;

	private bool showReminder;

	[NonSerialized]
	public SDateTime CurrentDate;

	[NonSerialized]
	private int PrefabCounter;

	public DatePicker DatePick;

	public string[] GetSections()
	{
		return (from x in Enum.GetValues(typeof(Section)).OfType<Section>()
			orderby (int)x
			select x.ToString() + " section").ToArray();
	}

	private void Start()
	{
		Instance = this;
		InitializeSections();
		SectionSelector.UpdateContent(GetSections());
		SectionSelector.Selected = 0;
		rect.sizeDelta = new Vector2(512f, -64f);
	}

	public void InitializeSections()
	{
		if (Stories == null)
		{
			Stories = new Dictionary<SDateTime, List<Story>>();
		}
	}

	public void AddReminder(bool showNow = false)
	{
		if (showNow)
		{
			if (!Show)
			{
				_newsCount++;
				Counter.SetNumber(_newsCount);
			}
		}
		else
		{
			_newNewsCount++;
			showReminder = true;
		}
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void UpdateAllStories()
	{
		UpdateStories();
	}

	public static void UpdateStories()
	{
		if (Instance == null)
		{
			return;
		}
		Instance.PrefabCounter = 0;
		Instance.ColumnCounter = 0;
		List<Story> value;
		if (Instance.Stories.TryGetValue(Instance.CurrentDate, out value))
		{
			Section selected = (Section)Instance.SectionSelector.Selected;
			foreach (Story item in value)
			{
				if (selected == Section.All || item.Section == selected)
				{
					Instance.AddStory(item);
				}
			}
		}
		for (int i = Instance.PrefabCounter; i < Instance.CurrentContent.Count; i++)
		{
			Instance.CurrentContent[i].gameObject.SetActive(false);
		}
		Instance.ScrollArea.verticalNormalizedPosition = 1f;
	}

	public static void StoryRollover(SDateTime time, bool clear = true, bool presim = false)
	{
		if (Instance == null || presim)
		{
			return;
		}
		if (Instance.showReminder)
		{
			if (!Instance.Show)
			{
				Instance._newsCount += Instance._newNewsCount;
				Instance._newNewsCount = 0;
				Instance.Counter.SetNumber(Instance._newsCount);
			}
			Instance.showReminder = false;
		}
		foreach (SDateTime item in Instance.Stories.Keys.ToList())
		{
			if (SDateTime.GetYears(item, time) >= 5f)
			{
				Instance.Stories.Remove(item);
			}
		}
	}

	public void AddNewStory(SDateTime date, Story story, bool showReminder = false)
	{
		if (showReminder)
		{
			Instance.AddReminder(true);
		}
		Stories.Append(date.Simplify(), story);
	}

	public static void GenerateProductReview(SoftwareProduct product)
	{
		if (!(Instance == null))
		{
			Instance.AddReminder();
			string input = (product.DevCompany.IsLocalPlayer ? "SoftwareReviewHeader" : "MultiplayerSoftwareReviewHeader");
			Instance.AddNewStory(SDateTime.Now() + new SDateTime(1, 0, 0), new Story(input.Loc(product.Name, product.DevCompany.Name), ArticleGenerator.GenerateSoftwareReview(product), Section.Review, null, float.PositiveInfinity));
		}
	}

	public static void GenerateProductReview(AddOnProduct product)
	{
		if (!(Instance == null))
		{
			Instance.AddReminder();
			string input = (product.Owner.IsLocalPlayer ? "SoftwareReviewHeader" : "MultiplayerSoftwareReviewHeader");
			Instance.AddNewStory(SDateTime.Now() + new SDateTime(1, 0, 0), new Story(input.Loc(product.Name, product.Owner.Name), ArticleGenerator.GenerateSoftwareReview(product), Section.Review, null, float.PositiveInfinity));
		}
	}

	public static void GenerateProductReview(string productName, FinalReviewGenerator.Review[] reviews)
	{
		if (!(Instance == null))
		{
			Instance.AddNewStory(SDateTime.Now(), new Story("SoftwareReviewHeader".Loc(productName), FinalReviewGenerator.ReviewToNews(reviews), Section.Review, null, float.PositiveInfinity));
		}
	}

	public static void GeneratePressbuildReview(ArticleGenerator.PressBuildReviewData d)
	{
		if (!(Instance == null))
		{
			Instance.AddReminder();
			Instance.AddNewStory(SDateTime.Now(), new Story("PressBuildReviewHeader".Loc(d.Product), ArticleGenerator.GeneratePressBuildReview(d), Section.Review, null, float.PositiveInfinity));
		}
	}

	public static void GeneratePressReleaseReview(ArticleGenerator.PressReleaseData d)
	{
		if (!(Instance == null))
		{
			Instance.AddReminder(true);
			Instance.AddNewStory(SDateTime.Now(), new Story("PressReleaseReviewHeader".Loc(d.Company, d.Product), ArticleGenerator.GeneratePressReleaseReview(d), Section.Review, null, float.PositiveInfinity));
		}
	}

	public static void GenerateStockBuyout(Company target, IList<Company> sources, double amount)
	{
		if (!(Instance == null))
		{
			double num = (double)target.Fans * Math.Max(1.0, amount);
			if (sources.Contains(GameSettings.Instance.MyCompany))
			{
				Instance.AddReminder();
				num = double.PositiveInfinity;
			}
			string[] values = sources.SelectInPlace((Company x) => x.Name);
			string title = Utilities.RobustStringFormat(GameData.SentenceGen["TakeOver"].GenerateSentence("StartTitle", (float)amount, target.BusinessReputation, sources.Count, target.Products.Count), false, false, target.Name, MakeList(values), target.Products.Count.ToString(), target.Money.Currency());
			string content = Utilities.RobustStringFormat(GameData.SentenceGen["TakeOver"].GenerateSentence("Start", (float)amount, target.BusinessReputation, sources.Count, target.Products.Count), false, false, target.Name, MakeList(values), target.Products.Count.ToString(), target.Money.Currency());
			Instance.AddNewStory(SDateTime.Now() + new SDateTime(0, 23, 0, 0, 0), new Story(title, content, Section.Business, null, (float)num));
		}
	}

	public static void GenerateGrowth(Company company, double amount)
	{
		if (!(Instance == null))
		{
			double num = amount / company.Money * (double)company.Fans;
			string title = "GrowthArticleTitle".Loc(company.Name);
			string content = "GrowthArticleBody".Loc(company.Name, amount.Currency(), company.GetMoneyWithInsurance(true, true).Currency(), company.Products.Count.ToString());
			Instance.AddNewStory(SDateTime.Now(), new Story(title, content, Section.Business, null, (float)num));
		}
	}

	public static string MakeList(IList<string> values, bool and = true, bool things = false)
	{
		if (values.Count == 0)
		{
			if (!things)
			{
				return "Nobody".Loc();
			}
			return "Nothing".Loc();
		}
		if (values.Count == 1)
		{
			return values[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < values.Count - 1; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(values[i]);
		}
		stringBuilder.Append((and ? "AndSeperator" : "OrSeperator").Loc());
		stringBuilder.Append(values[values.Count - 1]);
		return stringBuilder.ToString();
	}

	public static string MakeList(ICollection<string> values, bool things = false)
	{
		if (values.Count == 0)
		{
			if (!things)
			{
				return "Nobody".Loc();
			}
			return "Nothing".Loc();
		}
		if (values.Count == 1)
		{
			return values.First();
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		foreach (string value in values)
		{
			if (num == values.Count - 1)
			{
				stringBuilder.Append("AndSeperator".Loc());
			}
			else if (num > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(value);
			num++;
		}
		return stringBuilder.ToString();
	}

	private void AddStory(Story story)
	{
		GUIStory gUIStory;
		if (PrefabCounter < CurrentContent.Count)
		{
			gUIStory = CurrentContent[PrefabCounter];
			gUIStory.gameObject.SetActive(true);
		}
		else
		{
			gUIStory = UnityEngine.Object.Instantiate(StoryPrefab).GetComponent<GUIStory>();
			CurrentContent.Add(gUIStory);
		}
		gUIStory.Title.text = story.Title;
		gUIStory.Content.text = story.Content;
		gUIStory.transform.SetParent(Columns[ColumnCounter].transform, false);
		ColumnCounter = (ColumnCounter + 1) % Columns.Length;
		PrefabCounter++;
	}

	public void ShowNow(bool show)
	{
		if (Show != show && !DOTween.IsTweening(rect))
		{
			if (show)
			{
				_newsCount = 0;
				Counter.SetNumber(0);
				SetDate(SDateTime.Now(), true, false);
				ScrollArea.verticalNormalizedPosition = 1f;
				rect.DOSizeDelta(new Vector2(512f, 512f), 0.2f, true);
				UISoundFX.PlaySFX("NewspaperOpen");
			}
			else
			{
				rect.DOSizeDelta(new Vector2(512f, -64f), 0.2f, true);
				UISoundFX.PlaySFX("NewspaperClose");
			}
			Show = show;
		}
	}

	public void SetDate(SDateTime date, bool force, bool back)
	{
		SDateTime sd = SDateTime.Now().Simplify();
		date = date.Simplify();
		if (!force && (!(SDateTime.Now() > date) || date.Year <= 0))
		{
			return;
		}
		if (!force)
		{
			while (!date.Equals(sd, true) && !ValidDate(date) && date.Year >= 0)
			{
				if (back)
				{
					date += new SDateTime(-1, 0, 0);
				}
				else
				{
					date += new SDateTime(1, 0, 0);
				}
			}
			if (date.Year < 0)
			{
				return;
			}
		}
		CurrentDate = date;
		DatePick.CurrentDate = date;
		UpdateStories();
	}

	private bool ValidDate(SDateTime date)
	{
		Section selected = (Section)SectionSelector.Selected;
		if (selected == Section.All)
		{
			return Stories.ContainsKey(date);
		}
		List<Story> value = null;
		if (Stories.TryGetValue(date, out value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].Section == selected)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public void ChangeDateDirect(SDateTime date)
	{
		SetDate(date, true, false);
	}

	public void ChangeDate(int change)
	{
		SetDate(CurrentDate + new SDateTime(change, 0, 0), false, change < 0);
	}

	private void Update()
	{
		if (Show && !SectionSelector.IsShown && Input.GetMouseButton(0) && !RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition, UICamSize.GetUICam()))
		{
			ShowNow(false);
		}
	}
}
