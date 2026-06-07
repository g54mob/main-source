using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarkdownText : MonoBehaviour, IPointerMoveHandler, IEventSystemHandler, IPointerExitHandler
{
	private enum SectionType
	{
		Text = 0,
		Image = 1,
		Custom = 2
	}

	private struct TextSection
	{
		public SectionType type;

		public string text;

		public bool isSpoiler;

		public string spoilerText;

		public TextSection(SectionType type, string text, bool isSpoiler, string spoilerText = null)
		{
			this.type = type;
			this.text = text;
			this.isSpoiler = isSpoiler;
			this.spoilerText = spoilerText;
		}
	}

	private struct HoverInfo
	{
		public CodeInputField inputField;

		public string linkID;

		public int startIndex;
	}

	[SerializeField]
	private SpoilerWarning spoilerWarning;

	[SerializeField]
	private CodeInputField textPrefab;

	[SerializeField]
	private Image imgPrefab;

	[SerializeField]
	private OutputText outputPrefab;

	[SerializeField]
	private Inventory invPrefab;

	private List<CodeInputField> textFields = new List<CodeInputField>();

	private Action<string> clickLinkCallback;

	private HoverInfo hoverInfo;

	private string ChangeColorBeforeIndex(string text, string color, int index)
	{
		int num = index;
		while (num > 0 && text[num] != '#')
		{
			num--;
		}
		return text.Remove(num, 9).Insert(num, color);
	}

	public void OnPointerMove(PointerEventData eventData)
	{
		HoverInfo hoverInfo = default(HoverInfo);
		foreach (CodeInputField textField in textFields)
		{
			int num = TMP_TextUtilities.FindIntersectingLink(textField.textComponent, Input.mousePosition, MainSim.Inst.workspace.uiCam);
			if (num >= 0)
			{
				TMP_LinkInfo tMP_LinkInfo = textField.textComponent.textInfo.linkInfo[num];
				hoverInfo.startIndex = tMP_LinkInfo.linkIdFirstCharacterIndex;
				hoverInfo.inputField = textField;
				hoverInfo.linkID = tMP_LinkInfo.GetLinkID();
				break;
			}
		}
		if (hoverInfo.startIndex != this.hoverInfo.startIndex)
		{
			ColorTheme theme = ThemeManager.Inst.Theme;
			if (this.hoverInfo.linkID != null)
			{
				this.hoverInfo.inputField.text = ChangeColorBeforeIndex(this.hoverInfo.inputField.text, theme.docs.link, this.hoverInfo.startIndex);
			}
			this.hoverInfo = hoverInfo;
			if (this.hoverInfo.linkID != null)
			{
				this.hoverInfo.inputField.text = ChangeColorBeforeIndex(this.hoverInfo.inputField.text, theme.docs.link_hover, this.hoverInfo.startIndex);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hoverInfo = default(HoverInfo);
	}

	public void Update()
	{
		if (!string.IsNullOrEmpty(hoverInfo.linkID) && Input.GetKeyDown(KeyCode.Mouse0))
		{
			clickLinkCallback(hoverInfo.linkID);
		}
	}

	public int UpdateSearch(string searchTerm, int occurenceIndex)
	{
		int count = 0;
		foreach (CodeInputField textField in textFields)
		{
			if (string.IsNullOrEmpty(searchTerm))
			{
				textField.text = CodeUtilities.RemoveMarks(textField.text);
			}
			else
			{
				textField.text = CodeUtilities.MarkSearch(CodeUtilities.RemoveMarks(textField.text), searchTerm, occurenceIndex, ref count);
			}
		}
		return count;
	}

	public void Setup(string text, Action<string> clickLinkCallback)
	{
		this.clickLinkCallback = clickLinkCallback;
		ColorTheme theme = ThemeManager.Inst.Theme;
		List<Func<TextSection, IEnumerable<TextSection>>> obj = new List<Func<TextSection, IEnumerable<TextSection>>>
		{
			InsertCustomTexts,
			(TextSection section) => Enumerable.Repeat(new TextSection(section.type, CodeUtilities.ApplyCodeTags(section.text), section.isSpoiler), 1),
			ApplyHeadings,
			ApplyLinks,
			ApplyUnlocks,
			ApplySpoilers,
			ApplyImages,
			InsertCustomSections
		};
		IEnumerable<TextSection> enumerable = Enumerable.Repeat(new TextSection(SectionType.Text, text, isSpoiler: false), 1);
		foreach (Func<TextSection, IEnumerable<TextSection>> stage in obj)
		{
			enumerable = enumerable.SelectMany((TextSection section) => (section.type != SectionType.Text) ? Enumerable.Repeat(section, 1) : stage(section));
		}
		foreach (TextSection item in enumerable)
		{
			if (string.IsNullOrEmpty(item.text))
			{
				continue;
			}
			switch (item.type)
			{
			case SectionType.Text:
			{
				CodeInputField codeInputField = UnityEngine.Object.Instantiate(textPrefab, base.transform);
				theme.docs.text.ApplyTo(codeInputField);
				codeInputField.text = item.text;
				if (item.isSpoiler)
				{
					UnityEngine.Object.Instantiate(spoilerWarning, codeInputField.transform).SetText(item.spoilerText);
				}
				textFields.Add(codeInputField);
				break;
			}
			case SectionType.Image:
			{
				Image image = UnityEngine.Object.Instantiate(imgPrefab, base.transform);
				int num = item.text.Length;
				while (char.IsDigit(item.text[num - 1]))
				{
					num--;
				}
				string text2 = item.text.Substring(0, num);
				if (int.TryParse(item.text.Substring(num), out var result))
				{
					image.GetComponent<LayoutElement>().preferredHeight = result;
					image.sprite = ResourceManager.GetSprite(text2);
				}
				break;
			}
			case SectionType.Custom:
				if (item.text == "output")
				{
					OutputText outputText = UnityEngine.Object.Instantiate(outputPrefab, base.transform);
					theme.docs.text.ApplyTo(outputText.Text);
				}
				else
				{
					if (!item.text.StartsWith("itemblock"))
					{
						break;
					}
					string[] array = item.text.Split(' ');
					Func<ItemBlock> up;
					if (array[1] == "stats_sum")
					{
						up = delegate
						{
							if (!MainSim.Inst.MightBeSimulating())
							{
								Achievements.UpdateSum(MainSim.Inst.GetCurrentTime());
							}
							return Achievements.GetSum();
						};
					}
					else if (array[1] == "stats_best")
					{
						up = Achievements.GetBest;
					}
					else if (!(array[1] == "cost"))
					{
						up = ((!(array[1] == "tooltip")) ? ((Func<ItemBlock>)(() => (ItemBlock)null)) : ((Func<ItemBlock>)(() => MainSim.Inst.workspace.tooltip.Info?.itemBlock)));
					}
					else if (array[2] == "object")
					{
						FarmObjectSO fo = ResourceManager.GetFarmObject(array[3]);
						ItemBlock cost = fo.cost;
						int upgradeCount = Mathf.Max(0, MainSim.Inst.NumUnlocked(fo.yieldUpgradeName) - 1);
						up = () => cost * ((!(fo.yieldUpgradeName != "")) ? 1 : Mathf.Max(1, 1 << upgradeCount));
					}
					else if (array[2] == "unlock")
					{
						UnlockSO unlockSO = ResourceManager.GetUnlock(array[3]);
						up = ((unlockSO != null) ? ((Func<ItemBlock>)(() => MainSim.Inst.GetUnlockCost(unlockSO))) : ((Func<ItemBlock>)(() => (ItemBlock)null)));
					}
					else
					{
						up = () => (ItemBlock)null;
					}
					UnityEngine.Object.Instantiate(invPrefab, base.transform).SetUp(up);
				}
				break;
			}
		}
	}

	public void UpdateText(string text)
	{
		for (int num = base.transform.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(base.transform.GetChild(num).gameObject);
		}
		textFields.Clear();
		Setup(text, clickLinkCallback);
	}

	private IEnumerable<TextSection> ApplyHeadings(TextSection section)
	{
		Regex regex = new Regex("(?<=^|\\r\\n|\\n)#+ .*");
		StringBuilder stringBuilder = new StringBuilder(section.text);
		foreach (Match item in regex.Matches(section.text).Reverse())
		{
			Capture capture = item.Captures.First();
			stringBuilder.Remove(capture.Index, capture.Length);
			int num = capture.Value.IndexOf('#');
			int num2 = 40;
			while (capture.Value[num + 1] == '#')
			{
				num++;
				num2 -= 8;
			}
			string arg = capture.Value.Substring(num + 2);
			string value = $"<line-height=50%><size={num2}px>{arg}</size>\n</line-height>";
			stringBuilder.Insert(capture.Index, value);
		}
		section.text = stringBuilder.ToString();
		return Enumerable.Repeat(section, 1);
	}

	private IEnumerable<TextSection> ApplyLinks(TextSection section)
	{
		ColorTheme theme = ThemeManager.Inst.Theme;
		Regex regex = new Regex("(?<!!)\\[.*?\\]\\(.*?\\)");
		StringBuilder stringBuilder = new StringBuilder(section.text);
		foreach (Match item in regex.Matches(section.text).Reverse())
		{
			Capture capture = item.Captures.First();
			int num = capture.Value.IndexOf(']');
			string arg = capture.Value.Substring(1, num - 1);
			string arg2 = capture.Value.Substring(num + 2, capture.Value.Length - (num + 2) - 1);
			stringBuilder.Remove(capture.Index, capture.Length);
			string value = $"<font=\"FiraCode-Regular SDF\"><color={theme.docs.link}><u><link=\"{arg2}\">{arg}</link></u></color></font>";
			stringBuilder.Insert(capture.Index, value);
		}
		section.text = stringBuilder.ToString();
		return Enumerable.Repeat(section, 1);
	}

	private IEnumerable<TextSection> ApplyUnlocks(TextSection section)
	{
		IEnumerable<string> enumerable = from m in new Regex("<unlock=.*?>").Matches(section.text)
			select m.Captures.First().Value.Substring(8, m.Captures.First().Value.Length - 9);
		string[] array = new Regex("</?unlock=?.*?>").Split(section.text);
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		IEnumerator<string> enumerator = enumerable.GetEnumerator();
		string[] array2 = array;
		foreach (string value in array2)
		{
			if (flag)
			{
				enumerator.MoveNext();
				if (MainSim.Inst.IsUnlocked(enumerator.Current))
				{
					stringBuilder.Append(value);
				}
			}
			else
			{
				stringBuilder.Append(value);
			}
			flag = !flag;
		}
		section.text = stringBuilder.ToString();
		return Enumerable.Repeat(section, 1);
	}

	private IEnumerable<TextSection> ApplySpoilers(TextSection section)
	{
		IEnumerable<string> enumerable = from m in new Regex("<spoiler=.*?>").Matches(section.text)
			select m.Captures.First().Value.Substring(9, m.Captures.First().Value.Length - 10);
		string[] array = new Regex("</?spoiler=?.*?>").Split(section.text);
		List<TextSection> list = new List<TextSection>();
		bool flag = false;
		IEnumerator<string> enumerator = enumerable.GetEnumerator();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (flag)
			{
				enumerator.MoveNext();
				list.Add(new TextSection(SectionType.Text, text, isSpoiler: true, enumerator.Current));
			}
			else
			{
				list.Add(new TextSection(SectionType.Text, text, isSpoiler: false));
			}
			flag = !flag;
		}
		return list;
	}

	private IEnumerable<TextSection> ApplyImages(TextSection section)
	{
		Regex regex = new Regex("!\\[.*?\\]\\(.*?\\)");
		List<TextSection> list = (from s in regex.Split(section.text)
			select new TextSection(SectionType.Text, s, section.isSpoiler, section.spoilerText)).ToList();
		int num = 1;
		foreach (Match item2 in regex.Matches(section.text))
		{
			Capture capture = item2.Captures.First();
			int num2 = capture.Value.IndexOf(']');
			string text = capture.Value.Substring(num2 + 2, capture.Value.Length - (num2 + 2) - 1);
			TextSection item = new TextSection(SectionType.Image, text, section.isSpoiler, section.spoilerText);
			list.Insert(num, item);
			num += 2;
		}
		return list;
	}

	private IEnumerable<TextSection> InsertCustomTexts(TextSection section)
	{
		Regex regex = new Regex("{{.*}}");
		StringBuilder stringBuilder = new StringBuilder(section.text);
		foreach (Match item in regex.Matches(section.text).Reverse())
		{
			Capture capture = item.Captures.First();
			string text = capture.Value.Substring(2, capture.Value.Length - 4);
			stringBuilder.Remove(capture.Index, capture.Length);
			string value = capture.Value;
			switch (text)
			{
			case "unlocksTOC":
				value = GenerateUnlockTOC();
				break;
			case "builtinsTOC":
				value = GenerateBuiltinsTOC();
				break;
			case "itemsTOC":
				value = GenerateItemsTOC();
				break;
			case "entitiesTOC":
				value = GenerateEntitiesTOC();
				break;
			case "groundsTOC":
				value = GenerateGroundsTOC();
				break;
			default:
				if (text.StartsWith("@"))
				{
					value = Localizer.Localize(text.Substring(1));
				}
				break;
			}
			stringBuilder.Insert(capture.Index, value);
		}
		section.text = stringBuilder.ToString();
		return Enumerable.Repeat(section, 1);
	}

	private IEnumerable<TextSection> InsertCustomSections(TextSection section)
	{
		Regex regex = new Regex("{{.*}}");
		List<TextSection> list = (from s in regex.Split(section.text)
			select new TextSection(SectionType.Text, s, section.isSpoiler, section.spoilerText)).ToList();
		int num = 1;
		foreach (Match item2 in regex.Matches(section.text))
		{
			Capture capture = item2.Captures.First();
			string text = capture.Value.Substring(2, capture.Value.Length - 4);
			TextSection item = new TextSection(SectionType.Custom, text, section.isSpoiler, section.spoilerText);
			list.Insert(num, item);
			num += 2;
		}
		return list;
	}

	private string GenerateUnlockTOC()
	{
		IOrderedEnumerable<(string, string, string)> orderedEnumerable = from s in (from unlock in ResourceManager.GetAllUnlocks()
				where unlock.enabled
				select unlock).Select(delegate(UnlockSO unlock)
			{
				string text = unlock.docs;
				if (string.IsNullOrEmpty(text))
				{
					text = "unlocks/" + unlock.unlockName;
				}
				return (unlock.name, unlock.name, docLink: text);
			}).Append(("for", "expand_2", "docs/unlocks/expand_2.md"))
			orderby s.Item2
			select s;
		StringBuilder stringBuilder = new StringBuilder();
		foreach (var item in orderedEnumerable)
		{
			string value = $"<unlock={item.Item1}>[{Localizer.Localize(item.Item2)}]({item.Item3})      </unlock>";
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	private string GenerateBuiltinsTOC()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in BuiltinFunctions.Functions.Keys.OrderBy((string s) => s))
		{
			string value = string.Format("<unlock={0}>[{0}](functions/{0})      </unlock>", item);
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	private string GenerateItemsTOC()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ItemSO item in from i in ResourceManager.GetAllItems()
			where i.enabled
			select i)
		{
			string value = $"<unlock={item.itemName}>[{CodeUtilities.ToUpperSnake(item.itemName)}](items/{item.itemName})      </unlock>";
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	private string GenerateEntitiesTOC()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (FarmObjectSO item in from f in ResourceManager.GetAllFarmObjects()
			where !f.isGround
			select f)
		{
			string value = $"<unlock={item.objectName}>[{CodeUtilities.ToUpperSnake(item.objectName)}](objects/{item.objectName})      </unlock>";
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	private string GenerateGroundsTOC()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (FarmObjectSO item in from f in ResourceManager.GetAllFarmObjects()
			where f.isGround
			select f)
		{
			string value = $"<unlock={item.objectName}>[{CodeUtilities.ToUpperSnake(item.objectName)}](objects/{item.objectName})      </unlock>";
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}
}
