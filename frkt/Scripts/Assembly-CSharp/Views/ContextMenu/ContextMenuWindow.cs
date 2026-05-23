using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Views.Generic;
using Zenject;

namespace Views.ContextMenu
{
	public class ContextMenuWindow : MonoBehaviour
	{
		[SerializeField]
		private Canvas m_canvas;

		[SerializeField]
		private RectTransform m_windowPivot;

		[SerializeField]
		private PopupWindow m_popupWindow;

		[SerializeField]
		private RectTransform m_actionsPivot;

		[SerializeField]
		private CanvasGroup m_canvasGroup;

		[SerializeField]
		private SimpleContextMenuActionButton m_simpleButtonPrefab;

		[SerializeField]
		private ToggleableContextMenuActionButton m_toggleableButtonPrefab;

		[SerializeField]
		private SliderBasedContextMenuActionButton m_sliderBasedButtonPrefab;

		[SerializeField]
		private TextMeshProUGUI m_title;

		private ez pvi;

		private fa pvj;

		private beb pvk;

		[Inject]
		private void dxg(beb a)
		{
		}

		public void dxh(string a)
		{
		}

		public void dxi()
		{
		}

		public void dxj()
		{
		}

		public void dxk()
		{
		}

		public void dxl(IEnumerable<nz> a)
		{
		}

		private void Awake()
		{
		}
	}
}
