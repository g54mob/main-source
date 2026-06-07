using System;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEReplacePanel : SESmallToolPanel
	{
		[SerializeField]
		private UIButton replaceInsideFilterButton;

		[SerializeField]
		private UIButton replaceInsideImageButton;

		[SerializeField]
		private UIButton pickButton;

		public override void Init(Action<SEToolType> OnClick, SESelectedArea selectedArea)
		{
		}

		public override void ActivatePanel()
		{
		}

		public override void DeactivatePanel()
		{
		}
	}
}
