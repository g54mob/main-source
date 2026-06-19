using AssembleSystem.Utils;
using Services.Missions;
using UI.Inventory;
using UnityEngine;
using UnityHFSM;
using Zenject;

namespace AssembleSystem.FSM.Parts.States
{
	public class PartObjectPlacedState : StateBase<StateIdentifier>
	{
		private PartObject _part;

		private AssembleObjectParent _parent;

		private IInventoryService _inventoryService;

		private IInventoryUIService _inventoryUIService;

		[Inject]
		private MissionEventBus _missionEventBus;

		public PartObjectPlacedState(IInventoryService inventoryService, IInventoryUIService inventoryUIService, PartObject part, AssembleObjectParent parent, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_inventoryService = inventoryService;
			_inventoryUIService = inventoryUIService;
			_part = part;
			_parent = parent;
		}

		public override void OnEnter()
		{
			IInventoryManagable component = _part.GetComponent<IInventoryManagable>();
			if (_inventoryService.Items.Contains(component))
			{
				_inventoryService.RemoveItem(component);
				_inventoryUIService.RemoveItem(component);
			}
			PartConfig config = _part.Config;
			Rigidbody component2 = _part.GetComponent<Rigidbody>();
			if (_part.IsBase)
			{
				Object.Destroy(_part.GetComponent<Outline>());
			}
			component2.isKinematic = true;
			_part.transform.SetParent(_part.AssembleParent.transform, worldPositionStays: true);
			_part.transform.localPosition = config.AssembledPosition;
			_part.transform.localRotation = config.AssembledRotation;
			_part.enabled = false;
			_part.InvokeOnPlaced();
			if (_part.Config.name == "Table")
			{
				_missionEventBus.Emit("interact", "placeTableTop");
			}
		}
	}
}
