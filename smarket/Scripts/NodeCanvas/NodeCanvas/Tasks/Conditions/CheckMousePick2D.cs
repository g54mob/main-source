using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Input (Legacy System)")]
	public class CheckMousePick2D : ConditionTask
	{
		public ButtonKeys buttonKey;

		public LayerMask mask;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGoAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePosAs;

		private int buttonID;

		private RaycastHit2D hit;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
