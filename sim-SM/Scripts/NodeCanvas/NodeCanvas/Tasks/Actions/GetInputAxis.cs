using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input (Legacy System)")]
	public class GetInputAxis : ActionTask
	{
		public BBParameter<string> xAxisName;

		public BBParameter<string> yAxisName;

		public BBParameter<string> zAxisName;

		public BBParameter<float> multiplier;

		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;

		[BlackboardOnly]
		public BBParameter<float> saveXAs;

		[BlackboardOnly]
		public BBParameter<float> saveYAs;

		[BlackboardOnly]
		public BBParameter<float> saveZAs;

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
