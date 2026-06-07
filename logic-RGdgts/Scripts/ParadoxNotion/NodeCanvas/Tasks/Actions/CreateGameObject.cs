using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class CreateGameObject : ActionTask
	{
		public BBParameter<string> objectName;

		public BBParameter<Vector3> position;

		public BBParameter<Vector3> rotation;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override void OnExecute()
		{
		}
	}
}
