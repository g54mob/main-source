using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class OpenPanelCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private PanelID _panelID;

		[SerializeField]
		[ConditionalEnumHide("_panelID", 13, true)]
		private BuildableProperties _buildableProperties;

		public bool IsMet()
		{
			foreach (PanelContainer openPanel in GameManager.UIManager.OpenPanels)
			{
				if (openPanel.OpenPanel.ID == _panelID)
				{
					if (_panelID == PanelID.BuildablePanel)
					{
						return openPanel.OpenPanel is BuildablePanel buildablePanel && buildablePanel.Buildable.Properties == _buildableProperties;
					}
					return true;
				}
			}
			return false;
		}
	}
}
