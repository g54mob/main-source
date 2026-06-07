public interface BookTutHost
{
	void TutQueueAnim(BookAnim.Atom atom);

	void TutGoBack();

	bool TutCanHelpFace();

	void TutClearBookmark();

	void TutSetBookmark(string crewId);

	void TutOpenFateEditor(string crewId);

	void TutShowFolio(BookSpec.FolioSource source, string pageId, string folioId, bool resetScrollToTop);

	void TutExecuteAction(string pageItemId);

	BookSpec.PageSpec TutGetCurPageSpec();

	int TutGetListItemsCount();
}
