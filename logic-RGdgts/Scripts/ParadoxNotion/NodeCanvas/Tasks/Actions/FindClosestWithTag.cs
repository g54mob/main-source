using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class FindClosestWithTag : ActionTask<Transform>
	{
		[TagField]
		[RequiredField]
		public BBParameter<string> searchTag;

		public BBParameter<bool> ignoreChildren;

		[BlackboardOnly]
		public BBParameter<GameObject> saveObjectAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		protected override void OnExecute()
		{
		}
	}
}
