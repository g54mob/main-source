using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class RefuelProbeScript : PartModifierScript
	{
		public Vector3 Offset { get; set; }

		public Vector3 ProbePos => base.transform.TransformPoint(Offset);
	}
}
