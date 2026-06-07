using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class RemoveComponent<T> : ActionTask<Transform> where T : Component
	{
		public bool immediately;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
