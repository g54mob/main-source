using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public sealed class SolderingToolView : ToolView
	{
		[SerializeField]
		private GameObject model;

		[SerializeField]
		private GameObject decorations;

		public override void SetTool(ToolInfo toolInfo, bool instantly)
		{
			decorations.SetActive(value: false);
			model.SetActive(value: true);
		}
	}
}
