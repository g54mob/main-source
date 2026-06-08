using Rhizomatic.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class CurveField : UIAdapter<Curve>
	{
		public RectTransform rect;

		public float scale;

		public int thickness;

		public CurveFieldPopup popupPrefab;

		public Selectable selectable;

		public RawImage preview;

		private Texture2D texture;

		protected override void UpdateView()
		{
		}

		public void Open()
		{
		}
	}
}
