using System;
using Timberborn.BaseComponentSystem;
using Timberborn.Localization;
using Timberborn.NaturalResourcesLifecycle;
using Timberborn.NaturalResourcesMoisture;
using Timberborn.StatusSystem;

namespace Timberborn.NaturalResourcesMoistureUI
{
	internal class WateredNaturalResourceStatus : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private static readonly string DryingLocKey = "Status.NaturalResources.Drying";

		private readonly ILoc _loc;

		private LivingNaturalResource _livingNaturalResource;

		private WateredNaturalResource _wateredNaturalResource;

		private StatusToggle _dryingStatusToggle;

		public WateredNaturalResourceStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_livingNaturalResource = GetComponent<LivingNaturalResource>();
			_wateredNaturalResource = GetComponent<WateredNaturalResource>();
			_dryingStatusToggle = StatusToggle.CreateNormalStatus("DryingNaturalResource", _loc.T(DryingLocKey));
		}

		public void Start()
		{
			GetComponent<StatusSubject>().RegisterStatus(_dryingStatusToggle);
			_livingNaturalResource.Died += OnDied;
			_wateredNaturalResource.StartedDying += OnStartedDying;
			_wateredNaturalResource.StoppedDying += OnStoppedDying;
			if (!_livingNaturalResource.IsDead && _wateredNaturalResource.DyingProgress.IsDying)
			{
				_dryingStatusToggle.Activate();
			}
		}

		private void OnDied(object sender, EventArgs e)
		{
			_dryingStatusToggle.Deactivate();
		}

		private void OnStartedDying(object sender, EventArgs e)
		{
			_dryingStatusToggle.Activate();
		}

		private void OnStoppedDying(object sender, EventArgs e)
		{
			_dryingStatusToggle.Deactivate();
		}
	}
}
