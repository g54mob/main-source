using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LocoInZoneStep : AQuickTutorialStep
	{
		private TrainCar loco;

		private BoxCollider zone;

		public LocoInZoneStep(string message, TrainCar loco, BoxCollider zone, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.loco = loco;
			this.zone = zone;
		}

		protected override bool InternalCheck()
		{
			Vector3 vector = zone.transform.InverseTransformPoint(loco.transform.position);
			vector -= zone.center - zone.size * 0.5f;
			if (vector.x >= 0f && vector.y >= 0f && vector.z >= 0f && vector.x <= zone.size.x && vector.y <= zone.size.y)
			{
				return vector.z <= zone.size.z;
			}
			return false;
		}
	}
}
