using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	[Description("Will sort the gameobjects in the target list by their distance to the agent (closer first) and save that list to the blackboard")]
	public class SortGameObjectListByDistance : ActionTask<Transform>
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<GameObject>> targetList;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		public bool reverse;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
