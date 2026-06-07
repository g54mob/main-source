using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_MarketStoreBrowser : MonoBehaviour
	{
		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private ScrollRectAutoScroll m_scrollRectAutoScroll;

		[SerializeField]
		private GridLayoutGroup m_gridLayout;

		public NavBox BrowserNavBox => m_navBox;

		public ScrollRectAutoScroll ScrollRect => m_scrollRectAutoScroll;

		public GridLayoutGroup LayoutGroup => m_gridLayout;
	}
}
