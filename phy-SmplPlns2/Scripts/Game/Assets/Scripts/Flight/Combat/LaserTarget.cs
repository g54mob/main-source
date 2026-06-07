using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class LaserTarget : Target
	{
		private bool _dead;

		private Vector3 _position;

		public bool IsActive { get; set; }

		public override bool IsDead => _dead;

		public bool IsUserInteracting { get; set; }

		public override Vector3 Position => _position;

		public TargetingPodScript TargetingPod { get; }

		public override TargetType TargetType => TargetType.Laser;

		public override Vector3 Velocity => Vector3.zero;

		public LaserTarget(TargetingPodScript targetingPod, ushort teamId)
			: base(teamId)
		{
			TargetingPod = targetingPod;
			base.Name = "Laser Target";
		}

		public override float GetSignature(SignatureType signatureType)
		{
			if (signatureType == SignatureType.Laser)
			{
				return 1f;
			}
			return 0f;
		}

		public void MarkAsDead()
		{
			_dead = true;
		}

		public void SetPosition(Vector3 position)
		{
			_position = position;
		}
	}
}
