using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class NormalizeVector : ActionTask
	{
		public BBParameter<Vector3> targetVector;

		public BBParameter<float> multiply;

		protected override void OnExecute()
		{
		}
	}
}
