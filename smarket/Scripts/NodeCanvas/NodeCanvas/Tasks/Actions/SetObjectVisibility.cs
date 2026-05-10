using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Visibility", 0)]
	[Category("GameObject")]
	[Description("Set the Renderer active state, thus making the object visible or invisible.")]
	public class SetObjectVisibility : ActionTask<Renderer>
	{
		public enum SetVisibleMode
		{
			Hide = 0,
			Show = 1,
			Toggle = 2
		}

		public SetVisibleMode setTo;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
