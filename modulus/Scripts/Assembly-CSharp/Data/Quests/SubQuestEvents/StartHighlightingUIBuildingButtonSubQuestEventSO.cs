using System;
using Data.Buildings;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Start Highlighting UIBuildingButton", fileName = "StartHighlightingUIBuildingButton", order = 7)]
	public class StartHighlightingUIBuildingButtonSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private BuildingObjectData _buildingObjectData;

		public event Action<BuildingObjectData> OnStartHighlightingButton;

		public override void Execute()
		{
			this.OnStartHighlightingButton?.Invoke(_buildingObjectData);
		}
	}
}
