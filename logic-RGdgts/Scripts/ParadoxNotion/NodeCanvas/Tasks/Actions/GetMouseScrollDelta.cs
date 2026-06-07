using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{
	public class GetMouseScrollDelta : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<float> saveAs;

		public bool repeat;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void Do()
		{
		}
	}
}
