using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class FindObjectsOfType<T> : ActionTask where T : Component
	{
		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveGameObjects;

		[BlackboardOnly]
		public BBParameter<List<T>> saveComponents;

		protected override void OnExecute()
		{
		}
	}
}
