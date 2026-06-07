using System.Collections.Generic;
using Data.Shapes;
using Presentation.Locators;
using Presentation.Shapes;
using Presentation.UI.Menus;
using Presentation.UI.OperatorUIs.InsideOperatorUIs;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Cutter OutputShapes", fileName = "DetectCutterOutputShapes", order = 18)]
	public class DetectCutterOutputShapesSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private UIMenuLocator _cutterUILocator;

		[SerializeField]
		private List<ShapeDataSO> _requiredShapes;

		private CutterUI _cutterUI;

		public override bool IsValid()
		{
			if (!_uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowing(_cutterUILocator.UIMenu))
			{
				return false;
			}
			if (_cutterUI == null)
			{
				_cutterUI = _cutterUILocator.UIMenu as CutterUI;
			}
			if (_requiredShapes.Count == 0 || _requiredShapes.Count != _cutterUI.CutShapes.Length)
			{
				return false;
			}
			for (int i = 0; i < _requiredShapes.Count; i++)
			{
				ShapeDataSO shapeDataSO = _requiredShapes[i];
				bool flag = false;
				ShapeLoader[] cutShapes = _cutterUI.CutShapes;
				foreach (ShapeLoader shapeLoader in cutShapes)
				{
					if (shapeDataSO.Data.RotationIndependantHash.Contains(shapeLoader.Shape.GetShapeHash()))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		public override void Reset()
		{
			_cutterUI = null;
		}
	}
}
