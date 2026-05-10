using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	[Description("Note that this is very slow")]
	public class FindObjectsOfType<T> : ActionTask
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
