using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.StatusSystem;

namespace Timberborn.WaterBuildings
{
	internal class WaterInputObstructedStatus : BaseComponent, IAwakableComponent, IInitializableEntity
	{
		private static readonly string PipeObstructedLocKey = "Status.Buildings.PipeObstructed";

		private readonly ILoc _loc;

		private BlockObject _blockObject;

		private StatusToggle _statusToggle;

		private WaterInputCoordinates _waterInputCoordinates;

		private WaterInputObstructedStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_blockObject = GetComponent<BlockObject>();
			_statusToggle = StatusToggle.CreateNormalStatusWithFloatingIcon("BuildingNeedsWater", _loc.T(PipeObstructedLocKey));
			_waterInputCoordinates = GetComponent<WaterInputCoordinates>();
		}

		public void InitializeEntity()
		{
			GetComponent<StatusSubject>().RegisterStatus(_statusToggle);
			GetComponent<WaterInputCoordinates>().CoordinatesChanged += delegate
			{
				OnCoordinatesChanged();
			};
			OnCoordinatesChanged();
		}

		private void OnCoordinatesChanged()
		{
			if (_blockObject.IsFinished)
			{
				if (!_statusToggle.IsActive && _waterInputCoordinates.Depth == 0 && !IsWaterInputLimitedToZero())
				{
					_statusToggle.Activate();
				}
				else if ((_statusToggle.IsActive && _waterInputCoordinates.Depth != 0) || IsWaterInputLimitedToZero())
				{
					_statusToggle.Deactivate();
				}
			}
		}

		private bool IsWaterInputLimitedToZero()
		{
			if (_waterInputCoordinates.UseDepthLimit)
			{
				return _waterInputCoordinates.DepthLimit == 0;
			}
			return false;
		}
	}
}
