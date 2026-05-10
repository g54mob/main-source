using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject")]
	public class IsWithinLayerMask : ConditionTask<Transform>
	{
		public BBParameter<LayerMask> targetLayers;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
