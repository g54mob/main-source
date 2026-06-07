using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
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
