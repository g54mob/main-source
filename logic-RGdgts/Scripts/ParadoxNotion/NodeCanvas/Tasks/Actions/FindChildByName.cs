using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class FindChildByName : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> childName;

		[BlackboardOnly]
		public BBParameter<Transform> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
