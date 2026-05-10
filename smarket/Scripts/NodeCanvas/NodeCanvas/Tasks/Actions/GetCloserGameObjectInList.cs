using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	[Description("Get the closer game object to the agent from within a list of game objects and save it in the blackboard.")]
	public class GetCloserGameObjectInList : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<List<GameObject>> list;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
