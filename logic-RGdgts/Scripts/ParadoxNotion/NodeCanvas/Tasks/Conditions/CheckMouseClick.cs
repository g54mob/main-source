using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckMouseClick : ConditionTask<Collider>
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
