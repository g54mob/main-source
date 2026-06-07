using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SLS.Widgets.Table
{
	public sealed class Row : VisibleComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
	{
		private RectTransform _cgrt;

		private CanvasGroup _cg;

		public Row preceedingRow;

		public RectTransform extraTextRt;

		public Image extraTextBackground;

		public Text extraText;

		public List<Cell> cells;

		private Table table;

		private Image background;

		private MeasureMaster mm;

		private bool isHeader;

		private bool isFooter;

		public bool isDown;

		public bool foundMax;

		private bool _isRefreshPending;

		private bool _isSetColorPending;

		private Coroutine cDofadeCG;

		private Datum _datum;

		public RectTransform cgrt => null;

		public Datum datum
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		protected override void BecameVisible()
		{
		}

		protected override bool ShouldPostponeUpdate()
		{
			return false;
		}

		public bool Initialize(Table table, RectTransform rt, RectTransform cgrt, CanvasGroup cg, Image background, MeasureMaster mm, bool isHeader = false, bool isFooter = false)
		{
			return false;
		}

		public void Refresh()
		{
		}

		public void SetColor()
		{
		}

		public void ColorCells()
		{
		}

		private IEnumerator DofadeCG(float overTime, float v0, float v1)
		{
			return null;
		}

		public void OnPointerEnter(PointerEventData data)
		{
		}

		public void OnPointerExit(PointerEventData data)
		{
		}

		public void OnPointerDown(PointerEventData data)
		{
		}

		public void OnPointerUp(PointerEventData data)
		{
		}

		public void OnPointerClick(PointerEventData data)
		{
		}
	}
}
