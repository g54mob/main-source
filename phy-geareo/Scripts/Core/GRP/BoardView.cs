using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using Rhizomatic.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GRP
{
	public class BoardView : View<BoardViewable>, IPointerDownHandler, IEventSystemHandler
	{
		public RectTransform rect;

		public RectTransform collapsedRect;

		public ScreenFitter screenFitter;

		public Vector2 minSize;

		public TextAdapter[] title;

		public GameObject[] collapsed;

		public GameObject[] notCollapsed;

		public Button[] collapse;

		public Button[] close;

		public PageView pageView { get; private set; }

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		protected override void Update()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
