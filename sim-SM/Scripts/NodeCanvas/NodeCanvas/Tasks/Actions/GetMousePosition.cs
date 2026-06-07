using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input (Legacy System)")]
	public class GetMousePosition : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;

		public bool repeat;

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
