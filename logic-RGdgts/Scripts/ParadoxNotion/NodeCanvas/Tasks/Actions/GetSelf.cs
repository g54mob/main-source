using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class GetSelf : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override void OnExecute()
		{
		}
	}
}
