using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class InformationTarget : Target
	{
		private bool _dead;

		private Vector3 _globalPosition;

		private Rigidbody _rigidBody;

		public override bool IsDead => _dead;

		public override Vector3 Position
		{
			get
			{
				if (!(_rigidBody == null))
				{
					return _rigidBody.position;
				}
				return Utility.ConvertAbsoluteToFloatingOriginPosition(_globalPosition);
			}
		}

		public override bool SupportsOcclusion => false;

		public override TargetType TargetType => TargetType.Information;

		public override Vector3 Velocity
		{
			get
			{
				if (!(_rigidBody == null))
				{
					return _rigidBody.linearVelocity;
				}
				return Vector3.zero;
			}
		}

		public InformationTarget(string name, Vector3 globalPosition)
			: base(4)
		{
			_globalPosition = globalPosition;
			base.Name = name;
		}

		public InformationTarget(string name, Rigidbody rigidBody)
			: base(4)
		{
			_rigidBody = rigidBody;
			base.Name = name;
		}

		public void MarkAsDead()
		{
			_dead = true;
		}
	}
}
