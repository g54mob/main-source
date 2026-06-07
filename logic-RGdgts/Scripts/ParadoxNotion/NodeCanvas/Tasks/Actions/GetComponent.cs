using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class GetComponent<T> : ActionTask<Transform> where T : Component
	{
		[BlackboardOnly]
		public BBParameter<T> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
