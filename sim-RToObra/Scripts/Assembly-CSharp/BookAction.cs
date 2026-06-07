using UnityEngine;

public class BookAction
{
	public enum BookmarkAction
	{
		None = 0,
		GoFirst = 1,
		GoDeath = 2,
		GoNext = 3,
		GoPrev = 4,
		GoSketch = 5,
		GoDeck = 6,
		Clear = 7
	}

	private Book book;

	private BookSpec bookSpec;

	private BookContent bookContent;

	private FateEditor fateEditor;

	private FaceChooser faceChooser;

	private FaceLib faceLib;

	private Bookmark bookmark;

	public BookAction(Book book_, BookSpec bookSpec_, BookContent bookContent_, Bookmark bookmark_, FateEditor fateEditor_, FaceChooser faceChooser_, FaceLib faceLib_)
	{
		book = book_;
		bookSpec = bookSpec_;
		bookContent = bookContent_;
		bookmark = bookmark_;
		fateEditor = fateEditor_;
		faceChooser = faceChooser_;
		faceLib = faceLib_;
	}

	public void Execute(BookSpec.PageSpec pageSpec, PageItem pageItem)
	{
		Debug.LogFormat("CLICK {0} {1}", pageItem.id, pageItem.buttonSettings.actionId);
		string actionId = pageItem.buttonSettings.actionId;
		if (pageItem.buttonSettings.soundId.HasValue())
		{
			book.audioKit.Play(pageItem.buttonSettings.soundId);
		}
		switch (actionId)
		{
		case "go-next":
			if (pageSpec.nextPage != null)
			{
				book.GoToPage(pageSpec.nextPage);
			}
			return;
		case "go-prev":
			if (pageSpec.prevPage != null)
			{
				book.GoToPage(pageSpec.prevPage);
			}
			return;
		case "go-screenplay":
			bookContent.SetScreenplayMomentId(pageSpec.id);
			book.GoToPage(bookSpec.FindPage("screenplay"));
			return;
		}
		if (actionId.StartsWith("go-folio-sketch"))
		{
			if (actionId == "go-folio-sketch-death")
			{
				bookContent.SetFolioRemap("folio-sketch", new BookContent.FolioAddress(BookSpec.FolioSource.DeathSketch, pageSpec.id));
			}
			else if (actionId == "go-folio-sketch-global")
			{
				bookContent.SetFolioRemap("folio-sketch", new BookContent.FolioAddress(BookSpec.FolioSource.GlobalSketch, pageSpec.id));
			}
			book.GoToPage(bookSpec.FindPage("folio-sketch"));
			return;
		}
		if (actionId.StartsWith("go-folio-deck"))
		{
			if (actionId == "go-folio-deck-death")
			{
				bookContent.SetFolioRemap("folio-deck", new BookContent.FolioAddress(BookSpec.FolioSource.DeathDeck, pageSpec.id));
			}
			else if (actionId == "go-folio-deck-global")
			{
				bookContent.SetFolioRemap("folio-deck", new BookContent.FolioAddress(BookSpec.FolioSource.GlobalDeck, pageSpec.id));
			}
			book.GoToPage(bookSpec.FindPage("folio-deck"));
			return;
		}
		if (actionId.StartsWith("go-folio-chart"))
		{
			if (actionId == "go-folio-chart-chapter")
			{
				bookContent.SetFolioRemap("folio-chart", new BookContent.FolioAddress(BookSpec.FolioSource.ChapterChart, pageSpec.id));
			}
			else if (actionId == "go-folio-chart-global")
			{
				bookContent.SetFolioRemap("folio-chart", new BookContent.FolioAddress(BookSpec.FolioSource.GlobalChart, pageSpec.id));
			}
			book.GoToPage(bookSpec.FindPage("folio-chart"));
			return;
		}
		if (actionId.EndsWith("edit-fate-death"))
		{
			Story.Moment moment = Story.it.GetMoment(pageSpec.id);
			fateEditor.OpenFromFace(moment.dieCrewIds[0]);
			return;
		}
		if (actionId.EndsWith("edit-fate-death1"))
		{
			Story.Moment moment2 = Story.it.GetMoment(pageSpec.id);
			fateEditor.OpenFromFace(moment2.dieCrewIds[1]);
			return;
		}
		if (actionId.StartsWith("disappear") && actionId.EndsWith("-edit"))
		{
			Story.Disaster disaster = Story.it.GetDisaster(pageSpec.chapterSpec.disasterId);
			int num = int.Parse(actionId.Substring("disappear".Length, 1));
			string faceId = disaster.disappearCrewIds[num];
			fateEditor.OpenFromFace(faceId);
			return;
		}
		if (actionId == "edit-bookmark")
		{
			Bookmark.Info info = bookmark.GetInfo(pageSpec);
			if (info != null)
			{
				ListPanel.Spec spec = new ListPanel.Spec(OnBookmarkEdited, Lang.GetCounted(info.count, string.Empty, "bookmarked_marked_one", "bookmarked_marked_many"), info);
				FaceLib.Face face = faceLib.Find(info.crewId);
				if (face != null)
				{
					spec.SetBanner(face.spriteHi, "Bookmark", 0.75f, BookContent.GetClueFaceMaterial(book.assets, face.id));
				}
				spec.alignments = new TextAnchor[2]
				{
					TextAnchor.MiddleLeft,
					TextAnchor.MiddleRight
				};
				Manifest.Gender crewGender = Manifest.it.GetCrewGender(info.crewId);
				Bookmark.Destiny destiny = info.destiny;
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Manifest.ApplyGender(Lang.Get("bookmarked_first"), crewGender, crewGender),
					destiny.appearanceSummary.pageNum0.ToString()
				}, BookmarkAction.GoFirst));
				if (info.destiny.pageSpec.revealed)
				{
					spec.items.Add(new ListPanel.Item(new string[2]
					{
						info.destiny.description,
						info.destiny.pageNumStr
					}, BookmarkAction.GoDeath));
				}
				spec.items.Add(new ListPanel.Item(string.Empty));
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Lang.Get("bookmarked_godeck"),
					string.Empty
				}, BookmarkAction.GoDeck));
				string text = Manifest.ApplyGender(Lang.Get("bookmarked_gosketch", "$sketch", Lang.Get(Manifest.it.GetCrewSketchId(info.crewId))), Manifest.it.GetCrewGender(info.crewId));
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					text,
					string.Empty
				}, BookmarkAction.GoSketch));
				spec.items.Add(new ListPanel.Item(string.Empty));
				spec.items.Add(new ListPanel.Item(new string[2]
				{
					Lang.Get("bookmarked_clear"),
					string.Empty
				}, BookmarkAction.Clear));
				book.OpenList(spec);
			}
			return;
		}
		if (actionId.StartsWith("go-bookmark"))
		{
			Bookmark.Info info2 = bookmark.GetInfo(pageSpec, false);
			if (info2 != null)
			{
				if (actionId == "go-bookmarkl" && info2.prevPageSpec != null)
				{
					book.GoToPage(info2.prevPageSpec, Bookmark.PosToSelectableName(info2.prevPos, Bookmark.Pos.GoL));
				}
				if (actionId == "go-bookmarkr" && info2.nextPageSpec != null)
				{
					book.GoToPage(info2.nextPageSpec, Bookmark.PosToSelectableName(info2.nextPos, Bookmark.Pos.GoR));
				}
			}
			return;
		}
		if (actionId.StartsWith("define-gloss"))
		{
			int num2 = int.Parse(actionId.Substring("define-gloss".Length));
			if (num2 >= 0 && num2 < bookSpec.glossaryEntries.Count)
			{
				book.ShowGlossaryDefinition(bookSpec.glossaryEntries[num2]);
			}
			return;
		}
		if (actionId.EndsWith("close-popup"))
		{
			book.GoBack(0f);
			return;
		}
		if (actionId.StartsWith("go-"))
		{
			string text2 = actionId.Substring("go-".Length);
			BookSpec.PageSpec pageSpec2 = bookSpec.FindPage(text2);
			if (text2 == "toc")
			{
				book.audioKit.Play("riffle");
			}
			if (pageSpec2 != null)
			{
				book.GoToPage(pageSpec2);
			}
			return;
		}
		if (actionId.StartsWith("manifest-"))
		{
			string nameId = actionId.Substring("manifest-".Length);
			fateEditor.OpenFromMuster(nameId);
			return;
		}
		Popup topPopup = book.topPopup;
		if (topPopup != null)
		{
			if (topPopup.name == "EditFate")
			{
				fateEditor.OnPageButtonClick(actionId);
			}
			else if (topPopup.name == "ChooseFace")
			{
				faceChooser.OnPageButtonClick(actionId);
			}
		}
	}

	public void Execute(BookSpec.PageSpec pageSpec, PageItem folioPageItem, FolioSpec.PinSpec folioPinSpec)
	{
		if (folioPageItem.buttonSettings.actionId == "edit-sketch")
		{
			fateEditor.OpenFromFace(folioPinSpec.id);
		}
		else if (folioPageItem.buttonSettings.actionId == "edit-deck")
		{
			BookSpec.PageSpec pageSpec2 = bookSpec.FindPage(folioPinSpec.id);
			if (pageSpec2 != null && SaveData.it.momentRo[folioPinSpec.id].visited)
			{
				book.GoToPage(pageSpec2);
			}
		}
		else if (folioPageItem.buttonSettings.actionId == "edit-chart")
		{
			BookSpec.PageSpec pageSpec3 = bookSpec.FindPage(folioPinSpec.id);
			if (pageSpec3 != null)
			{
				book.GoToPage(pageSpec3);
			}
		}
	}

	private void OnBookmarkEdited(ListPanel.Spec spec, ListPanel.Item item)
	{
		if (item != null)
		{
			Bookmark.Info info = (Bookmark.Info)spec.data;
			switch ((BookmarkAction)item.data)
			{
			case BookmarkAction.GoFirst:
				book.GoToPage(info.destiny.appearanceSummary.pageSpec0);
				break;
			case BookmarkAction.GoDeath:
				book.GoToPage(info.destiny.pageSpec);
				break;
			case BookmarkAction.GoNext:
				book.GoToPage(info.nextPageSpec, Bookmark.PosToSelectableName(info.nextPos, Bookmark.Pos.None));
				break;
			case BookmarkAction.GoPrev:
				book.GoToPage(info.prevPageSpec, Bookmark.PosToSelectableName(info.prevPos, Bookmark.Pos.None));
				break;
			case BookmarkAction.GoSketch:
				book.ShowInSketch(info.crewId);
				break;
			case BookmarkAction.GoDeck:
				book.ShowFocusDeck(info.crewId);
				break;
			case BookmarkAction.Clear:
				bookmark.Clear();
				break;
			}
		}
	}
}
