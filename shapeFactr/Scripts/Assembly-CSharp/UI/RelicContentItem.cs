using UnityEngine.UI;

namespace UI
{
	public class RelicContentItem : ChoiceMenuButtonBase
	{
		public class RelicContentItemInit : ChoiceMenuButtonInitBase
		{
			public eRelic Id { get; private set; }

			public RelicContentItemInit(eRelic id, string name, string desc, string iconPath, float? width = null, float? hight = null, int level = 0)
				: base(null, null, null)
			{
			}
		}

		public Image iconWhiteMask;

		public eRelic Id { get; private set; }

		public override void InitComponent(ChoiceMenuButtonInitBase init)
		{
		}

		public void GetRelicAnimation()
		{
		}

		public void SetUseRelic(float alpha)
		{
		}
	}
}
