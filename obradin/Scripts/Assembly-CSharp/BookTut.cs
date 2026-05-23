using System.Collections.Generic;

public class BookTut
{
	public enum Kind
	{
		None = 0,
		FaceBlur = 1,
		FaceClear = 2,
		BookUsage = 3,
		Difficulty = 4,
		FatesCheck = 5,
		Bookmarks = 6
	}

	private class FaceInfo
	{
		public readonly bool canEdit;

		public readonly BookHelp.Side textSide;

		public readonly Manifest.Gender gender;

		public FaceInfo(string crewId)
		{
			canEdit = SaveData.it.HaveVisitedClimax(crewId);
			gender = Manifest.it.GetCrewGender(crewId);
			textSide = (canEdit ? BookHelp.Side.OnRight : BookHelp.Side.Above);
		}
	}

	private Book book;

	private BookTutHost host;

	private BookHelp bookHelp;

	private BookSpec bookSpec;

	private Kind kind;

	private string crewId_;

	private IEnumerator<bool> func;

	private Book.Snapshot bookSnapshot;

	private FaceInfo faceInfo;

	public bool running
	{
		get
		{
			return func != null;
		}
	}

	public string crewId
	{
		get
		{
			return (!running) ? null : crewId_;
		}
		set
		{
			crewId_ = value;
		}
	}

	public bool canSkip
	{
		get
		{
			return saveDataBool;
		}
	}

	private bool saveDataBool
	{
		get
		{
			if (kind == Kind.FaceBlur)
			{
				return SaveData.it.generalRo.helpedBookFaceBlur;
			}
			if (kind == Kind.FaceClear)
			{
				return SaveData.it.generalRo.helpedBookFaceClear;
			}
			if (kind == Kind.BookUsage)
			{
				return SaveData.it.generalRo.helpedBookUsage;
			}
			if (kind == Kind.Difficulty)
			{
				return SaveData.it.generalRo.helpedBookDifficulty;
			}
			if (kind == Kind.FatesCheck)
			{
				return SaveData.it.generalRo.helpedBookFatesCheck;
			}
			if (kind == Kind.Bookmarks)
			{
				return SaveData.it.generalRo.helpedBookBookmarks;
			}
			return false;
		}
		set
		{
			if (kind == Kind.FaceBlur)
			{
				SaveData.it.general.helpedBookFaceBlur = value;
			}
			if (kind == Kind.FaceClear)
			{
				SaveData.it.general.helpedBookFaceClear = value;
			}
			if (kind == Kind.BookUsage)
			{
				SaveData.it.general.helpedBookUsage = value;
			}
			if (kind == Kind.Difficulty)
			{
				SaveData.it.general.helpedBookDifficulty = value;
			}
			if (kind == Kind.FatesCheck)
			{
				SaveData.it.general.helpedBookFatesCheck = value;
			}
			if (kind == Kind.Bookmarks)
			{
				SaveData.it.general.helpedBookBookmarks = value;
			}
		}
	}

	public BookTut(Book book_, BookHelp bookHelp_, BookSpec bookSpec_)
	{
		book = book_;
		host = book;
		bookHelp = bookHelp_;
		bookSpec = bookSpec_;
	}

	public void Start(Kind kind_, string crewId__)
	{
		if (!host.TutCanHelpFace())
		{
			return;
		}
		kind = kind_;
		crewId = crewId__;
		func = null;
		if (kind == Kind.FaceBlur)
		{
			func = RunFaceBlur();
		}
		else if (kind == Kind.FaceClear)
		{
			func = RunFaceClear();
		}
		else if (kind == Kind.FatesCheck)
		{
			func = RunFatesCheck();
		}
		else if (kind == Kind.Difficulty)
		{
			func = RunDifficulty();
		}
		else if (kind == Kind.BookUsage)
		{
			func = RunBookUsage();
		}
		else
		{
			if (kind != Kind.Bookmarks)
			{
				return;
			}
			func = RunBookmarks();
		}
		faceInfo = new FaceInfo(crewId);
		bookSnapshot = book.MakeSnapshot();
		bookHelp.InitShow();
	}

	public bool Step()
	{
		if (func == null)
		{
			return false;
		}
		if (func.MoveNext())
		{
			return true;
		}
		bookHelp.gameObject.SetActive(false);
		book.RestoreSnapshot(bookSnapshot);
		faceInfo = null;
		func = null;
		saveDataBool = true;
		return false;
	}

	private void QueueWait(float wait)
	{
		if (wait > 0f)
		{
			QueueAnim(BookAnim.MakeWaitForInputDuringHelp(wait));
		}
	}

	private void QueueRect(string id, float expand = 0f, float duration = 0.5f, float wait = 1f)
	{
		QueueAnim(BookAnim.MakeHelp(id, expand, duration));
		if (wait > 0f)
		{
			QueueAnim(BookAnim.MakeWaitForInputDuringHelp(wait));
		}
	}

	private void QueueText(string id, BookHelp.Side side, float wait = 5f)
	{
		QueueAnim(BookAnim.MakeHelp(id, faceInfo.gender, side, 1f));
		if (wait > 0f)
		{
			QueueAnim(BookAnim.MakeWaitForInputDuringHelp(wait));
		}
	}

	private void QueueAnim(BookAnim.Atom atom)
	{
		host.TutQueueAnim(atom);
	}

	private void GoToPage(string pageId)
	{
		book.GoToPage(bookSpec.FindPage(pageId));
	}

	private BookSpec.PageSpec FindDemoDeathPage()
	{
		Story.Moment deathMoment = Story.it.GetDeathMoment(crewId);
		if (deathMoment != null && SaveData.it.momentRo[deathMoment.id].visited)
		{
			return bookSpec.FindPage(deathMoment.id);
		}
		foreach (string item in Story.it.IterateAllMomentIds())
		{
			if (SaveData.it.momentRo[item].visited)
			{
				return bookSpec.FindPage(item);
			}
		}
		return null;
	}

	private IEnumerator<bool> RunFaceBlur()
	{
		yield return true;
		QueueRect("button-face");
		QueueText("help_faceblur_intro0", faceInfo.textSide);
		QueueText("help_faceblur_intro1", faceInfo.textSide);
		if (faceInfo.canEdit)
		{
			QueueRect("part1", 10f);
			QueueText("help_faceblur_fate", BookHelp.Side.Above);
			QueueRect("part0", 10f);
			QueueText("help_faceblur_name", BookHelp.Side.Below);
		}
		else
		{
			QueueRect("button-name", 10f);
			QueueText("help_faceblur_name", BookHelp.Side.Below);
		}
		QueueRect("button-face");
		QueueText("help_faceblur_outro0", faceInfo.textSide);
		QueueText("help_faceblur_outro1", faceInfo.textSide);
		QueueRect("@open");
		yield return true;
		SaveData.it.general.helpedBookFaceBlur = true;
	}

	private IEnumerator<bool> RunBookUsage()
	{
		yield return true;
		BookSpec.PageSpec demoDeathPageSpec = FindDemoDeathPage();
		BookSpec.PageSpec curPageSpec = host.TutGetCurPageSpec();
		host.TutClearBookmark();
		QueueRect("@book");
		yield return true;
		host.TutGoBack();
		yield return true;
		GoToPage(demoDeathPageSpec.id);
		QueueWait(1f);
		yield return true;
		QueueRect("photo-button", 10f);
		QueueText("help_faceclear_dialog", BookHelp.Side.OnRight);
		QueueRect("@folio", 0f, 0.5f, 0f);
		yield return true;
		host.TutExecuteAction("photo-button");
		yield return true;
		QueueWait(4f);
		yield return true;
		host.TutGoBack();
		yield return true;
		QueueRect("deck-button", 10f);
		QueueText("help_faceclear_map", BookHelp.Side.OnLeft);
		QueueRect("@book", 0f, 0.5f, 0f);
		yield return true;
		host.TutShowFolio(BookSpec.FolioSource.GlobalDeck, "maps", "folio-deck", true);
		QueueWait(2f);
		yield return true;
		QueueRect("@deckmap-labels");
		QueueAnim(BookAnim.MakeHelp("@book", 0f, 0.5f));
		yield return true;
		host.TutGoBack();
		yield return true;
		GoToPage("crew");
		yield return true;
		QueueWait(1f);
		QueueRect("@page-right");
		QueueText("help_faceclear_sketch", BookHelp.Side.OnLeft);
		yield return true;
		host.TutShowFolio(BookSpec.FolioSource.GlobalSketch, "crew", "folio-sketch", false);
		QueueRect("@book", 0f, 0.5f, 4f);
		yield return true;
		host.TutGoBack();
		yield return true;
		QueueWait(1f);
		QueueRect("@page-left");
		QueueText("help_faceclear_manifest", BookHelp.Side.OnRight);
		yield return true;
		GoToPage("scrollable-manifest");
		QueueRect("@book", 0f, 0.5f, 2f);
		QueueRect("@manifest-origins");
		QueueText("help_faceclear_origins", BookHelp.Side.OnLeft);
		QueueRect("@manifest-jobs");
		QueueText("help_faceclear_jobs", BookHelp.Side.OnRight);
		QueueRect("@manifest-nums");
		QueueText("help_faceclear_nums", BookHelp.Side.OnRight);
		yield return true;
		QueueRect("@book");
		host.TutGoBack();
		yield return true;
		GoToPage(curPageSpec.id);
		yield return true;
		host.TutOpenFateEditor(crewId);
		yield return true;
		QueueRect("@open", 0f, 0.5f, 0f);
		yield return true;
	}

	private IEnumerator<bool> RunFaceClear()
	{
		yield return true;
		QueueRect("button-face");
		QueueText("help_faceclear_intro0", faceInfo.textSide);
		QueueText("help_faceclear_intro1", faceInfo.textSide);
		QueueText("help_faceclear_pocketwatch", faceInfo.textSide, 10f);
		QueueText(Lang.Get("help_faceclear_book", "$pages", "2-4"), faceInfo.textSide, 12f);
		yield return true;
		QueueRect("@fate-editor-short");
		QueueText("help_faceclear_outro0", BookHelp.Side.Below);
		QueueText("help_faceclear_outro1", BookHelp.Side.Below);
		QueueText("help_faceclear_outro2", BookHelp.Side.Below);
		QueueText("help_faceclear_outro3", BookHelp.Side.Below);
		QueueText("help_faceclear_elimination", BookHelp.Side.Below);
		QueueText("help_faceclear_goodluck", BookHelp.Side.Below, 3f);
		QueueRect("@open", 0f, 0.5f, 0f);
		yield return true;
	}

	private IEnumerator<bool> RunFatesCheck()
	{
		yield return true;
		QueueRect("@book", 0f, 0.5f, 2f);
		QueueRect("@fate-editor-short");
		QueueText("help_faceclear_fates_may", BookHelp.Side.Below);
		QueueText("help_faceclear_fates0", BookHelp.Side.Below);
		QueueText("help_faceclear_fates1", BookHelp.Side.Below);
		QueueRect("@open", 0f, 0.5f, 0f);
		yield return true;
	}

	private IEnumerator<bool> RunDifficulty()
	{
		yield return true;
		QueueRect("button-face");
		QueueRect("@difficulty", 5f, 0.75f);
		QueueText("help_difficulty0", faceInfo.textSide);
		QueueText("help_difficulty1", faceInfo.textSide);
		QueueText("help_difficulty2", faceInfo.textSide);
		QueueRect("@open", 0f, 0.5f, 0f);
		yield return true;
	}

	private IEnumerator<bool> RunBookmarks()
	{
		yield return true;
		host.TutClearBookmark();
		QueueRect("button-memories", 20f);
		QueueText("help_faceclear_memories", BookHelp.Side.Above);
		yield return true;
		host.TutExecuteAction("button-memories");
		yield return true;
		QueueRect("@list-full", 2f, 0.5f, 4f);
		string bookmarkItemRectName = string.Format("@list-item-{0}", host.TutGetListItemsCount() - 1);
		QueueRect(bookmarkItemRectName, 10f);
		QueueText("help_faceclear_bookmark", BookHelp.Side.Above);
		yield return true;
		host.TutGoBack();
		QueueRect("@book");
		yield return true;
		host.TutSetBookmark(crewId);
		QueueWait(4f);
		yield return true;
		BookSpec.PageSpec curPageSpec = host.TutGetCurPageSpec();
		if (curPageSpec.isDeath || curPageSpec.isDisappearance)
		{
			host.TutGoBack();
			yield return true;
			QueueRect("@bookmarks");
			QueueText("help_faceclear_bookmark2", BookHelp.Side.Below);
			QueueRect("@book", 0f, 0.5f, 0f);
			yield return true;
			host.TutOpenFateEditor(crewId);
			yield return true;
		}
		QueueRect("@open", 0f, 0.5f, 0f);
		yield return true;
	}
}
