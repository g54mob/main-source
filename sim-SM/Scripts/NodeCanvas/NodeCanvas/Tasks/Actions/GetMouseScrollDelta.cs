using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input (Legacy System)")]
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
