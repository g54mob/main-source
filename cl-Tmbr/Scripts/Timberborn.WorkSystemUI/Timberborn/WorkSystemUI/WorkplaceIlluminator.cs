using Timberborn.BaseComponentSystem;
using Timberborn.Illumination;
using Timberborn.TickSystem;
using Timberborn.WorkSystem;

namespace Timberborn.WorkSystemUI
{
	public class WorkplaceIlluminator : TickableComponent, IAwakableComponent
	{
		private IlluminatorToggle _illuminatorToggle;

		private Workplace _workplace;

		private bool _illuminationEnabled;

		public void Awake()
		{
			_illuminatorToggle = GetComponent<Illuminator>().CreateToggle();
			_workplace = GetComponent<Workplace>();
			GetComponent<WorkplaceWorkerType>().WorkerTypeChanged += OnWorkerTypeChanged;
		}

		public override void StartTickable()
		{
			UpdateIllumination(forceUpdate: true);
		}

		public override void Tick()
		{
			UpdateIllumination(forceUpdate: false);
		}

		private void OnWorkerTypeChanged(object sender, WorkerTypeChangedEventArgs e)
		{
			UpdateIllumination(forceUpdate: true);
		}

		private void UpdateIllumination(bool forceUpdate)
		{
			bool flag = _workplace.AnyWorkerHasJobRunning();
			if (flag != _illuminationEnabled || forceUpdate)
			{
				_illuminationEnabled = flag;
				if (_illuminationEnabled)
				{
					_illuminatorToggle.TurnOn();
				}
				else
				{
					_illuminatorToggle.TurnOff();
				}
			}
		}
	}
}
