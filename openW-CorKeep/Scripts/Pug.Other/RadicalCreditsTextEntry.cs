using UnityEngine;

public class RadicalCreditsTextEntry : PoolableSimple
{
	public CreditsData creditsData;

	public PugText titleText;

	public PugText namesText;

	public Color headerColor;

	public Color titleColor;

	private Vector3 topOffset;

	private Vector3 botOffset;

	public const float PADDING_TO_REMOVE_ENTRY = -5f;

	private RadicalCreditsMenu creditsMenu;

	private const string creditsNames = "CreditsNames/";

	private const float SPACING_BEFORE_HEADER = 1.875f;

	private const float SPACING_BEFORE_HEADER_WHEN_SKIP_TITLE = -0.5f;

	private const float SPACING_BETWEEN_TITLE_AND_NAME = 0.375f;

	private Vector3 centerWorldPosition => new Vector3(0f, base.transform.position.y, 0f);

	private Vector3 centerLocalPosition => new Vector3(0f, base.transform.localPosition.y, 0f);

	public Vector3 topWorldPosition => centerWorldPosition + topOffset;

	public Vector3 botWorldPosition => centerWorldPosition + botOffset;

	public Vector3 topLocalPosition => centerLocalPosition + topOffset;

	public Vector3 botLocalPosition => centerLocalPosition + botOffset;

	public int entryIndex { get; private set; }

	private RadicalCreditsTextEntry entryBelow
	{
		get
		{
			if (!creditsMenu.entries.ContainsKey(entryIndex + 1))
			{
				return null;
			}
			return creditsMenu.entries[entryIndex + 1];
		}
	}

	private RadicalCreditsTextEntry entryAbove
	{
		get
		{
			if (!creditsMenu.entries.ContainsKey(entryIndex - 1))
			{
				return null;
			}
			return creditsMenu.entries[entryIndex - 1];
		}
	}

	public static RadicalCreditsTextEntry SpawnTextEntry(bool spawnBeneathPosition, Vector3 localPosition, int entryIndex, RadicalCreditsMenu radicalCreditsMenu, float padding = 0.5f)
	{
		RadicalCreditsTextEntry freeComponent = Manager.memory.GetFreeComponent<RadicalCreditsTextEntry>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.transform.parent = radicalCreditsMenu.container;
			freeComponent.creditsMenu = radicalCreditsMenu;
			freeComponent.entryIndex = entryIndex;
			freeComponent.RenderText();
			CreditsData.CreditsEntry creditsEntry = freeComponent.creditsData.creditsElements[entryIndex];
			if (spawnBeneathPosition)
			{
				padding = (creditsEntry.skipTitle ? (padding + -0.5f) : (padding + ((creditsEntry.layout == CreditLayout.Centered) ? 1.875f : 0f)));
			}
			else if (entryIndex + 1 < freeComponent.creditsData.creditsElements.Count)
			{
				padding = (freeComponent.creditsData.creditsElements[entryIndex + 1].skipTitle ? (padding + -0.5f) : (padding + ((freeComponent.creditsData.creditsElements[entryIndex + 1].layout == CreditLayout.Centered) ? 1.875f : 0f)));
			}
			if (spawnBeneathPosition && entryIndex == 1)
			{
				padding += 0.625f;
			}
			else if (!spawnBeneathPosition && entryIndex == 0)
			{
				padding += 0.625f;
			}
			if (spawnBeneathPosition)
			{
				freeComponent.transform.localPosition = localPosition - freeComponent.topOffset - new Vector3(0f, padding, 0f);
			}
			else
			{
				freeComponent.transform.localPosition = localPosition - freeComponent.botOffset + new Vector3(0f, padding, 0f);
			}
			radicalCreditsMenu.AddEntry(entryIndex, freeComponent);
			freeComponent.OnOccupied();
			freeComponent.UpdateAdjacentEntries();
			if (creditsEntry.layout == CreditLayout.Centered)
			{
				radicalCreditsMenu.SpawnTitleSprite(creditsEntry.title, freeComponent.transform.localPosition + new Vector3(0f, freeComponent.topOffset.y, 0f));
			}
		}
		else
		{
			Debug.LogError("failed to instantiate RadicalCreditsTextEntry");
		}
		return freeComponent;
	}

	private void RenderText()
	{
		CreditsData.CreditsEntry creditsEntry = creditsData.creditsElements[entryIndex];
		if (creditsEntry.layout == CreditLayout.Horizontal)
		{
			titleText.style.fontFace = TextManager.FontFace.thinMedium;
			titleText.style.horizontalAlignment = PugTextStyle.HorizontalAlignment.right;
			titleText.style.verticalAlignment = PugTextStyle.VerticalAlignment.top;
			namesText.style.horizontalAlignment = PugTextStyle.HorizontalAlignment.left;
			namesText.style.verticalAlignment = PugTextStyle.VerticalAlignment.top;
			titleText.maxWidth = 15f;
		}
		else
		{
			titleText.style.fontFace = TextManager.FontFace.boldMedium;
			titleText.style.horizontalAlignment = PugTextStyle.HorizontalAlignment.center;
			titleText.style.verticalAlignment = PugTextStyle.VerticalAlignment.center;
			namesText.style.horizontalAlignment = PugTextStyle.HorizontalAlignment.center;
			namesText.style.verticalAlignment = PugTextStyle.VerticalAlignment.center;
			titleText.maxWidth = 25f;
		}
		if (creditsEntry.layout == CreditLayout.Centered)
		{
			titleText.style.color = headerColor;
		}
		else
		{
			titleText.style.color = titleColor;
		}
		if (!creditsEntry.skipTitle)
		{
			titleText.Render(CreditsData.TitleToTerm(creditsEntry.title));
		}
		else
		{
			titleText.Render("");
		}
		string text = "";
		for (int i = 0; i < creditsEntry.creditNames.Count; i++)
		{
			text += PugText.ProcessText("CreditsNames/" + creditsEntry.creditNames[i], null, shouldLocalize: true, shouldLocalizeFormatFields: false);
			if (i != creditsEntry.creditNames.Count - 1 || creditsEntry.endWithComma)
			{
				text += (creditsEntry.useCommaSeparationForNames ? ", " : "\n");
			}
		}
		namesText.Render(text);
		UpdateLayout(creditsEntry);
	}

	private void UpdateLayout(CreditsData.CreditsEntry entry)
	{
		if (entry.layout == CreditLayout.Horizontal)
		{
			titleText.transform.localPosition = new Vector3(-0.375f, 0f, 0f);
		}
		else
		{
			titleText.transform.localPosition = Vector3.zero;
		}
		float num = titleText.dimensions.height / 2f;
		float num2 = ((num % 0.0625f > 0f) ? (0.0625f - num % 0.0625f) : 0f);
		float num3 = num + num2;
		topOffset = new Vector3(0f, titleText.transform.localPosition.y + num3, 0f);
		float num4 = titleText.transform.localPosition.y - num3;
		if (entry.layout == CreditLayout.Horizontal)
		{
			if (entry.creditNames.Count > 0)
			{
				namesText.transform.localPosition = new Vector3(0.375f, titleText.transform.localPosition.y, 0f);
				float num5 = namesText.transform.localPosition.y - namesText.dimensions.height + 0.625f;
				if (num5 < num4)
				{
					num4 = num5;
				}
			}
		}
		else if (entry.creditNames.Count > 0)
		{
			namesText.transform.localPosition = Vector3.zero;
			if (!entry.skipTitle)
			{
				num4 = UIManager.PositionElementBeneath(namesText.transform, num4, namesText.dimensions.height, 0.125f);
			}
			else
			{
				float num6 = namesText.dimensions.height / 2f;
				float num7 = ((num6 % 0.0625f > 0f) ? (0.0625f - num6 % 0.0625f) : 0f);
				float num8 = num6 + num7;
				topOffset = new Vector3(0f, namesText.transform.localPosition.y + num8, 0f);
				num4 = namesText.transform.localPosition.y - num8;
			}
		}
		botOffset = new Vector3(0f, num4, 0f);
	}

	private void Update()
	{
		if (!EntryShouldExistAtHeight(base.transform.position.y, -5f))
		{
			Free();
		}
		else
		{
			UpdateAdjacentEntries();
		}
	}

	public override void OnFree()
	{
		creditsMenu.RemoveEntry(entryIndex);
		base.OnFree();
	}

	public void UpdateAdjacentEntries()
	{
		int num = entryIndex + 1;
		if (entryBelow == null && num > 0 && num < creditsData.creditsElements.Count && EntryShouldExistAtHeight(botWorldPosition.y))
		{
			SpawnTextEntry(spawnBeneathPosition: true, botLocalPosition, num, creditsMenu);
		}
		int num2 = entryIndex - 1;
		if (entryAbove == null && num2 >= 0 && num2 < creditsData.creditsElements.Count && EntryShouldExistAtHeight(topWorldPosition.y))
		{
			SpawnTextEntry(spawnBeneathPosition: false, topLocalPosition, num2, creditsMenu);
		}
	}

	public static bool EntryShouldExistAtHeight(float height, float padding = 0f)
	{
		if (height + padding < 20f)
		{
			return height - padding > -20f;
		}
		return false;
	}
}
