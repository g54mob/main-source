using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.BlockingSystem;
using Timberborn.Localization;
using Timberborn.StatusSystem;

namespace Timberborn.WorkSystem
{
	public class NothingToDoInRangeStatus : BaseComponent, IAwakableComponent, IStartableComponent, IFinishedStateListener
	{
		private static readonly string NothingToDoInRangeLocKey = "Status.Yielding.NothingToDoInRange";

		private readonly ILoc _loc;

		private StatusToggle _nothingToDoInRangeStatus;

		private Workplace _workplace;

		public NothingToDoInRangeStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_workplace = GetComponent<Workplace>();
			GetComponent<BlockableObject>().ObjectBlocked += delegate
			{
				DeactivateStatus();
			};
			_workplace.WorkerUnassigned += delegate
			{
				OnWorkerUnassigned();
			};
			string text = _loc.T(NothingToDoInRangeLocKey);
			_nothingToDoInRangeStatus = StatusToggle.CreateNormalStatusWithAlertAndFloatingIcon("NothingToDo", text, text);
			DisableComponent();
		}

		public void Start()
		{
			GetComponent<StatusSubject>().RegisterStatus(_nothingToDoInRangeStatus);
		}

		public void OnEnterFinishedState()
		{
			EnableComponent();
		}

		public void OnExitFinishedState()
		{
			DeactivateStatus();
			DisableComponent();
		}

		public void ActivateStatus()
		{
			_nothingToDoInRangeStatus.Activate();
		}

		public void DeactivateStatus()
		{
			_nothingToDoInRangeStatus.Deactivate();
		}

		private void OnWorkerUnassigned()
		{
			if (_workplace.NumberOfAssignedWorkers == 0)
			{
				DeactivateStatus();
			}
		}
	}
}
