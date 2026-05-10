using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class InstantiateGameObject : ActionTask<Transform>
	{
		public BBParameter<Transform> parent;

		public BBParameter<Vector3> clonePosition;

		public BBParameter<Vector3> cloneRotation;

		[BlackboardOnly]
		public BBParameter<GameObject> saveCloneAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
