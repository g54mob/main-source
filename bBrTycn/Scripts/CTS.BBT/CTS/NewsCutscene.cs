using System;
using System.Collections.Generic;
using Animancer;
using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class NewsCutscene : CTSSingleton<NewsCutscene>, IRepaint
	{
		[SerializeField]
		private AnimancerComponent _animator;

		[SerializeField]
		private AnimationClip _fadeInAnimation;

		[SerializeField]
		private AnimationClip _fadeOutAnimation;

		[SerializeField]
		private ObjectToggleGroupByKey _visualToggle;

		[SerializeField]
		private ObjectToggleGroupByKey _characterToggle;

		[SerializeField]
		private CTSButton _nextButton;

		[SerializeField]
		private CTSButton _previousButton;

		private readonly List<CutscenePageData> _pageQueue = new List<CutscenePageData>();

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private CutsceneFeature[] _features;

		[Inject(false)]
		private CanvasGroupController _canvas;

		[Header("Debug")]
		[SerializeField]
		private CutscenePageData _debugPage;

		public CutscenePageData CurrentPage { get; private set; }

		public static event Action<CutscenePageData> PageShown;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void AddPage(CutscenePageData page)
		{
			_pageQueue.Add(page);
			if ((object)CurrentPage == null)
			{
				ShowPage(0);
				_animator.Play(_fadeInAnimation);
			}
			else
			{
				Repaint();
			}
		}

		public void ClearPages()
		{
			_animator.Play(_fadeOutAnimation);
			CurrentPage = null;
			_pageQueue.Clear();
		}

		public void HideCanvas()
		{
			_canvas.QuickHide();
		}

		public void ShowNextPage()
		{
			if (TryGetCurrentPageIndex(out var pageIndex))
			{
				pageIndex = _pageQueue.IndexOf(CurrentPage) + 1;
				if (pageIndex.IsCorrectArrayIndex(_pageQueue))
				{
					ShowPage(pageIndex);
				}
				else
				{
					ClearPages();
				}
			}
			else if (_pageQueue.Count > 0)
			{
				ShowPage(0);
			}
		}

		public void ShowPreviousPage()
		{
			if (TryGetCurrentPageIndex(out var pageIndex))
			{
				pageIndex = _pageQueue.IndexOf(CurrentPage) - 1;
				if (pageIndex.IsCorrectArrayIndex(_pageQueue))
				{
					ShowPage(pageIndex);
				}
			}
			else if (_pageQueue.Count > 0)
			{
				ShowPage(0);
			}
		}

		private bool TryGetCurrentPageIndex(out int pageIndex)
		{
			pageIndex = 0;
			if ((object)CurrentPage == null)
			{
				return false;
			}
			if (!_pageQueue.Contains(CurrentPage))
			{
				return false;
			}
			pageIndex = _pageQueue.IndexOf(CurrentPage);
			return true;
		}

		private void ShowPage(int pageIndex)
		{
			CutscenePageData cutscenePageData = _pageQueue[pageIndex];
			if (cutscenePageData == null)
			{
				throw new NullReferenceException("Page is null");
			}
			CurrentPage = cutscenePageData;
			_canvas.QuickShow();
			Repaint();
			NewsCutscene.PageShown?.Invoke(cutscenePageData);
		}

		public void Repaint()
		{
			if ((object)CurrentPage == null)
			{
				_visualToggle.Swap(_visualToggle.DefaultMode);
				return;
			}
			if (TryGetCurrentPageIndex(out var pageIndex))
			{
				_previousButton.gameObject.SetActive(pageIndex != 0);
			}
			else
			{
				_previousButton.gameObject.SetActive(value: false);
			}
			_visualToggle.Swap(CurrentPage.DisplayMode);
			_characterToggle.Swap(CurrentPage.MainCharacter);
			CutsceneFeature[] features = _features;
			for (int i = 0; i < features.Length; i++)
			{
				features[i].Repaint();
			}
		}

		[Button(null, EButtonEnableMode.Playmode)]
		public void DebugAddPage()
		{
			AddPage(_debugPage);
		}
	}
}
