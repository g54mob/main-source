using System;

namespace CTS.BBT.AI
{
	[Serializable]
	public abstract class WorkerAction : AgentAction<Worker>
	{
		protected WorkerAction()
		{
			base.Name = GetType().Name.Remove(0, 12);
		}
	}
}
