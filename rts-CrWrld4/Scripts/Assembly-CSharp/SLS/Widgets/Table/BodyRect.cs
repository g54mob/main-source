using UnityEngine;
using UnityEngine.EventSystems;

namespace SLS.Widgets.Table
{
	public class BodyRect : UIBehaviour
	{
		private Table _table;

		private RectTransform _rt;

		public bool isMeasured;

		public float lastWidth;

		public Table table => null;

		public RectTransform rt => null;

		public void Init(Table t, RectTransform rt)
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}
	}
}
