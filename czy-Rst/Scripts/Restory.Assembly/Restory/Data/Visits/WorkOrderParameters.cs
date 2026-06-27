using Mandragora.Utils;
using Restory.Data.Base;
using Restory.Data.Devices.Condition;
using Restory.Data.Equipment;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Data.Visits
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/WorkOrderParameters", fileName = "WorkOrderParameters - Name")]
	public class WorkOrderParameters : RestoryEntityInfoBase
	{
		[SerializeField]
		private DeviceCondition deviceCondition;

		[SerializeField]
		private string rewardID;

		[SerializeField]
		private StoryNpcInfo claimingNpc;

		[SerializeField]
		private string claimingNpcTextureID;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool addPaintingToWorkOrder;

		[SerializeField]
		private PaintingPaletteInfo concretePalette;

		public DeviceCondition DeviceCondition => deviceCondition;

		public string RewardID => rewardID;

		public StoryNpcInfo ClaimingNpc => claimingNpc;

		public string ClaimingNpcTextureID => claimingNpcTextureID;

		public bool AddPaintingToWorkOrder => addPaintingToWorkOrder;

		public PaintingPaletteInfo ConcretePaintingPalette => concretePalette;
	}
}
