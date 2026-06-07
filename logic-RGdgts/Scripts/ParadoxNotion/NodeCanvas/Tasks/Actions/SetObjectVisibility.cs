using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
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
