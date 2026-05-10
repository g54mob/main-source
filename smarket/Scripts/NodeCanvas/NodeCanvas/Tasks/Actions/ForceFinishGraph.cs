using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	[Description("Force Finish the current graph this Task is assigned to.")]
	public class ForceFinishGraph : ActionTask
	{
		public CompactStatus finishStatus;

		protected override void OnExecute()
		{
		}
	}
}
