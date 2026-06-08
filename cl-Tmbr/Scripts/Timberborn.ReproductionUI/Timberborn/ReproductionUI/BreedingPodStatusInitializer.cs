using Timberborn.BaseComponentSystem;
using Timberborn.Localization;
using Timberborn.Reproduction;
using Timberborn.StatusSystem;
using Timberborn.TickSystem;

namespace Timberborn.ReproductionUI
{
	public class BreedingPodStatusInitializer : TickableComponent, IAwakableComponent
	{
		private static readonly string ProgressHaltedLocKey = "Status.Breeding.ProgressHalted";

		private static readonly string ProgressHaltedShortLocKey = "Status.Breeding.ProgressHalted.Short";

		private readonly ILoc _loc;

		private BreedingPod _breedingPod;

		private StatusToggle _statusToggle;

		public BreedingPodStatusInitializer(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_breedingPod = GetComponent<BreedingPod>();
			_statusToggle = StatusToggle.CreateNormalStatusWithAlertAndFloatingIcon("LackOfNutrients", _loc.T(ProgressHaltedLocKey), _loc.T(ProgressHaltedShortLocKey));
		}

		public override void StartTickable()
		{
			UpdateToggle();
			GetComponent<StatusSubject>().RegisterStatus(_statusToggle);
		}

		public override void Tick()
		{
			UpdateToggle();
		}

		private void UpdateToggle()
		{
			if (_breedingPod.ProgressHalted)
			{
				_statusToggle.Activate();
			}
			else
			{
				_statusToggle.Deactivate();
			}
		}
	}
}
