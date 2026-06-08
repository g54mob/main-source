using System;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.NeedSpecs;
using Timberborn.NeedSystem;

namespace Timberborn.WorkSystem
{
	public class WorkRefuser : BaseComponent, IAwakableComponent
	{
		private NeedManager _needManager;

		private Worker _worker;

		public bool RefusesWork { get; private set; }

		public event EventHandler RefusesWorkChanged;

		public void Awake()
		{
			_needManager = GetComponent<NeedManager>();
			_needManager.NeedChangedCriticalState += OnNeedChangedCriticalState;
			_worker = GetComponent<Worker>();
		}

		private void OnNeedChangedCriticalState(object sender, NeedChangedCriticalStateEventArgs e)
		{
			UpdateRefuseWork();
		}

		private void UpdateRefuseWork()
		{
			bool flag = ShouldRefuseWork();
			if (RefusesWork != flag)
			{
				RefusesWork = flag;
				if (RefusesWork)
				{
					_worker.Unemploy();
				}
				this.RefusesWorkChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private bool ShouldRefuseWork()
		{
			ImmutableArray<NeedSpec>.Enumerator enumerator = _needManager.NeedSpecs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				NeedSpec current = enumerator.Current;
				if (_needManager.NeedIsInCriticalState(current.Id) && current.HasSpec<NeedPreventingWorkSpec>())
				{
					return true;
				}
			}
			return false;
		}
	}
}
