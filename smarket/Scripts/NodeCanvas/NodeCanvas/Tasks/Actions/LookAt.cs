using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class LookAt : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> lookTarget;

		public bool repeat;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void DoLook()
		{
		}
	}
}
