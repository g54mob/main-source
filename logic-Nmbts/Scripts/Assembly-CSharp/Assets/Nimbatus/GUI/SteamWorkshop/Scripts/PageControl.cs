using System;
using System.Linq;
using Assets.Nimbatus.Scripts.Workshop;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class PageControl : MonoBehaviour
	{
		public UIGrid PagesGrid;

		public PageButton ButtonPrefab;

		public PageButton FirstPagePrefab;

		public PageButton LastPagePrefab;

		[HideInInspector]
		public uint CurrentPage;

		[HideInInspector]
		public uint TotalPages;

		public void Init()
		{
			CurrentPage = 1u;
			(from Transform child in PagesGrid.transform
				select child.gameObject).ToList().ForEach(UnityEngine.Object.Destroy);
		}

		public void ResetFromQuery(SteamWorkshopQuery query)
		{
			if (TotalPages != query.TotalNumberOfPages || CurrentPage != query.PageNumber)
			{
				CurrentPage = Math.Max(1u, query.PageNumber);
				TotalPages = query.TotalNumberOfPages;
				ResetLayout();
			}
		}

		private void ResetLayout()
		{
			(from Transform child in PagesGrid.transform
				select child.gameObject).ToList().ForEach(UnityEngine.Object.Destroy);
			PagesGrid.gameObject.SetActive(true);
			uint num = ((CurrentPage < 2) ? 1u : Math.Max(1u, CurrentPage - 2));
			uint num2 = ((TotalPages > 2) ? (TotalPages - 2) : 0u);
			if (CurrentPage > num2)
			{
				num = ((TotalPages <= 5) ? 1u : (TotalPages - 5));
			}
			uint num3 = ((CurrentPage <= 2) ? Math.Min(TotalPages, 5u) : Math.Min(TotalPages, CurrentPage + 2));
			if (num3 - num != 0)
			{
				AddPageButton(1u, FirstPagePrefab);
				for (uint num4 = num; num4 <= num3; num4++)
				{
					AddPageButton(num4, ButtonPrefab);
				}
				AddPageButton(TotalPages, LastPagePrefab);
				PagesGrid.repositionNow = true;
			}
			else
			{
				AddPageButton(1u, FirstPagePrefab);
				AddPageButton(1u, ButtonPrefab);
				AddPageButton(TotalPages, LastPagePrefab);
				PagesGrid.repositionNow = true;
			}
		}

		private void AddPageButton(uint i, PageButton prefab)
		{
			PageButton pageButton = UnityEngine.Object.Instantiate(prefab);
			pageButton.Init(this, i);
			pageButton.gameObject.transform.position = PagesGrid.transform.position;
			pageButton.gameObject.transform.parent = PagesGrid.transform;
			pageButton.gameObject.transform.localScale = PagesGrid.transform.localScale;
		}

		public void SetPage(uint pageNumber)
		{
			if (CurrentPage != pageNumber)
			{
				CurrentPage = pageNumber;
				ResetLayout();
			}
		}
	}
}
