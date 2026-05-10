using CTS.Core;

namespace CTS.BBT.AI
{
	public abstract class WorkerState : State<Worker>
	{
		public abstract void SpreadUpdate();

		public abstract void Update();
	}
}
