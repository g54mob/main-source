using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SetObjectActive : ActionTask<Transform>
	{
		public enum SetActiveMode
		{
			Deactivate = 0,
			Activate = 1,
			Toggle = 2
		}

		public SetActiveMode setTo;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
