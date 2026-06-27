using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public class ToolActivator : EquipmentActivatorBase
	{
		[SerializeField]
		protected ToolsCategory[] toolsCategories = Array.Empty<ToolsCategory>();

		[SerializeField]
		protected ToolView[] views = Array.Empty<ToolView>();

		public IReadOnlyCollection<ToolsCategory> ToolsCategories => toolsCategories;

		public virtual void SetTool(ToolInfo toolInfo, bool instantly)
		{
			ToolView toolView = Array.Find(views, (ToolView v) => v.ToolCategory == toolInfo.ToolsCategory);
			if (toolView != null)
			{
				toolView.SetTool(toolInfo, instantly);
			}
		}
	}
}
