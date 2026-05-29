using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input (Legacy System)")]
	public class WaitMousePick : ActionTask
	{
		public enum ButtonKeys
		{
			Left = 0,
			Right = 1,
			Middle = 2
		}

		public ButtonKeys buttonKey;

		public LayerMask mask;

		[BlackboardOnly]
		public BBParameter<GameObject> saveObjectAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePositionAs;

		private int buttonID;

		private RaycastHit hit;

		protected override string info => null;

		protected override void OnUpdate()
		{
		}
	}
}
