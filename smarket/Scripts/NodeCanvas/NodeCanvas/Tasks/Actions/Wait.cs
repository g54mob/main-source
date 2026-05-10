using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	public class Wait : ActionTask
	{
		public BBParameter<float> waitTime;

		public CompactStatus finishStatus;

		protected override string info => null;

		protected override void OnUpdate()
		{
		}
	}
}
