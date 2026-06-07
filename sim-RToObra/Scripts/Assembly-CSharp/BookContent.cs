using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BookContent
{
	public enum RefreshMode
	{
		Normal = 0,
		SelectionChanged = 1,
		Animating = 2,
		PopupJustClosed = 3
	}

	public class Selection
	{
		public string pageId;

		public string itemId;

		public Vector2 posInCanvas;

		public Selection()
		{
		}

		public Selection(string pageId_, string itemId_, Vector2 posInCanvas_)
		{
			pageId = pageId_;
			itemId = itemId_;
			posInCanvas = posInCanvas_;
		}
	}

	public enum ClueStatus
	{
		Ignore = 0,
		NotYet = 1,
		Seen = 2
	}

	public struct FolioAddress
	{
		public BookSpec.FolioSource source;

		public string pageId;

		public FolioAddress(BookSpec.FolioSource source_, string pageId_)
		{
			source = source_;
			pageId = pageId_;
		}

		public static bool operator ==(FolioAddress a, FolioAddress b)
		{
			return a.source == b.source && a.pageId == b.pageId;
		}

		public static bool operator !=(FolioAddress a, FolioAddress b)
		{
			return !(a == b);
		}

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return false;
			}
			FolioAddress folioAddress = (FolioAddress)o;
			return this == folioAddress;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	public class DisappearId
	{
		public string button;

		public string fate;

		public string face;

		public string guess;

		public string bookmark;

		public string difficulty;

		public Vector2 basePos;

		public DisappearId(int i)
		{
			button = string.Format("disappear{0}-button", i);
			fate = string.Format("disappear{0}-fate", i);
			face = string.Format("disappear{0}-face", i);
			guess = string.Format("disappear{0}-guess", i);
			difficulty = string.Format("disappear{0}-difficulty", i);
			bookmark = string.Format("disappear{0}-bookmark", i);
			basePos = new Vector2((i >= 2 && i <= 3) ? 40 : (-40), 0f);
		}
	}

	public class Consts
	{
		public DisappearId[] disappearIds = new DisappearId[7]
		{
			new DisappearId(0),
			new DisappearId(1),
			new DisappearId(2),
			new DisappearId(3),
			new DisappearId(4),
			new DisappearId(5),
			new DisappearId(6)
		};

		public string[] dialogLineMainIds = new string[10] { "dialog0-main", "dialog1-main", "dialog2-main", "dialog3-main", "dialog4-main", "dialog5-main", "dialog6-main", "dialog7-main", "dialog8-main", "dialog9-main" };

		public string[] dialogLineTextIds = new string[10] { "dialog0-text", "dialog1-text", "dialog2-text", "dialog3-text", "dialog4-text", "dialog5-text", "dialog6-text", "dialog7-text", "dialog8-text", "dialog9-text" };

		public string[] dialogLineMarkIds = new string[10] { "dialog0-mark", "dialog1-mark", "dialog2-mark", "dialog3-mark", "dialog4-mark", "dialog5-mark", "dialog6-mark", "dialog7-mark", "dialog8-mark", "dialog9-mark" };

		public string[] glossaryIds = new string[16]
		{
			"gloss0", "gloss1", "gloss2", "gloss3", "gloss4", "gloss5", "gloss6", "gloss7", "gloss8", "gloss9",
			"gloss10", "gloss11", "gloss12", "gloss13", "gloss14", "gloss15"
		};
	}

	public class Mod
	{
		public string message;

		public Sprite messageIcon;

		public string hiddenFateCrewId;

		public string forceChapterTallyId;

		public int forceChapterTallyCount;

		public int forceFateSealCount = -1;

		public List<string> maskedCorrectFaceIds = new List<string>();

		public List<BookSpec.PageSpec> hiddenPageSpecs = new List<BookSpec.PageSpec>();

		public List<BookSpec.PageSpec> hiddenGuessPageSpecs = new List<BookSpec.PageSpec>();

		public void AddHiddenPageSpec(BookSpec.PageSpec pageSpec)
		{
			if (!hiddenPageSpecs.Contains(pageSpec))
			{
				hiddenPageSpecs.Add(pageSpec);
			}
		}

		public void AddHiddenGuessPageSpec(BookSpec.PageSpec pageSpec)
		{
			if (!hiddenGuessPageSpecs.Contains(pageSpec))
			{
				hiddenGuessPageSpecs.Add(pageSpec);
			}
		}

		public void AddMaskedCorrectFaceId(string faceId)
		{
			if (!maskedCorrectFaceIds.Contains(faceId))
			{
				maskedCorrectFaceIds.Add(faceId);
			}
		}

		public void RemoveHiddenPageSpec(BookSpec.PageSpec pageSpec)
		{
			hiddenPageSpecs.Remove(pageSpec);
		}

		public void RemoveHiddenGuessPageSpec(BookSpec.PageSpec pageSpec)
		{
			hiddenGuessPageSpecs.Remove(pageSpec);
		}

		public void RemoveMaskedCorrectFaceId(string faceId)
		{
			maskedCorrectFaceIds.Remove(faceId);
		}

		public bool HasHiddenPageSpec(BookSpec.PageSpec pageSpec)
		{
			return hiddenPageSpecs.Contains(pageSpec);
		}

		public bool HasHiddenGuessPageSpec(BookSpec.PageSpec pageSpec)
		{
			return hiddenGuessPageSpecs.Contains(pageSpec);
		}

		public bool HasMaskedCorrectFaceId(string faceId)
		{
			return maskedCorrectFaceIds.Contains(faceId);
		}

		public void Reset()
		{
			message = null;
			messageIcon = null;
			hiddenFateCrewId = null;
			forceChapterTallyId = null;
			forceChapterTallyCount = -1;
			forceFateSealCount = -1;
			hiddenPageSpecs.Clear();
			hiddenGuessPageSpecs.Clear();
			maskedCorrectFaceIds.Clear();
		}
	}

	private BookSpec spec;

	private BookAssets bookAssets;

	private FaceLib faceLib;

	private string screenplayMomentId;

	private string focusDeckCrewId;

	private Dictionary<string, FolioAddress> folioRemaps = new Dictionary<string, FolioAddress>();

	private Selection selection = new Selection();

	private Bookmark bookmark;

	private Consts consts;

	public Mod mod;

	public BookContent(BookSpec spec_, Bookmark bookmark_, FaceLib faceLib_, BookAssets bookAssets_)
	{
		spec = spec_;
		faceLib = faceLib_;
		bookAssets = bookAssets_;
		bookmark = bookmark_;
		consts = new Consts();
		mod = new Mod();
	}

	public void SetFolioRemap(string pageId, FolioAddress toAddress)
	{
		folioRemaps[pageId] = toAddress;
	}

	public void SetScreenplayMomentId(string screenplayMomentId_)
	{
		screenplayMomentId = screenplayMomentId_;
	}

	public void SetFocusDeckCrewId(string focusDeckCrewId_)
	{
		focusDeckCrewId = focusDeckCrewId_;
	}

	public bool SetSelection(Selection s)
	{
		if (s.pageId != selection.pageId || s.itemId != selection.itemId)
		{
			selection = s;
			return true;
		}
		return false;
	}

	public Selection GetSelection()
	{
		return selection;
	}

	public void RefreshPage(BookSpec.PageSpec pageSpec, PageTemplate pageTemplate, RefreshMode refreshMode = RefreshMode.Normal)
	{
		Dictionary<string, PageItem> pageItemDict = pageTemplate.pageItemDict;
		pageTemplate.BeginRefresh();
		if (pageTemplate.id == BookSpec.TemplateId.Base)
		{
			if (pageSpec.pageNumL > 0)
			{
				pageItemDict["pagenuml"].text = pageSpec.pageNumLStr;
			}
			if (pageSpec.pageNumR > 0)
			{
				pageItemDict["pagenumr"].text = pageSpec.pageNumRStr;
			}
			if (!string.IsNullOrEmpty(pageSpec.runningHeadL))
			{
				pageItemDict["runningheadl"].text = pageSpec.runningHeadL;
			}
			if (!string.IsNullOrEmpty(pageSpec.runningHeadR))
			{
				pageItemDict["runningheadr"].text = pageSpec.runningHeadR;
			}
			pageItemDict["prev-button"].visible = pageSpec.prevPage != null;
			pageItemDict["next-button"].visible = pageSpec.nextPage != null;
			pageItemDict["sheetl"].visible = pageSpec.prevPage != null;
			pageItemDict["sheetr"].visible = pageSpec.nextPage != null;
			pageItemDict["tocbutton"].visible = pageSpec.hasTocJump;
		}
		if (pageTemplate.id == BookSpec.TemplateId.Title)
		{
			pageItemDict["congrats"].visible = SaveData.it.generalRo.era == 3;
		}
		if (pageTemplate.id == BookSpec.TemplateId.Preface)
		{
			pageItemDict["signature"].text = Manifest.it.GetCrew("surgeon").name;
		}
		else if (pageTemplate.id == BookSpec.TemplateId.Toc)
		{
			pageItemDict["toc-glossary"].text = this.spec.FindPage("glossary").pageNumLStr;
			pageItemDict["toc-last-page"].text = this.spec.FindPage("last").pageNumLStr;
			for (int i = 0; i < Story.it.disasterCount; i++)
			{
				Story.Disaster disaster = Story.it.GetDisaster(i);
				pageItemDict[disaster.id].text = this.spec.FindPage(disaster.id).pageNumRStr;
			}
		}
		else if (pageTemplate.id == BookSpec.TemplateId.Death)
		{
			Story.Moment moment = Story.it.GetMoment(pageSpec.id);
			SaveData.MomentDataRo momentDataRo = SaveData.it.momentRo[pageSpec.id];
			pageItemDict["root"].visible = true;
			if (momentDataRo.revealedPageInBook && !mod.HasHiddenPageSpec(pageSpec))
			{
				DialogLib.Spec spec = bookAssets.dialogLib.Find(moment.id);
				if (spec != null && spec.pages.Count > 0)
				{
					pageItemDict["photo-caption"].text = spec.pages[0].captionText + Lang.Get("dialog_ellipses");
				}
				else
				{
					pageItemDict["photo-caption"].text = " ";
				}
				pageItemDict["photo-button"].visible = true;
				Vector2 guessBasePos = new Vector2(-30f, -40f);
				Vector2 guessBasePos2 = new Vector2(40f, 0f);
				Vector2 guessBasePos3 = new Vector2(-40f, 0f);
				if (moment.deathType == Story.DeathType.Other)
				{
					pageItemDict["main-other-root"].visible = true;
					pageItemDict["main-other-noncrew-title"].text = Lang.Get(moment.locationId1);
					pageItemDict["main-other-noncrew-fate"].text = Lang.Get("fate_noncrew_" + moment.id);
				}
				else if (moment.deathType == Story.DeathType.Crew1)
				{
					pageItemDict["main-crew1-root"].visible = true;
					pageItemDict["main-crew1-title"].text = Lang.Get(moment.locationId1);
					SetCrewFateUi(pageSpec.deathSpec.crewId0, pageItemDict["main-crew1-fate0"], pageItemDict["main-crew1-fate-button"], pageItemDict["main-crew1-guess0"], pageItemDict["main-crew1-face0"], pageItemDict["main-crew1-faceborder0"], pageItemDict["main-crew1-difficulty"], pageSpec, pageSpec.deathSpec.guessSpec0, guessBasePos);
				}
				else if (moment.deathType == Story.DeathType.Crew2)
				{
					pageItemDict["main-crew2-root"].visible = true;
					SetCrewFateUi(pageSpec.deathSpec.crewId0, pageItemDict["main-crew2-fate0"], pageItemDict["main-crew2-fate-button"], pageItemDict["main-crew2-guess0"], pageItemDict["main-crew2-face0"], pageItemDict["main-crew2-faceborder0"], pageItemDict["main-crew2-difficulty0"], pageSpec, pageSpec.deathSpec.guessSpec0, guessBasePos2);
					SetCrewFateUi(pageSpec.deathSpec.crewId1, pageItemDict["main-crew2-fate1"], pageItemDict["main-crew2-fate-button1"], pageItemDict["main-crew2-guess1"], pageItemDict["main-crew2-face1"], pageItemDict["main-crew2-faceborder1"], pageItemDict["main-crew2-difficulty1"], pageSpec, pageSpec.deathSpec.guessSpec1, guessBasePos3);
				}
				else if (moment.deathType == Story.DeathType.CrewOther)
				{
					pageItemDict["main-crewother-root"].visible = true;
					pageItemDict["main-crewother-noncrew-fate"].text = Lang.Get("fate_noncrew_" + moment.id);
					SetCrewFateUi(pageSpec.deathSpec.crewId0, pageItemDict["main-crewother-fate0"], pageItemDict["main-crewother-fate-button"], pageItemDict["main-crewother-guess0"], pageItemDict["main-crewother-face0"], pageItemDict["main-crewother-faceborder0"], pageItemDict["main-crewother-difficulty"], pageSpec, pageSpec.deathSpec.guessSpec0, guessBasePos);
				}
				pageItemDict["photo"].uvRect = MomentPhotographer.GetUvRect(moment.index, 260, 100);
				pageItemDict["deck-button"].visible = true;
				pageItemDict["sketch-button"].visible = true;
				if (moment.corpseType == Story.CorpseType.Normal)
				{
					pageItemDict["deck-caption"].text = Lang.Get((moment.dieCrewIds.Length >= 2) ? "book_caption_corpses" : "book_caption_corpse");
				}
				else if (moment.corpseType == Story.CorpseType.Moved)
				{
					pageItemDict["deck-caption"].text = Lang.Get("book_caption_corpsemoved");
				}
				else if (moment.corpseType == Story.CorpseType.Inceptive)
				{
					pageItemDict["deck-caption"].text = Lang.Get("book_caption_corpsegone");
				}
				pageItemDict["sketch-caption"].text = Lang.GetCounted(moment.numCrewPresentAndAlive, "book_caption_others_zero", "book_caption_others_one", "book_caption_others_many");
				RefreshFolio(pageItemDict["folio-deck"].folio, new FolioAddress(BookSpec.FolioSource.DeathDeck, pageSpec.id));
				RefreshFolio(pageItemDict["folio-sketch"].folio, new FolioAddress(BookSpec.FolioSource.DeathSketch, pageSpec.id));
			}
			else if (moment.skeleton)
			{
				pageItemDict["main-crew1-root"].visible = true;
				pageItemDict["main-crew1-fate-button"].visible = true;
				pageItemDict["main-crew1-fate-button"].canSelect = false;
				pageItemDict["main-crew1-title"].text = Lang.Get(moment.locationId0);
				BookSpec.SkeletonCircleSpec skeletonCircleSpec = pageSpec.deathSpec.skeletonCircleSpec;
				if (skeletonCircleSpec != null)
				{
					pageItemDict["main-crew1-skelcircle"].visible = true;
					Transform child = pageItemDict["main-crew1-skelcircle"].rt.GetChild(0);
					child.localRotation = Quaternion.Euler(0f, 0f, skeletonCircleSpec.rot);
					child.localScale = new Vector3(skeletonCircleSpec.flip.x, skeletonCircleSpec.flip.y, 1f);
				}
			}
		}
		else if (pageTemplate.id == BookSpec.TemplateId.Disappear || pageTemplate.id == BookSpec.TemplateId.Disappear2)
		{
			SaveData.DisasterDataRo disasterDataRo = SaveData.it.disasterRo[pageSpec.chapterSpec.disasterId];
			pageItemDict["root"].visible = true;
			if (disasterDataRo.revealedDisappearancesInBook && !mod.HasHiddenPageSpec(pageSpec))
			{
				if (pageTemplate.id == BookSpec.TemplateId.Disappear)
				{
					pageItemDict["disappeared-text"].text = Lang.Get("disappeared_text_" + pageSpec.chapterSpec.disasterId);
				}
				pageItemDict["disappear-left"].visible = true;
				for (int j = 0; j < consts.disappearIds.Length; j++)
				{
					DisappearId disappearId = consts.disappearIds[j];
					if (pageSpec.chapterSpec.disappearCrewIds.Length <= j || !pageItemDict.ContainsKey(disappearId.button))
					{
						continue;
					}
					string text = pageSpec.chapterSpec.disappearCrewIds[j];
					ClueStatus clueStatus = GetClueStatus(text);
					pageItemDict[disappearId.button].visible = true;
					pageItemDict[disappearId.face].sprite = faceLib.Find(text).spriteHi;
					pageItemDict[disappearId.face].material = GetClueFaceMaterial(bookAssets, clueStatus, Graphic.defaultGraphicMaterial);
					pageItemDict[disappearId.bookmark].visible = text == bookmark.crewId;
					SetCrewDifficulty(pageItemDict[disappearId.difficulty], text, clueStatus);
					SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[text];
					if (!(text == mod.hiddenFateCrewId))
					{
						if (faceDataRo.markedCorrect && !mod.HasMaskedCorrectFaceId(faceDataRo.id))
						{
							pageItemDict[disappearId.fate].text = GetCompleteFateSentence(text);
							continue;
						}
						ApplyGuessSpec(pageItemDict[disappearId.guess], pageSpec.chapterSpec.disappearGuessSpecs[j], disappearId.basePos);
						pageItemDict[disappearId.guess].text = GetCompleteFateSentence(text);
					}
				}
			}
		}
		else if (pageTemplate.id == BookSpec.TemplateId.Chapter)
		{
			pageItemDict["numeral"].text = pageSpec.chapterSpec.numeral;
			pageItemDict["title"].text = pageSpec.chapterSpec.name;
			Story.Disaster disaster2 = Story.it.GetDisaster(pageSpec.chapterSpec.disasterId);
			if (disaster2.zone == Story.Zone.Office && SaveData.it.generalRo.era != 3)
			{
				pageItemDict["withheld-button"].visible = true;
			}
			else if (SaveData.it.disasterRo[pageSpec.id].revealedChartInBook && !mod.HasHiddenPageSpec(pageSpec))
			{
				pageItemDict["chart-button"].visible = true;
				RefreshFolio(pageItemDict["folio-chart"].folio, new FolioAddress(BookSpec.FolioSource.ChapterChart, pageSpec.id));
				pageItemDict["sketch"].sprite = bookAssets.GetChapterSketchSprite(pageSpec.chapterSpec.disasterId);
				if (SaveData.it.disasterRo[pageSpec.id].revealedDisappearancesInBook)
				{
					SetChapterTally(disaster2, pageItemDict["chapter-tally"]);
				}
			}
		}
		else if (pageTemplate.id == BookSpec.TemplateId.Glossary)
		{
			for (int k = 0; k < consts.glossaryIds.Length && k < this.spec.glossaryEntries.Count; k++)
			{
				pageItemDict[consts.glossaryIds[k]].text = this.spec.glossaryEntries[k].name;
			}
		}
		else if (pageTemplate.id == BookSpec.TemplateId.Maps)
		{
			RefreshFolio(pageItemDict["folio-chart"].folio, new FolioAddress(BookSpec.FolioSource.GlobalChart, string.Empty));
			RefreshFolio(pageItemDict["folio-deck"].folio, new FolioAddress(BookSpec.FolioSource.GlobalDeck, string.Empty));
		}
		else if (pageTemplate.id != BookSpec.TemplateId.Crew)
		{
			if (pageTemplate.id == BookSpec.TemplateId.Last)
			{
				float num = ((mod.forceFateSealCount < 0) ? SaveData.it.GetNumFatesCorrect() : mod.forceFateSealCount);
				pageItemDict["fateseal"].imageRadialFill = num / (float)Manifest.it.crewCount;
				if (SaveData.it.generalRo.era != 3)
				{
					pageItemDict["fateseal-block"].visible = true;
				}
			}
			else if (pageTemplate.id == BookSpec.TemplateId.FolioDeck)
			{
				PageItem pageItem = pageItemDict["folio-deck"];
				FolioAddress address = folioRemaps["folio-deck"];
				if (refreshMode == RefreshMode.SelectionChanged || refreshMode == RefreshMode.PopupJustClosed)
				{
					pageItem.visible = true;
				}
				else
				{
					RefreshFolio(pageItem.folio, address);
				}
				if (pageItem.folio.hasVisibleMeshPin)
				{
					pageItemDict["arrowshint"].visible = true;
				}
				Story.Moment moment2 = Story.it.GetMoment(selection.itemId);
				if (moment2 != null && SaveData.it.momentRo[moment2.id].visited)
				{
					BookSpec.PageSpec pageSpec2 = this.spec.FindPage(moment2.id);
					pageItemDict["info"].position = new Vector2((!(selection.posInCanvas.x < 0f)) ? (-200) : 200, 140f);
					pageItemDict["moment-title"].text = this.spec.chapterSpecs[moment2.disaster.index].head + "\n" + pageSpec2.runningHeadL;
					pageItemDict["moment-photo"].uvRect = MomentPhotographer.GetUvRect(moment2.index);
				}
			}
			else if (pageTemplate.id == BookSpec.TemplateId.FolioSketch)
			{
				if (refreshMode == RefreshMode.SelectionChanged || refreshMode == RefreshMode.PopupJustClosed)
				{
					pageItemDict["folio-sketch"].visible = true;
				}
				else
				{
					RefreshFolio(pageItemDict["folio-sketch"].folio, folioRemaps["folio-sketch"]);
				}
				if (selection.itemId != null)
				{
					string itemId = selection.itemId;
					SaveData.FaceDataRo faceDataRo2 = SaveData.it.faceRo[itemId];
					FaceLib.Face face = faceLib.Find(itemId);
					if (face != null)
					{
						pageItemDict["face"].sprite = face.spriteHi;
						pageItemDict["face"].material = GetClueFaceMaterial(bookAssets, face.id, Graphic.defaultGraphicMaterial);
						pageItemDict["info"].position = new Vector2((!(selection.posInCanvas.x < 0f)) ? (-230) : 230, 140f);
						string entJob = Manifest.it.GetEntJob(faceDataRo2.id, faceDataRo2.nameId);
						if (!string.IsNullOrEmpty(entJob) && entJob != "crew_job_unknown")
						{
							pageItemDict["job"].text = entJob;
							pageItemDict["job"].font = bookAssets.GetFont(faceDataRo2.markedCorrect);
						}
						if (faceDataRo2.nameId != "unknown" && !faceDataRo2.nameId.Contains("?"))
						{
							pageItemDict["name-root"].visible = true;
							pageItemDict["name-text"].text = Manifest.it.GetEntName(faceDataRo2.id, faceDataRo2.nameId, false);
							pageItemDict["name-text"].font = bookAssets.GetFont(faceDataRo2.markedCorrect);
						}
						if (SaveData.it.HaveVisitedClimax(faceDataRo2.id))
						{
							Manifest.Fate fate = Manifest.it.GetFate(faceDataRo2.fateId);
							if (fate != null && fate.summary.hasValue)
							{
								pageItemDict["name-root"].visible = true;
								pageItemDict["fate-text"].text = Manifest.it.GetFateSummary(faceDataRo2.fateId, faceDataRo2.id, faceDataRo2.nameId);
								pageItemDict["fate-text"].font = bookAssets.GetFont(faceDataRo2.markedCorrect);
							}
						}
					}
				}
			}
			else if (pageTemplate.id == BookSpec.TemplateId.FolioChart)
			{
				if (refreshMode == RefreshMode.SelectionChanged || refreshMode == RefreshMode.PopupJustClosed)
				{
					pageItemDict["folio-chart"].visible = true;
				}
				else
				{
					RefreshFolio(pageItemDict["folio-chart"].folio, folioRemaps["folio-chart"]);
				}
				if (selection.itemId != null)
				{
					Story.Disaster disaster3 = Story.it.GetDisaster(selection.itemId);
					if (disaster3 != null)
					{
						pageItemDict["info"].visible = true;
						pageItemDict["chapter-title"].text = this.spec.chapterSpecs[disaster3.index].head;
						pageItemDict["chapter-sketch"].sprite = bookAssets.GetChapterSketchSprite(disaster3.id);
					}
				}
			}
			else if (pageTemplate.id == BookSpec.TemplateId.Screenplay)
			{
				Story.Moment moment3 = Story.it.GetMoment(screenplayMomentId);
				pageItemDict["title"].text = Lang.Get(moment3.locationId1);
				pageItemDict["photo"].uvRect = MomentPhotographer.GetUvRect(moment3.index);
				DialogLib.Spec spec2 = bookAssets.dialogLib.Find(screenplayMomentId);
				if (spec2 != null)
				{
					string quoteOpen = Lang.Get("quote_open");
					string quoteClose = Lang.Get("quote_close");
					int num2 = 0;
					string speakerId = null;
					StringBuilder stringBuilder = new StringBuilder();
					for (int l = 0; l < spec2.pages.Count; l++)
					{
						DialogLib.Page page = spec2.pages[l];
						speakerId = page.speakerId;
						if (l > 0 && page.speakerId != spec2.pages[l - 1].speakerId && stringBuilder.Length > 0)
						{
							SetScreenplayLine(pageItemDict, moment3.id, spec2.pages[l - 1].speakerId, num2, stringBuilder, quoteOpen, quoteClose);
							num2++;
							if (num2 >= consts.dialogLineMainIds.Length)
							{
								break;
							}
						}
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(" • ");
						}
						stringBuilder.Append(page.screenplayText);
					}
					if (stringBuilder.Length > 0 && num2 < consts.dialogLineMainIds.Length)
					{
						SetScreenplayLine(pageItemDict, moment3.id, speakerId, num2, stringBuilder, quoteOpen, quoteClose);
					}
				}
			}
			else if (pageTemplate.id == BookSpec.TemplateId.ScrollableManifest)
			{
				for (int m = 0; m < Manifest.it.crewCount; m++)
				{
					string crewId = Manifest.it.GetCrewId(m);
					SaveData.FaceData faceData = SaveData.it.FindFaceDataForNameId(crewId);
					if (faceData != null)
					{
						pageItemDict[crewId].font = ((!faceData.markedCorrect) ? bookAssets.guessFont : bookAssets.finalFont);
						pageItemDict[crewId].text = Manifest.it.GetFateSummary(faceData.fateId, faceData.id, faceData.nameId);
						if (faceData.markedCorrect)
						{
							pageItemDict[crewId + "-check"].visible = true;
						}
					}
					else
					{
						pageItemDict[crewId].text = string.Empty;
					}
				}
			}
			else if (pageTemplate.id == BookSpec.TemplateId.Message)
			{
				if (mod.message.HasValue())
				{
					pageItemDict["message"].text = mod.message;
				}
				if (mod.messageIcon != null)
				{
					pageItemDict["icon"].sprite = mod.messageIcon;
				}
			}
		}
		if (bookmark.valid && pageItemDict.ContainsKey("bookmark-gol"))
		{
			Bookmark.Pos pos = bookmark.markedPages[pageSpec.index];
			if ((pos & Bookmark.Pos.GoL) != Bookmark.Pos.None)
			{
				pageItemDict["bookmark-gol"].visible = true;
			}
			if ((pos & Bookmark.Pos.GoR) != Bookmark.Pos.None)
			{
				pageItemDict["bookmark-gor"].visible = true;
			}
			if ((pos & Bookmark.Pos.PinL) != Bookmark.Pos.None)
			{
				pageItemDict["bookmark-pinl"].visible = true;
			}
			if ((pos & Bookmark.Pos.PinR) != Bookmark.Pos.None)
			{
				pageItemDict["bookmark-pinr"].visible = true;
			}
		}
		pageTemplate.EndRefresh();
	}

	private void SetScreenplayLine(Dictionary<string, PageItem> items, string momentId, string speakerId, int speakerIndex, StringBuilder builder, string quoteOpen, string quoteClose)
	{
		if (speakerId.HasValue())
		{
			builder.Insert(0, quoteOpen);
			builder.Append(quoteClose);
			Story.Climax climax = Story.it.GetClimax(speakerId);
			if (climax != null && climax.type == Story.ClimaxType.Die && climax.deathMomentIdOrDisasterId == momentId)
			{
				items[consts.dialogLineMarkIds[speakerIndex]].visible = true;
			}
		}
		items[consts.dialogLineMainIds[speakerIndex]].visible = true;
		items[consts.dialogLineTextIds[speakerIndex]].text = builder.ToString();
		builder.Length = 0;
	}

	private void SetCrewFateUi(string crewId, PageItem fateItem, PageItem fateButtonItem, PageItem guessItem, PageItem faceItem, PageItem faceBorderItem, PageItem difficultyItem, BookSpec.PageSpec pageSpec, BookSpec.GuessSpec guessSpec, Vector2 guessBasePos)
	{
		fateButtonItem.visible = true;
		fateButtonItem.canSelect = true;
		SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[crewId];
		if (faceDataRo.id == mod.hiddenFateCrewId)
		{
			fateItem.visible = false;
			fateButtonItem.textFitterEnabled = false;
		}
		else if (faceDataRo.markedCorrect && !mod.HasMaskedCorrectFaceId(faceDataRo.id))
		{
			fateItem.text = GetCompleteFateSentence(crewId);
			fateItem.textFitterEnabled = true;
			fateButtonItem.textFitterEnabled = true;
		}
		else
		{
			ApplyGuessSpec(guessItem, guessSpec, guessBasePos);
			guessItem.text = GetCompleteFateSentence(crewId);
			guessItem.textUnveilT = ((!mod.HasHiddenGuessPageSpec(pageSpec)) ? 1f : 0f);
			fateButtonItem.textFitterEnabled = false;
		}
		FaceLib.Face face = faceLib.Find(crewId);
		if (face != null)
		{
			ClueStatus clueStatus = GetClueStatus(face.id);
			faceItem.sprite = face.spriteHi;
			faceItem.material = GetClueFaceMaterial(bookAssets, clueStatus, Graphic.defaultGraphicMaterial);
			faceBorderItem.visible = true;
			SetCrewDifficulty(difficultyItem, face.id, clueStatus);
		}
	}

	private void SetCrewDifficulty(PageItem difficultyItem, string crewId, ClueStatus clueStatus)
	{
		SetCrewDifficulty(bookAssets, difficultyItem, crewId, clueStatus);
	}

	public static void SetCrewDifficulty(BookAssets assets, PageItem difficultyItem, string crewId, ClueStatus clueStatus)
	{
		Manifest.Crew crew = Manifest.it.GetCrew(crewId);
		if (crew != null && clueStatus == ClueStatus.Seen && !SaveData.it.faceRo[crewId].markedCorrect && (int)crew.difficulty < assets.difficultySprites.Count)
		{
			difficultyItem.childSprite = assets.difficultySprites[(int)crew.difficulty];
		}
	}

	private void SetChapterTally(Story.Disaster disaster, PageItem tallyItem)
	{
		RectTransform rt = tallyItem.rt;
		tallyItem.visible = true;
		int numDead = disaster.numDead;
		int numDisappear = disaster.numDisappear;
		int num = ((!(mod.forceChapterTallyId == disaster.id)) ? (-1) : mod.forceChapterTallyCount);
		int num2 = numDead + numDisappear;
		for (int i = 0; i < num2 && i < rt.childCount; i++)
		{
			Image component = rt.GetChild(i).GetComponent<Image>();
			if (!(component == null))
			{
				component.gameObject.SetActive(true);
				if (num < 0 || i < num)
				{
					component.sprite = bookAssets.GetFolioIconSprite((i >= numDead) ? "Disappear" : "Skull");
				}
				else
				{
					component.sprite = null;
				}
			}
		}
		for (int j = num2; j < rt.childCount; j++)
		{
			rt.GetChild(j).gameObject.SetActive(false);
		}
	}

	public static bool GetCrewShowingDifficulty(string crewId)
	{
		Manifest.Crew crew = Manifest.it.GetCrew(crewId);
		ClueStatus clueStatus = GetClueStatus(crewId);
		return crew != null && clueStatus == ClueStatus.Seen && !SaveData.it.faceRo[crewId].markedCorrect;
	}

	public bool ValidatePopup(PageTemplate pageTemplate)
	{
		return true;
	}

	private static void ApplyGuessSpec(PageItem pageItem, BookSpec.GuessSpec guessSpec, Vector2 basePos)
	{
		pageItem.position = basePos + guessSpec.offset;
		pageItem.rotation = guessSpec.rot;
		pageItem.width = guessSpec.width;
	}

	private void RefreshFolio(Folio folio, FolioAddress address)
	{
		folio.BeginRefresh();
		if (address.source == BookSpec.FolioSource.DeathDeck)
		{
			folio.SetFocusPin(address.pageId);
			folio.ShowPin("back");
			Story.Moment moment = Story.it.GetMoment(address.pageId);
			SaveData.MomentDataRo momentDataRo = SaveData.it.momentRo[moment.id];
			if (momentDataRo.visited)
			{
				Bookmark.Moment moment2 = bookmark.markedMoments[moment.index];
				if (bookmark.valid && moment2 != Bookmark.Moment.None)
				{
					folio.ShowPin(moment.id, bookAssets.GetFolioIconSprite("BookmarkSkull"));
				}
				else
				{
					folio.ShowPin(moment.id);
				}
				if (moment.corpseType == Story.CorpseType.Inceptive)
				{
					for (int i = moment.index; i < Story.it.momentCount - 1; i++)
					{
						Story.Moment moment3 = Story.it.GetMoment(i);
						Story.Moment moment4 = Story.it.GetMoment(i + 1);
						if (folio.includeMeshPins)
						{
							folio.ShowPin(moment3.id + "_" + moment4.id);
						}
						folio.ShowPin(moment4.id);
						if (moment4.corpseType != Story.CorpseType.Inceptive)
						{
							break;
						}
					}
				}
			}
			if (Player.instance != null)
			{
				Navigator.Mark navigatorMark = Player.instance.GetNavigatorMark();
				if (navigatorMark.valid)
				{
					folio.ShowPin("player", navigatorMark.pos, navigatorMark.dir);
				}
			}
		}
		else if (address.source == BookSpec.FolioSource.GlobalDeck)
		{
			Story.Moment moment5 = null;
			SaveData.MomentDataRo momentDataRo2 = null;
			folio.ShowPin("back");
			for (int j = 0; j < Story.it.momentCount; j++)
			{
				Story.Moment moment6 = moment5;
				SaveData.MomentDataRo momentDataRo3 = momentDataRo2;
				moment5 = Story.it.GetMoment(j);
				momentDataRo2 = SaveData.it.momentRo[moment5.id];
				if (momentDataRo2.visited)
				{
					Bookmark.Moment moment7 = bookmark.markedMoments[moment5.index];
					if (bookmark.valid && moment7 != Bookmark.Moment.None)
					{
						folio.ShowPin(moment5.id, bookAssets.GetFolioIconSprite((moment7 != Bookmark.Moment.Skull) ? "BookmarkCross" : "BookmarkSkull"));
					}
					else
					{
						folio.ShowPin(moment5.id, bookAssets.GetFolioIconSprite("Cross"));
					}
					if (folio.includeMeshPins && momentDataRo3 != null && moment6.disaster == moment5.disaster && (momentDataRo3.visited || (momentDataRo3.unlocked && Game.isExploring)))
					{
						folio.ShowPin(moment6.id + "_" + moment5.id);
					}
				}
				else if (momentDataRo2.unlocked && Game.isExploring)
				{
					folio.ShowPin(moment5.id, bookAssets.GetFolioIconSprite("UnlockedUnvisited"));
				}
			}
			if (Player.instance != null)
			{
				Navigator.Mark navigatorMark2 = Player.instance.GetNavigatorMark();
				if (navigatorMark2.valid)
				{
					folio.ShowPin("player", navigatorMark2.pos, navigatorMark2.dir);
					folio.SetFocusPin("player");
				}
			}
		}
		else if (address.source == BookSpec.FolioSource.FocusDeck)
		{
			Story.Moment moment8 = null;
			SaveData.MomentDataRo momentDataRo4 = null;
			string text = string.Empty;
			folio.ShowPin("back");
			for (int k = 0; k < Story.it.momentCount; k++)
			{
				Story.Moment moment9 = moment8;
				SaveData.MomentDataRo momentDataRo5 = momentDataRo4;
				moment8 = Story.it.GetMoment(k);
				momentDataRo4 = SaveData.it.momentRo[moment8.id];
				if (momentDataRo4.visited && moment8.IsPresent(focusDeckCrewId))
				{
					Bookmark.Moment moment10 = bookmark.markedMoments[moment8.index];
					if (bookmark.valid && moment10 != Bookmark.Moment.None)
					{
						folio.ShowPin(moment8.id, bookAssets.GetFolioIconSprite((moment10 != Bookmark.Moment.Skull || !(focusDeckCrewId == bookmark.crewId)) ? "BookmarkCross" : "BookmarkSkull"));
					}
					else
					{
						folio.ShowPin(moment8.id, bookAssets.GetFolioIconSprite((Array.IndexOf(moment8.dieCrewIds, focusDeckCrewId) < 0) ? "Cross" : "Skull"));
					}
					if (folio.includeMeshPins && momentDataRo5 != null && momentDataRo5.visited && moment9.disaster == moment8.disaster && moment9.IsPresent(focusDeckCrewId))
					{
						folio.ShowPin(moment9.id + "_" + moment8.id);
					}
				}
			}
			if (Story.it.GetMoment(address.pageId) != null)
			{
				text = address.pageId;
			}
			if (Player.instance != null)
			{
				Navigator.Mark navigatorMark3 = Player.instance.GetNavigatorMark();
				if (navigatorMark3.valid)
				{
					folio.ShowPin("player", navigatorMark3.pos, navigatorMark3.dir);
					if (!text.HasValue())
					{
						text = "player";
					}
				}
			}
			if (text.HasValue())
			{
				folio.SetFocusPin(text);
			}
		}
		else if (address.source == BookSpec.FolioSource.DeathSketch)
		{
			Story.Moment moment11 = Story.it.GetMoment(address.pageId);
			string text2 = null;
			if (moment11.deathType == Story.DeathType.Other)
			{
				foreach (KeyValuePair<string, Story.Zest> zest in moment11.zests)
				{
					Story.Zest value = zest.Value;
					if (value == Story.Zest.Alive)
					{
						text2 = zest.Key;
						break;
					}
				}
			}
			else
			{
				text2 = moment11.dieCrewIds[0];
			}
			if (text2 != null)
			{
				folio.SetFocusPin(text2);
			}
			folio.ShowPin("back-blur");
			if (bookmark.valid)
			{
				folio.ShowPin(bookmark.crewId + "-bookmark");
			}
			foreach (KeyValuePair<string, Story.Zest> zest2 in moment11.zests)
			{
				Story.Zest value2 = zest2.Value;
				if (value2 == Story.Zest.Alive || value2 == Story.Zest.Die)
				{
					folio.ShowPin(zest2.Key);
				}
			}
		}
		else if (address.source == BookSpec.FolioSource.GlobalSketch)
		{
			if (Manifest.it.GetCrewIndex(address.pageId) >= 0)
			{
				folio.SetFocusPin(address.pageId);
			}
			folio.ShowPin("back");
			if (bookmark.valid)
			{
				folio.ShowPin(bookmark.crewId + "-bookmark");
			}
			for (int l = 0; l < Manifest.it.crewCount; l++)
			{
				folio.ShowPin(Manifest.it.GetCrewId(l));
			}
		}
		else if (address.source == BookSpec.FolioSource.GlobalChart || address.source == BookSpec.FolioSource.ChapterChart)
		{
			bool flag = address.source == BookSpec.FolioSource.ChapterChart;
			folio.ShowPin("back");
			folio.SetFocusPin(address.pageId);
			Story.Disaster disaster = null;
			bool flag2 = false;
			for (int m = 0; m < Story.it.disasterCount; m++)
			{
				Story.Disaster disaster2 = disaster;
				bool flag3 = flag2;
				disaster = Story.it.GetDisaster(m);
				flag2 = SaveData.it.HaveVisitedDisaster(disaster.id) || SaveData.it.disasterRo[disaster.id].revealedChartInBook;
				bool flag4 = flag && disaster.id == address.pageId;
				if (flag2)
				{
					folio.ShowPin(disaster.id);
					if (disaster2 != null && flag3)
					{
						folio.ShowPin(disaster2.id + "_" + disaster.id);
					}
				}
				if (flag4)
				{
					break;
				}
			}
		}
		folio.EndRefresh();
	}

	private static string GetCompleteFateSentence(string faceId)
	{
		SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[faceId];
		if (faceDataRo.isTotallyUnknown)
		{
			return Lang.Get((Story.it.GetClimaxType(faceId) != Story.ClimaxType.Die) ? "fate_unknown_disappear" : "fate_unknown_die");
		}
		return Manifest.it.GetFateSentenceComplete(faceDataRo.fateId, faceDataRo.id, faceDataRo.nameId);
	}

	private static bool InOrHaveVisitedMoment(string momentId)
	{
		return momentId.Length == 1 || SaveData.it.HaveVisitedMoment(momentId) || Game.IsInMoment(momentId);
	}

	private static string Pop(string[] tokens, ref int index)
	{
		if (index >= tokens.Length)
		{
			return null;
		}
		string result = tokens[index];
		index++;
		return result;
	}

	private static bool Eval(string[] tokens, ref int index)
	{
		string text = Pop(tokens, ref index);
		if (text == "|")
		{
			bool flag = Eval(tokens, ref index);
			bool flag2 = Eval(tokens, ref index);
			return flag || flag2;
		}
		if (text == "&")
		{
			bool flag3 = Eval(tokens, ref index);
			bool flag4 = Eval(tokens, ref index);
			return flag3 && flag4;
		}
		return InOrHaveVisitedMoment(text);
	}

	private static bool Eval(string[] tokens)
	{
		int index = 0;
		return Eval(tokens, ref index);
	}

	public static ClueStatus GetClueStatus(string faceId)
	{
		SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[faceId];
		if (faceDataRo == null || faceDataRo.markedCorrect)
		{
			return ClueStatus.Ignore;
		}
		string[] crewClueMomentIds = Manifest.it.GetCrewClueMomentIds(faceId);
		if (crewClueMomentIds == null)
		{
			return ClueStatus.Ignore;
		}
		if (Eval(crewClueMomentIds))
		{
			return ClueStatus.Seen;
		}
		return ClueStatus.NotYet;
	}

	public static Material GetClueFaceMaterial(BookAssets bookAssets, ClueStatus clueStatus, Material defaultMaterial = null)
	{
		if (clueStatus == ClueStatus.NotYet)
		{
			return bookAssets.faceBlurMaterial;
		}
		return defaultMaterial;
	}

	public static Material GetClueFaceMaterial(BookAssets bookAssets, string faceId, Material defaultMaterial = null)
	{
		ClueStatus clueStatus = GetClueStatus(faceId);
		if (clueStatus == ClueStatus.NotYet)
		{
			return bookAssets.faceBlurMaterial;
		}
		return defaultMaterial;
	}
}
