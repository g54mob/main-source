using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class IconElement : Element
	{
		[SerializeField]
		private TextMeshPro Icon;

		[SerializeField]
		private TextMeshPro Text;

		[SerializeField]
		private Bounds Bounds;

		public override Bounds BoundingBox => new Bounds
		{
			center = base.transform.localPosition,
			extents = Bounds.extents
		};

		public void Set(string icon, string text)
		{
			if (Icon != null)
			{
				Icon.gameObject.layer = base.gameObject.layer;
				Icon.text = icon;
			}
			if (Text != null)
			{
				Text.gameObject.layer = base.gameObject.layer;
				Text.text = text;
			}
		}
	}
}
