public interface PageTemplateHost
{
	void OnPageButtonClick(PageItem pageItem);

	void MoveOffPage(int dir, PageItem sourcePageItem);
}
