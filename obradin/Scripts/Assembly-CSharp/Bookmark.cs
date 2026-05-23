using System;
using UnityEngine;

public class Bookmark
{
	[Flags]
	public enum Pos
	{
		None = 0,
		PinL = 1,
		GoL = 2,
		PinR = 4,
		GoR = 8,
		PinEither = 5
	}

	public enum Moment
	{
		None = 0,
		Cross = 1,
		Skull = 2
	}

	public class Info
	{
		public string crewId;

		public int count;

		public Destiny destiny;

		public BookSpec.PageSpec prevPageSpec;

		public string prevPageNumStr;

		public Pos prevPos;

		public BookSpec.PageSpec nextPageSpec;

		public string nextPageNumStr;

		public Pos nextPos;
	}

	public class Destiny
	{
		public string crewId;

		public string description;

		public string pageNumStr;

		public BookSpec.PageSpec pageSpec;

		public BookSpec.AppearanceSummary appearanceSummary;

		public Destiny(string crewId_)
		{
			crewId = crewId_;
		}
	}

	public string crewId;

	public Moment[] markedMoments;

	public Pos[] markedPages;

	private BookSpec bookSpec;

	public bool valid
	{
		get
		{
			return crewId != null;
		}
	}

	public Bookmark(BookSpec bookSpec_)
	{
		bookSpec = bookSpec_;
		markedPages = new Pos[bookSpec.pageSpecs.Count];
		markedMoments = new Moment[Story.it.momentCount];
		if (SaveData.it.general.bookBookmarkedCrewId.HasValue())
		{
			MarkCrewMember(SaveData.it.general.bookBookmarkedCrewId);
		}
	}

	public void MarkCrewMember(string crewId_)
	{
		crewId = crewId_;
		SaveData.it.general.bookBookmarkedCrewId = crewId;
		int num = 10000;
		int num2 = -10000;
		for (int i = 0; i < bookSpec.pageSpecs.Count; i++)
		{
			markedPages[i] = Pos.None;
			BookSpec.PageSpec pageSpec = bookSpec.pageSpecs[i];
			if (pageSpec.isDeath && pageSpec.revealed)
			{
				Pos pos = Pos.None;
				BookSpec.PageSide appearancePageSide = pageSpec.GetAppearancePageSide(crewId);
				switch (appearancePageSide)
				{
				case BookSpec.PageSide.Left:
					pos |= Pos.PinL;
					break;
				case BookSpec.PageSide.Right:
					pos |= Pos.PinR;
					break;
				}
				markedPages[i] = pos;
				if (appearancePageSide != BookSpec.PageSide.None)
				{
					num = Mathf.Min(num, i);
					num2 = Mathf.Max(num2, i);
				}
			}
		}
		for (int j = 0; j < bookSpec.pageSpecs.Count; j++)
		{
			if (j > num)
			{
				Pos[] array;
				int num3;
				(array = markedPages)[num3 = j] = array[num3] | Pos.GoL;
			}
			if (j < num2)
			{
				Pos[] array;
				int num4;
				(array = markedPages)[num4 = j] = array[num4] | Pos.GoR;
			}
		}
		for (int k = 0; k < Story.it.momentCount; k++)
		{
			Story.Moment moment = Story.it.GetMoment(k);
			if (SaveData.it.momentRo[moment.id].revealedPageInBook)
			{
				switch (moment.GetZest(crewId))
				{
				case Story.Zest.Die:
					markedMoments[k] = Moment.Skull;
					break;
				case Story.Zest.Alive:
					markedMoments[k] = Moment.Cross;
					break;
				default:
					markedMoments[k] = Moment.None;
					break;
				}
			}
			else
			{
				markedMoments[k] = Moment.None;
			}
		}
	}

	public void Clear()
	{
		crewId = null;
		SaveData.it.general.bookBookmarkedCrewId = string.Empty;
	}

	public void Refresh()
	{
		if (crewId != null)
		{
			MarkCrewMember(crewId);
		}
	}

	public Info GetInfo(BookSpec.PageSpec pageSpec, bool includeDestinyAndCount = true)
	{
		if (!valid)
		{
			return null;
		}
		Info info = new Info();
		info.crewId = crewId;
		for (int num = pageSpec.index - 1; num > 0; num--)
		{
			Pos pos = markedPages[num];
			if ((pos & Pos.PinEither) != Pos.None && info.prevPageSpec == null)
			{
				info.prevPos = pos;
				info.prevPageSpec = bookSpec.pageSpecs[num];
				info.prevPageNumStr = (((pos & Pos.PinL) == 0) ? info.prevPageSpec.pageNumRStr : info.prevPageSpec.pageNumLStr);
				break;
			}
		}
		for (int i = pageSpec.index + 1; i < bookSpec.pageSpecs.Count; i++)
		{
			Pos pos2 = markedPages[i];
			if ((pos2 & Pos.PinEither) != Pos.None && info.nextPageSpec == null)
			{
				info.nextPos = pos2;
				info.nextPageSpec = bookSpec.pageSpecs[i];
				info.nextPageNumStr = (((pos2 & Pos.PinL) == 0) ? info.nextPageSpec.pageNumRStr : info.nextPageSpec.pageNumLStr);
			}
		}
		if (includeDestinyAndCount)
		{
			info.destiny = GetDestiny(crewId);
			info.count = 0;
			for (int j = 0; j < markedPages.Length; j++)
			{
				if ((markedPages[j] & Pos.PinEither) != Pos.None)
				{
					info.count++;
				}
			}
		}
		return info;
	}

	public BookSpec.AppearanceSummary GetAppearanceSummary(string crewId)
	{
		return bookSpec.GetAppearanceSummary(crewId);
	}

	public Destiny GetDestiny(string crewId)
	{
		Destiny destiny = new Destiny(crewId);
		Manifest.Gender crewGender = Manifest.it.GetCrewGender(crewId);
		BookSpec.PageSide pageSide = BookSpec.PageSide.None;
		Story.Moment deathMoment = Story.it.GetDeathMoment(crewId);
		if (deathMoment != null)
		{
			destiny.pageSpec = bookSpec.FindPage(deathMoment.id);
			destiny.description = Manifest.ApplyGender(Lang.Get("bookmarked_death", "$chapter", destiny.pageSpec.chapterSpec.name, "$part", destiny.pageSpec.runningHeadL), crewGender);
			pageSide = destiny.pageSpec.GetAppearancePageSide(crewId);
		}
		else
		{
			Story.Disaster disappearDisaster = Story.it.GetDisappearDisaster(crewId);
			if (disappearDisaster != null)
			{
				foreach (BookSpec.PageSpec pageSpec in bookSpec.pageSpecs)
				{
					if (pageSpec.isDisappearance && !(pageSpec.chapterSpec.disasterId != disappearDisaster.id))
					{
						pageSide = pageSpec.GetAppearancePageSide(crewId);
						if (pageSide != BookSpec.PageSide.None)
						{
							destiny.pageSpec = pageSpec;
							destiny.description = Manifest.ApplyGender(Lang.Get("bookmarked_disappear", "$chapter", pageSpec.chapterSpec.name), crewGender);
							break;
						}
					}
				}
			}
		}
		destiny.pageNumStr = ((pageSide != BookSpec.PageSide.Left) ? destiny.pageSpec.pageNumRStr : destiny.pageSpec.pageNumLStr);
		destiny.appearanceSummary = bookSpec.GetAppearanceSummary(crewId);
		return destiny;
	}

	public static string PosToSelectableName(Pos pos, Pos ideal)
	{
		if ((ideal & Pos.GoL) != Pos.None && (pos & Pos.GoL) != Pos.None)
		{
			return "bookmark-gol";
		}
		if ((ideal & Pos.GoR) != Pos.None && (pos & Pos.GoR) != Pos.None)
		{
			return "bookmark-gor";
		}
		if ((pos & Pos.PinL) != Pos.None)
		{
			return "bookmark-pinl";
		}
		if ((pos & Pos.PinR) != Pos.None)
		{
			return "bookmark-pinr";
		}
		return null;
	}
}
