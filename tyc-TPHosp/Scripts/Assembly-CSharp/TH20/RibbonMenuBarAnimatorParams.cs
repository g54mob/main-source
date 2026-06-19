using System;
using FullInspector;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class RibbonMenuBarAnimatorParams
	{
		[InspectorMargin(8)]
		public RectTransform RibbonBar;

		[InspectorHeader("Bar Left and Right Section")]
		public RectTransform BarLeftSection;

		public RectTransform BarRightSection;
	}
}
