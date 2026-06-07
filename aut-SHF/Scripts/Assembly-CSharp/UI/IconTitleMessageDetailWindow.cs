using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class IconTitleMessageDetailWindow : BaseMouseOverWindow
	{
		public class IconTitleMessageDetailWindowParam : BaseMouseOverWindowParam
		{
			public Sprite icon;

			public string detailText;

			public IconTitleMessageDetailWindowParam(string title, string message, Sprite icon, string detailText)
				: base(null, null)
			{
			}
		}

		public Image image;

		public TMP_Text detailText;

		public override void InitComponent(BaseMouseOverWindowParam param)
		{
		}

		protected void SetImage(Sprite sprite)
		{
		}

		protected void SetDetailText(string str)
		{
		}
	}
}
