using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Assets.Scripts.Character.State
{
	[Serializable]
	public class LookingDirectionParameters
	{
		public enum LookingDirectionMode
		{
			Movement = 0,
			Target = 1,
			ExternalReference = 2
		}

		public enum LookingDirectionMovementSource
		{
			Velocity = 0,
			Input = 1
		}

		[SerializeField]
		private bool _changeLookingDirection = true;

		[SerializeField]
		private LookingDirectionMode _lookDirectionMode;

		[Condition("_lookDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private LookingDirectionMovementSource _notGroundedLookingDirectionMode = LookingDirectionMovementSource.Input;

		[SerializeField]
		private float _speed = 10f;

		[Condition("_lookDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private LookingDirectionMovementSource _stableGroundedLookingDirectionMode = LookingDirectionMovementSource.Input;

		[Condition("_lookDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 1f)]
		[SerializeField]
		private Transform _target;

		[Condition("_lookDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private LookingDirectionMovementSource _unstableGroundedLookingDirectionMode;

		public bool ChangeLookingDirection
		{
			get
			{
				return _changeLookingDirection;
			}
			set
			{
				_changeLookingDirection = value;
			}
		}

		public LookingDirectionMode LookDirectionMode
		{
			get
			{
				return _lookDirectionMode;
			}
			set
			{
				_lookDirectionMode = value;
			}
		}

		public LookingDirectionMovementSource NotGroundedLookingDirectionMode
		{
			get
			{
				return _notGroundedLookingDirectionMode;
			}
			set
			{
				_notGroundedLookingDirectionMode = value;
			}
		}

		public float Speed
		{
			get
			{
				return _speed;
			}
			set
			{
				_speed = value;
			}
		}

		public LookingDirectionMovementSource StableGroundedLookingDirectionMode
		{
			get
			{
				return _stableGroundedLookingDirectionMode;
			}
			set
			{
				_stableGroundedLookingDirectionMode = value;
			}
		}

		public Transform Target
		{
			get
			{
				return _target;
			}
			set
			{
				_target = value;
			}
		}

		public LookingDirectionMovementSource UnstableGroundedLookingDirectionMode
		{
			get
			{
				return _unstableGroundedLookingDirectionMode;
			}
			set
			{
				_unstableGroundedLookingDirectionMode = value;
			}
		}
	}
}
