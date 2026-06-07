using System;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SESelectionPanel : SESmallToolPanel
	{
		[SerializeField]
		private UIButton squareButton;

		private SESelectionShapes currentSelection;

		public UIButton circleButton;

		[SerializeField]
		public UIButton horizontalFlipButton;

		[SerializeField]
		public UIButton verticalFlipButton;

		[SerializeField]
		public UIButton diagonalFlipButton;

		[SerializeField]
		private UIToggle ignoreTransparencyToggle;

		[SerializeField]
		private GameObject activeToggleText;

		[SerializeField]
		private GameObject inactiveToggleText;

		private Action<bool> OnToggleChange;

		public override void Init(Action<SEToolType> OnClick, SESelectedArea selectedArea)
		{
		}

		public override void ActivatePanel()
		{
		}

		public void SetCurrentActiveSelection(SESelectionShapes currentSelection)
		{
		}

		public override void DeactivatePanel()
		{
		}

		public void SetOnToggleChange(Action<bool> OnToggleChange)
		{
		}

		private void OnSelectChange(bool useless, bool selectionActive)
		{
		}
	}
}
