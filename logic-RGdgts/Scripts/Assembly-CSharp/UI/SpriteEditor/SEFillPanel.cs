using System;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEFillPanel : SESmallToolPanel
	{
		[SerializeField]
		private UIButton insideFilterButton;

		[SerializeField]
		private UIButton insideImageButton;

		[SerializeField]
		private UIButton replaceInsideFilterButton;

		[SerializeField]
		private UIButton replaceInsideImageButton;

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
