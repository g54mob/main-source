using System;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEPenPanel : SESmallToolPanel
	{
		[SerializeField]
		private UIButton penButton;

		[SerializeField]
		private UIButton lineButton;

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
