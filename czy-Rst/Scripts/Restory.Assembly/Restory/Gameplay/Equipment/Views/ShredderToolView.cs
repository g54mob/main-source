using Restory.Data.Equipment;
using Restory.Gameplay.Common;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public sealed class ShredderToolView : ToolView
	{
		[SerializeField]
		private OutlinableAdapter shredderOutlinableAdapter;

		public override void SetTool(ToolInfo toolInfo, bool instantly)
		{
			base.SetTool(toolInfo, instantly);
			shredderOutlinableAdapter.AddAllChildRenderersToRenderingList();
		}
	}
}
