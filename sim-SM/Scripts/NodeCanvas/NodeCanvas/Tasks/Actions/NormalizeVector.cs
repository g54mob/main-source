using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	public class NormalizeVector : ActionTask
	{
		public BBParameter<Vector3> targetVector;

		public BBParameter<float> multiply;

		protected override void OnExecute()
		{
		}
	}
}
