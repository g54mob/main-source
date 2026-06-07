using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
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
