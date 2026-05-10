using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Active", 0)]
	[Category("GameObject")]
	[Description("Set the gameobject active state.")]
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
