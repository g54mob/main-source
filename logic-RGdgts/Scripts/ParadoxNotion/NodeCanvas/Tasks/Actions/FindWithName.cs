using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class FindWithName : ActionTask
	{
		[RequiredField]
		public BBParameter<string> gameObjectName;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
