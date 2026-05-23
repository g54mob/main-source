using System;
using System.Collections.Generic;
using UnityEngine;

public class BookSpec
{
	public enum TemplateId
	{
		Base = 0,
		Desk = 1,
		Cover = 2,
		Title = 3,
		Preface = 4,
		Toc = 5,
		Maps = 6,
		Crew = 7,
		Chapter = 8,
		Death = 9,
		Disappear = 10,
		Disappear2 = 11,
		Glossary = 12,
		Last = 13,
		FolioChart = 14,
		FolioDeck = 15,
		FolioSketch = 16,
		ScrollableManifest = 17,
		Screenplay = 18,
		Message = 19,
		EditFate = 20,
		ListPanel = 21,
		ChooseFace = 22,
		DefineTerm = 23,
		MessagePanel = 24,
		SettingsMenu = 25,
		TitleOcean = 26,
		Controls = 27,
		Credits = 28,
		Profiles = 29,
		TallyInsurance = 30,
		TallyMessage = 31
	}

	public enum TransitionType
	{
		Turn = 0,
		Roll = 1,
		Open = 2,
		Drop = 3,
		Lift = 4,
		Instant = 5
	}

	public enum FolioSource
	{
		GlobalManifest = 0,
		GlobalDeck = 1,
		GlobalChart = 2,
		GlobalSketch = 3,
		DeathDeck = 4,
		DeathSketch = 5,
		ChapterChart = 6,
		FocusDeck = 7
	}

	public class GuessSpec
	{
		public Vector2 offset;

		public float rot;

		public float width;

		public GuessSpec(MersenneTwister twister, float offsetRand, float rotRand, float widthMin, float widthMax)
		{
			offset = new Vector2(Mathf.Round(twister.Range(0f - offsetRand, offsetRand)), Mathf.Round(twister.Range(0f - offsetRand, offsetRand)));
			rot = twister.Range(0f - rotRand, rotRand);
			width = Mathf.Floor(twister.Range(widthMin, widthMax));
		}
	}

	public class SkeletonCircleSpec
	{
		public Vector2 flip;

		public float rot;

		public float scale;

		public SkeletonCircleSpec(MersenneTwister twister)
		{
			float num = 160f;
			rot = twister.Range(0f - num, num);
			float f = (rot * ((float)Math.PI / 180f) + (float)Math.PI * 8f) % ((float)Math.PI / 2f);
			scale = Util.LerpScale(Vector2.Angle(new Vector2(1f, 1f), new Vector2(Mathf.Cos(f), Mathf.Sin(f))), 0f, 45f, 1f, 0.75f);
			flip = scale * new Vector2((!(twister.value < 0.5f)) ? 1 : (-1), (!(twister.value < 0.5f)) ? 1 : (-1));
		}
	}

	public class ChapterSpec
	{
		public int index;

		public string disasterId;

		public string numeral;

		public string name;

		public string head;

		public int numDeathPages;

		public List<PageSpec> pageSpecs = new List<PageSpec>();

		public string[] disappearCrewIds = new string[0];

		public List<GuessSpec> disappearGuessSpecs = new List<GuessSpec>();
	}

	public class DeathSpec
	{
		public string crewId0;

		public string crewId1;

		public GuessSpec guessSpec0;

		public GuessSpec guessSpec1;

		public SkeletonCircleSpec skeletonCircleSpec;
	}

	public enum PageSide
	{
		None = 0,
		Left = 1,
		Right = 2
	}

	public class PageSpec
	{
		public string id;

		public int index;

		public TemplateId templateId;

		public string templateIdStr;

		public int pageNumL;

		public int pageNumR;

		public string pageNumLStr;

		public string pageNumRStr;

		public string runningHeadL;

		public string runningHeadR;

		public PageSpec nextPage;

		public PageSpec prevPage;

		public ChapterSpec chapterSpec;

		public DeathSpec deathSpec;

		public TransitionType transitionType;

		public bool isDeath
		{
			get
			{
				return templateId == TemplateId.Death;
			}
		}

		public bool isDisappearance
		{
			get
			{
				return templateId == TemplateId.Disappear || templateId == TemplateId.Disappear2;
			}
		}

		public bool isGroup
		{
			get
			{
				return templateId == TemplateId.Maps || templateId == TemplateId.Crew;
			}
		}

		public bool hasTocJump
		{
			get
			{
				return pageNumL >= 1 && templateId <= TemplateId.Last;
			}
		}

		public bool aliasPrevNextToBack
		{
			get
			{
				return transitionType == TransitionType.Roll;
			}
		}

		public bool isTurnable
		{
			get
			{
				return transitionType == TransitionType.Turn;
			}
		}

		public bool isRollable
		{
			get
			{
				return transitionType == TransitionType.Roll;
			}
		}

		public bool revealed
		{
			get
			{
				if (isDeath)
				{
					return SaveData.it.momentRo[id].revealedPageInBook;
				}
				if (isDisappearance)
				{
					return SaveData.it.disasterRo[chapterSpec.disasterId].revealedDisappearancesInBook;
				}
				return true;
			}
		}

		public PageSpec SetRunningHeads(string runningHeadL_, string runningHeadR_)
		{
			runningHeadL = runningHeadL_;
			runningHeadR = runningHeadR_;
			return this;
		}

		public PageSpec SetTransitionType(TransitionType transitionType_)
		{
			transitionType = transitionType_;
			return this;
		}

		public PageSide GetAppearancePageSide(string crewId, bool onlyFinal = false)
		{
			if (templateId == TemplateId.Disappear)
			{
				int num = Array.IndexOf(chapterSpec.disappearCrewIds, crewId);
				if (num >= 0 && num < 2)
				{
					return PageSide.Right;
				}
			}
			else if (templateId == TemplateId.Disappear2)
			{
				int num2 = Array.IndexOf(chapterSpec.disappearCrewIds, crewId);
				if (num2 >= 2)
				{
					return (num2 < 4) ? PageSide.Left : PageSide.Right;
				}
			}
			else if (isDeath)
			{
				Story.Moment moment = Story.it.GetMoment(id);
				Story.Zest zest = moment.GetZest(crewId);
				if (zest == Story.Zest.Die)
				{
					return PageSide.Left;
				}
				if (!onlyFinal && (zest == Story.Zest.Alive || zest == Story.Zest.Die))
				{
					return PageSide.Right;
				}
			}
			return PageSide.None;
		}
	}

	public class GlossaryEntry
	{
		public string name;

		public string definition;

		public GlossaryEntry(string id)
		{
			string[] array = Util.SplitAndTrim(Lang.Get(id), '|');
			name = ((array.Length <= 0) ? ("NAME: " + id) : array[0]);
			definition = ((array.Length <= 1) ? ("DEFINITION: " + id) : array[1]);
		}
	}

	public class AppearanceSummary
	{
		public int count;

		public int pageNum0;

		public int pageNum1;

		public PageSpec pageSpec0;

		public PageSpec pageSpec1;
	}

	public readonly List<ChapterSpec> chapterSpecs = new List<ChapterSpec>();

	public readonly List<PageSpec> pageSpecs = new List<PageSpec>();

	public readonly int numNavigablePages;

	public readonly Dictionary<string, PageSpec> pageSpecsDict = new Dictionary<string, PageSpec>();

	public readonly List<GlossaryEntry> glossaryEntries = new List<GlossaryEntry>();

	private int pageNumCount;

	private MersenneTwister twister = new MersenneTwister(0uL);

	public BookSpec()
	{
		AddPage("title", TemplateId.Title);
		AddPage("preface", TemplateId.Preface);
		AddPage("toc", TemplateId.Toc);
		AddPage("maps", TemplateId.Maps).SetRunningHeads(Lang.Get("book_head_chart"), Lang.Get("book_head_deck"));
		AddPage("crew", TemplateId.Crew).SetRunningHeads(Lang.Get("book_head_crew"), Lang.Get("book_head_sketch"));
		for (int i = 0; i < Story.it.disasterCount; i++)
		{
			Story.Disaster disaster = Story.it.GetDisaster(i);
			AddChapter(disaster.id, disaster.disappearCrewIds);
		}
		AddPage("glossary", TemplateId.Glossary).SetRunningHeads(string.Empty, Lang.Get("book_glossary"));
		AddPage("last", TemplateId.Last);
		numNavigablePages = pageSpecs.Count;
		AddPage("air", TemplateId.Desk).SetTransitionType(TransitionType.Lift);
		AddPage("desk", TemplateId.Desk).SetTransitionType(TransitionType.Drop);
		PageSpec pageSpec = AddPage("cover", TemplateId.Cover).SetTransitionType(TransitionType.Open);
		pageSpec.nextPage = FindPage("title");
		AddPage("folio-chart", TemplateId.FolioChart).SetTransitionType(TransitionType.Roll);
		AddPage("folio-deck", TemplateId.FolioDeck).SetTransitionType(TransitionType.Roll);
		AddPage("folio-sketch", TemplateId.FolioSketch).SetTransitionType(TransitionType.Roll);
		AddPage("scrollable-manifest", TemplateId.ScrollableManifest).SetTransitionType(TransitionType.Roll);
		AddPage("screenplay", TemplateId.Screenplay).SetTransitionType(TransitionType.Roll);
		AddPage("message", TemplateId.Message).SetTransitionType(TransitionType.Instant);
		for (int j = 0; j < numNavigablePages; j++)
		{
			if (j > 0)
			{
				pageSpecs[j].prevPage = pageSpecs[j - 1];
			}
			if (j < numNavigablePages - 1)
			{
				pageSpecs[j].nextPage = pageSpecs[j + 1];
			}
		}
		AddGlossary("glossary_captain");
		AddGlossary("glossary_mate");
		AddGlossary("glossary_bosun");
		AddGlossary("glossary_gunner");
		AddGlossary("glossary_purser");
		AddGlossary("glossary_surgeon");
		AddGlossary("glossary_carpenter");
		AddGlossary("glossary_helmsman");
		AddGlossary("glossary_steward");
		AddGlossary("glossary_midshipman");
		AddGlossary("glossary_topman");
		AddGlossary("glossary_seaman");
		AddGlossary("glossary_rigging");
		AddGlossary("glossary_maindeck");
		AddGlossary("glossary_gundeck");
		AddGlossary("glossary_orlopdeck");
		AddGlossary("glossary_cargodeck");
	}

	private void AddGlossary(string id)
	{
		glossaryEntries.Add(new GlossaryEntry(id));
	}

	private PageSpec AddPage(string id, TemplateId templateId, ChapterSpec chapterSpec = null)
	{
		PageSpec pageSpec = new PageSpec();
		pageSpec.id = id;
		pageSpec.templateId = templateId;
		pageSpec.templateIdStr = templateId.ToString();
		pageSpec.chapterSpec = chapterSpec;
		PageSpec pageSpec2 = pageSpec;
		pageSpec2.index = pageSpecs.Count;
		if (templateId > TemplateId.Toc)
		{
			pageSpec2.pageNumL = ++pageNumCount;
			pageSpec2.pageNumR = ++pageNumCount;
			pageSpec2.pageNumLStr = pageSpec2.pageNumL.ToString();
			pageSpec2.pageNumRStr = ((templateId == TemplateId.Last) ? string.Empty : pageSpec2.pageNumR.ToString());
		}
		else
		{
			pageSpec2.pageNumL = -1;
			pageSpec2.pageNumR = -1;
		}
		if (pageSpec2.isDeath)
		{
			pageSpec2.SetRunningHeads(Lang.Get("book_part_num", "$0", chapterSpec.numDeathPages + 1), chapterSpec.head);
			pageSpec2.deathSpec = new DeathSpec();
			Story.Moment moment = Story.it.GetMoment(id);
			pageSpec2.deathSpec.crewId0 = moment.dieCrewIds[0];
			pageSpec2.deathSpec.crewId1 = ((moment.dieCrewIds.Length <= 1) ? null : moment.dieCrewIds[1]);
			pageSpec2.deathSpec.guessSpec0 = new GuessSpec(twister, 10f, 4f, 180f, 210f);
			pageSpec2.deathSpec.guessSpec1 = new GuessSpec(twister, 10f, 4f, 180f, 210f);
			if (pageSpec2.chapterSpec.disasterId != "d090")
			{
				pageSpec2.deathSpec.skeletonCircleSpec = new SkeletonCircleSpec(twister);
			}
		}
		else if (pageSpec2.isDisappearance)
		{
			pageSpec2.SetRunningHeads(Lang.Get("book_conclusion"), chapterSpec.head);
		}
		pageSpecs.Add(pageSpec2);
		pageSpecsDict.Add(id, pageSpec2);
		return pageSpec2;
	}

	private ChapterSpec AddChapter(string disasterId, string[] disappearCrewIds = null)
	{
		ChapterSpec chapterSpec = new ChapterSpec();
		chapterSpec.disasterId = disasterId;
		ChapterSpec chapterSpec2 = chapterSpec;
		chapterSpec2.index = chapterSpecs.Count;
		chapterSpec2.numeral = Lang.Get("book_numeral_" + (chapterSpec2.index + 1));
		chapterSpec2.name = Lang.Get("book_chapter_" + chapterSpec2.index + "_name");
		chapterSpec2.head = Lang.Get("book_chapter_" + chapterSpec2.index + "_head");
		if (disappearCrewIds != null)
		{
			chapterSpec2.disappearCrewIds = disappearCrewIds;
		}
		chapterSpecs.Add(chapterSpec2);
		AddPage(disasterId, TemplateId.Chapter, chapterSpec2);
		Story.Disaster disaster = Story.it.GetDisaster(disasterId);
		foreach (Story.Moment moment in disaster.moments)
		{
			AddPage(moment.id, TemplateId.Death, chapterSpec2);
			chapterSpec2.numDeathPages++;
		}
		if (chapterSpec2.disappearCrewIds.Length > 0)
		{
			AddPage(disasterId + "-disappear", TemplateId.Disappear, chapterSpec2);
			if (disappearCrewIds.Length > 2)
			{
				AddPage(disasterId + "-disappear2", TemplateId.Disappear2, chapterSpec2);
			}
			for (int i = 0; i < disappearCrewIds.Length; i++)
			{
				chapterSpec2.disappearGuessSpecs.Add(new GuessSpec(twister, 8f, 3f, 170f, 210f));
			}
		}
		return chapterSpec2;
	}

	public PageSpec FindPage(string id)
	{
		if (id == null)
		{
			return null;
		}
		PageSpec value = null;
		pageSpecsDict.TryGetValue(id, out value);
		return value;
	}

	public PageSpec FindFinalPage(string crewId)
	{
		foreach (PageSpec pageSpec in pageSpecs)
		{
			if (pageSpec.GetAppearancePageSide(crewId, true) != PageSide.None)
			{
				return pageSpec;
			}
		}
		return null;
	}

	public AppearanceSummary GetAppearanceSummary(string crewId)
	{
		AppearanceSummary appearanceSummary = new AppearanceSummary();
		for (int i = 0; i < numNavigablePages; i++)
		{
			PageSpec pageSpec = pageSpecs[i];
			if (!pageSpec.revealed || !pageSpec.isDeath)
			{
				continue;
			}
			PageSide appearancePageSide = pageSpec.GetAppearancePageSide(crewId);
			if (appearancePageSide != PageSide.None)
			{
				int num = ((appearancePageSide != PageSide.Left) ? pageSpec.pageNumR : pageSpec.pageNumL);
				if (appearanceSummary.count == 0)
				{
					appearanceSummary.pageNum0 = num;
					appearanceSummary.pageSpec0 = pageSpec;
				}
				if (appearanceSummary.count == 1)
				{
					appearanceSummary.pageNum1 = num;
					appearanceSummary.pageSpec1 = pageSpec;
				}
				appearanceSummary.count++;
			}
		}
		return appearanceSummary;
	}
}
