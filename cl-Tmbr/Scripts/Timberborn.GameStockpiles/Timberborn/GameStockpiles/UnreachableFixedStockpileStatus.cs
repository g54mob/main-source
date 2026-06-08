using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.GameDistricts;
using Timberborn.Localization;
using Timberborn.StatusSystem;

namespace Timberborn.GameStockpiles
{
	internal class UnreachableFixedStockpileStatus : BaseComponent, IAwakableComponent, IStartableComponent, IFinishedStateListener
	{
		private static readonly string UnreachableLocKey = "Status.FixedStockpile.Unreachable";

		private readonly ILoc _loc;

		private DistrictBuilding _districtBuilding;

		private StatusToggle _unreachableStatus;

		public UnreachableFixedStockpileStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_districtBuilding = GetComponent<DistrictBuilding>();
			_unreachableStatus = StatusToggle.CreateNormalStatus("UnconnectedBuilding", _loc.T(UnreachableLocKey));
		}

		public void Start()
		{
			GetComponent<StatusSubject>().RegisterStatus(_unreachableStatus);
		}

		public void OnEnterFinishedState()
		{
			UpdateStatus();
			_districtBuilding.ReassignedInstantDistrict += OnReassignedInstantDistrict;
		}

		public void OnExitFinishedState()
		{
			_unreachableStatus.Deactivate();
			_districtBuilding.ReassignedInstantDistrict -= OnReassignedInstantDistrict;
		}

		private void OnReassignedInstantDistrict(object sender, EventArgs e)
		{
			UpdateStatus();
		}

		private void UpdateStatus()
		{
			if ((bool)_districtBuilding.InstantDistrict)
			{
				_unreachableStatus.Deactivate();
			}
			else
			{
				_unreachableStatus.Activate();
			}
		}
	}
}
