using System;

public class UIModList : UIModListSimple, IUIList, IUIMultiPageList
{
	public void MoveToFirstPage()
	{
		throw new NotImplementedException();
	}

	public void MoveToLastPage()
	{
		throw new NotImplementedException();
	}

	public bool PageForward()
	{
		throw new NotImplementedException();
	}

	public bool PageBack()
	{
		throw new NotImplementedException();
	}

	public void Show(int pageIdx)
	{
		throw new NotImplementedException();
	}

	public override void Refresh()
	{
		base.Refresh();
	}

	private void RefreshVisible()
	{
	}

	public int NumberOfPages()
	{
		return 0;
	}
}
