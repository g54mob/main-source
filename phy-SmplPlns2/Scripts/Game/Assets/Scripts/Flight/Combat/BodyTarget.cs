using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class BodyTarget : Target
	{
		private Rigidbody _body;

		public override bool IsDead
		{
			get
			{
				if (!(_body == null))
				{
					return !_body.gameObject.activeSelf;
				}
				return true;
			}
		}

		public override Vector3 Position => _body.transform.position;

		public override TargetType TargetType => TargetType.Air;

		public override Vector3 Velocity => _body.linearVelocity;

		public BodyTarget(string name, Rigidbody body, ushort teamId)
			: base(teamId)
		{
			_body = body;
			base.Name = name;
		}
	}
}
