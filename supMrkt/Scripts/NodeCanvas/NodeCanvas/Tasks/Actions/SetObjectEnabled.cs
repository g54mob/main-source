using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Enabled", 0)]
	[Category("GameObject")]
	[Description("Set the monobehaviour's enabled state.")]
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
