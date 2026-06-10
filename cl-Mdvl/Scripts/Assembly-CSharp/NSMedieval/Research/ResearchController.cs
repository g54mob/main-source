using System;
using NSEipix.Base;

namespace NSMedieval.Research
{
	public class ResearchController : MonoSingleton<ResearchController>
	{
		private bool allResearchActive;

		public bool DebugAllUnlocked => allResearchActive;

		public event Action<ResearchNodeInstance> UnlockResearchEvent;

		public event Action<ResearchNodeInstance> LockResearchEvent;

		public event Action<ResearchNodeInstance, bool, bool> ActivateResearchEvent;

		public event Action NodeActivatedEvent;

		public event Action<ResearchNodeInstance> DeactivateResearchEvent;

		public event Action ResetAllResearchEvent;

		public event Action<bool> ActivateAllResearchEvent;

		public void Unlock(ResearchNodeInstance node)
		{
			this.UnlockResearchEvent?.Invoke(node);
		}

		public void Lock(ResearchNodeInstance node)
		{
			this.LockResearchEvent?.Invoke(node);
		}

		public void Activate(ResearchNodeInstance node, bool afterLoading = false)
		{
			this.ActivateResearchEvent?.Invoke(node, afterLoading, arg3: true);
			this.NodeActivatedEvent?.Invoke();
		}

		public void ActivateScenarioResearch(ResearchNodeInstance node)
		{
			this.ActivateResearchEvent?.Invoke(node, arg2: false, arg3: true);
		}

		public void Deactivate(ResearchNodeInstance node)
		{
			this.DeactivateResearchEvent?.Invoke(node);
		}

		public void ResetAllResearch()
		{
			this.ResetAllResearchEvent?.Invoke();
		}

		public void ActivateAllResearch()
		{
			allResearchActive = !allResearchActive;
			this.ActivateAllResearchEvent?.Invoke(allResearchActive);
		}
	}
}
