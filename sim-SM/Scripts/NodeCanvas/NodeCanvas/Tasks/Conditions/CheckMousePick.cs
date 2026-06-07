using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Input (Legacy System)")]
	public class CheckMousePick : ConditionTask
	{
		public ButtonKeys buttonKey;

		[LayerField]
		public int layer;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGoAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePosAs;

		private RaycastHit hit;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
