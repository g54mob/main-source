#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Shapes;
using Presentation.UI.Menus;
using Presentation.UI.OperatorUIs.InsideOperatorUIs;
using UnityEngine;
using Utils;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Set Cutter Required Shape", fileName = "SetCutterRequiredShape", order = 25)]
	public class SetCutterRequiredShapeSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private UIMenuLocator _cutterUIMenuLocator;

		[SerializeField]
		private List<ShapeDataSO> _shapeDatas;

		public override void Execute()
		{
			if (_cutterUIMenuLocator == null || _shapeDatas == null)
			{
				this.LogError("CutterUILocator or shapeDatas can't be null", "Execute", 20);
			}
			else
			{
				(_cutterUIMenuLocator.UIMenu as CutterUI).SetRequiredOnboardingShapeData(_shapeDatas);
			}
		}
	}
}
