using System;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEPickPanel : SESmallToolPanel
	{
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
