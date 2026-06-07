using System;
using System.Collections.Generic;
using DG.Tweening;
using Dhs5.Utility.Debuggers;
using I2.Loc;
using Simulator.Menus;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class UI_Pager : MonoBehaviour
	{
		private enum EPageChangeMode
		{
			CANVAS_GROUP = 0,
			GAME_OBJECT = 1,
			CANVAS = 2,
			MENU_ACTIVABLE = 3
		}

		public delegate void OnPageChangedDelegate(UI_Page previousPage, UI_Page currentPage);

		[Header("References")]
		[SerializeField]
		private NavBox m_navBox;

		[Header("Pages infos")]
		[UseCustomCollectionElementName]
		[SerializeField]
		[ReadOnly(false, false)]
		private List<UI_Page> m_pages = new List<UI_Page>();

		[SerializeField]
		[ReadOnly(false, false)]
		private int m_currentPageIndex;

		[SerializeField]
		[ReadOnly(false, false)]
		private int m_previousPageIndex;

		[Header("Settings")]
		[SerializeField]
		private int m_startupPage;

		[SerializeField]
		private bool m_pageLoop = true;

		[SerializeField]
		private EPageChangeMode m_pageChangeMode;

		[SerializeField]
		private bool m_crossFadePages = true;

		[SerializeField]
		[Show("m_crossFadePages", false)]
		private float m_crossFadeDuration = 0.25f;

		[SerializeField]
		private bool m_rebuildPagesLayoutGroupOnPageChange = true;

		private Tween m_currentPageFadeTween;

		private Tween m_previousPageFadeTween;

		public bool IsFirstPage => m_currentPageIndex == 0;

		public bool IsLastPage => m_currentPageIndex == m_pages.Count - 1;

		public UI_Page PreviousPage => GetPage(m_previousPageIndex);

		public UI_Page CurrentPage => GetPage(m_currentPageIndex);

		public NavBox NavBox => m_navBox;

		public event OnPageChangedDelegate OnPageChanged;

		private void Awake()
		{
			MarkAllPagesAsDirty();
		}

		private void Start()
		{
			GoToPage(m_startupPage, forceGoToPage: true);
		}

		private void OnEnable()
		{
			LocalizationManager.OnLocalizedEvent += MarkAllPagesAsDirty;
		}

		private void OnDisable()
		{
			LocalizationManager.OnLocalizedEvent -= MarkAllPagesAsDirty;
		}

		public void RefreshPages()
		{
			Debugger<EDebugCategory>.Log(EDebugCategory.UI, "Refreshing the pager...");
			m_pages.Clear();
			List<RectTransform> componentsInChildrenOnlyFirstDepth = base.transform.GetComponentsInChildrenOnlyFirstDepth<RectTransform>();
			for (int i = 0; i < componentsInChildrenOnlyFirstDepth.Count; i++)
			{
				RectTransform rectTransform = componentsInChildrenOnlyFirstDepth[i];
				rectTransform.gameObject.SetActive(value: true);
				if (rectTransform.TryGetComponent<CanvasGroup>(out var component))
				{
					component.alpha = 1f;
					component.blocksRaycasts = true;
				}
				if (rectTransform.TryGetComponent<Canvas>(out var component2))
				{
					component2.enabled = true;
				}
				if (rectTransform.TryGetComponent<GraphicRaycaster>(out var component3))
				{
					component3.enabled = true;
				}
				LayoutGroup componentInChildren = rectTransform.GetComponentInChildren<LayoutGroup>();
				Menu component4 = rectTransform.GetComponent<Menu>();
				UI_Page item = new UI_Page(i, rectTransform.gameObject, component, component2, component3, componentInChildren, component4);
				m_pages.Add(item);
			}
			Debugger<EDebugCategory>.Log(EDebugCategory.UI, "Pager refreshed !");
		}

		public void GoToNextPage()
		{
			int num = m_currentPageIndex;
			if (m_currentPageIndex + 1 > m_pages.Count - 1)
			{
				if (m_pageLoop)
				{
					num = 0;
				}
			}
			else
			{
				num++;
			}
			GoToPage(num);
		}

		public void GoToPreviousPage()
		{
			int num = m_currentPageIndex;
			if (m_currentPageIndex - 1 < 0)
			{
				if (m_pageLoop)
				{
					num = m_pages.Count - 1;
				}
			}
			else
			{
				num--;
			}
			GoToPage(num);
		}

		public void GoToPage(GameObject gameObject)
		{
			int num = m_pages.FindIndex((UI_Page page) => page.GameObject == gameObject);
			if (num == -1)
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.UI, "The page " + gameObject.name + " is not in the pager.");
			}
			else
			{
				GoToPage(num);
			}
		}

		public void GoToPage(int pageIndex)
		{
			GoToPage(pageIndex, forceGoToPage: false);
		}

		public void GoToPage(int pageIndex, bool forceGoToPage)
		{
			if (pageIndex != m_currentPageIndex || forceGoToPage)
			{
				m_previousPageIndex = m_currentPageIndex;
				m_currentPageIndex = pageIndex;
				ChangePageVisualBehaviour();
			}
		}

		private void OnPageChange()
		{
			if (m_rebuildPagesLayoutGroupOnPageChange)
			{
				CurrentPage.SetLayoutGroupDirty();
				CurrentPage.TryRefreshLayoutGroupsImmediateAndRecursive();
			}
			PreviousPage.OnPageUnselected();
			CurrentPage.OnPageSelected();
			RefreshCurrentPageNavBox();
			this.OnPageChanged?.Invoke(PreviousPage, CurrentPage);
		}

		public void RefreshCurrentPageNavBox()
		{
			if (CurrentPage.GameObject.TryGetComponent<NavBox>(out var component))
			{
				if (component.Parent != null)
				{
					component.Parent.SetCurrentElement(component);
				}
				component.SetActive();
			}
		}

		private UI_Page GetPage(int pageIndex)
		{
			return m_pages[pageIndex];
		}

		private void CrossFadePages(Action onComplete)
		{
			CanvasGroup canvasGroup = PreviousPage.CanvasGroup;
			CanvasGroup canvasGroup2 = CurrentPage.CanvasGroup;
			m_previousPageFadeTween?.Kill();
			m_currentPageFadeTween?.Kill(complete: true);
			m_previousPageFadeTween = canvasGroup.DOFade(0f, m_crossFadeDuration).SetUpdate(isIndependentUpdate: true).OnKill(delegate
			{
				m_previousPageFadeTween = null;
			});
			m_currentPageFadeTween = canvasGroup2.DOFade(1f, m_crossFadeDuration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
			{
				onComplete?.Invoke();
			})
				.OnKill(delegate
				{
					m_currentPageFadeTween = null;
				});
		}

		private void ChangePageVisualBehaviour()
		{
			if (m_crossFadePages)
			{
				CrossFadePages(ExecutePageChangeMode);
			}
			else
			{
				ExecutePageChangeMode();
			}
			void ExecutePageChangeMode()
			{
				switch (m_pageChangeMode)
				{
				case EPageChangeMode.CANVAS_GROUP:
					UpdateCanvasGroup();
					break;
				case EPageChangeMode.GAME_OBJECT:
					UpdateGameObject();
					break;
				case EPageChangeMode.CANVAS:
					UpdateCanvas();
					break;
				case EPageChangeMode.MENU_ACTIVABLE:
					UpdateMenuActivable();
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				OnPageChange();
			}
		}

		private void UpdateCanvasGroup()
		{
			PreviousPage.CanvasGroup.alpha = 0f;
			PreviousPage.CanvasGroup.blocksRaycasts = false;
			CurrentPage.CanvasGroup.alpha = 1f;
			CurrentPage.CanvasGroup.blocksRaycasts = true;
		}

		private void UpdateGameObject()
		{
			PreviousPage.GameObject.SetActive(value: false);
			CurrentPage.GameObject.SetActive(value: true);
		}

		private void UpdateCanvas()
		{
			PreviousPage.Canvas.enabled = false;
			PreviousPage.GraphicRaycaster.enabled = false;
			CurrentPage.Canvas.enabled = true;
			CurrentPage.GraphicRaycaster.enabled = true;
		}

		private void UpdateMenuActivable()
		{
			PreviousPage.Menu.SetActive(active: false);
			CurrentPage.Menu.SetActive(active: true);
		}

		private void MarkAllPagesAsDirty()
		{
			for (int i = 0; i < m_pages.Count; i++)
			{
				m_pages[i].SetLayoutGroupDirty();
			}
			CurrentPage.TryRefreshLayoutGroupsImmediateAndRecursive();
		}
	}
}
