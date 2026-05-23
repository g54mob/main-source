using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FateEditor
{
	private enum Mode
	{
		Muster = 0,
		Face = 1
	}

	public enum Action
	{
		None = 0,
		GoDeath = 1,
		GoSketch = 2,
		GoFocusDeck = 3,
		GoFirst = 4,
		Bookmark = 5,
		RemoveBookmark = 6,
		IgnoreNoClues = 7,
		ExplainFaceBlur = 8
	}

	public enum TakeOverResult
	{
		None = 0,
		TakingOverBook = 1
	}

	private delegate void OnFaceClueWarningDone(bool applySelection);

	private class FaceClueWarningInfo
	{
		public string faceId;

		public OnFaceClueWarningDone onFaceClueWarningDone;

		public FaceClueWarningInfo(string faceId_, OnFaceClueWarningDone onFaceClueWarningDone_)
		{
			faceId = faceId_;
			onFaceClueWarningDone = onFaceClueWarningDone_;
		}
	}

	private Mode mode;

	private FaceLib faceLib;

	private Book book;

	private Bookmark bookmark;

	private SaveData.FaceData faceData;

	private BookContent.Mod bookContentMod;

	public const int kCorrectGroupMaxSize = 3;

	public FateEditor(FaceLib faceLib_, Book book_, Bookmark bookmark_, BookContent.Mod bookContentMod_)
	{
		faceLib = faceLib_;
		book = book_;
		bookmark = bookmark_;
		bookContentMod = bookContentMod_;
	}

	public void OpenFromFace(string faceId)
	{
		mode = Mode.Face;
		faceData = SaveData.it.face[faceId];
		book.OpenPopup("EditFate");
	}

	public void OpenFromMuster(string nameId)
	{
		mode = Mode.Muster;
		faceData = SaveData.it.FindFaceDataForNameId(nameId);
		if (faceData != null)
		{
			book.OpenPopup("EditFate");
		}
		else
		{
			book.ChooseFace(nameId, OnFaceChosenFirstTime);
		}
	}

	private void ApplyFaceChosen(FaceChooser.Choice choice, bool firstTime)
	{
		if (mode != Mode.Muster)
		{
			return;
		}
		ShowFaceClueWarning(choice.faceId, delegate(bool applySelection)
		{
			if (applySelection)
			{
				book.ClosePopupsUntil("EditFate");
				book.audioKit.Play("tap");
				SaveData.FaceData faceData = SaveData.it.FindFaceDataForNameId(choice.nameId);
				if (faceData != null)
				{
					faceData.nameId = "unknown";
				}
				this.faceData = SaveData.it.face[choice.faceId];
				this.faceData.nameId = choice.nameId;
				if (UpdateFateGuesses() == TakeOverResult.None)
				{
					book.OpenPopup("EditFate");
				}
			}
		});
	}

	private void OnFaceChosen(FaceChooser.Choice choice)
	{
		ApplyFaceChosen(choice, false);
	}

	private void OnFaceChosenFirstTime(FaceChooser.Choice choice)
	{
		ApplyFaceChosen(choice, true);
	}

	public void Refresh(Dictionary<string, PageItem> items)
	{
		BookContent.ClueStatus clueStatus = BookContent.ClueStatus.Seen;
		FaceLib.Face face = faceLib.Find(faceData.id);
		if (face != null)
		{
			clueStatus = BookContent.GetClueStatus(face.id);
			items["face"].sprite = face.spriteHi;
			items["face"].material = BookContent.GetClueFaceMaterial(book.assets, clueStatus, Graphic.defaultGraphicMaterial);
		}
		bool flag = SaveData.it.HaveVisitedClimax(faceData.id);
		if (flag)
		{
			items["right"].visible = true;
			string[] fateSentenceParts = Manifest.it.GetFateSentenceParts(faceData.fateId, faceData.id, faceData.nameId);
			bool flag2 = faceData.markedCorrect && !bookContentMod.HasMaskedCorrectFaceId(faceData.id);
			if (fateSentenceParts.Length > 0)
			{
				items["part0"].text = fateSentenceParts[0];
				items["part0"].canSelect = mode == Mode.Face && !flag2;
				items["part0"].font = book.assets.GetFont(flag2);
			}
			if (fateSentenceParts.Length > 1)
			{
				items["part1"].text = fateSentenceParts[1];
				items["part1"].canSelect = flag && !flag2;
				items["part1"].font = book.assets.GetFont(flag2);
			}
			if (fateSentenceParts.Length > 2)
			{
				items["part2"].text = fateSentenceParts[2];
				items["part2"].canSelect = !flag2;
				items["part2"].font = book.assets.GetFont(flag2);
			}
			items["checkmark"].visible = flag2;
			if (mode == Mode.Face && !flag2 && clueStatus != BookContent.ClueStatus.NotYet && SaveData.it.generalRo.helpedBookFaceClear)
			{
				items["hint-holder"].visible = true;
			}
		}
		else if (SaveData.it.HaveVisitedThisManyMoments(1))
		{
			items["button-name"].text = Manifest.it.GetEntName(faceData.id, faceData.nameId, true);
			items["button-name"].canSelect = mode == Mode.Face;
		}
		BookContent.SetCrewDifficulty(book.assets, items["difficulty"], faceData.id, clueStatus);
		items["button-face"].visible = true;
		items["button-face"].canSelect = mode == Mode.Muster && !faceData.markedCorrect;
		if (bookmark.valid && bookmark.crewId == faceData.id)
		{
			items["bookmark"].visible = true;
		}
		BookSpec.AppearanceSummary appearanceSummary = bookmark.GetAppearanceSummary(faceData.id);
		if (appearanceSummary.count > 0)
		{
			items["memories-divider"].visible = true;
			items["button-memories"].text = Lang.GetCounted(appearanceSummary.count, "memories_zero", "memories_one", "memories_many");
		}
	}

	public void OnPageButtonClick(string actionId)
	{
		switch (actionId)
		{
		case "edit-face":
			EditFace();
			break;
		case "edit-name":
			EditPart(0);
			break;
		case "edit-memories":
			EditMemories();
			break;
		case "edit-part0":
			EditPart(0);
			break;
		case "edit-part1":
			EditPart(1);
			break;
		case "edit-part2":
			EditPart(2);
			break;
		case "show-help":
			ShowHelp(faceData.id);
			break;
		}
	}

	private void EditFace()
	{
		book.ChooseFace(faceData.nameId, OnFaceChosen);
	}

	private void EditMemories()
	{
		if (!book.inTutorial && !SaveData.it.generalRo.helpedBookBookmarks && !LocReview.active)
		{
			book.RunTutorial(BookTut.Kind.Bookmarks, faceData.id);
			return;
		}
		Bookmark.Destiny destiny = bookmark.GetDestiny(faceData.id);
		int count = destiny.appearanceSummary.count;
		Manifest.Gender crewGender = Manifest.it.GetCrewGender(faceData.id);
		if (count > 0)
		{
			string title_ = Manifest.ApplyGender(Lang.GetCounted(count, string.Empty, "bookmarked_title_one", "bookmarked_title_many"), crewGender);
			ListPanel.Spec spec = new ListPanel.Spec(OnFaceBookmarked, title_, destiny);
			spec.alignments = new TextAnchor[2]
			{
				TextAnchor.MiddleLeft,
				TextAnchor.MiddleRight
			};
			FaceLib.Face face = faceLib.Find(faceData.id);
			if (face != null)
			{
				spec.SetBanner(face.spriteHi, "Circle", 0.75f, BookContent.GetClueFaceMaterial(book.assets, faceData.id));
			}
			spec.items.Add(new ListPanel.Item(new string[2]
			{
				Manifest.ApplyGender(Lang.Get("bookmarked_first"), crewGender),
				destiny.appearanceSummary.pageNum0.ToString()
			}, Action.GoFirst));
			if (destiny.pageSpec != null && destiny.pageSpec.revealed)
			{
				spec.items.Add(new ListPanel.Item(new string[2] { destiny.description, destiny.pageNumStr }, Action.GoDeath));
			}
			spec.items.Add(new ListPanel.Item(string.Empty));
			spec.items.Add(new ListPanel.Item(new string[2]
			{
				Lang.Get("bookmarked_godeck"),
				string.Empty
			}, Action.GoFocusDeck));
			spec.items.Add(new ListPanel.Item(new string[2]
			{
				Manifest.ApplyGender(Lang.Get("bookmarked_gosketch", "$sketch", Lang.Get(Manifest.it.GetCrewSketchId(face.id))), crewGender),
				string.Empty
			}, Action.GoSketch));
			spec.items.Add(new ListPanel.Item(string.Empty));
			if (bookmark.valid && bookmark.crewId == faceData.id)
			{
				spec.items.Add(new ListPanel.Item(Lang.Get("bookmarked_clear"), Action.RemoveBookmark));
			}
			else
			{
				spec.items.Add(new ListPanel.Item(Lang.Get("bookmarked_mark"), Action.Bookmark));
			}
			book.OpenList(spec);
		}
		else
		{
			ListPanel.Spec spec2 = new ListPanel.Spec(OnFaceBookmarked, Manifest.ApplyGender(Lang.Get("bookmarked_unknown"), crewGender), destiny);
			FaceLib.Face face2 = faceLib.Find(faceData.id);
			if (face2 != null)
			{
				spec2.SetBanner(face2.spriteHi, "Circle", 0.75f, BookContent.GetClueFaceMaterial(book.assets, faceData.id));
			}
			spec2.items.Add(new ListPanel.Item(Manifest.ApplyGender(Lang.Get("bookmarked_gosketch", "$sketch", Lang.Get(Manifest.it.GetCrewSketchId(face2.id))), crewGender), Action.GoSketch));
			book.OpenList(spec2);
		}
	}

	private void OnFaceBookmarked(ListPanel.Spec spec, ListPanel.Item item)
	{
		if (item != null)
		{
			Bookmark.Destiny destiny = spec.data as Bookmark.Destiny;
			switch ((Action)item.data)
			{
			case Action.GoDeath:
				book.GoToPage(destiny.pageSpec);
				break;
			case Action.GoSketch:
				book.ShowInSketch(destiny.crewId);
				break;
			case Action.GoFirst:
				book.GoToPage(destiny.appearanceSummary.pageSpec0);
				break;
			case Action.GoFocusDeck:
				book.ShowFocusDeck(faceData.id);
				break;
			case Action.Bookmark:
				bookmark.MarkCrewMember(destiny.crewId);
				break;
			case Action.RemoveBookmark:
				bookmark.Clear();
				break;
			}
		}
	}

	private void ShowFaceClueWarning(string clueFaceId, OnFaceClueWarningDone onFaceClueWarningDone)
	{
		SaveData.FaceData faceData = SaveData.it.face[clueFaceId];
		BookContent.ClueStatus clueStatus = BookContent.GetClueStatus(clueFaceId);
		if (faceData != null && faceData.clueWarning != -1 && clueStatus == BookContent.ClueStatus.NotYet)
		{
			if (mode == Mode.Face && !SaveData.it.generalRo.helpedBookFaceBlur && faceData.nameId == "unknown")
			{
				book.RunTutorial(BookTut.Kind.FaceBlur, faceData.id);
				return;
			}
			ListPanel.Spec spec = new ListPanel.Spec(OnListItemSelectFaceClueWarning, Lang.Get(((faceData.clueWarning & 1) != 0) ? "noclues_title1" : "noclues_title0"));
			spec.data = new FaceClueWarningInfo(clueFaceId, onFaceClueWarningDone);
			spec.items.Add(new ListPanel.Item(Lang.Get("noclues_cancel")));
			if (mode == Mode.Face)
			{
				spec.items.Add(new ListPanel.Item(Lang.Get("noclues_explain"), Action.ExplainFaceBlur));
			}
			spec.items.Add(new ListPanel.Item(Lang.Get("noclues_continue"), Action.IgnoreNoClues));
			spec.selectedIndex = 0;
			book.OpenList(spec);
			faceData.clueWarning++;
			return;
		}
		if (mode == Mode.Face && clueStatus == BookContent.ClueStatus.Seen && faceData.nameId == "unknown")
		{
			if (!SaveData.it.generalRo.helpedBookFaceClear)
			{
				book.RunTutorial(BookTut.Kind.FaceClear, faceData.id);
				return;
			}
			if (!SaveData.it.generalRo.helpedBookDifficulty)
			{
				Manifest.Crew crew = Manifest.it.GetCrew(clueFaceId);
				if (crew != null && crew.difficulty == Manifest.Difficulty.Hard)
				{
					book.RunTutorial(BookTut.Kind.Difficulty, faceData.id);
					return;
				}
			}
		}
		if (onFaceClueWarningDone != null)
		{
			onFaceClueWarningDone(true);
		}
	}

	private void OnListItemSelectFaceClueWarning(ListPanel.Spec spec, ListPanel.Item item)
	{
		if (item == null || item.data == null)
		{
			return;
		}
		FaceClueWarningInfo faceClueWarningInfo = (FaceClueWarningInfo)spec.data;
		if ((Action)item.data == Action.IgnoreNoClues)
		{
			if (faceClueWarningInfo.onFaceClueWarningDone != null)
			{
				faceClueWarningInfo.onFaceClueWarningDone(true);
			}
		}
		else if ((Action)item.data == Action.ExplainFaceBlur)
		{
			book.RunTutorial(BookTut.Kind.FaceBlur, faceData.id);
		}
		else if (faceClueWarningInfo.onFaceClueWarningDone != null)
		{
			faceClueWarningInfo.onFaceClueWarningDone(false);
		}
	}

	private void ShowHelp(string faceId)
	{
		if (mode == Mode.Face)
		{
			if (BookContent.GetClueStatus(faceId) == BookContent.ClueStatus.Seen)
			{
				ListPanel.Spec spec = new ListPanel.Spec(OnExplainSelected, Lang.Get("help_title_heading"), faceId);
				spec.alignments = new TextAnchor[2]
				{
					TextAnchor.MiddleLeft,
					TextAnchor.MiddleRight
				};
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Lang.Get("help_title_deducing"),
					"..."
				}, BookTut.Kind.FaceClear));
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Lang.Get("help_title_difficulty"),
					"..."
				}, BookTut.Kind.Difficulty, false, !SaveData.it.generalRo.helpedBookDifficulty));
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Lang.Get("help_title_fatescheck"),
					"..."
				}, BookTut.Kind.FatesCheck, false, !SaveData.it.generalRo.helpedBookFatesCheck));
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Lang.Get("help_title_usingbook"),
					"..."
				}, BookTut.Kind.BookUsage));
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Lang.Get("help_title_bookmarks"),
					"..."
				}, BookTut.Kind.Bookmarks));
				book.OpenList(spec);
			}
			else
			{
				book.RunTutorial(BookTut.Kind.FaceBlur, faceId);
			}
		}
	}

	private void OnExplainSelected(ListPanel.Spec spec, ListPanel.Item item)
	{
		string text = (string)spec.data;
		if (item != null && text != null)
		{
			BookTut.Kind kind = (BookTut.Kind)item.data;
			book.RunTutorial(kind, text);
		}
	}

	private void EditPart(int partIndex)
	{
		Manifest.Fate fate = Manifest.it.GetFate(faceData.fateId);
		if (fate == null || partIndex >= fate.sentenceParts.Length)
		{
			return;
		}
		Manifest.SentencePart sentencePart = fate.sentenceParts[partIndex];
		if (sentencePart.isSubject)
		{
			if (mode != Mode.Face)
			{
				return;
			}
			ShowFaceClueWarning(faceData.id, delegate(bool applySelection)
			{
				if (applySelection)
				{
					ListPanel.Spec spec2 = new ListPanel.Spec(OnListItemSelectSubject, string.Empty);
					foreach (Manifest.Ent item in Manifest.it.IterateEnts(true))
					{
						bool strike_ = false;
						if (item.crew != null)
						{
							SaveData.FaceData faceData = SaveData.it.FindFaceDataForNameId(item.crew.id);
							if (faceData != null)
							{
								if (faceData.markedCorrect)
								{
									continue;
								}
								if (item.crew.id != this.faceData.nameId)
								{
									strike_ = true;
								}
							}
						}
						else if (item.id.StartsWith("?") && SaveData.it.GetCrewCategoryIsSolved(item.id))
						{
							continue;
						}
						spec2.items.Add(new ListPanel.Item(item.listColumns.Get(item.gender, item.gender), item, strike_));
						if (item.id == this.faceData.nameId)
						{
							spec2.selectedIndex = spec2.items.Count - 1;
						}
					}
					book.OpenList(spec2);
				}
			});
		}
		else if (sentencePart.isKiller)
		{
			string text = Manifest.FateId_KillerId(faceData.fateId);
			ListPanel.Spec spec = new ListPanel.Spec(OnListItemSelectedKiller, string.Empty);
			foreach (Manifest.Ent item2 in Manifest.it.IterateEnts(false))
			{
				if (item2.crew == null || !(item2.id == faceData.nameId))
				{
					bool grey_ = false;
					spec.items.Add(new ListPanel.Item(item2.listColumns.Get(item2.gender, item2.gender), item2, false, grey_));
					if (item2.id == text)
					{
						spec.selectedIndex = spec.items.Count - 1;
					}
				}
			}
			book.OpenList(spec);
		}
		else
		{
			if (!sentencePart.isBody)
			{
				return;
			}
			Manifest.FateNode fateNode = Manifest.it.FindFateNode(fate);
			if (fateNode != null)
			{
				while (fateNode.parent != null && fateNode.parent.parent != null)
				{
					fateNode = fateNode.parent;
				}
				OpenFateNodeList(fateNode.parent);
			}
		}
	}

	private void OnListItemSelectSubject(ListPanel.Spec spec, ListPanel.Item item)
	{
		if (item == null || mode != Mode.Face)
		{
			return;
		}
		Manifest.Ent ent = item.data as Manifest.Ent;
		if (ent == null)
		{
			return;
		}
		if (ent.crew != null)
		{
			string id = ent.id;
			SaveData.FaceData faceData = SaveData.it.FindFaceDataForNameId(id);
			if (faceData != null && faceData.id != this.faceData.id)
			{
				faceData.nameId = string.Empty;
			}
			this.faceData.nameId = id;
			this.faceData.fateId = Manifest.it.FateId_ScrubSelfKiller(this.faceData.nameId, this.faceData.fateId);
		}
		else
		{
			this.faceData.nameId = ent.id;
		}
		book.audioKit.Play("scribble");
		UpdateFateGuesses();
	}

	private void OpenFateNodeList(Manifest.FateNode parentFateNode, Manifest.FateNode overrideSelectedFateNode = null)
	{
		if (parentFateNode == null)
		{
			return;
		}
		Manifest.Fate fate = Manifest.it.GetFate(faceData.fateId);
		Manifest.Gender entGender = Manifest.it.GetEntGender(faceData.nameId, Manifest.it.GetEntGender(faceData.id));
		Manifest.Gender entGender2 = Manifest.it.GetEntGender(Manifest.FateId_KillerId(faceData.fateId));
		ListPanel.Spec spec = new ListPanel.Spec(OnListItemSelectedBody, parentFateNode.name.Get(entGender, entGender2), parentFateNode);
		spec.alignments = new TextAnchor[3]
		{
			TextAnchor.MiddleLeft,
			TextAnchor.MiddleCenter,
			TextAnchor.MiddleRight
		};
		spec.manualBackHandling = !parentFateNode.isRoot;
		foreach (Manifest.FateNode node in parentFateNode.nodes)
		{
			spec.items.Add(new ListPanel.Item(node.listColumns.Get(entGender, entGender2), node));
			if (overrideSelectedFateNode != null)
			{
				if (node == overrideSelectedFateNode)
				{
					spec.selectedIndex = spec.items.Count - 1;
				}
			}
			else if (node.FindInTree(fate) != null)
			{
				spec.selectedIndex = spec.items.Count - 1;
			}
		}
		book.OpenList(spec);
	}

	private void OnListItemSelectedBody(ListPanel.Spec spec, ListPanel.Item item)
	{
		if (item != null)
		{
			Manifest.FateNode fateNode = item.data as Manifest.FateNode;
			if (fateNode.fate != null)
			{
				string killerId = Manifest.FateId_KillerId(faceData.fateId);
				if (fateNode.fate.hasKiller)
				{
					faceData.fateId = Manifest.FateId_Join(fateNode.fate.baseId, killerId);
				}
				else
				{
					faceData.fateId = fateNode.fate.baseId;
				}
				book.audioKit.Play("scribble");
				UpdateFateGuesses();
			}
			else
			{
				OpenFateNodeList(fateNode);
			}
		}
		else
		{
			Manifest.FateNode fateNode2 = spec.data as Manifest.FateNode;
			if (fateNode2 != null)
			{
				OpenFateNodeList(fateNode2.parent, fateNode2);
			}
		}
	}

	private void OnListItemSelectedKiller(ListPanel.Spec spec, ListPanel.Item item)
	{
		if (item != null)
		{
			Manifest.Ent ent = item.data as Manifest.Ent;
			if (ent != null)
			{
				faceData.fateId = Manifest.FateId_Join(faceData.fateId, ent.id);
				book.audioKit.Play("scribble");
				UpdateFateGuesses();
			}
		}
	}

	private TakeOverResult UpdateFateGuesses()
	{
		return UpdateFateGuesses(book, faceData.id);
	}

	public static TakeOverResult UpdateFateGuesses(Book book, string recentlyEditedFaceId)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < Manifest.it.crewCount; i++)
		{
			string crewId = Manifest.it.GetCrewId(i);
			SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[crewId];
			if (!faceDataRo.markedCorrect && faceDataRo.id == faceDataRo.nameId && Manifest.it.IsCorrectFate(faceDataRo.id, faceDataRo.fateId))
			{
				list.Add(faceDataRo.id);
			}
		}
		Story.Zone zone = ((SaveData.it.general.era != 3) ? Story.Zone.Ship : Story.Zone.Office);
		int zoneUnsolvedCount = SaveData.it.GetZoneUnsolvedCount(zone);
		int num = 3;
		if (zoneUnsolvedCount == 4 || zoneUnsolvedCount == 2)
		{
			num = 2;
		}
		if (list.Count >= num)
		{
			list = list.GetRange(0, num);
		}
		if (list.Count == num)
		{
			list.Sort(delegate(string a, string b)
			{
				if (a == recentlyEditedFaceId)
				{
					return -1;
				}
				return (b == recentlyEditedFaceId) ? 1 : 0;
			});
			int numFatesCorrect = SaveData.it.GetNumFatesCorrect();
			int disasterSolvedBits = SaveData.it.GetDisasterSolvedBits();
			foreach (string item in list)
			{
				SaveData.it.face[item].markedCorrect = true;
			}
			int disasterSolvedBits2 = SaveData.it.GetDisasterSolvedBits();
			for (int num2 = 0; num2 < Story.it.disasterCount; num2++)
			{
				Story.Disaster disaster = Story.it.GetDisaster(num2);
				int num3 = 1 << num2;
				bool flag = (disasterSolvedBits & num3) != 0;
				bool flag2 = (disasterSolvedBits2 & num3) != 0;
				if (!flag && flag2)
				{
					Awards.Give(disaster.solvedAwardId);
				}
			}
			int numFatesCorrect2 = SaveData.it.GetNumFatesCorrect();
			if (numFatesCorrect < 6 && numFatesCorrect2 >= 6)
			{
				Awards.Give(Awards.Id.Any6);
			}
			if (numFatesCorrect < 15 && numFatesCorrect2 >= 15)
			{
				Awards.Give(Awards.Id.Any15);
			}
			if (numFatesCorrect < 30 && numFatesCorrect2 >= 30)
			{
				Awards.Give(Awards.Id.Any30);
			}
			if (numFatesCorrect < 45 && numFatesCorrect2 >= 45)
			{
				Awards.Give(Awards.Id.Any45);
			}
			book.RevealCorrectGuesses(list);
			Game.SaveActive(Game.SaveMilestone.CorrectFates);
			return TakeOverResult.TakingOverBook;
		}
		Game.SaveActive(Game.SaveMilestone.EditFate);
		if (recentlyEditedFaceId.HasValue() && !SaveData.it.generalRo.helpedBookFatesCheck && !GetHasUnknowns(recentlyEditedFaceId))
		{
			book.RunTutorial(BookTut.Kind.FatesCheck, recentlyEditedFaceId);
			return TakeOverResult.TakingOverBook;
		}
		return TakeOverResult.None;
	}

	private static bool GetHasUnknowns(string crewId)
	{
		SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[crewId];
		string nameId = faceDataRo.nameId;
		string fateId = faceDataRo.fateId;
		if (nameId == "unknown" || nameId.Contains("?"))
		{
			return true;
		}
		string text = Manifest.FateId_BaseId(fateId);
		if (text == "unknown")
		{
			return true;
		}
		if (text.Contains("-killer"))
		{
			string text2 = Manifest.FateId_KillerId(fateId);
			if (text2 == null || text2 == "unknown" || text2.Contains("?"))
			{
				return true;
			}
		}
		return false;
	}

	private static bool GetKnownKillerIsAbsent(Story.Moment moment, string killerId)
	{
		if (Manifest.it.GetCrew(killerId) == null)
		{
			return false;
		}
		SaveData.FaceDataRo faceDataRo = SaveData.it.faceRo[killerId];
		if (!faceDataRo.markedCorrect)
		{
			return false;
		}
		Story.Zest zest = moment.GetZest(killerId);
		return zest != Story.Zest.Alive && zest != Story.Zest.Die;
	}
}
