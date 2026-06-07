using System;
using Simulator.Menus;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	[Serializable]
	public class UI_Page
	{
		[Header("Dirty")]
		[SerializeField]
		[ReadOnly(false, false)]
		private bool m_isLayoutGroupDirty = true;

		[Header("Page index")]
		[SerializeField]
		[ReadOnly(false, false)]
		private int m_pageIndex;

		[Header("Page components")]
		[SerializeField]
		[ReadOnly(false, false)]
		private GameObject m_gameObject;

		[SerializeField]
		[ReadOnly(false, false)]
		private CanvasGroup m_canvasGroup;

		[SerializeField]
		[ReadOnly(false, false)]
		private Canvas m_canvas;

		[SerializeField]
		[ReadOnly(false, false)]
		private GraphicRaycaster m_graphicRaycaster;

		[SerializeField]
		[ReadOnly(false, false)]
		private LayoutGroup m_layoutGroup;

		[SerializeField]
		[ReadOnly(false, false)]
		private Menu m_menu;

		public GameObject GameObject => m_gameObject;

		public CanvasGroup CanvasGroup => m_canvasGroup;

		public Canvas Canvas => m_canvas;

		public GraphicRaycaster GraphicRaycaster => m_graphicRaycaster;

		public LayoutGroup LayoutGroup => m_layoutGroup;

		public Menu Menu => m_menu;

		public int PageIndex => m_pageIndex;

		public event Action<UI_Page> OnPageSelectedEvent;

		public event Action<UI_Page> OnPageUnselectedEvent;

		public UI_Page(int pageIndex, GameObject gameObject, CanvasGroup canvasGroup, Canvas canvas, GraphicRaycaster graphicRaycaster, LayoutGroup layoutGroup, Menu menu)
		{
			m_gameObject = gameObject;
			m_pageIndex = pageIndex;
			m_canvasGroup = canvasGroup;
			m_canvas = canvas;
			m_graphicRaycaster = graphicRaycaster;
			m_layoutGroup = layoutGroup;
			m_menu = menu;
		}

		public void OnPageSelected()
		{
			this.OnPageSelectedEvent?.Invoke(this);
		}

		public void OnPageUnselected()
		{
			this.OnPageUnselectedEvent?.Invoke(this);
		}

		public void SetLayoutGroupDirty()
		{
			m_isLayoutGroupDirty = true;
		}

		public void TryRefreshLayoutGroupsImmediateAndRecursive()
		{
			if (m_isLayoutGroupDirty && !(m_layoutGroup == null))
			{
				m_layoutGroup.RefreshLayoutGroupsImmediateAndRecursive();
				m_isLayoutGroupDirty = false;
			}
		}
	}
}
