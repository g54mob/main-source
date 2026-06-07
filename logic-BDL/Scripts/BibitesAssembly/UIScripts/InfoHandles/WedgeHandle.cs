using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.InfoHandles
{
	public class WedgeHandle : ValueInfoHandle<float>
	{
		public Color color;

		private Image img;

		private TooltipTrigger tooltip;

		public override void InitHandle()
		{
			img = GetComponent<Image>();
		}

		public void InitWedge(WedgeInfo info)
		{
			InitHandle();
			img.color = info.color;
		}

		protected override void OnValueChange()
		{
			img.fillAmount = value;
		}
	}
}
