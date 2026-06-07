using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class SetEnum : ActionTask
	{
		[BlackboardOnly]
		[RequiredField]
		public BBObjectParameter valueA;

		public BBObjectParameter valueB;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
