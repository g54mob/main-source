using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class IsWithinLayerMask : ConditionTask<Transform>
	{
		public BBParameter<LayerMask> targetLayers;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
