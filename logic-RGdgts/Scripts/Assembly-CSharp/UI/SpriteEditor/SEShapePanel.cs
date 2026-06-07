using System;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEShapePanel : SESmallToolPanel
	{
		[SerializeField]
		private UIButton circleButton;

		[SerializeField]
		private UIButton squareButton;

		[SerializeField]
		private UIButton filledCircleButton;

		[SerializeField]
		private UIButton filledSquareButton;

		[SerializeField]
		private UIToggle fixedCentreToggle;

		[SerializeField]
		private GameObject activeToggleText;

		[SerializeField]
		private GameObject inactiveToggleText;

		private Action<bool> OnToggleChange;

		public override void Init(Action<SEToolType> OnClick, SESelectedArea selectedArea)
		{
		}

		public void SetOnToggleChange(Action<bool> OnToggleChange)
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
