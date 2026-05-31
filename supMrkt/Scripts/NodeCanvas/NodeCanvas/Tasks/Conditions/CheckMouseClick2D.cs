using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("System Events")]
	[Name("Check Mouse Click 2D", 0)]
	public class CheckMouseClick2D : ConditionTask<Collider2D>
	{
		public MouseClickEvent checkType;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnMouseDown(EventData msg)
		{
		}

		private void OnMouseUp(EventData msg)
		{
		}
	}
}
