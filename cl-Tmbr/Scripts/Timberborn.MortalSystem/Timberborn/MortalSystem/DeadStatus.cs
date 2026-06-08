using Timberborn.BaseComponentSystem;
using Timberborn.Localization;
using Timberborn.MortalComponents;
using Timberborn.StatusSystem;

namespace Timberborn.MortalSystem
{
	internal class DeadStatus : BaseComponent, IAwakableComponent, IStartableComponent, IDeadNeededComponent
	{
		private readonly ILoc _loc;

		private StatusToggle _toggleWithIcon;

		private StatusToggle _toggleWithoutIcon;

		public DeadStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			string description = _loc.T(GetComponent<DeadStatusSpec>().DeadStatusLocKey);
			string spriteName = "Death";
			_toggleWithIcon = StatusToggle.CreatePriorityStatusWithFloatingIcon(spriteName, description);
			_toggleWithoutIcon = StatusToggle.CreateNormalStatus(spriteName, description);
		}

		public void Start()
		{
			StatusSubject component = GetComponent<StatusSubject>();
			component.RegisterStatus(_toggleWithIcon);
			component.RegisterStatus(_toggleWithoutIcon);
		}

		public void Activate(bool diedPublicly)
		{
			if (diedPublicly)
			{
				_toggleWithIcon.Activate();
			}
			else
			{
				_toggleWithoutIcon.Activate();
			}
		}
	}
}
