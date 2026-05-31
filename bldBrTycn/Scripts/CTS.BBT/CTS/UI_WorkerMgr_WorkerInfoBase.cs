using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public abstract class UI_WorkerMgr_WorkerInfoBase : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		protected UI_WorkerMgr_WorkerPanel _workerPanel;

		protected Worker _worker => _workerPanel.AssignedWorker;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_workerPanel.WorkerChanged += OnWorkerChanged;
			_workerPanel.NameWorkerChanged += _workerPanel_NameWorkerChanged;
			if ((bool)_workerPanel.AssignedWorker)
			{
				OnWorkerChanged(new EventChange<Worker>(null, _workerPanel.AssignedWorker));
			}
		}

		private void _workerPanel_NameWorkerChanged(Worker obj)
		{
			if (obj == _worker)
			{
				Repaint();
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_workerPanel.WorkerChanged -= OnWorkerChanged;
			_workerPanel.NameWorkerChanged -= _workerPanel_NameWorkerChanged;
			if ((bool)_workerPanel.AssignedWorker)
			{
				OnWorkerChanged(new EventChange<Worker>(_workerPanel.AssignedWorker, null));
			}
		}

		private void OnWorkerChanged(EventChange<Worker> obj)
		{
			if ((bool)obj.Previous)
			{
				OnWorkerUnset(obj.Previous);
			}
			if ((bool)obj.Current)
			{
				OnWorkerSet(obj.Current);
			}
			Repaint();
		}

		protected virtual void OnWorkerSet(Worker worker)
		{
		}

		protected virtual void OnWorkerUnset(Worker worker)
		{
		}

		public abstract void Repaint();
	}
}
