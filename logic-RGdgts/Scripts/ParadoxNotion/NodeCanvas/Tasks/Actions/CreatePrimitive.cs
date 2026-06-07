using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class CreatePrimitive : ActionTask
	{
		public BBParameter<string> objectName;

		public BBParameter<Vector3> position;

		public BBParameter<Vector3> rotation;

		public BBParameter<PrimitiveType> type;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override void OnExecute()
		{
		}
	}
}
