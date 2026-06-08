public interface IUIMultiPageList : IUIList
{
	void MoveToFirstPage();

	void MoveToLastPage();

	bool PageForward();

	bool PageBack();

	void Show(int pageIdx);

	int NumberOfPages();
}
