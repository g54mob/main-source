using UnityEngine;

namespace DV.Items
{
	public class PageBookTransparencyHandler : ItemTransparencyHandler
	{
		private int currentPageShown = -1;

		private PageBook pageBook;

		private void Awake()
		{
			pageBook = GetComponent<PageBook>();
		}

		private void UpdatePages()
		{
			for (int i = 0; i < pageBook.pages.Count; i++)
			{
				pageBook.pages[i].renderer.enabled = i == currentPageShown || currentPageShown == -1;
			}
			if ((bool)pageBook.bookVolumeModel)
			{
				pageBook.bookVolumeModel.GetComponent<Renderer>().enabled = currentPageShown == -1;
			}
		}

		protected override bool ShouldHandleTransparency(Renderer renderer)
		{
			if (!renderer)
			{
				return false;
			}
			if (!renderer.GetComponentInParent<Page>())
			{
				return false;
			}
			return true;
		}

		protected override void SetTransparentAll()
		{
			pageBook.PageFlipped += PageFlipped;
			currentPageShown = pageBook.currentPage;
			UpdatePages();
			base.SetTransparentAll();
		}

		private void PageFlipped(int page)
		{
			currentPageShown = pageBook.currentPage;
			UpdatePages();
			pageBook.pages[page].ForceEndAnimation();
		}

		protected override void SetOpaqueAll()
		{
			currentPageShown = -1;
			UpdatePages();
			pageBook.PageFlipped -= PageFlipped;
			base.SetOpaqueAll();
		}
	}
}
