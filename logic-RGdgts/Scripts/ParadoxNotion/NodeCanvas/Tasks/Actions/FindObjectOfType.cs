using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class FindObjectOfType<T> : ActionTask where T : Component
	{
		[BlackboardOnly]
		public BBParameter<T> saveComponentAs;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGameObjectAs;

		protected override void OnExecute()
		{
		}
	}
}
