using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.Common;
using Timberborn.NeedSpecs;
using Timberborn.NeedSystem;
using Timberborn.StatusSystem;

namespace Timberborn.NeedBehaviorSystem
{
	public class CriticalNeedStateStatusRegistrar : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private NeedManager _needManager;

		private readonly List<StatusToggle> _statusToggles = new List<StatusToggle>();

		public void Awake()
		{
			_needManager = GetComponent<NeedManager>();
			InitializeStatusToggles();
		}

		public void Start()
		{
			GetComponent<StatusSubject>().RegisterStatuses(_statusToggles.AsReadOnlyEnumerable());
		}

		private void InitializeStatusToggles()
		{
			ImmutableArray<NeedSpec>.Enumerator enumerator = _needManager.NeedSpecs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				NeedSpec current = enumerator.Current;
				CriticalNeedSpec spec = current.GetSpec<CriticalNeedSpec>();
				if ((object)spec != null)
				{
					if (spec.CriticalNeedType == CriticalNeedType.State)
					{
						StatusToggle statusToggle = StatusToggle.CreateNormalStatusWithFloatingIcon(spec.SpriteName, spec.Description.Value);
						InitializeStatusToggle(current, statusToggle);
					}
					if (spec.CriticalNeedType == CriticalNeedType.Alert)
					{
						StatusToggle statusToggle2 = StatusToggle.CreateNormalStatusWithAlert(spec.SpriteName, spec.Description.Value, spec.DescriptionShort.Value);
						InitializeStatusToggle(current, statusToggle2);
					}
					if (spec.CriticalNeedType == CriticalNeedType.StateWithAlert)
					{
						StatusToggle statusToggle3 = StatusToggle.CreateNormalStatusWithAlertAndFloatingIcon(spec.SpriteName, spec.Description.Value, spec.DescriptionShort.Value);
						InitializeStatusToggle(current, statusToggle3);
					}
				}
			}
		}

		private void InitializeStatusToggle(NeedSpec needSpec, StatusToggle statusToggle)
		{
			_needManager.NeedChangedCriticalState += OnNeedChangedCriticalState;
			_statusToggles.Add(statusToggle);
			void OnNeedChangedCriticalState(object sender, NeedChangedCriticalStateEventArgs e)
			{
				if (e.NeedSpec == needSpec)
				{
					if (e.IsInCriticalState)
					{
						statusToggle.Activate();
					}
					else
					{
						statusToggle.Deactivate();
					}
				}
			}
		}
	}
}
