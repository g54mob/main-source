using System;
using Timberborn.Automation;
using Timberborn.BaseComponentSystem;
using Timberborn.Localization;
using Timberborn.StatusSystem;

namespace Timberborn.AutomationUI
{
	public class AutomationLoopStatus : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private static readonly string AutomationLoopLocKey = "Status.Automation.AutomationLoop";

		private static readonly string AutomationLoopShortLocKey = "Status.Automation.AutomationLoop.Short";

		private readonly ILoc _loc;

		private Automator _automator;

		private StatusToggle _statusToggle;

		public AutomationLoopStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_automator = GetComponent<Automator>();
			_statusToggle = StatusToggle.CreateNormalStatusWithAlertAndFloatingIcon("AutomationLoop", _loc.T(AutomationLoopLocKey), _loc.T(AutomationLoopShortLocKey));
			_automator.IsCyclicOrBlockedChanged += OnChanged;
		}

		public void Start()
		{
			GetComponent<StatusSubject>().RegisterStatus(_statusToggle);
		}

		private void OnChanged(object sender, EventArgs e)
		{
			_statusToggle.Toggle(_automator.IsCyclicOrBlocked);
		}
	}
}
