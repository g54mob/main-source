using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraMoveSettings : Settings
	{
		private static readonly float _minMoveSpeed = 0.1f;

		[SerializeField]
		private float _moveSpeed = 6f;

		[SerializeField]
		private float _alternateMoveSpeed = 18f;

		[SerializeField]
		private float _accelerationRate = 15f;

		public float MoveSpeed
		{
			get
			{
				return _moveSpeed;
			}
			set
			{
				_moveSpeed = Mathf.Max(_minMoveSpeed, value);
			}
		}

		public float AlternateMoveSpeed
		{
			get
			{
				return _alternateMoveSpeed;
			}
			set
			{
				_alternateMoveSpeed = Mathf.Max(_minMoveSpeed, value);
			}
		}

		public float AccelerationRate
		{
			get
			{
				return _accelerationRate;
			}
			set
			{
				_accelerationRate = Mathf.Max(0f, value);
			}
		}
	}
}
