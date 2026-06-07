using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SetObjectEnabled : ActionTask<MonoBehaviour>
	{
		public enum SetEnableMode
		{
			Disable = 0,
			Enable = 1,
			Toggle = 2
		}

		public SetEnableMode setTo;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
